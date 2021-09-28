using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.BillPayment;

namespace XApsisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillPaymentsController : ControllerBase
    {
        private readonly IBillPaymentService _billPaymentService;

        public BillPaymentsController(IBillPaymentService billPaymentService)
        {
            _billPaymentService = billPaymentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(BillPaymentAddDto billPaymentAddDto)
        {
            var result =await _billPaymentService.AddWithDtoAsync(billPaymentAddDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(BillPaymentUpdateDto billPaymentUpdateDto)
        {
            var result =await _billPaymentService.UpdateWithDtoAsync(billPaymentUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(BillPaymentDeleteDto billPaymentDeleteDto)
        {
            var result =await _billPaymentService.DeleteWithDtoAsync(billPaymentDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _billPaymentService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getBillPaymentDetails")]
        public IActionResult GetBillPaymentDetails()
        {
            var result = _billPaymentService.GetBillPaymentDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _billPaymentService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    }
}
