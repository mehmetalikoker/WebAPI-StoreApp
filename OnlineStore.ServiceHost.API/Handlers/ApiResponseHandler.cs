using OnlineStore.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace OnlineStore.ServiceHost.API.Handlers
{
    public class ApiResponseHandler : DelegatingHandler
    {
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            return BuildApiResponse(request,response);
        }

        private HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            object content = null;
            string errorMessage = string.Empty;

            ValidateApiResponse(response, ref content, ref errorMessage);

            var newResponse = CreateHttpResponseMessage(request, response, content, errorMessage);

            foreach (var loopHeader in response.Headers)
            {
                newResponse.Headers.Add(loopHeader.Key, loopHeader.Value);
            }

            return newResponse;
        }

        private HttpResponseMessage CreateHttpResponseMessage<T>(HttpRequestMessage request, HttpResponseMessage response, T content, string errorMessage)
        {
            return request.CreateResponse(response.StatusCode, 
                new ApiResponse<T>(response.StatusCode, content,errorMessage));
        }

        private void ValidateApiResponse(HttpResponseMessage response,ref object content, ref string errorMessage)
        {
            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;

                if (error != null)
                {
                    content = null;
                    StringBuilder sb = new StringBuilder();

                    foreach (var loopError in error)
                    {
                        sb.Append(string.Format("{0} {1}", loopError.Key, loopError.Value));
                    }

                    errorMessage = sb.ToString();
                }
            }
        }


    }
}