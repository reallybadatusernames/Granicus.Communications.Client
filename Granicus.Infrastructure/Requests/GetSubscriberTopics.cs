using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;

using Granicus.Infrastructure.Helpers;
using Granicus.Infrastructure.Entities;
using Granicus.Infrastructure.Interfaces;
using Granicus.Infrastructure.Infrastructure;

namespace Granicus.Infrastructure.Requests
{
    public class GetSubscriberTopics
    {
        public class Request : IRequest, IAuthRequest, IRequestHandler<Request, Response>, IRequestHandlerAsync<Request, Response>
        {
            public string AccountCode { get; set; } = string.Empty;

            public string UserName { get; set; } = string.Empty;

            public string Password { get; set; } = string.Empty;

            public string Uri { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public Response ProcessRequest()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Uri);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(string.Format("{0}:{1}", UserName, Password))
                        )
                    );

                    using (var response = client.GetAsync(string.Format(Constants.SubscriberTopics, AccountCode, Email.ToBase64())).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Topics));

                            return new Response
                            {
                                Topics = ((Topics)serializer.Deserialize(new StringReader(response.Content.ReadAsStringAsync().Result))).topics
                            };
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
                    client.BaseAddress = new Uri(Uri);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(string.Format("{0}:{1}", UserName, Password))
                        )
                    );

                    using (var response = await client.GetAsync(string.Format(Constants.Subsciber, AccountCode, Email.ToBase64())))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Topics));

                            return new Response
                            {
                                Topics = ((Topics)serializer.Deserialize(new StringReader(response.Content.ReadAsStringAsync().Result))).topics
                            };
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
            public List<Topic> Topics { get; set; } = new List<Topic>();
        }
    }
}
