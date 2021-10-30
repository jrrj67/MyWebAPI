using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Services
{
    public class UsersService : IUsersService<UsersResponse, UsersRequest>
    {
        private readonly IBaseRepository<UsersEntity> _repository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UsersService(IBaseRepository<UsersEntity> repository, IMapper mapper, ITokenService tokenService)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public List<UsersResponse> GetAll()
        {
            var response = _repository.GetAll();
            return _mapper.Map<List<UsersResponse>>(response);
        }

        public UsersResponse GetById(int id)
        {
            var response = _repository.GetById(id);
            return _mapper.Map<UsersResponse>(response);
        }

        public async Task<UsersResponse> SaveAsync(UsersRequest request)
        {
            request.Validate();
            var requestModel = _mapper.Map<UsersEntity>(request);
            requestModel.Password = BCrypt.Net.BCrypt.HashPassword(requestModel.Password);
            await _repository.SaveAsync(requestModel);
            return _mapper.Map<UsersResponse>(requestModel);
        }

        public async Task<UsersResponse> UpdateAsync(int id, UsersRequest request)
        {
            request.Validate();
            var requestModel = _mapper.Map<UsersEntity>(request);
            requestModel.Password = BCrypt.Net.BCrypt.HashPassword(requestModel.Password);
            await _repository.UpdateAsync(id, requestModel);
            return _mapper.Map<UsersResponse>(requestModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public LoginResponse Login(UsersRequest userRequest)
        {
            userRequest.Validate();
         
            var userEntity = _repository
                .GetAll()
                .Where(u => u.Email == userRequest.Email && BCrypt.Net.BCrypt.Verify(userRequest.Password, u.Password))
                .FirstOrDefault();

            if (userEntity == null)
            {
                throw new ArgumentException("Wrong credentials provided.");
            }

            var token = _tokenService.GenerateToken(userEntity);

            var userResponse = _mapper.Map<UsersResponse>(userEntity);

            return new LoginResponse
            {
                UserResponse = userResponse,
                Token = token
            };
        }
    }
}
