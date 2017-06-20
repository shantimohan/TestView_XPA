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
    public partial class StepperViewPage : ContentPage
    {
        public StepperViewPage()
        {
            InitializeComponent();
        }

        private void stpMyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblStepperValue.Text = String.Format("Stepper value is {0:F1}", e.NewValue);
        }
    }
}