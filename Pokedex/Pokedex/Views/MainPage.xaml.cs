using Pokedex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokedex
{
	public partial class MainPage : ContentPage
	{

        public PokeTypeViewModel ViewModel
        {
            get
            {
                if (BindingContext == null)
                    BindingContext = new PokeTypeViewModel();

                return (BindingContext as PokeTypeViewModel);
            }
        }

        public MainPage()
		{
			InitializeComponent();
            Title = "PokeDEX";
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.LoadData();
        }

    }
}
