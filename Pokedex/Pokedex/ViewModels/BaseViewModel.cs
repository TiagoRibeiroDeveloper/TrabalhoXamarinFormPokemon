using Pokedex.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class BaseViewModel: BindableObject
    {
        public INavigation Navigation => Application.Current.MainPage.Navigation;
        public API Api => new API();
        public bool isLoading = false;
        public bool IsLoading { get { return isLoading; } set { isLoading = value; OnPropertyChanged(); } }
    }
}
