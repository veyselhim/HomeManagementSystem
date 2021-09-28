using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Abstract;
using Core.Utilities.Results;
using Entity;
using Entity.Concrete;
using Entity.DTOs.Aparment;

namespace ApsisDemoCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> Add(ApartmentAddDto apartmentAddDto)
        {
            var result =await _apartmentService.AddWithDtoAsync(apartmentAddDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ApartmentUpdateDto apartmentUpdateDto)
        {
            var result =await _apartmentService.UpdateWithDtoAsync(apartmentUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromHeader] ApartmentDeleteDto apartmentDeleteDto)
        {
            var result =await _apartmentService.DeleteWithDtoAsync(apartmentDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
           var result =await _apartmentService.GetAllAsync();
           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result);
        }


        [HttpGet("getApartmentDetails")]
        public IActionResult GetApartmentDetails()
        {
            var result = _apartmentService.GetApartmentDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getApartmentDetail")]
        public async Task<IActionResult> GetApartmentDetail(int id)
        {
            var result =await _apartmentService.GetApartmentDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _apartmentService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var result = await _apartmentService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
