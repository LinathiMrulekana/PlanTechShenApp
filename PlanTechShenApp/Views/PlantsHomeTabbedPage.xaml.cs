using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanTechShenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantsHomeTabbedPage : TabbedPage
    {
        public PlantsHomeTabbedPage()
        {
            InitializeComponent();

            Children.Add(new PlantListPage());
            Children.Add(new TipsPage());
            Children.Add(new CommunityPage());

        }
    }
}