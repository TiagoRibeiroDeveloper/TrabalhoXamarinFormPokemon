using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model
{
    class TypeResponse
    {
        public int count { get; set; }
        public object previous { get; set; }
        public List<PokeType> results { get; set; }
        public object next { get; set; }
    }
}
