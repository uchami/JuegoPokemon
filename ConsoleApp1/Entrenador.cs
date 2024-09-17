using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Entrenador
    {
        List<Pokemon> Pokemones;
        string Nombre;
        Pokemon PokemonElegido;

        public Entrenador(List<Pokemon> pokemones,
        string nombre)
        {
            Pokemones = pokemones;
            Nombre = nombre;
        }

        public void ElegirPokemon(int indice)
        {
            PokemonElegido = Pokemones[indice];
        }

        public Pokemon GetPokemonElegido() {
            return PokemonElegido;
        }

        public void CombatirRound(Entrenador oponente)
        {
            // verificar que ambos elegimos pokemon, si no error.
            Pokemon pokemonOponente = oponente.GetPokemonElegido();

            while (pokemonOponente.getVidaActual() > 0 && PokemonElegido.getVidaActual() > 0) {
                int danioOponente = pokemonOponente.calcularDanio(PokemonElegido);
                int danioMio = PokemonElegido.calcularDanio(pokemonOponente);
                pokemonOponente.bajarVida(danioMio);
                PokemonElegido.bajarVida(danioOponente);
            }
        }
        public List<Pokemon> GetPokemonesVivos() {
            List<Pokemon> vivos = new List<Pokemon>();
            for (int i = 0; i < Pokemones.Count; i++)
            {
                if(Pokemones[i].getVidaActual() > 0)
                {
                    vivos.Add(Pokemones[i]);
                }
            }
            return vivos;
        }

        public List<Pokemon> GetPokemones()
        {
            return Pokemones;
        }

        public string getNombre ()
        {
            return Nombre; 
        }
    }
}
