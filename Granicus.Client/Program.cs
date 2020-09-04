using System;
using System.Linq;
using System.Threading.Tasks;

using Granicus.Communications;

namespace Granicus.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = CommunicationClient.InitializeClient("ACCOUNTCODE", "username@domain.com", "P@22w0rd!");

            var subscriberEmail = "someone@gmail.com";
            var subscriber = client.GetSubscriber(subscriberEmail);

            if (subscriber == null)
            {
                var subscriberId = client.CreateSubscriber(subscriberEmail);
                subscriber = client.GetEncodedSubscriber(subscriberId);
            }

            //get subscriber topics
            var subscriberTopics = client.GetSubscriberTopics(subscriber.Email);

            //get all topics
            var allTopics = client.GetTopics();
            
            if (subscriber != null)
            {
                //subscribe subscriber to all topics
                client.UpdateSubscriberTopics(subscriber.Email, allTopics.Select(x => x.Code).ToArray());
            }

            var categories = client.GetCategories();

            //get all categories and itterate their topics
            foreach (var category in categories)
            {
                Console.WriteLine(string.Format("Getting topics for category {0}", category.Name));
                var topics = client.GetCategoryTopics(category.Code);
                foreach (var topic in topics)
                {
                    Console.WriteLine(string.Format("Topic '{0}' belongs in category: {1}.", topic.Name, category.Name));
                }
            }
        }
    }
}
