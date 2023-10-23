using System;
using System.Collections.Generic;

namespace Bozlak_Fatih_Tp1
{
    public class Spaceship
    {
        private readonly string _name;

        private readonly int _maxStructure;
        private int _currentStructure;

        private readonly int _maxShield;
        private int _currentShield;

        private int _structureDamage;
        private int _shieldDamage;

        private List<Weapon> _weapons = new List<Weapon>();

        public Spaceship(int maxStructure, int maxShield, string name)
        {
            this._maxStructure = maxStructure;
            this._maxShield = maxShield;
            this._name = name;
        }

        private int MaxStructure
        {
            get => _maxStructure;
        }

        public int CurrentStructure
        {
            private get => _currentStructure;
            set => _currentStructure = value;
        }

        private int MaxShield
        {
            get => _maxShield;
        }

        public int CurrentShield
        {
            private get => _currentShield;
            set => _currentShield = value;
        }

        public int StructureDamage
        {
            get => this.MaxStructure - this.CurrentStructure;
        }

        public int ShieldDamage
        {
            get => this.MaxShield - this.CurrentShield;
        }

        public List<Weapon> Weapons
        {
            get => _weapons;
        }

        public string Name
        {
            get => this._name;
        }

        //TODO répondre à la question 3 de la question 3 ... IsDestroyed

        public void AddWeapon(Weapon weapon)
        {
            if (this.Weapons.Count == 3)
                throw new Exception("Nombre d'arme maximum atteint, supprime en une pour en ajouter une nouvelle");

            this._weapons.Add(weapon);
        }

        public void RemoveWeapon(Weapon weapon)
        {
            this.Weapons.Remove(weapon);
        }

        public void ClearWeapons()
        {
            this._weapons.Clear();
        }

        public void ViewWeapons()
        {
            if (this.Weapons.Count > 0)
                Console.WriteLine("Le vaisseau possède les armes suivantes : ");
            else
                Console.WriteLine("Le vaisseau ne possède aucune armes !");

            foreach (Weapon weapon in this.Weapons)
            {
                Console.WriteLine(weapon);
            }
        }

        /*
         * Je n'ai pas très bien compris la question :
         * Je part donc du principe qu'avec les armes que dispose le vaisseau à un instant T,
         * je calcule les dégâts moyen qu'il peut infliger.
         */
        public double AverageDamages()
        {
            int sumMaxDomages = 0;
            foreach (Weapon weapon in this.Weapons)
            {
                sumMaxDomages += (weapon.MinDamage + weapon.MaxDamage) / 2;
            }

            return sumMaxDomages / this.Weapons.Count;
        }

        public void ViewShip()
        {
            Console.WriteLine($"Le vaisseau {this.Name} à {this.MaxStructure} de structure max, " +
                              $"{this.MaxShield} de shield max, " +
                              $"{this.CurrentShield} de shield courant, " +
                              $"{this.CurrentStructure} de structure courante, " +
                              $"et donc {this.ShieldDamage} de shield total dispo, " +
                              $"et {this.StructureDamage} de structure total dispo");
        }
    }
}