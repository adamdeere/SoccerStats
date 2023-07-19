namespace UtilityLibraries
{
    /// <summary>
    /// can be used for logging purposes
    /// </summary>
    static class HttpResponseMessageExtensions
    {
        internal static void LogRequestToConsole(this HttpResponseMessage response)
        {
            if (response is null)
            {
                return;
            }

            var request = response.RequestMessage;
            Console.Write($"{request?.Method} ");
            Console.Write($"{request?.RequestUri} ");
            Console.WriteLine($"HTTP/{request?.Version}");
        }
    }
}
