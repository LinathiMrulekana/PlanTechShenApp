using System.Net.Http;

namespace PlanTechShenApp.Services
{
    public interface IHttpNativeHandler
    {
        HttpClientHandler GetHttpClientHandler();
    }
}