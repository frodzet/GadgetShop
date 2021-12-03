using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public AuthenticationController(IUserService  userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] JObject data)
        {
            try
            {
                var validToken = _userService.Login(data["Username"].ToString(), data["Password"].ToString());
                return Ok(new
                {
                    Token = validToken
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}