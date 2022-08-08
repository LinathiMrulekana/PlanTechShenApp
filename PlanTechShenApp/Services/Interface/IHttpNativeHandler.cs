using System.Net.Http;

namespace PlanTechShenApp.Services.Interface
{
    public interface IHttpNativeHandler
    {
        HttpClientHandler GetHttpClientHandler();
    }
}