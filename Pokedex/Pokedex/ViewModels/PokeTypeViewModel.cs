using Pokedex.Model;
using Pokedex.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class PokeTypeViewModel: BaseViewModel
    {
       
        public ObservableCollection<PokeType> PokeTypes { get; set; } = new ObservableCollection<PokeType>();

        public ICommand ItemClickCommand { get; set; }

        public PokeTypeViewModel()
        {
            ItemClickCommand = new Command<PokeType>(async (item) => await ItemClick(item));
        }

        public async Task LoadData()
        {
            IsLoading = true;
            var types = await Api.GetAllPokeTypes();
            PokeTypes.Clear();
            
            foreach (var type in types)
            {
                PokeTypes.Add(type);
            }
            IsLoading = false;
        }

        async Task ItemClick(PokeType type)
        {
            var pokePage = new PokemonList(type);
            await Navigation.PushAsync(pokePage);
        }
    }
}