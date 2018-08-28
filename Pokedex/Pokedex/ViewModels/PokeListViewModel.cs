using Pokedex.Model;
using Pokedex.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class PokeListViewModel: BaseViewModel
    {
        public ObservableCollection<Pokemon> Pokemons { get; set; } = new ObservableCollection<Pokemon>();
        public ICommand ItemClickCommand { get; set; }

        public PokeListViewModel()
        {
            ItemClickCommand = new Command<Pokemon>(async (item) => await ItemClick(item));
        }

        public async Task LoadData(PokeType type)
        {
            IsLoading = true;
            var pokemons = await Api.GetAllPokemonsFromType(type.url);

            Pokemons.Clear();

            foreach (var p in pokemons)
            {
                Pokemons.Add(p);
            }
            IsLoading = false;
        }

        async Task ItemClick(Pokemon poke)
        {
            var detailPage = new DetailPage(poke);
            await Navigation.PushAsync(detailPage);
            //var pokePage = new PokemonList(type);
            //await Navigation.PushAsync(pokePage);
        }
    }
}
