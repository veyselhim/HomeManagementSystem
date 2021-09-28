using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.UserOperationClaim;

namespace XApsisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        public readonly IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
           var result = await _userOperationClaimService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userOperationClaimService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getUserOperationClaimsDetail")]
        public async Task<IActionResult> GetUserOperationClaimsDetail()
        {
            var result = await _userOperationClaimService.GetUserOperationClaimsDetail();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UserOperationClaimAddDto userOperationClaimAddDto)
        {
            var result = await _userOperationClaimService.AddAsync(userOperationClaimAddDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(UserOperationClaimDeleteDto userOperationClaimDeleteDto)
        {
            var result = await _userOperationClaimService.DeleteAsync(userOperationClaimDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
