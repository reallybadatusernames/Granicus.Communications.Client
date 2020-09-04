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
    public class GetEncodedSubscriber
    {
        public class Request : IRequest, IAuthRequest, IRequestHandler<Request, Response>, IRequestHandlerAsync<Request, Response>
        {
            public string AccountCode { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }

            public string EncodedEmail { get; set; }

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

                    using (var response = client.GetAsync(string.Format(Constants.Subsciber, AccountCode, EncodedEmail)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Subscriber));

                            return new Response
                            {
                                Subscriber = (Subscriber)serializer.Deserialize(new StringReader(response.Content.ReadAsStringAsync().Result))
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
                    client.BaseAddress = new Uri(Constants.Uri);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(string.Format("{0}:{1}", UserName, Password))
                        )
                    );

                    using (var response = await client.GetAsync(string.Format(Constants.Subsciber, AccountCode, EncodedEmail)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Category));

                            return new Response
                            {
                                Subscriber = (Subscriber)serializer.Deserialize(new StringReader(await response.Content.ReadAsStringAsync()))
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
            public Subscriber Subscriber { get; set; }
        }
    }
}
