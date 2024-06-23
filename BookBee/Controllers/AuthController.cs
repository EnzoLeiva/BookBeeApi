using BookBee.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookBee.Api.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    [TypeFilter(typeof(ExceptionManager))]
    public class AuthController : ControllerBase
    {
        //[HttpGet("google-login")]
        //public IActionResult GoogleLogin()
        //{
        //    var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
        //    return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        //}

        //[HttpGet("google-response")]
        //public async Task<IActionResult> GoogleResponse([FromServices] IGetTokenJwtService getTokenJwtService)
        //{
        //    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claims = result.Principal.Identities
        //        .FirstOrDefault()?.Claims.Select(claim => new
        //        {
        //            claim.Type,
        //            claim.Value
        //        });

        //    var userId = GetOrCreateUser(claims); // Implementar este método

        //    var token = getTokenJwtService.Execute(userId);

        //    return Ok(new { token });
        //}
    }
}
