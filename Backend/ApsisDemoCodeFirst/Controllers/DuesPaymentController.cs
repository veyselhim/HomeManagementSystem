using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Dues;
using Entity.DTOs.DuesPayment;

namespace XApsisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuesPaymentController : ControllerBase
    {
        private readonly IDuesPaymentService _paymentService;

        public DuesPaymentController(IDuesPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(DuesPaymentAddDto duesPaymentAddDto)
        {
            var result =await _paymentService.AddWithDtoAsync(duesPaymentAddDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(DuesPaymentUpdateDto duesPaymentUpdateDto)
        {
            var result =await  _paymentService.UpdateWithDtoAsync(duesPaymentUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DuesPaymentDeleteDto duesPaymentDeleteDto)
        {
            var result = await _paymentService.DeleteWithDtoAsync(duesPaymentDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _paymentService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _paymentService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getDuesPaymentDetails")]
        public IActionResult GetDuesPaymentDetails()
        {
            var result = _paymentService.GetDuesPaymentDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getDuesPaymentDetailByUser")]
        public async Task<IActionResult> GetDuesPaymentDetailByUser(int id)
        {
            var result =await _paymentService.GetDuesPaymentDetailByDues(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}