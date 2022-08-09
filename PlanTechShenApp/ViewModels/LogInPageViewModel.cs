using PlanTechShenApp.Helper;
using PlanTechShenApp.Helper.Validations;
using PlanTechShenApp.Helper.Validations.Rules;
using PlanTechShenApp.Models;
using PlanTechShenApp.Services.Interface;
using PlanTechShenApp.Views.Dialogs;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using Xamarin.CommunityToolkit.UI.Views;

namespace PlanTechShenApp.ViewModels
{
    public class SignInPageViewModel : ViewModelBase
    {
        private IAuthentication _authenticationService;
        private IDialogService _dialogService;
        private IEventAggregator _eventAggregator;

        private IDataCache _dataCache;

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

      
        public ValidatableObject<string> Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }



        private DelegateCommand _LoginCommand;
        public DelegateCommand LoginCommand =>
            _LoginCommand ?? (_LoginCommand = new DelegateCommand(ExecuteLoginCommand));

        private async void ExecuteLoginCommand()
        {
            try
            {
                MainState = LayoutState.Loading;
                if (ValidateLoginData())
                {
                    var authResponse = await _authenticationService.Authenticate(Email.Value, Password.Value);

                    if (authResponse.Authenticated)
                    {
                        ClearAuthData();


                        // TODO set login state

                        _dataCache.IsAuthenticated = true;
                        _dataCache.AuthenticatedCustomer = authResponse.AuthenticatedUserAccount;


                        await NavigationService.NavigateAsync("myapp:///NavigationPage/HomePage");

                    }
                    else
                    {
                        var param = new DialogParameters()
                        {
                            { "message", Constant.Errors.WrongUserOrPinError }
                        };
                        _dialogService.ShowDialog(nameof(ErrorDialog), param);
                    }
                }
            }
            catch (Exception ex)
            {
                var param = new DialogParameters()
                {
                    { "message", Constant.Errors.GeneralError }
                };
                _dialogService.ShowDialog(nameof(ErrorDialog), param);
            }
            finally
            {
                MainState = LayoutState.None;
            }
        }

        private DelegateCommand<string> _validateCommand;
        public DelegateCommand<string> ValidateCommand =>
            _validateCommand ?? (_validateCommand = new DelegateCommand<string>(ExecuteValidateCommand));

        private void ExecuteValidateCommand(string field)
        {
            switch (field)
            {
                case "email": Email.Validate(); break;
                case "password": Password.Validate(); break;
            }
        }

        private DelegateCommand _resetCommand;
        public DelegateCommand ResetCommand =>
            _resetCommand ?? (_resetCommand = new DelegateCommand(ExecuteResetCommand));

        void ExecuteResetCommand()
        {

        }

        private DelegateCommand _switchToSignUpCommand;
        private ValidatableObject<string> _password;

        public DelegateCommand SwitchToSignUpCommand =>
            _switchToSignUpCommand ?? (_switchToSignUpCommand = new DelegateCommand(ExecuteSwitchToSignUpCommand));

        private async void ExecuteSwitchToSignUpCommand()
        {
            await NavigationService.NavigateAsync("HomePage");
        }

        public SignInPageViewModel(INavigationService navigationService, IDialogService dialogService,
            IEventAggregator eventAggregator, IAuthentication authentication, IDataCache dataCache) : base(navigationService)
        {
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;

            _authenticationService = authentication;

            _dataCache = dataCache;

            AddValidations();

        }

        public override void Initialize(INavigationParameters parameters)
        {
            Title = "Login";

        }




        private void AddValidations()
        {
            Email = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A email is required." });
            Email.Validations.Add(new IsEmailRule<string> { ValidationMessage = "Email format is not correct" });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A pin is required." });
        }

        private bool ValidateLoginData()
        {
            Email.Validate(true);
            Password.Validate(true);

            if (Email.IsValid == false ||
                Password.IsValid == false)
                return false;
            return true;
        }

        private void ClearAuthData()
        {
            Email.Value = Password.Value = string.Empty;
        }


    }
}

