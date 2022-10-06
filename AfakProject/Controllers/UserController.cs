﻿using Afak.Service.Dto;
using Afak.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AfakProject.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService userService;
        readonly ILogger<UserController> Logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            Logger = logger;
        }


        //Http Post Method
        [HttpPost]
        //Don't need auth
        [AllowAnonymous]
        //Route or final endpoint name.
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AddUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return ValidationProblem();
                var output = await userService.AddAsync(userDto);
                if (output == false)
                    return Problem();
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        //Http GET Method
        [HttpGet]
        //Don't need auth
        [AllowAnonymous]
        //Route or final endpoint name.
        [Route("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var output = await userService.List();
                if (output == null)
                    return Problem();
                return Ok(output);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
