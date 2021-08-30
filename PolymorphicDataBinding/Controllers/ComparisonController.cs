using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolymorphicDataBinding.Models;

namespace PolymorphicDataBinding.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComparisonController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] ProductRequest request)
        {
            string additionalProperty = "";
            string firstName = "";
            string lastName = "";
            
            switch (request.Product)
            {
                case "Property Owners":
                {
                    switch (request.Version)
                    {
                        case 1:
                        {
                            PropertyOwnersV1 rv1 = (PropertyOwnersV1)request;
                            additionalProperty = $"Property Owners V1: ({rv1.POV1SpecificAnswer})";
                            firstName = rv1.FirstName;
                            lastName = rv1.LastName;
                            break;
                        }
                        default:
                        {
                            PropertyOwnersV2 rv2 = (PropertyOwnersV2)request;
                            additionalProperty = $"Property Owners V2: ({rv2.POV2SpecificAnswer})";
                            firstName = rv2.FirstName;
                            lastName = rv2.LastName;
                            break;
                        }
                    }

                    break;
                }
                default:
                {
                    TradesAndProfessionsV1 tpv1 = (TradesAndProfessionsV1)request;
                    additionalProperty = $"Tradesman V1: ({tpv1.TPV1SpecificAnswer})";
                    firstName = tpv1.FirstName;
                    lastName = tpv1.LastName;
                    break;
                }
            }
            return $"{additionalProperty}\n\n{firstName} {lastName}";
        }
    }
}