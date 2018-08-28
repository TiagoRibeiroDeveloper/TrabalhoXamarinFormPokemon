using Pokedex.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.ViewModels
{
    public class DetailViewModel: BaseViewModel
    {
        public string name = "";
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        public string weight = "";
        public string Weight { get { return weight; } set { weight = value; OnPropertyChanged(); } }
        public string height = "";
        public string Height { get { return height; } set { height = value; OnPropertyChanged(); } }

        public async Task LoadData(Pokemon poke)
        {
            var details = await Api.GetPokeDetails(poke.url);
            Name = $"Name: {details.name}";
            Weight = $"Weight: {details.weight}";
            Height = $"Height: {details.height}";
        }
    }
}
