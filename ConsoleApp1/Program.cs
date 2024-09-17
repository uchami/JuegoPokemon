using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pokemon pikachu = new Pokemon(30, TipoPokemon.agua, "Pikachu", 1);
            Pokemon charizard = new Pokemon(15, TipoPokemon.fuego, "Charizard", 1);
            Pokemon blastois = new Pokemon(40, TipoPokemon.tierra, "Blastois", 3);
            List<Pokemon> pokemonesDeUri = new List<Pokemon>();
            pokemonesDeUri.Add(charizard);
            pokemonesDeUri.Add(pikachu);
            pokemonesDeUri.Add(blastois);
            Entrenador uri = new Entrenador(pokemonesDeUri, "Uri");

            Pokemon charmander = new Pokemon(5, TipoPokemon.agua, "Charmander", 5);
            Pokemon miutu = new Pokemon(20, TipoPokemon.fuego, "Miutu", 1);
            List<Pokemon> pokemonesDeGianfranco = new List<Pokemon>();
            pokemonesDeGianfranco.Add(charmander);
            pokemonesDeGianfranco.Add(miutu);
            Entrenador gianfranco = new Entrenador(pokemonesDeGianfranco, "Gianfranco");

            int cantidadDeRounds = 1;
            while (gianfranco.GetPokemonesVivos().Count() > 0 && uri.GetPokemonesVivos().Count() > 0)
            {
                int indiceElegido = ElegirPokemon(gianfranco);
                gianfranco.ElegirPokemon(indiceElegido);
                declararPokemonElegido(gianfranco);

                indiceElegido = ElegirPokemon(uri);
                uri.ElegirPokemon(indiceElegido);
                declararPokemonElegido(uri);

                gianfranco.CombatirRound(uri);

                anunciarResultadosDelRound(cantidadDeRounds, gianfranco, uri);
                cantidadDeRounds++;
            }
            anunciarGanador(uri, gianfranco);
            Console.WriteLine("Toque cualquier tecla para salir..");
            Console.ReadLine();
        }

        static void anunciarResultadosDelRound(int cantidadDeRounds, Entrenador entrenador1, Entrenador entrenador2)
        {
            Console.WriteLine("Round " + cantidadDeRounds + ": terminado.");
            if (entrenador1.GetPokemonElegido().getVidaActual() == 0 && entrenador2.GetPokemonElegido().getVidaActual() == 0)
            {
                //ambos pokemones murieron
                Console.WriteLine("Rayos y centellas! Los pokemones se golpearon mutuamente hasta morir en simultaneo.");
            }
            else if (entrenador1.GetPokemonElegido().getVidaActual() == 0)
            {
                Console.WriteLine("Oh no! El "+ entrenador1.GetPokemonElegido().GetNombre() + " de " + entrenador1.getNombre() + " ha perecido en batalla. ");
            } else
            {
                Console.WriteLine("Caramba! El " + entrenador2.GetPokemonElegido().GetNombre() + " de " + entrenador2.getNombre() + " no pudo con su oponente. ");
            }
            Console.WriteLine("---------------------------");
        }

        static void anunciarGanador(Entrenador entrenador1, Entrenador entrenador2)
        {
            Console.WriteLine("Otra sangrienta batalla llega a su fin:");
            if (entrenador1.GetPokemonesVivos().Count() == 0 && entrenador2.GetPokemonesVivos().Count() == 0)
            {
                Console.WriteLine("Hubo un empate.");
            }
            else if (entrenador2.GetPokemonesVivos().Count() == 0)
            {
                Console.WriteLine("Gano " + entrenador1.getNombre());
            }
            else
            {
                Console.WriteLine("Gano " + entrenador2.getNombre());
            }
        }

        static void declararPokemonElegido(Entrenador entrenador)
        {
            Console.WriteLine(entrenador.getNombre() + " eligio a su apreciadisimo " +
                    entrenador.GetPokemonElegido().GetNombre());
        }
        static int ElegirPokemon(Entrenador entrenador)
        {
            Console.WriteLine(entrenador.getNombre() + "! Estos son sus pokemones:");
            List<Pokemon> pokemones = entrenador.GetPokemones();
            for (int i = 0; i < pokemones.Count(); i++)
            {
                Console.WriteLine(i + ": " + pokemones[i].toString());
            }
            int indiceElegido = -1;
            do
            {
                if(indiceElegido != -1)
                {
                    Console.WriteLine("Ups! Ese no esta vivo! Elija un pokemon vivo: ");
                } else
                {
                    Console.WriteLine("Elija un pokemon vivo: ");
                }
                Int32.TryParse(Console.ReadLine(), out indiceElegido);
            }
            while(indiceElegido >= pokemones.Count() || pokemones[indiceElegido].getVidaActual() == 0);
            
            return indiceElegido;
        }
    }
}
