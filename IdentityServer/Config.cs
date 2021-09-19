using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId="movieClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "movieAPI" }
                },
                new Client
                {
                    ClientId = "movies_mvc_Client",
                    ClientName = "Movies User Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    }
                }
            };
        public static IEnumerable<IdentityResource> IdentityResources => 
            new IdentityResource[] 
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] { };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("movieAPI","Movie API")
            };
        public static List<TestUser> TestUsers => 
            new List<TestUser> 
            { 
                new TestUser
                {
                     SubjectId = "1",
                     Username = "Bhuvan",
                     Password =  "Test123",
                     Claims = new List<Claim>
                     {
                          new  Claim(JwtClaimTypes.GivenName, "Bhuvan"),
                          new Claim(JwtClaimTypes.FamilyName, "Raj")
                     }
                }
            };

    }
}
