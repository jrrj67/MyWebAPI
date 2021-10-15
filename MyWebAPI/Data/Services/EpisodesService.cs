using AutoMapper;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Services
{
    public class EpisodesService : IBaseService<EpisodeResponse, EpisodeRequest>
    {
        private readonly IBaseRepository<Episode> _repository;
        private readonly IMapper _mapper;

        public EpisodesService(IBaseRepository<Episode> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<EpisodeResponse> GetAll()
        {
            var response = _repository.GetAll();
            return _mapper.Map<List<EpisodeResponse>>(response);
        }

        public EpisodeResponse GetById(int id)
        {
            var response = _repository.GetById(id);
            return _mapper.Map<EpisodeResponse>(response);
        }

        public async Task<EpisodeResponse> SaveAsync(EpisodeRequest request)
        {
            request.Validate();
            var requestModel = _mapper.Map<Episode>(request);
            await _repository.SaveAsync(requestModel);
            return _mapper.Map<EpisodeResponse>(requestModel);
        }

        public async Task<EpisodeResponse> UpdateAsync(int id, EpisodeRequest request)
        {
            request.Validate();
            var requestModel = _mapper.Map<Episode>(request);
            await _repository.UpdateAsync(id, requestModel);
            return _mapper.Map<EpisodeResponse>(requestModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
