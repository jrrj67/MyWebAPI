using AutoMapper;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Services
{
    public class AnimesService : IBaseService<AnimeResponse, AnimeRequest>
    {
        private readonly IBaseRepository<Anime> _repository;
        private readonly IMapper _mapper;

        public AnimesService(IBaseRepository<Anime> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<AnimeResponse> GetAll()
        {
            var response = _repository.GetAll();
            return _mapper.Map<List<AnimeResponse>>(response);
        }

        public AnimeResponse GetById(int id)
        {
            var response = _repository.GetById(id);
            return _mapper.Map<AnimeResponse>(response);
        }

        public async Task<AnimeResponse> SaveAsync(AnimeRequest request)
        {
            request.Validate();
            var requestModel = _mapper.Map<Anime>(request);
            await _repository.SaveAsync(requestModel);
            return _mapper.Map<AnimeResponse>(requestModel);
        }

        public async Task<AnimeResponse> UpdateAsync(int id, AnimeRequest request)
        {
            request.Validate();
            var requestModel = _mapper.Map<Anime>(request);
            await _repository.UpdateAsync(id, requestModel);
            return _mapper.Map<AnimeResponse>(requestModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
