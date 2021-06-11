using Microsoft.IdentityModel.Tokens;
using MyGraphQLs.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphQLs
{
    public class GenerateToken
    {
        public static string Execute (string username, string password)
        {
			var key = "4fb4043e16ff127eca681216598a830e8b0cf3bf";
			var issuer = DataEncryption.EncryptString(System.Net.Dns.GetHostName());

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var permClaims = new List<Claim>();
			permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
			permClaims.Add(new Claim("username", username));
			permClaims.Add(new Claim("password", password));

			var jwtToken = new JwtSecurityToken (
				issuer: issuer,
				audience: issuer,
				claims: permClaims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: credentials
			);

			string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
			return token;
		}
    }
}
