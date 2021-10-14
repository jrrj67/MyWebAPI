using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/animes")]
    public class AnimesController : ControllerBase
    {
        private readonly ILogger<AnimesController> _logger;
        private readonly IBaseRepository<Anime> _repository;
        private readonly IBaseRepository<Episode> _episodeRepository;
        private readonly IMapper _mapper;

        public AnimesController(ILogger<AnimesController> logger, IBaseRepository<Anime> repository, IBaseRepository<Episode> episodeRepository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        [HttpGet]   
        public IActionResult GetAll()
        {
            try
            {
                var animes = _repository.GetAll();
                animes.ForEach(a => a.Episodes = _episodeRepository.GetAll().Where(e => e.AnimeId == a.Id).ToList());
                var animesResponse = _mapper.Map<List<AnimeResponse>>(animes);
                return Ok(animesResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpGet("{id}")]   
        public IActionResult GetById(int id)
        {
            try
            {
                var anime = _repository.GetById(id);
                var animeResponse = _mapper.Map<AnimeResponse>(anime);
                return Ok(animeResponse);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]   
        public async Task<IActionResult> SaveAsync(AnimeRequest anime)
        {
            try
            {
                anime.Validate();
                var animeModel = _mapper.Map<Anime>(anime);
                await _repository.SaveAsync(animeModel);
                var animeResponse = _mapper.Map<AnimeResponse>(animeModel);
                return Ok(animeResponse);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpPut("{id}")]   
        public async Task<IActionResult> UpdateAsync(int id, AnimeRequest anime)
        {
            try
            {
                anime.Validate();
                var animeModel = _mapper.Map<Anime>(anime);
                await _repository.UpdateAsync(id, animeModel);
                var animeResponse = _mapper.Map<AnimeResponse>(animeModel);
                return Ok(animeResponse);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("{id}")]   
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
