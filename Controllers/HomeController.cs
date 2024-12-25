using System.Diagnostics;
using JWTAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("generate-token")]
        public IActionResult GenerateToken([FromBody] TokenRequest request)
        {
            string secretKey = "your_very_secure_and_longer_secret_key_123!";
            string issuer = "https://yourapp.com";
            string audience = "https://yourapp.com";

            // Generate the token with dynamic claims
            string token = TokenGenerator.GenerateToken(secretKey, issuer, audience, request.Username, request.Roles);
            return Ok(new { Token = token });
        }
        public class TokenRequest
        {
            public string Username { get; set; }
            public List<string> Roles { get; set; }
        }


    }
}
