using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Services
{
    public class EpisodesService : IBaseService<EpisodesResponse, EpisodesRequest>
    {
        private readonly IBaseRepository<EpisodesEntity> _repository;
        private readonly IMapper _mapper;

        public EpisodesService(IBaseRepository<EpisodesEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<EpisodesResponse> GetAll()
        {
            var response = _repository.GetAll();
            return _mapper.Map<List<EpisodesResponse>>(response);
        }

        public EpisodesResponse GetById(int id)
        {
            var response = _repository.GetById(id);
            return _mapper.Map<EpisodesResponse>(response);
        }

        public async Task<EpisodesResponse> SaveAsync(EpisodesRequest request)
        {
            var requestModel = _mapper.Map<EpisodesEntity>(request);
            await _repository.SaveAsync(requestModel);
            return _mapper.Map<EpisodesResponse>(requestModel);
        }

        public async Task<EpisodesResponse> UpdateAsync(int id, EpisodesRequest request)
        {
            var requestModel = _mapper.Map<EpisodesEntity>(request);
            await _repository.UpdateAsync(id, requestModel);
            return _mapper.Map<EpisodesResponse>(requestModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
