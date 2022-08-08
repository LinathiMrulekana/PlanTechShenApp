using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanTechShenApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        
     
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            Title = "Sign Up";
        }

    }
}

