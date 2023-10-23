using System;
using System.Collections.Generic;

namespace Bozlak_Fatih_Tp1
{
    public class SpaceInvaders
    {
        private readonly List<Player> _players = new List<Player>();

        public SpaceInvaders()
        {
            this.Init();
        }

        public List<Player> Players
        {
            get => _players;
        }

        private void AddPlayerToPlayers(Player player)
        {
            this._players.Add(player);
        }

        private void Init()
        {
            this.AddPlayerToPlayers(new Player("fatih", "bozlak", "bobylatruffe"));
            this.AddPlayerToPlayers(new Player("dupond", "deMarchand", "duPondLeMeilleur"));
            this.AddPlayerToPlayers(new Player("cristiano", "ronaldo", "cr7"));
        }

        public static void Main(string[] args)
        {
            SpaceInvaders spaceInvaders = new SpaceInvaders();

            foreach (Player player in spaceInvaders.Players)
            {
                Console.WriteLine(player);
                Console.WriteLine($"Le joueur {player.Alias} possède le vaisseau {player.Spaceship.Name}");

                Console.WriteLine("\nL'état complet du vaisseau est : ");
                player.Spaceship.ViewShip();

                if (player.Spaceship.Weapons.Count > 0)
                {
                    Console.WriteLine($"\nCe vaisseau possède les armes suivante : ");
                    foreach (Weapon weapon in player.Spaceship.Weapons)
                    {
                        Console.WriteLine(weapon);
                    }
                }

            }
        }
    }
}