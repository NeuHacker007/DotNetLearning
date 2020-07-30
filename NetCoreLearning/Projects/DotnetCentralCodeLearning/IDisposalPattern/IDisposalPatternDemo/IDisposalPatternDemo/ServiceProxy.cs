using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IDisposalPatternDemo
{
    // if ServiceProxy doesn't implement IDisposable interface, then using key word will not work for this class
    public class ServiceProxy : IDisposable
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// This property is used to avoid dispose an object over and over again. 
        /// </summary>
        private bool _isDisposed;
        public ServiceProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        public void Get()
        {
            var response = _httpClient.GetAsync("");
        }

        public void Post(string request)
        {
            var response = _httpClient.PostAsync("", new StringContent(request));
        }

        ~ServiceProxy()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            // if we don't include this statement, then the Disposal method will be called multiple times, in this case two, but 
            // this is not what we want. So, if the disposal method has been called already, then we 
            // prevent the finalize method (de-constructor) from calling. 
            GC.SuppressFinalize(this);
        }

        // here we use protected virtual is because we allow the derived class can either override or call
        // the base implementation of Disposal method
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;

            }

            if (disposing)
            {
                // dispose the managed objects;

                _httpClient.Dispose();
            }
            // dispose the unmanaged objects; in this case, the http client object is already
            // internally disposed the unmanaged objects, so we don't have any code here to dispose
            _isDisposed = true;
        }
    }
}
