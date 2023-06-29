using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        private string units = "imperial";
        public string Units
        {
            get { return units; }
            set
            {
                units = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsImperial));
                OnPropertyChanged(nameof(IsMetric));
                OnPropertyChanged(nameof(IsHybrid));
                OnPropertyChanged(nameof(Temperature));
            }
        }


        public string Temperature => IsImperial ? "70˚F" : "21˚C";

        public bool IsImperial => units == "imperial";

        public bool IsMetric => units == "metric";

        public bool IsHybrid => units == "hybrid";

        public Command SelectUnits { get; set; }

        public SettingsViewModel()
        {
            SelectUnits = new Command<string>(OnSelectUnits);
        }

        private void OnSelectUnits(string unit)
        {
            Units = unit;
        }
    }
}
