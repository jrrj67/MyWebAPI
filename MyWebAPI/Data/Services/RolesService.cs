using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Services
{
    public class RolesService : IBaseService<RolesResponse, RolesRequest>
    {
        private readonly IBaseRepository<RolesEntity> _repository;
        private readonly IMapper _mapper;

        public RolesService(IBaseRepository<RolesEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<RolesResponse> GetAll()
        {
            var response = _repository.GetAll();
            return _mapper.Map<List<RolesResponse>>(response);
        }

        public RolesResponse GetById(int id)
        {
            var response = _repository.GetById(id);
            return _mapper.Map<RolesResponse>(response);
        }

        public async Task<RolesResponse> SaveAsync(RolesRequest request)
        {
            request.Validate();
            var requestModel = _mapper.Map<RolesEntity>(request);
            await _repository.SaveAsync(requestModel);
            return _mapper.Map<RolesResponse>(requestModel);
        }

        public async Task<RolesResponse> UpdateAsync(int id, RolesRequest request)
        {
            request.Validate();
            var requestModel = _mapper.Map<RolesEntity>(request);
            await _repository.UpdateAsync(id, requestModel);
            return _mapper.Map<RolesResponse>(requestModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
