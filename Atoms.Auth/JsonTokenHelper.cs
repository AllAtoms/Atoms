using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT.Algorithms;

namespace Atoms.Auth
{
    public static class JsonTokenHelper
    {
        const string Secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        public static string MakeToken(string userJson)
        {
            var token = new JwtBuilder().
    .SetAlgorithm(new HMACSHA256Algorithm())
    .SetSecret(secret)
    .AddClaim(ClaimName.ExpirationTime, DateTime.UtcNow.AddHours(1))
    .Build();

            Console.WriteLine(token);

            return null;
        }
    }
}
