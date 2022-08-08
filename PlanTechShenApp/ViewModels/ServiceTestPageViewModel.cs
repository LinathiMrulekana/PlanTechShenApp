using PlanTechShenApp.Services.Interface;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanTechShenApp.ViewModels
{
   
        public class ServiceTestPageViewModel : BindableBase
        {
            private IAuthentication _authentication;

            private DelegateCommand _testCommand;
            public DelegateCommand TestCommand =>
                _testCommand ?? (_testCommand = new DelegateCommand(ExecuteTestCommand));

            void ExecuteTestCommand()
            {
                _authentication.Authenticate("hello", "1234");
            }

            public ServiceTestPageViewModel(IAuthentication authentication)
            {
                _authentication = authentication;
            }
        }
}
