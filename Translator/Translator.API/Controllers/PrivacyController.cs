using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Translator.API.DTO;
using Translator.API.JwtFeatures;
using Translator.Domain.Models;

namespace Translator.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    [Authorize]
    public class PrivacyController : ControllerBase
    {
        [HttpGet("Privacy")]
        [Authorize]
        public IActionResult Privacy()
        {
            var claims = User.Claims
                .Select(c => new { c.Type, c.Value })
                .ToList();

            return Ok(claims);
        }
    }
}
