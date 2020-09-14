namespace Granicus.Core
{
    public static class Constants
    {
        #region Cloud Communication

        public const string Categories = "/api/account/{0}/categories.xml";

        public const string CategoryTopics = "/api/account/{0}/categories/{1}/topics";

        public const string Category = "api/account/{0}/categories/{1}.xml";

        public const string Topics = "/api/account/{0}/topics.xml";

        public const string Topic = "/api/account/{0}/topics/{1}.xml";

        public const string Subscribers = "/api/account/{0}/subscribers.xml";

        public const string Subsciber = "/api/account/{0}/subscribers/{1}.xml";

        public const string SubscriberTopics = "/api/account/{0}/subscribers/{1}/topics.xml";

        #endregion
    }
}
