using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellarPayRoll.API.ActionResults
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error) : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
