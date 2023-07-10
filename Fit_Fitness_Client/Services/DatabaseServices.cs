
using RestSharp;
using Microsoft.Maui.Controls;

namespace Fit_Fitness_Client.Services
{

    public static class DatabaseServices
    {
        private static RestClient _restClient = new RestClient();

        public static RestResponse<TResponse> PostData<TRequest, TResponse>(string apiUrl, object obj)
            where TRequest : class
            where TResponse : class, new()

        {
            var request = new RestRequest(apiUrl, Method.Post).AddJsonBody(obj);

            var response = _restClient.Execute<TResponse>(request);
            Console.WriteLine(response.ToString());
            if (response.IsSuccessful)
            {
                return response;
            }
            else
            {// Handle error response

                // Return a default or empty response to avoid crashing the app
                return default;
            }

        }
        //get 'all'
        public static RestResponse<List<TResponse>> GetData<TRequest, TResponse>(string apiUrl)
        where TRequest : class
        where TResponse : class, new()
        {
            var request = new RestRequest(apiUrl, Method.Get);

            var response = _restClient.Execute<List<TResponse>>(request);
            if (response.IsSuccessful)
            {
                return response;
            }
            else
            {
                return default;
            }

        }
        public static RestResponse<TResponse> DeleteData<TRequest, TResponse>(string apiUrl)
        where TRequest : class
        where TResponse : class, new()
        {
            var request = new RestRequest(apiUrl, Method.Delete);

            var response = _restClient.Execute<TResponse>(request);
            if (response.IsSuccessful)
            {
                return response;
            }
            else
            {
                return default;
            }

        }
        public static RestResponse<TResponse> UpdateData<TRequest, TResponse>(string apiUrl, object body)
        where TRequest : class
        where TResponse : class, new()
        {
            var request = new RestRequest(apiUrl, Method.Put).AddJsonBody(body);

            var response = _restClient.Execute<TResponse>(request);
            if (response.IsSuccessful)
            {
                return response;
            }
            else
            {
                return default;
            }

        }

        public static RestResponse<TResponse> AddClassToClient<TRequest, TResponse>(string apiUrl)
        where TRequest : class
        where TResponse : class, new()
        {
            var request = new RestRequest(apiUrl, Method.Post);

            var response = _restClient.Execute<TResponse>(request);
            if (response.IsSuccessful)
            {
                return response;
            }
            else
            {
                return default;
            }

        }
        public static RestResponse<TResponse> UpdateEnrollment<TRequest, TResponse>(string apiUrl)
        where TRequest : class
        where TResponse : class, new()
        {
            var request = new RestRequest(apiUrl, Method.Put);

            var response = _restClient.Execute<TResponse>(request);
            if (response.IsSuccessful)
            {
                return response;
            }
            else
            {
                return default;
            }

        }

    }
}
