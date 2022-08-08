﻿using PlanTechShenApp.Helper.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace PlanTechShenApp.Helper.Validations
{
    public class ValidatableObject<T> : ExtendedBindableObject, IValidaty
    {
        private readonly List<IValidationRule<T>> _validations;
        private List<string> _errors;
        private T _value;
        private bool _isValid;
        private bool _isButtonActive;
        private bool _isFirstTime;

        public List<IValidationRule<T>> Validations => _validations;

        public List<string> Errors
        {
            get => _errors;
            set
            {
                _errors = value;
                RaisePropertyChanged(() => Errors);
            }
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public bool IsButtonActive
        {
            get => _isButtonActive;
            set
            {
                _isButtonActive = value;
                RaisePropertyChanged(() => IsButtonActive);
            }
        }

        public ValidatableObject()
        {
            _isValid = true;
            _isButtonActive = false;
            _isFirstTime = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate(bool force = false)
        {
            Errors.Clear();

            if (_isFirstTime && !force)
            {
                _isFirstTime = false;
                IsValid = true;
                IsButtonActive = false;
            }
            else
            {
                IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                    .Select(v => v.ValidationMessage);

                Errors = errors.ToList();
                IsValid = !Errors.Any();
                IsButtonActive = !Errors.Any();
            }

            return IsValid;
        }
    }
}