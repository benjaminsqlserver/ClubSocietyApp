using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace SocietyApp.Authentication
{
    public class TokenProviderOptions
    {
        public static string Audience { get; } = "SocietyAppAudience";
        public static string Issuer { get; } = "SocietyApp";
        public static SymmetricSecurityKey Key { get; } = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SocietyAppSecretSecurityKeySocietyApp"));
        public static TimeSpan Expiration { get; } = TimeSpan.FromMinutes(15);
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
    }
}
