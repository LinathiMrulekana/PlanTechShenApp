using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PlanTechShenApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlanTechShenApp.Droid.Services.NoSslAndroidHandler))]
namespace PlanTechShenApp.Droid.Services
{
    public class NoSslAndroidHandler : IHttpNativeHandler
    {
        public HttpClientHandler GetHttpClientHandler()
        {
            return new IgnoreSSLClientHandler();
        }
    }
}