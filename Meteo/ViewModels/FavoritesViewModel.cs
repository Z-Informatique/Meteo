using Meteo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.ViewModels
{
    public class FavoritesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        IWeatherService weatherService = new WeatherService(null);

        private ObservableCollection<Services.Location> favorites;
        public ObservableCollection<Services.Location> Favorites
        {
            get
            {
                return favorites;
            }

            set
            {
                favorites = value;
                OnPropertyChanged();
            }
        }

        //Cette fonction récupère la liste des localisation afin de permettre la mise à jour des favorites
        async void Fetch()
        {
            var locations = await weatherService.GetLocations(string.Empty);
            //Mise à jour des favorites après récupération des locations
            UpdateFavorites(locations);

            OnPropertyChanged(nameof(Favorites));
        }
        //Cette fonction permet de mettre à jour la liste des favorites pour la page Favorites
        private void UpdateFavorites(IEnumerable<Services.Location> locations)
        {
            favorites = new ObservableCollection<Services.Location>();
            //Boucle permettant de rajouter une location à nos favorites suivant le principe de décrémentation (i--)
            for (int i = locations.Count() - 1; i >= 0; i--)
            {
                favorites.Add(locations.ElementAt(i));
            }
        }

        public FavoritesViewModel()
        {
            //Appel de la fonction Fecth pour charger la liste de éléments de la page Favorites
            Fetch();
        }
    }
}
