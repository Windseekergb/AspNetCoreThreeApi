using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route(template:"V1/[Controller]")]
    [ApiController]
    public class SummaryController:ControllerBase
       
    {
        private readonly ISummaryRepository _summaryRepository;
       public  SummaryController(ISummaryRepository summaryResposiory)
        {
            _summaryRepository = summaryResposiory;
        }
        public    async  Task<IActionResult>Get()
        {
            var result = await _summaryRepository.GetCompanySummary();
            return Ok(result);
        }
    }
}
