using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System;
using System.Linq;

namespace MyWebAPI.Data.Services
{
    public class LoginService : ILoginService<LoginResponse, LoginRequest>
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public LoginService(IUsersRepository repository, IMapper mapper, ITokenService tokenService)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            var userEntity = _repository
                .GetAll()
                .Where(u => u.Email == loginRequest.Email && BCrypt.Net.BCrypt.Verify(loginRequest.Password, u.Password))
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
