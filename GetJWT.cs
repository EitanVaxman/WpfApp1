using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WpfApp1
{
    public sealed class GetJWT
    {
        private static readonly object padlock = new object();
        private static GetJWT _Instance = null;
        public static GetJWT Instance
        {
            get
            {
                lock (padlock)//critical section
                {
                    if (_Instance == null)
                    {
                        _Instance = new GetJWT();
                    }
                    return _Instance;
                }
            }
        }
        
        private GetJWT()
        {

        }

        public string GetJsonWebToke(string str)
        {
            // Define const Key this should be private secret key  stored in some safe place
            string key = "VAXMANeab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

            // Create Security key  using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            //
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Finally create a Token
            JwtHeader header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            JwtPayload payload = new JwtPayload()
            {
                { str, "hello "},
            };

            JwtSecurityToken secToken = new JwtSecurityToken(header, payload);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            string tokenString = handler.WriteToken(secToken);

            // And finally when  you received token from client
            // you can  either validate it or try to  read
            JwtSecurityToken token = handler.ReadJwtToken(tokenString);

            return tokenString;
        }
    }
}
