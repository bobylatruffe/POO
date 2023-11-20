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

            Armory armory = new Armory();
            Console.WriteLine("Voici les armes disponnible : ");
            armory.ViewArmory();

            foreach (Player player in spaceInvaders.Players)
            {
                Console.WriteLine(player);
                Console.WriteLine($"\nLe joueur {player.Alias} possède le vaisseau {player.Spaceship.Name}");

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

            Console.WriteLine("\nTentative d'ajouter une arme n'étant pas l'armerie : ");
            try
            {
                spaceInvaders.Players[0].Spaceship
                    .AddWeapon(new Weapon("IMOPOSSIBLE_WEAPON", 0, 100, EWeaponType.Direct, 2), armory);
            }
            catch (ArmoryException e)
            {
                Console.WriteLine(e.Message);
            }

            Weapon w = new Weapon("Laser", 2, 3, EWeaponType.Direct, 2);
            armory.AddWeapon(w);
            Console.WriteLine("\nLaser");
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());


            w = new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 2);
            armory.AddWeapon(w);
            Console.WriteLine("\nHammer");
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());

            w = new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2);
            armory.AddWeapon(w);
            Console.WriteLine("\nTorpille");
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());

            w = new Weapon("Misille", 4, 100, EWeaponType.Direct, 0);
            armory.AddWeapon(w);
            Console.WriteLine("\nMissile");
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());
            Console.WriteLine(w.Shoot());

            // Spaceship spaceship1 = new Spaceship(100, 100, "spaceship1");
            // Spaceship spaceship2 = new Spaceship(100, 100, "spaceship2");
            //
            // spaceship1.AddWeapon(w, armory);
            // spaceship1.AddWeapon(w, armory);
            // spaceship2.AddWeapon(w, armory);
            //
            // spaceship1.ViewShip();
            // spaceship2.ViewShip();
            //
            // spaceship1.ShootTarget(spaceship2);
            // spaceship1.ViewShip();
            // spaceship2.ViewShip();


        }
    }
}