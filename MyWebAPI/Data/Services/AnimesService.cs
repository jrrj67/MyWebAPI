using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Services
{
    public class AnimesService : IBaseService<AnimesResponse, AnimesRequest>
    {
        private readonly IBaseRepository<AnimesEntity> _repository;
        private readonly IMapper _mapper;

        public AnimesService(IBaseRepository<AnimesEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<AnimesResponse> GetAll()
        {
            var response = _repository.GetAll();
            return _mapper.Map<List<AnimesResponse>>(response);
        }

        public AnimesResponse GetById(int id)
        {
            var response = _repository.GetById(id);
            return _mapper.Map<AnimesResponse>(response);
        }

        public async Task<AnimesResponse> SaveAsync(AnimesRequest request)
        {
            var requestModel = _mapper.Map<AnimesEntity>(request);
            await _repository.SaveAsync(requestModel);
            return _mapper.Map<AnimesResponse>(requestModel);
        }

        public async Task<AnimesResponse> UpdateAsync(int id, AnimesRequest request)
        {
            var requestModel = _mapper.Map<AnimesEntity>(request);
            await _repository.UpdateAsync(id, requestModel);
            return _mapper.Map<AnimesResponse>(requestModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
