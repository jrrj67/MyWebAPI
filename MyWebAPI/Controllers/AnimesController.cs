using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using MyWebAPI.Data.Services;
using System;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/animes")]
    public class AnimesController : ControllerBase
    {
        private readonly ILogger<AnimesController> _logger;
        private readonly IBaseService<AnimesResponse, AnimesRequest> _animesService;

        public AnimesController(ILogger<AnimesController> logger, IBaseService<AnimesResponse, AnimesRequest> animesService)
        {
            _logger = logger;
            _animesService = animesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_animesService.GetAll());
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
                return Ok(_animesService.GetById(id));
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
        public async Task<IActionResult> SaveAsync(AnimesRequest request)
        {
            try
            {
                return Ok(await _animesService.SaveAsync(request));
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
        public async Task<IActionResult> UpdateAsync(int id, AnimesRequest request)
        {
            try
            {
                return Ok(await _animesService.UpdateAsync(id, request));
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
                await _animesService.DeleteAsync(id);
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
