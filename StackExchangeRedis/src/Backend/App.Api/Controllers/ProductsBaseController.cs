using App.Domain.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsBaseController : ControllerBase
    {
        protected static bool IsNotAuthenticated(AuthenticateResult authenticate)
        {
            return authenticate.Succeeded.IsFalse()
                || authenticate.Principal is null
                || authenticate.Principal.Identities.Any(id => id.IsAuthenticated).IsFalse();
        }
    }
}
