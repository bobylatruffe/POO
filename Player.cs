using System;

namespace Bozlak_Fatih_Tp1
{
    public class Player
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _alias;
        private readonly string _name;

        public Player(string firstName, string lastName, string alias)
        {
            Player.FormatterFirstAndLastName(ref firstName, ref lastName);
            _firstName = firstName;
            _lastName = lastName;
            _alias = alias;
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

        public string Name
        {
            get => this.FirstName + " " + this.LastName;
        }

        public override string ToString()
        {
            return $"{this.Alias} ({this.FirstName} {this.LastName})";
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