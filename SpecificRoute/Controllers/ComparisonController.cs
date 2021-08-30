using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificRoute.Models;

namespace SpecificRoute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComparisonController : ControllerBase
    {

        [HttpPost("property_owners/v1")]
        public string POV1([FromBody]PropertyOwnersV1 request)
        {
            return $"Property Owners V1 ({request.POV1SpecificAnswer}):\n\n{request.FirstName} {request.LastName}";
        }
        
        [HttpPost("property_owners/v2")]
        public string POV2([FromBody]PropertyOwnersV2 request)
        {
            return $"Property Owners V2 ({request.POV2SpecificAnswer}):\n\n{request.FirstName} {request.LastName}";
        }
        
        [HttpPost("trades_and_professions/v1")]
        public string TPV1([FromBody]TradesAndProfessionsV1 request)
        {
            return $"Tradesman V1 ({request.TPV1SpecificAnswer}):\n\n{request.FirstName} {request.LastName}";
        }
    }
}