using System;

namespace Bozlak_Fatih_Tp1
{
    public class Player : IPlayer
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _alias;
        private readonly string _name;
        private Spaceship _spaceship;

        /*
         * Mettre à jour la classe Player afin qu’il puisse utiliser un vaisseau par défaut :
         * "Par défaut" je l'interprète s'il n'est pas reçu dans le constructeur, alors le constructeur
         * en crée un par defaut.
         */
        public Player(string firstName, string lastName, string alias)
        {
            Player.FormatterFirstAndLastName(ref firstName, ref lastName);
            _firstName = firstName;
            _lastName = lastName;
            _alias = alias;

            _spaceship = new Dart("Norstrodon" + alias);
        }

        public Player(string firstName, string lastName, string alias, Spaceship spaceship) : this(firstName, lastName,
            alias)
        {
            this._spaceship = spaceship;
        }

        private string FirstName
        {
            get => _firstName;
            // set => _firstName = value; pas besoin puisque je veux le rendre immuable 
        }

        private string LastName
        {
            get => _lastName;
        }

        public string Alias
        {
            get => _alias;
        }

        public Spaceship BattleShip { get; set; }

        public string Name
        {
            get => this.FirstName + " " + this.LastName;
        }

        public Spaceship Spaceship
        {
            get => this._spaceship;
            set => this._spaceship = value;
        }

        public override string ToString()
        {
            return $"{this.Alias} ({this.Name})";
        }

        public override bool Equals(object obj)
        {
            Player otherPlayer = obj as Player;
            if (otherPlayer == null)
                throw new Exception("Merci de fournir deux objets Player");

            return this.Alias == otherPlayer.Alias;
            // return this.Alias.Equals(otherPlayer.Alias);
        }

        private static void FormatterFirstAndLastName(ref string firstName, ref string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) return;

            firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
            lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
        }
    }
}