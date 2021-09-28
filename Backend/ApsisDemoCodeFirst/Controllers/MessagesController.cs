using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Message;

namespace XApsisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(MessageAddDto messageAddDto)
        {
            var result = await _messageService.AddWithDtoAsync(messageAddDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("delete")]
        public async Task<IActionResult> Delete(MessageDeleteDto messageDeleteDto)
        {
            var result =await _messageService.DeleteWithDtoAsync(messageDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _messageService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _messageService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getMessageDetails")]
        public IActionResult GetMessageDetails()
        {
            var result = _messageService.GetMessageDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
