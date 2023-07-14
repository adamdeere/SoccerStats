namespace UtilityLibraries
{
    public abstract class BaseHttpService : IDisposable
    {
        protected readonly HttpClient _httpClient;

        public BaseHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual void Dispose()
        {
            _httpClient?.Dispose();
        }

        protected bool ClientStatus()
        {
            return _httpClient != null;
        }
    }
}