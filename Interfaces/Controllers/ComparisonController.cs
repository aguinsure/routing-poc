using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interfaces.Controllers
{
    enum ProductType
    {
        PropertyOwners,
        TradesAndProfessions
    }
    
    [ApiController]
    [Route("[controller]")]
    public class ComparisonController : ControllerBase
    {
        public ComparisonController()
        {
            
        }

        [HttpPost("{product}/{version}")]
        public string Post([FromBody] ProductRequest request, string product, int version)
        {
            var productType = product.EndsWith("property_owners")
                ? ProductType.PropertyOwners
                : ProductType.TradesAndProfessions;

            var firstName = request.FirstName;
            var lastName = request.LastName;

            string additionalProperty = "";

            switch (productType)
            {
                case ProductType.PropertyOwners:
                {
                    if (version == 1)
                    {
                        additionalProperty = $"PropertyOwners V1: {((IPropertyOwnersV1)request).POV1SpecificAnswer}";
                    }
                    else
                    {
                        additionalProperty = $"PropertyOwners V2: {((IPropertyOwnersV2)request).POV2SpecificAnswer}";
                    }

                    break;
                }
                case ProductType.TradesAndProfessions:
                {
                    additionalProperty = $"TradesAndProfessions V1: {((ITradesAndProfessionsV1)request).TPV1SpecificAnswer}";
                    break;
                }
            }
            
            return $"{additionalProperty}\n\n{firstName} {lastName}";
        }
    }
}