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
    public partial class SwitchViewPage : ContentPage
    {
        public SwitchViewPage()
        {
            InitializeComponent();
        }

        private void swiMySwitch_Toggled(object sender, ToggledEventArgs e)
        {
            lblSwitchStatus.Text = String.Format("Switch is set to {0}", e.Value);
        }
    }
}