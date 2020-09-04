using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Granicus.Core.Entities;

namespace Granicus.Communications
{
    public class CommunicationClient
    {
        #region Properties/Constructor

        private RequestDispatcher _dispatcher;

        private string _accountCode;

        private string _userName;

        private string _password;

        public CommunicationClient(string accountCode, string userName, string password)
        {
            if (string.IsNullOrEmpty(accountCode) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Initialization Failed: One or more parameters is null");

            _accountCode = accountCode;
            _userName = userName;
            _password = password;
            _dispatcher = new RequestDispatcher();
        }

        public static CommunicationClient InitializeClient(string accountCode, string userName, string password)
        {
            var client = new CommunicationClient(accountCode, userName, password);
            return client;
        }

        #endregion

        #region Categories

        public List<Category> GetCategories()
        {
            var request = new GetCategories.Request();
            setupPermissions(request);
            return _dispatcher.Dispatch<GetCategories.Request, GetCategories.Response>(request).Categories;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var request = new GetCategories.Request();
            setupPermissions(request);
            return (await _dispatcher.DispatchAsync<GetCategories.Request, GetCategories.Response>(request)).Categories;
        }

        public Category GetCategory(string categoryCode)
        {
            var request = new GetCategory.Request { CategoryCode = categoryCode };
            setupPermissions(request);
            return _dispatcher.Dispatch<GetCategory.Request, GetCategory.Response>(request).Category;
        }

        public async Task<Category> GetCategoryAsync(string categoryCode)
        {
            var request = new GetCategory.Request { CategoryCode = categoryCode };
            setupPermissions(request);
            return (await _dispatcher.DispatchAsync<GetCategory.Request, GetCategory.Response>(request)).Category;
        }

        public List<Topic> GetCategoryTopics(string categoryCode)
        {
            var request = new GetCategoryTopics.Request { CategoryCode = categoryCode };
            setupPermissions(request);
            return _dispatcher.Dispatch<GetCategoryTopics.Request, GetCategoryTopics.Response>(request).Topics;
        }

        public async Task<List<Topic>> GetCategoryTopicsAsync(string categoryCode)
        {
            var request = new GetCategoryTopics.Request { CategoryCode = categoryCode };
            setupPermissions(request);
            return (await _dispatcher.DispatchAsync<GetCategoryTopics.Request, GetCategoryTopics.Response>(request)).Topics;
        }

        public List<Topic> GetTopics()
        {
            var request = new GetTopics.Request();
            setupPermissions(request);
            return _dispatcher.Dispatch<GetTopics.Request, GetTopics.Response>(request).Topics;
        }

        public async Task<List<Topic>> GetTopicsAsync()
        {
            var request = new GetTopics.Request();
            setupPermissions(request);
            return (await _dispatcher.DispatchAsync<GetTopics.Request, GetTopics.Response>(request)).Topics;
        }

        #endregion

        #region Subscibers

        public string CreateSubscriber(string email, string telephone = "")
        {
            var request = new CreateSubscriber.Request { Email = email };
            setupPermissions(request);
            return _dispatcher.Dispatch<CreateSubscriber.Request, CreateSubscriber.Response>(request).EncodedSubscriberId;
        }

        public async Task<string> CreateSubscriberAsync(string email, string telephone = "")
        {
            var request = new CreateSubscriber.Request { Email = email };
            setupPermissions(request);
            return (await _dispatcher.DispatchAsync<CreateSubscriber.Request, CreateSubscriber.Response>(request)).EncodedSubscriberId;
        }

        public Subscriber GetSubscriber(string email)
        {
            var request = new GetSubscriber.Request { Email = email };
            setupPermissions(request);
            return _dispatcher.Dispatch<GetSubscriber.Request, GetSubscriber.Response>(request).Subscriber;
        }

        public async Task<Subscriber> GetSubscriberAsync(string email)
        {
            var request = new GetSubscriber.Request { Email = email };
            setupPermissions(request);
            return (await _dispatcher.DispatchAsync<GetSubscriber.Request, GetSubscriber.Response>(request)).Subscriber;
        }

        public Subscriber GetEncodedSubscriber(string encodedEmail)
        {
            var request = new GetEncodedSubscriber.Request { EncodedEmail = encodedEmail };
            setupPermissions(request);
            return _dispatcher.Dispatch<GetEncodedSubscriber.Request, GetEncodedSubscriber.Response>(request).Subscriber;
        }

        public async Task<Subscriber> GetEncodedSubscriberAsync(string encodedEmail)
        {
            var request = new GetEncodedSubscriber.Request { EncodedEmail = encodedEmail };
            setupPermissions(request);
            return (await _dispatcher.DispatchAsync<GetEncodedSubscriber.Request, GetEncodedSubscriber.Response>(request)).Subscriber;
        }

        public List<Topic> GetSubscriberTopics(string email)
        {
            var request = new GetSubscriberTopics.Request { Email = email };
            setupPermissions(request);
            return _dispatcher.Dispatch<GetSubscriberTopics.Request, GetSubscriberTopics.Response>(request).Topics;
        }

        public async Task<List<Topic>> GetSubscriberTopicsAsync(string email)
        {
            var request = new GetSubscriberTopics.Request { Email = email };
            setupPermissions(request);
            return (await _dispatcher.DispatchAsync<GetSubscriberTopics.Request, GetSubscriberTopics.Response>(request)).Topics;
        }

        public void UpdateSubscriberTopics(string email, string[] topicCodes)
        {
            var request = new UpdateSubscriberTopics.Request { SubscriberEmail = email, Topics = topicCodes};
            setupPermissions(request);
            _dispatcher.Dispatch<UpdateSubscriberTopics.Request, UpdateSubscriberTopics.Response>(request);
        }

        public async Task UpdateSubscriberTopicsAsync(string email, string[] topicCodes)
        {
            var request = new UpdateSubscriberTopics.Request { SubscriberEmail = email, Topics = topicCodes };
            setupPermissions(request);
            await _dispatcher.DispatchAsync<UpdateSubscriberTopics.Request, UpdateSubscriberTopics.Response>(request);
        }

        #endregion

        #region Helpers

        private void setupPermissions(IAuthRequest request)
        {
            request.AccountCode = _accountCode;
            request.UserName = _userName;
            request.Password = _password;
        }

        #endregion
    }
}
