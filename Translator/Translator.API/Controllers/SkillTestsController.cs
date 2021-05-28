using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Translator.API.DTO;
using Translator.API.JwtFeatures;
using Translator.Domain.Models;
using Translator.Domain.Models.SkillTests;
using Translator.Domain.SkillTests;
using Translator.EntityFramework;
using Translator.EntityFramework.Services;

namespace Translator.API.Controllers
{
    [Route("api/skilltests")]
    [ApiController]
    public class SkillTestsController : ControllerBase
    {
        private readonly IDbGenericService<TestTree> _testTreeService;


        public SkillTestsController(IDbGenericService<TestTree> testTreeService)
        {
            _testTreeService = testTreeService;
        }
        
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            var treeModel = (await _testTreeService.GetAll()).First();
            return Ok(treeModel.JsonValue);
        }

        [HttpPost("CheckTest")]
        public IActionResult CheckTest([FromBody] string tree)
        {
            var deserializedUserTree = JsonConvert.DeserializeObject<GroupTestNode>(tree, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            var earnedPoints = deserializedUserTree.CalculateEarnedPoints();
            var fullPoints = deserializedUserTree.CalculateFullPoints();
            return Ok(new CheckTestDto { EarnedPoints = earnedPoints, FullPoints = fullPoints});
        }
    }
}
