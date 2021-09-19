using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Client.HttpHandler
{
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        private IHttpClientFactory _httpClientFactory = null;
        private ClientCredentialsTokenRequest _clientCredentialsTokenRequest = null;

        public AuthenticationDelegatingHandler(IHttpClientFactory httpClientFactory, ClientCredentialsTokenRequest clientCredTokenReq)
        {
            _httpClientFactory = httpClientFactory;
            _clientCredentialsTokenRequest = clientCredTokenReq;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpclient = _httpClientFactory.CreateClient("IDPClient");
            var tokenResponse = await httpclient.RequestClientCredentialsTokenAsync(_clientCredentialsTokenRequest);
            if (tokenResponse.IsError)
            {
                throw new HttpRequestException("something went wrong while requesting the access token");
            }

            request.SetBearerToken(tokenResponse.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
