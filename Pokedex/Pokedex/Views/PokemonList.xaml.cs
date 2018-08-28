using Pokedex.Model;
using Pokedex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PokemonList : ContentPage
	{

        public PokeListViewModel ViewModel
        {
            get
            {
                if (BindingContext == null)
                    BindingContext = new PokeListViewModel();

                return (BindingContext as PokeListViewModel);
            }
        }

        public PokeType type { get; set; }

        public PokemonList (PokeType type)
		{
			InitializeComponent ();
            this.type = type;
            Title = type.name;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.LoadData(this.type);
        }
    }
}