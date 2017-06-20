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
    public partial class ToolbarItemsPage : ContentPage
    {
        public ToolbarItemsPage()
        {
            InitializeComponent();
        }

        private void tbiAccept_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "Accepted";
        }

        private void tbiCancel_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "Rejected";
        }
    }
}