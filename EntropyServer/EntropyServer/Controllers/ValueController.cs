﻿using EntropyServer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EntropyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly IEntropyTypeConfigurationMappingService _entropyConfigurationMapper;

        public ValueController(IEntropyTypeConfigurationMappingService entropyConfigurationMapper)
        {
            _entropyConfigurationMapper = entropyConfigurationMapper;
        }


        [HttpGet]
        [Route("typedefinitions")]
        public IActionResult GetTypeDefinitions() => Ok(new List<object> { _entropyConfigurationMapper.GetConfiguration<int>() });
    }
}
