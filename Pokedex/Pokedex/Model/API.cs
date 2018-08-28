using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model
{
    public class API
    {
        readonly string BaseURL = "http://pokeapi.co/api/v2";

        public async Task<List<PokeType>> GetAllPokeTypes()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                //grab json from server
                var json = await client.GetStringAsync($"{BaseURL}/type");

                //Deserialize json
                var items = JsonConvert.DeserializeObject<TypeResponse>(json);
                Debug.Print($"Count: {items.count}");
                //return the items
                return items.results;
            }
        }

        public async Task<List<Pokemon>> GetAllPokemonsFromType(string url)
        {
            Debug.Print($"URL: {url}");
            using (var client = new System.Net.Http.HttpClient())
            {
                var json = await client.GetStringAsync(url);
                var items = JsonConvert.DeserializeObject<PokeListResponse>(json);
                List<Pokemon> pokeList = items.pokemonObject.Select(p => p.pokemon).ToList();
                Debug.Print($"PokeListCount: {pokeList.Count}");

                return pokeList;

            }
        }

        public async Task<DetailResponse> GetPokeDetails(string url)
        {
            Debug.Print($"URL: {url}");
            using (var client = new System.Net.Http.HttpClient())
            {
                var json = await client.GetStringAsync(url);
                var response = JsonConvert.DeserializeObject<DetailResponse>(json);
                Debug.Print($"NAMEEE: {response.name}");


                return response;

            }
        }


    }
}
