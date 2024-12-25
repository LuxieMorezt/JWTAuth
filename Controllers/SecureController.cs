using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SecureController : Controller
    {
        [HttpGet("/secure/index")]
        public IActionResult Index()
        {
            return Ok("You have accessed a protecteed endpoint");
        }
    }
}
