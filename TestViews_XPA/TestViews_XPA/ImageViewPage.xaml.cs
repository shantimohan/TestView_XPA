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
    public partial class ImageViewPage : ContentPage
    {
        string strImageUri = "";

        public ImageViewPage()
        {
            InitializeComponent();

            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    strImageUri = "Default.png";
                    break;
                case Device.Android:
                    strImageUri = "icon.png";
                    break;
            }
            imgMyImage.Source = strImageUri;
        }

        private void btnTranslateImage_Clicked(object sender, EventArgs e)
        {
            imgMyImage.TranslationX = 50;
            imgMyImage.TranslationY = 50;
        }
    }
}