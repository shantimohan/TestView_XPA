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
    public partial class DatePickerPage : ContentPage
    {
        DateTime dateSelected;

        public DatePickerPage()
        {
            InitializeComponent();
        }

        private void dpMyDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            dateSelected = dpMyDate.Date;
        }
    }
}