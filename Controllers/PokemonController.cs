using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace PokeApp_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {       
        private readonly ILogger<PokemonController> _logger;
        private readonly IMemoryCache _pokemonListCache;

        public PokemonController(ILogger<PokemonController> logger, IMemoryCache pokemonListCache)
        {
            _logger = logger;
            _pokemonListCache = pokemonListCache;
        }
                        
        [HttpGet]
        public Pokemons Get()
        {
            if(!_pokemonListCache.TryGetValue("ListOfPokemon", out Pokemons pokemons))
            {
                pokemons = JsonConvert.DeserializeObject<Pokemons>(System.IO.File.ReadAllText(@"C:\Users\w505563\Desktop\PokeApp_Backend\Pokemon.json"));                
                _pokemonListCache.Set("ListOfPokemon", pokemons, TimeSpan.FromSeconds(3600));
            }
            pokemons.count = pokemons.results.Count();
            return pokemons;
        }

        [HttpGet]
        [Route("{id:int}")]
        public Pokemon Get(int id)
        {
            var pkm = (Pokemons)_pokemonListCache.Get("ListOfPokemon");
            pkm.count = pkm.results.Count();
            return pkm.results.FirstOrDefault(p => p.id == id);
        }

        [HttpGet]
        [Route("{nome:alpha}")]
        public Pokemon Get(string nome)
        {
            var pkm = (Pokemons)_pokemonListCache.Get("ListOfPokemon");
            pkm.count = pkm.results.Count();
            return pkm.results.FirstOrDefault(p => p.name == nome);
        }

        [HttpDelete("{id}")]
        public Pokemons Delete(int id)
        {
            var pkm = (Pokemons)_pokemonListCache.Get("ListOfPokemon");
            pkm.results.RemoveAll(pk => pk.id == id);
            pkm.count = pkm.results.Count();
            _pokemonListCache.Set("ListOfPokemon", pkm, TimeSpan.FromSeconds(3600));
            return pkm;
        }

        [HttpPost]
        public Pokemons Add([FromBody] Pokemon pokemon)
        {
            var pkm = (Pokemons)_pokemonListCache.Get("ListOfPokemon");
            pkm.results.Add(pokemon);
            pkm.count = pkm.results.Count();
            _pokemonListCache.Set("ListOfPokemon", pkm, TimeSpan.FromSeconds(3600));
            return pkm;
        }

    }
}
