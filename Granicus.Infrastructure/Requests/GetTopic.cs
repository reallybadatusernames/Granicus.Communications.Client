using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Granicus.Infrastructure.Entities;
using Granicus.Infrastructure.Interfaces;
using Granicus.Infrastructure.Infrastructure;

namespace Granicus.Infrastructure.Requests
{
    public class GetTopic
    {
        public class Request : IRequest, IAuthRequest, IRequestHandler<Request, Response>, IRequestHandlerAsync<Request, Response>
        {
            public string AccountCode { get; set; } = string.Empty;

            public string UserName { get; set; } = string.Empty;

            public string Password { get; set; } = string.Empty;

            public string Uri { get; set; } = string.Empty;

            public string TopicCode { get; set; } = string.Empty;

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

                    using (var response = client.GetAsync(string.Format(Constants.Topic, AccountCode, TopicCode)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Topic));
                            var content = response.Content.ReadAsStringAsync().Result;

                            return new Response
                            {
                                Topic = ((Topic)serializer.Deserialize(new StringReader(content)))
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

                    using (var response = await client.GetAsync(string.Format(Constants.Topic, AccountCode, TopicCode)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Categories));
                            var content = await response.Content.ReadAsStringAsync();
                            return new Response
                            {
                                Topic = ((Topic)serializer.Deserialize(new StringReader(content)))
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
            public Topic Topic { get; set; } = new Topic();
        }
    }
}
