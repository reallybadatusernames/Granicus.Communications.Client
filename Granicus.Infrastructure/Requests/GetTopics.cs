using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;

using Granicus.Infrastructure.Entities;
using Granicus.Infrastructure.Interfaces;
using Granicus.Infrastructure.Infrastructure;

namespace Granicus.Infrastructure.Requests
{
    public class GetTopics
    {
        public class Request : IRequest, IAuthRequest, IRequestHandler<Request, Response>, IRequestHandlerAsync<Request, Response>
        {
            public string AccountCode { get; set; } = string.Empty;

            public string UserName { get; set; } = string.Empty;

            public string Password { get; set; } = string.Empty;

            public string Uri { get; set; } = string.Empty;

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

                    using (var response = client.GetAsync(string.Format(Constants.Topics, AccountCode)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Topics));
                            var content = response.Content.ReadAsStringAsync().Result;

                            return new Response
                            {
                                Topics = ((Topics)serializer.Deserialize(new StringReader(content))).topics
                            };
                        };
                    }

                    return new Response();
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

                    using (var response = await client.GetAsync(string.Format(Constants.Topics, AccountCode)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Topics));
                            var content = await response.Content.ReadAsStringAsync();
                            return new Response
                            {
                                Topics =  ((Topics)serializer.Deserialize(new StringReader(content))).topics
                            };
                        };
                    }

                    return new Response();
                }
            }
        }

        public class Response : IResponse
        {
            public List<Topic> Topics { get; set; } = new List<Topic>();
        }
    }
}
