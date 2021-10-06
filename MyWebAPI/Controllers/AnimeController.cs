using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebAPI.Data;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/anime")]
    public class AnimeController : ControllerBase
    {
        private readonly ILogger<AnimeController> _logger;
        private readonly IBaseRepository<Anime> _repository;

        public AnimeController(ILogger<AnimeController> logger, IBaseRepository<Anime> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]   
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        } 
        
        [HttpGet("{id}")]   
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpPost]   
        public async Task<IActionResult> SaveAsync(AnimeDTO anime)
        {
            try
            {
                await _repository.SaveAsync(anime);
                return Created("", anime);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        } 
        
        [HttpPut("{id}")]   
        public async Task<IActionResult> UpdateAsync(int id, AnimeDTO anime)
        {
            try
            {
                await _repository.UpdateAsync(id, anime);
                return Ok(anime);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
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
                return BadRequest(ex.Message);
            }
        } 
    }
}
