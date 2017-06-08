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
    public partial class BoxViewPage : ContentPage
    {
        public BoxViewPage()
        {
            InitializeComponent();
        }

        private void bvMyBox_Focused(object sender, FocusEventArgs e)
        {
            bvMyBox.Color = Color.Beige;
        }

        private void bvMyBox_Unfocused(object sender, FocusEventArgs e)
        {
            bvMyBox.Color = Color.Red;
        }

        private void btnChangeColor1_Clicked(object sender, EventArgs e)
        {
            bvMyBox.Color = Color.Green;
        }

        private void btnChangeColor2_Clicked(object sender, EventArgs e)
        {
            bvMyBox.Color = Color.Red;
        }
    }
}