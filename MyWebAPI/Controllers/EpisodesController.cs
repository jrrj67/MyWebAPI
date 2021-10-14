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

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodesController : ControllerBase
    {
        private readonly ILogger<EpisodesController> _logger;
        private readonly IBaseRepository<Episode> _repository;
        private readonly IMapper _mapper;

        public EpisodesController(ILogger<EpisodesController> logger, IBaseRepository<Episode> repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]   
        public IActionResult GetAll()
        {
            try
            {
                var records = _repository.GetAll();
                var recordResponse = _mapper.Map<List<EpisodeResponse>>(records);
                return Ok(recordResponse);
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
                var record = _repository.GetById(id);
                var recordResponse = _mapper.Map<EpisodeResponse>(record);
                return Ok(record);
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
        public async Task<IActionResult> SaveAsync(EpisodeRequest request)
        {
            try
            {
                request.Validate();
                var requestModel = _mapper.Map<Episode>(request);
                await _repository.SaveAsync(requestModel);
                var response = _mapper.Map<EpisodeResponse>(requestModel);
                return Ok(response);
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
        public async Task<IActionResult> UpdateAsync(int id, EpisodeRequest request)
        {
            try
            {
                request.Validate();
                var requestModel = _mapper.Map<Episode>(request);
                await _repository.UpdateAsync(id, requestModel);
                var response = _mapper.Map<EpisodeResponse>(requestModel);
                return Ok(response);
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
