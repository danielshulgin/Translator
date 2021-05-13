using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Translator.API.Controllers.RequestChainOfResponsibility;
using Translator.API.DTO;
using Translator.API.JwtFeatures;
using Translator.Domain.Models;
using Translator.EntityFramework;
using Translator.EntityFramework.Services;

namespace Translator.API.Controllers
{
    [Route("api/translations")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        private readonly IRequestHandler<string, TranslationResponseDto> _translationChainOfResponsibility;
        
            
        public TranslationController(DbGenericService<Sentence> sentenceService, 
            DbGenericService<Word> wordService, 
            DbGenericService<Collocation> collocationService,
            DbGenericService<LogMessage> logMessageService)
        {
            var startLogHandler = 
                new LogMessageHandler<string, TranslationResponseDto>(logMessageService,"start handle search request");
            var translationHandler = new TranslationHandler(wordService);
            var translationLogHandler = 
                new LogMessageHandler<string, TranslationResponseDto>(logMessageService,"translations search request end");
            var sentencesHandler = new SentencesHandler(sentenceService);
            var sentencesLogHandler = 
                new LogMessageHandler<string, TranslationResponseDto>(logMessageService,"sentences search request end");
            var collocationsHandler = new CollocationsHandler(collocationService);
            var collocationsLogHandler = 
                new LogMessageHandler<string, TranslationResponseDto>(logMessageService,"sentences search request end");

            _translationChainOfResponsibility = startLogHandler
                .AddNext(translationHandler)
                .AddNext(translationLogHandler)
                .AddNext(sentencesHandler)
                .AddNext(sentencesLogHandler)
                .AddNext(collocationsHandler)
                .AddNext(collocationsLogHandler);
        }   
        
        [HttpGet("Translate")]
        public async Task<IActionResult> Translate([FromQuery(Name = "word")] string word)
        {
            return Ok(await _translationChainOfResponsibility.Handle(word, new TranslationResponseDto()));
        }
    }
}