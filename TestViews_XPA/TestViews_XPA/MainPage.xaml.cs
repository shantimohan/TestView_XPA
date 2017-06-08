using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestViews_XPA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnActivityIndicator_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ActivityIndicatorPage());
        }

        private void btnBoxView_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new BoxViewPage());
        }
    }
}
