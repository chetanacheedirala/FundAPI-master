using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundAPI.DB;
using FundAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FundAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FundController : ControllerBase
    {
        
        private readonly ILogger<FundController> _logger;
        private readonly IFundManager _fundManager;
        public FundController(ILogger<FundController> logger, IFundManager fundManager)
        {
            _logger = logger;
            _fundManager = fundManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Get fund details");
                var list = _fundManager.GetFundDetails();
                return Ok(list);
                    }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
