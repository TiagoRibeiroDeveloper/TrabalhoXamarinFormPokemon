using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model
{
    public class PokeListResponse
    {
        public string name { get; set; }
        //public Generation generation { get; set; }
        //public DamageRelations damage_relations { get; set; }
        //public List<GameIndice> game_indices { get; set; }
        //public MoveDamageClass move_damage_class { get; set; }
        //public List<Move> moves { get; set; }
        [JsonProperty("pokemon")]
        public List<PokeObject> pokemonObject { get; set; }
        //public int id { get; set; }
        //public List<Name> names { get; set; }
    }
}
