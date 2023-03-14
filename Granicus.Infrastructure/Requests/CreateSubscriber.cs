using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Granicus.Infrastructure.Helpers;
using Granicus.Infrastructure.Entities;
using Granicus.Infrastructure.Interfaces;
using Granicus.Infrastructure.DataTransfer;
using Granicus.Infrastructure.Infrastructure;

namespace Granicus.Infrastructure.Requests
{
    public class CreateSubscriber
    {
        public class Request : IRequest,
            IAuthRequest, 
            IRequestHandler<Request, Response>, 
            IRequestHandlerAsync<Request, Response>
        {
            public string AccountCode { get; set; } = string.Empty;

            public string UserName { get; set; } = string.Empty;

            public string Password { get; set; } = string.Empty;

            public string Uri { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public bool SendNotifications { get; set; } = false;

            public Digest DigestFor { get; set; } = Digest.Weekly;
            
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

                    var model = new CreateSubscriberDTO() { Email = this.Email, SendSubscriberUpdateNotifications = false };
                    var contents = model.ToStringContent();

                    using (var response = client.PostAsync(string.Format(Constants.Subscribers, AccountCode), contents).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(SubscriberCreatedDTO));
                            var respContent = response.Content.ReadAsStringAsync().Result;
                            var res = ((SubscriberCreatedDTO)serializer.Deserialize(new StringReader(respContent)));

                            return new Response
                            {
                                EncodedSubscriberId = res.ToParam
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

                    var model = new CreateSubscriberDTO() { Email = this.Email, SendSubscriberUpdateNotifications = this.SendNotifications, SendBulletins = this.DigestFor };
                    var contents = model.ToStringContent();

                    using (var response = await client.PostAsync(string.Format(Constants.Subscribers, AccountCode), contents))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(CreateSubscriberDTO));
                            var respContent = response.Content.ReadAsStringAsync().Result;
                            var res = ((SubscriberCreatedDTO)serializer.Deserialize(new StringReader(respContent)));

                            return new Response
                            {
                                EncodedSubscriberId = res.ToParam
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
            public string EncodedSubscriberId { get; set; } = string.Empty;
        }
    }
}
