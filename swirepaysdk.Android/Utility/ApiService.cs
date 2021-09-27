using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using swirepaysdk.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace swirepaysdk.Droid.Utility
{
    class ApiService
    {
        public static IApiInterface getService()
        {
            return DependencyService.Get<IApiInterface>();
        }
    }
}