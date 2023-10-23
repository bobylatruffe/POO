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

        //TODO enlever les commentaires
        /*public static void Main(string[] args)
        {
            SpaceInvaders spaceInvaders = new SpaceInvaders();

            foreach (Player player in spaceInvaders.Players)
            {
                Console.WriteLine(player);
            }
        }*/
    }
}