using System;
using FluentValidation;
using MyWebAPI.Data.Services;
using System.Threading.Tasks;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodesController : ControllerBase
    {
        private readonly ILogger<EpisodesController> _logger;
        private readonly IBaseService<EpisodesResponse, EpisodesRequest> _episodesService;

        public EpisodesController(ILogger<EpisodesController> logger, IBaseService<EpisodesResponse, EpisodesRequest> episodesService)
        {
            _logger = logger;
            _episodesService = episodesService;
        }

        [HttpGet]   
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_episodesService.GetAll());
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
                return Ok(_episodesService.GetById(id));
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
        public async Task<IActionResult> SaveAsync(EpisodesRequest request)
        {
            try
            {
                return Ok(await _episodesService.SaveAsync(request));
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
        public async Task<IActionResult> UpdateAsync(int id, EpisodesRequest request)
        {
            try
            {
                return Ok(await _episodesService.UpdateAsync(id, request));
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
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _episodesService.DeleteAsync(id);
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
