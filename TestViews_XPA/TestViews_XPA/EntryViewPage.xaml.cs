using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// This validates only for the fixed username and passwords
//    to validate both valid and invalid cases. This doesn't access
//    any external authentication sites. This is only to test the
//    Entry and not to test authentication as such.

namespace TestViews_XPA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryViewPage : ContentPage
    {
        public EntryViewPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            btnLogin.IsEnabled = false;

            entUserName.Text = entUserName.Text.ToLower();
            entPassword.Text = entPassword.Text.ToLower();

            if ((entUserName.Text == "asdfg" && entPassword.Text == "qwerty")
                || (entUserName.Text == "zxcvb" && entPassword.Text == "12345"))
            {
                lblLoginResult.Text = "Login Validated";
                lblLoginResult.TextColor = Color.DarkGreen;
                lblLoginResult.FontAttributes = FontAttributes.Bold;
            }
            else
            {
                lblLoginResult.Text = "Invalid Login";
                lblLoginResult.TextColor = Color.DarkRed;

                btnLogin.IsEnabled = true;
            }
        }
    }
}