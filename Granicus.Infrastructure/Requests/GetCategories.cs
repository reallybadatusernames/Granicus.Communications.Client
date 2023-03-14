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
    public class GetCategories 
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

                    using (var response = client.GetAsync(string.Format(Constants.Categories, AccountCode)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Categories));
                            return new Response
                            {
                                Categories = ((Categories)serializer.Deserialize(new StringReader(response.Content.ReadAsStringAsync().Result))).categories
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

                    using (var response = await client.GetAsync(string.Format(Constants.Categories, AccountCode)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Categories));
                            return new Response
                            {
                                Categories = ((Categories)serializer.Deserialize(new StringReader(await response.Content.ReadAsStringAsync()))).categories
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
            public List<Category> Categories { get; set; } = new List<Category>();
        }
    }
}
