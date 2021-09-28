using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Bill;

namespace XApsisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillsController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(BillAddDto billAddDto)
        {
            var result =await _billService.AddWithDtoAsync(billAddDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(BillUpdateDto billUpdateDto)
        {
            var result =await _billService.UpdateWithDtoAsync(billUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(BillDeleteDto billDeleteDto)
        {
            var result = await _billService.DeleteWithDtoAsync(billDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _billService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _billService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getBillDetails")]
        public IActionResult GetBillDetails()
        {
            var result = _billService.GetBillDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getBillDetailsByUser")]
        public async Task<IActionResult> GetBillDetailsByUser(int userId)
        {
            var result =await _billService.GetBillDetailsByUser(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var result = await _billService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
