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
    public partial class SearchBarPage : ContentPage
    {
        public SearchBarPage()
        {
            InitializeComponent();

            sbMySearchBar.SearchCommand = new Command(() => { lblResults.Text = "Result: " + sbMySearchBar.Text + " is what you asked for."; });

        }
    }
}