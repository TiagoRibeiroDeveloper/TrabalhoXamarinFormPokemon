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
	public partial class DetailPage : ContentPage
	{
        public Pokemon pokemon { get; set; }

        public DetailViewModel ViewModel
        {
            get
            {
                if (BindingContext == null)
                    BindingContext = new DetailViewModel();

                return (BindingContext as DetailViewModel);
            }
        }

        public DetailPage (Pokemon pokemon)
		{
			InitializeComponent ();
            this.pokemon = pokemon;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.LoadData(this.pokemon);
        }
    }
}