using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Granicus.Core;
using Granicus.Core.Entities;
using Granicus.Core.Infrastructure;

namespace Granicus.Communications
{
    public class GetCategory
    {
        public class Request : IRequest, IAuthRequest, IRequestHandler<Request, Response>, IRequestHandlerAsync<Request, Response>
        {
            public string AccountCode { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }

            public string CategoryCode { get; set; }

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

                    using (var response = client.GetAsync(string.Format(Constants.Category, AccountCode, CategoryCode)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Category));

                            return new Response
                            {
                                Category = (Category)serializer.Deserialize(new StringReader(response.Content.ReadAsStringAsync().Result))
                            };
                        }
                    }
      

                    return new Response();
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

                    using (var response = await client.GetAsync(string.Format(Constants.Category, AccountCode, CategoryCode)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Category));
                            return new Response
                            {
                                Category = (Category)serializer.Deserialize(new StringReader(await response.Content.ReadAsStringAsync()))
                            };
                        }
                    }

                    return new Response();
                }
            }
        }

        public class Response : IResponse
        {
            public Category Category { get; set; }
        }
    }
}
