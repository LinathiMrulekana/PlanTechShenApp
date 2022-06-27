using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlanTechShenApp
{
    public class Plant : INotifyPropertyChanged
    {
        private string _name;
        private string _neighbours;
       

        public event PropertyChangedEventHandler PropertyChanged;


        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;

                OnPropertyChanged();
            }
        }
        public Plant( string name,  string neighbours)
        {
            
            _name = name;
            _neighbours = neighbours;
          
        }
        public Plant()
        {
            
            this._name = "Ford";

            Console.WriteLine("");
        }
        public string Neighbours
        {
            get
            {
                return _neighbours;
            }

            set
            {
                _neighbours = value;

                OnPropertyChanged();
            }
        }
        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
        public string GetNeighbours()
        {
            return _neighbours;
        }

        public void SetNeighbours(string neighbours)
        {
            _neighbours = neighbours;
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
