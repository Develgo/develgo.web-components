using Microsoft.AspNetCore.Http;

namespace Develgo.WebUi
{
    public static class RequestExtensions
    {
        public static string UrlFrom(this HttpRequest request, string relativePath)
        {
            var path = relativePath.StartsWith('/') ? relativePath : $"/{relativePath}";
            return $"{request.Scheme}://{request.Host}{request.PathBase}{path}";
        }
    }
}
