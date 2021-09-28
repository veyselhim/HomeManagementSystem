using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.CardDocument;

namespace XApsisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardDocumentsController : ControllerBase
    {
        private readonly ICardMongoDbService _cardMongoDbService;
        public CardDocumentsController(ICardMongoDbService cardMongoDbService)
        {
            _cardMongoDbService = cardMongoDbService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cardMongoDbService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _cardMongoDbService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var result = await _cardMongoDbService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CardAddDocument cardAddDocument)
        {
            var result = await _cardMongoDbService.AddAsync(cardAddDocument);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addRange")]
        public async Task<IActionResult> AddRange(List<CardAddDocument> cardAddDocuments)
        {
            var result = await _cardMongoDbService.AddRangeAsync(cardAddDocuments);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(CardUpdateDocument cardUpdateDocument)
        {
            var result =await  _cardMongoDbService.UpdateAsync(cardUpdateDocument);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _cardMongoDbService.DeleteAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

       
    }
}
