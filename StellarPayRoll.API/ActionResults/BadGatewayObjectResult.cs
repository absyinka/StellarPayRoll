using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellarPayRoll.API.ActionResults
{
    public class BadGatewayObjectResult : ObjectResult
    {
        public BadGatewayObjectResult(object error) : base(error)
        {
            StatusCode = StatusCodes.Status502BadGateway;
        }
    }
}
