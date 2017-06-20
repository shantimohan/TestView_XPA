using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestViews_XPA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityIndicatorPage : ContentPage
    {
        public ActivityIndicatorPage()
        {
            InitializeComponent();
        }

        private void btnStartActivity_Clicked(object sender, EventArgs e)
        {
            btnStartActivity.IsEnabled = false;
            busyIndicator.IsRunning = true;
            btnStopActivity.IsEnabled = true;
        }

        private void btnStopActivity_Clicked(object sender, EventArgs e)
        {
            btnStopActivity.IsEnabled = false;
            busyIndicator.IsVisible = false;
            btnStartActivity.IsEnabled = true;
        }
    }
}