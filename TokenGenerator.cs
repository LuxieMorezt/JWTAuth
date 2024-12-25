using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuth
{
    public class TokenGenerator
    {
        public static string GenerateToken(string secretKey, string issuer, string audience, string username, List<string> roles, int expiryMinutes = 30)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            // Create claims based on user information
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),  // Add the username
            new Claim("CustomClaim", "DemoValue")  // Example custom claim
        };

            // Add role claims dynamically
            roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));

            // Create the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
