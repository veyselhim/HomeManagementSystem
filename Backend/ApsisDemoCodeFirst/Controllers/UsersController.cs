using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities;
using Entity.Concrete;
using Entity.DTOs.User;

namespace XApsisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromHeader]UserDeleteDto userDeleteDto)
        {
            var result = await _userService.DeleteWithDtoAsync(userDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("editProfile")]
        public async Task<IActionResult> EditProfile(UserForUpdateDto userForUpdate)
        {
           
            var result =await _userService.EditProfileAsync(userForUpdate,userForUpdate.Password);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _userService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getByEmail")]
        public async Task<IActionResult> GetByMail(string email)
        {
            var result =await _userService.GetUserByEmailAsync(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
