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
using Translator.API.Controllers.RequestChainOfResponsibility.Base;
using Translator.API.Controllers.RequestChainOfResponsibility.CommonRequestHandlers;
using Translator.API.Controllers.RequestChainOfResponsibility.TranslationRequestHandlers;
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
        private readonly IRequestHandler<TranslationRequestDto, TranslationResponseDto> _translationChainOfResponsibility;
        
            
        public TranslationController(IDbGenericService<Sentence> sentenceService, 
            IDbGenericService<Word> wordService, 
            IDbGenericService<Collocation> collocationService,
            IDbGenericService<LogMessage> logMessageService)
        {
            var startLogHandler = new LogMessageHandler<TranslationRequestDto, TranslationResponseDto>(logMessageService,
                "start handle search request");
            
            var translationHandler = new MainTranslationsHandler(wordService);
            var translationLogHandler = new LogMessageHandler<TranslationRequestDto, TranslationResponseDto>(logMessageService,
                "translations search request end");
            
            var sentencesHandler = new SentencesHandler(sentenceService);
            var sentencesLogHandler = new LogMessageHandler<TranslationRequestDto, TranslationResponseDto>(logMessageService,
                "sentences search request end");
            
            var collocationsHandler = new CollocationsHandler(collocationService);
            var collocationsLogHandler = new LogMessageHandler<TranslationRequestDto, TranslationResponseDto>(logMessageService,
                "collocations search request end");

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
            return Ok(await _translationChainOfResponsibility.Handle(
                new TranslationRequestDto(word), new TranslationResponseDto()));
        }
    }
}