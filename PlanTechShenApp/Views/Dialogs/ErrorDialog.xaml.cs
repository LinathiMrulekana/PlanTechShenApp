using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanTechShenApp.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorDialog : Frame
    {
        public ErrorDialog()
        {
            InitializeComponent();
        }
    }
}