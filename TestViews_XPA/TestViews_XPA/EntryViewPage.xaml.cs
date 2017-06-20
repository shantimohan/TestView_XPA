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