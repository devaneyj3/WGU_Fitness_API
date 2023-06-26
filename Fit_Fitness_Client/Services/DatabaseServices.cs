using RestSharp;

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
            if (response.IsSuccessful)
            {
                return response;
            }
            else
            {
                // Handle error response
                throw new Exception($"API request failed with status code: {response.StatusCode}");
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
                // Handle error response
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
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
                // Handle error response
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
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
                // Handle error response
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                return default;
            }

        }

    }
}
