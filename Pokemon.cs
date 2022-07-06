using System;
using System.Collections.Generic;

namespace PokeApp_Backend
{
    public class Pokemons
    {
        public List<Pokemon> results { get; set; }
        public int count { get; set; }
        public string next  { get; set; }
        public string previous  { get; set; }
    }

    public class Pokemon
    {
        public string url { get; set;}
        public List<Ability> abilities { get; set; }
        public int height { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public Sprites sprites { get; set; }
        public List<Type> types { get; set; }
        public int weight { get; set; }
    }

    public class Ability
    {
        public AbilityDetail ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }

    public class AbilityDetail
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    
    public class DreamWorld
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
    }

    public class Home
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }

    public class Other
    {
        public DreamWorld dream_world { get; set; }
        public Home home { get; set; }
    }

    public class Sprites
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
        public Other other { get; set; }
    }

    public class Type
    {
        public int slot { get; set; }
        public TypeDetail type { get; set; }
    }

    public class TypeDetail
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
