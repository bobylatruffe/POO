using System;
using System.Collections.Generic;

namespace Bozlak_Fatih_Tp1
{
    public class SpaceInvaders
    {
        private readonly List<Player> _players = new List<Player>();

        private List<Spaceship> _ennemis = new List<Spaceship>();

        private Spaceship PlayerSpaceShip { get; set; }

        public SpaceInvaders()
        {
            this.Init();
        }

        public List<Player> Players
        {
            get => _players;
        }

        public List<Spaceship> Ennemis
        {
            get => this._ennemis;
        }

        private void AddPlayerToPlayers(Player player)
        {
            this._players.Add(player);
        }

        private void Init()
        {
            this._ennemis.Add(new Dart("DartVaisseau"));
            this._ennemis.Add(new Rocinante("RocinanteVaissau"));
            this._ennemis.Add(new ViperMKII("ViperMKIIVaisseau"));
            this._ennemis.Add(new Tardis("F18Vaisaiu"));

            Spaceship spaceshipForPlayer = new BWings("BWingsOfPlayer");
            spaceshipForPlayer.Player = new Player("Fatih", "Bozlak", "bobylatruffe");

            this.PlayerSpaceShip = spaceshipForPlayer;
        }

        private void checkVaisseauxRestant()
        {
            List<Spaceship> newSpaceships = new List<Spaceship>();

            foreach (Spaceship spaceship in this._ennemis)
            {
                if (!spaceship.IsDestroyed)
                {
                    newSpaceships.Add(spaceship);
                }
            }

            this._ennemis = newSpaceships;

            if (this.PlayerSpaceShip.CurrentStructure <= 0)
                this.PlayerSpaceShip = null;
        }

        private int PlayRound()
        {
            Console.WriteLine($"Les ennemis attaquent le joueur ... il y'a {this._ennemis.Count} ennemis");
            foreach (Spaceship spaceship in Ennemis)
            {
                Console.WriteLine(spaceship.Name + " attaque ...");
                spaceship.ShootTarget(PlayerSpaceShip);

                Console.WriteLine("L'état de ton vaisseau mec : ");
                PlayerSpaceShip.ViewShip();
            }

            this.checkVaisseauxRestant();

            if (this._ennemis.Count == 0)
                return 1;
            if (this.PlayerSpaceShip == null)
                return 2;

            int quiAttaquerIndex = new Random().Next(0, this._ennemis.Count);
            Console.WriteLine("Le joueur attaque au hassard ..." + this._ennemis[quiAttaquerIndex].Name);

            this.PlayerSpaceShip.ShootTarget(this._ennemis[quiAttaquerIndex]);

            Console.WriteLine("Voici l'état de son vaisseau : ");
            this.PlayerSpaceShip.ViewShip();

            return 0;
        }

        public static void Main(string[] args)
        {
            SpaceInvaders spaceInvaders = new SpaceInvaders();

            Console.WriteLine("Bienvenu dans mon super jeu ...");
            Console.WriteLine("Voici les vaisseaux de la partie : \n");
            foreach (Spaceship spaceship in spaceInvaders.Ennemis)
            {
                spaceship.ViewShip();
                spaceship.ViewWeapons();
                Console.WriteLine("");
            }

            Console.WriteLine(
                "Plus tard, peut-être un jour, tu pourras choisir ton vaisseau, mais la dans l'immédiat c'est le magnifique BWings");
            spaceInvaders.PlayerSpaceShip.ViewShip();
            spaceInvaders.PlayerSpaceShip.ViewWeapons();
            Console.WriteLine("\n\n");

            bool gagant = false;
            while (!gagant)
            {
                int resultat = spaceInvaders.PlayRound();
                switch (resultat)
                {
                    case 1:
                        Console.WriteLine("Félication au joueur !");
                        gagant = true;
                        break;
                    case 2:
                        Console.WriteLine("Le joueur à perdu !");
                        gagant = true;
                        break;
                }
            }
        }

        /* Name juste pour tester en même temps que le code ... */
        // public static void Main(string[] args)
        // {
        //     SpaceInvaders spaceInvaders = new SpaceInvaders();
        //
        //     Armory armory = new Armory();
        //     Console.WriteLine("Voici les armes disponnible : ");
        //     armory.ViewArmory();
        //
        //     foreach (Player player in spaceInvaders.Players)
        //     {
        //         Console.WriteLine(player);
        //         Console.WriteLine($"\nLe joueur {player.Alias} possède le vaisseau {player.Spaceship.Name}");
        //
        //         Console.WriteLine("\nL'état complet du vaisseau est : ");
        //         player.Spaceship.ViewShip();
        //
        //         if (player.Spaceship.Weapons.Count > 0)
        //         {
        //             Console.WriteLine($"\nCe vaisseau possède les armes suivante : ");
        //             foreach (Weapon weapon in player.Spaceship.Weapons)
        //             {
        //                 Console.WriteLine(weapon);
        //             }
        //         }
        //     }
        //
        //     Console.WriteLine("\nTentative d'ajouter une arme n'étant pas l'armerie : ");
        //     try
        //     {
        //         spaceInvaders.Players[0].Spaceship
        //             .AddWeapon(new Weapon("IMOPOSSIBLE_WEAPON", 0, 100, EWeaponType.Direct, 2));
        //     }
        //     catch (ArmoryException e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }
        //
        //     Weapon w = new Weapon("Laser", 2, 3, EWeaponType.Direct, 2);
        //     armory.AddWeapon(w);
        //     Console.WriteLine("\nLaser");
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //
        //
        //     w = new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 2);
        //     armory.AddWeapon(w);
        //     Console.WriteLine("\nHammer");
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //
        //     w = new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2);
        //     armory.AddWeapon(w);
        //     Console.WriteLine("\nTorpille");
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //
        //     w = new Weapon("Misille", 4, 100, EWeaponType.Direct, 4);
        //     armory.AddWeapon(w);
        //     Console.WriteLine("\nMissile");
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //     Console.WriteLine(w.Shoot());
        //
        //     // Spaceship spaceship1 = new Spaceship(100, 100, "spaceship1");
        //     // Spaceship spaceship2 = new Spaceship(100, 100, "spaceship2");
        //     //
        //     // spaceship1.AddWeapon(w, armory);
        //     // spaceship1.AddWeapon(w, armory);
        //     // spaceship2.AddWeapon(w, armory);
        //     //
        //     // spaceship1.ViewShip();
        //     // spaceship2.ViewShip();
        //     //
        //     // spaceship1.ShootTarget(spaceship2);
        //     // spaceship1.ViewShip();
        //     // spaceship2.ViewShip();
        //
        //     Dart dart = new Dart("Dart");
        //     dart.ViewShip();
        //     dart.ViewWeapons();
        //
        //     BWings bWings = new BWings("BWings");
        //     bWings.ViewShip();
        //     bWings.ViewWeapons();
        //
        //     Rocinante rocinante = new Rocinante("Rocinante");
        //     rocinante.ViewShip();
        //     rocinante.ViewWeapons();
        //
        //     ViperMKII viperMkii = new ViperMKII("ViperMKII");
        //     viperMkii.ViewShip();
        //     viperMkii.ViewWeapons();
        // }
    }
}