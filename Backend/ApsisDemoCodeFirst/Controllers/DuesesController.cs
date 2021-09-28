using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity;
using Entity.Concrete;
using Entity.DTOs.Dues;

namespace XApsisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuesesController : ControllerBase
    {
        private readonly IDuesService _duesService;

        public DuesesController(IDuesService duesService)
        {
            _duesService = duesService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(DuesAddDto duesAddDto)
        {
            var result =await _duesService.AddWithDtoAsync(duesAddDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(DuesUpdateDto duesUpdateDto)
        {
            var result =await _duesService.UpdateWithDtoAsync(duesUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DuesDeleteDto duesDeleteDto)
        {
            var result =await _duesService.DeleteWithDtoAsync(duesDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _duesService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _duesService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getDuesDetails")]
        public IActionResult GetDuesDetails()
        {
            var result = _duesService.GetDuesDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var result = await _duesService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
