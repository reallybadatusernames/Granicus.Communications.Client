using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Granicus.Core;
using Granicus.Core.Entities;
using Granicus.Core.DataTransfer;
using Granicus.Core.Infrastructure;
using Granicus.Communications.Helpers;

namespace Granicus.Communications
{
    public class GetSubscriber
    {
        public class Request : IRequest, IAuthRequest, IRequestHandler<Request, Response>, IRequestHandlerAsync<Request, Response>
        {
            public string AccountCode { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }

            public string Email { get; set; }

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

                    using (var response = client.GetAsync(string.Format(Constants.Subsciber, AccountCode, Email.ToBase64())).Result)
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
                            return new Response();
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

                    using (var response = await client.GetAsync(string.Format(Constants.Subsciber, AccountCode, Email.ToBase64())))
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
