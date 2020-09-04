using System;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Granicus.Core;
using Granicus.Core.Infrastructure;
using Granicus.Communications.Helpers;
using Granicus.Core.DataTransfer.Subscriber;

namespace Granicus.Communications
{
    public class UpdateSubscriberTopics
    {
        public class Request : IRequest, IAuthRequest, IRequestHandler<Request, Response>, IRequestHandlerAsync<Request, Response>
        {
            public string AccountCode { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }

            public string[] Topics { get; set; }

            public string SubscriberEmail { get; set; }

            public Response ProcessRequest()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.Uri);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(string.Format("{0}:{1}", UserName, Password))
                        )
                    );

                    var model = new SubscriberTopicsDTO
                    {
                        Topics = new SubscriberTopics
                        {
                            topic = this.Topics.Select(x => new SubscriberTopic { Code = x }).ToList()
                        }
                    };

                    var content = model.ToStringContent();
                    using (var response = client.PutAsync(string.Format(Constants.SubscriberTopics, AccountCode, SubscriberEmail.ToBase64()), content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return new Response { Suceeded = true };
                        }
                        else
                        {
                            response.EnsureSuccessStatusCode();
                            return null;
                        }
                    }
                }
            }

            public async Task<Response> ProcessRequestAsync()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.Uri);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(string.Format("{0}:{1}", UserName, Password))
                        )
                    );

                    var model = new SubscriberTopicsDTO
                    {
                        Topics = new SubscriberTopics
                        {
                            topic = this.Topics.Select(x => new SubscriberTopic { Code = x }).ToList()
                        }
                    };

                    var content = model.ToStringContent();
                    using (var response = await client.PutAsync(string.Format(Constants.SubscriberTopics, AccountCode, SubscriberEmail.ToBase64()), content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return new Response { Suceeded = true };
                        }
                        else
                        {
                            response.EnsureSuccessStatusCode();
                            return null;
                        }
                    }
                }
            }
        }

        public class Response : IResponse
        {
            public bool Suceeded { get; set; }
        }
    }
}
