using System;
using System.Collections.Generic;

namespace Bozlak_Fatih_Tp1
{
    public abstract class Spaceship : ISpaceship
    {
        private string _name;

        private readonly int _maxStructure;
        private double _currentStructure;

        private readonly int _maxShield;
        private double _currentShield;

        private int _structureDamage;
        private int _shieldDamage;

        private List<Weapon> _weapons = new List<Weapon>();
        private double _averageDamages;

        private Player _player;

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

        double ISpaceship.AverageDamages => _averageDamages;

        public Player Player
        {
            get => this._player;
            set => this._player = value;
        }

        public double CurrentStructure
        {
            get => _currentStructure;
            set => _currentStructure = value;
        }

        private int MaxShield
        {
            get => _maxShield;
        }

        public double CurrentShield
        {
            get => _currentShield;
            set => _currentShield = value;
        }

        public double StructureDamage
        {
            get => this.MaxStructure - this.CurrentStructure;
        }

        public double ShieldDamage
        {
            get => this.MaxShield - this.CurrentShield;
        }

        public int MaxWeapons { get; }

        public List<Weapon> Weapons
        {
            get => _weapons;
        }

        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        public double Structure { get; set; }
        public double Shield { get; set; }

        public bool IsDestroyed
        {
            get => StructureDamage <= 0 ? true : false;
        }

        //TODO répondre à la question 3 de la question 3 ... IsDestroyed

        public void ReloadWeapons()
        {
            foreach (Weapon weapon in Weapons)
            {
                weapon.TimeBeforeReload = 0;
            }
        }

        public virtual void AddWeapon(Weapon weapon)
        {
            if (this.Weapons.Count == 3)
                throw new Exception("Nombre d'arme maximum atteint, supprime en une pour en ajouter une nouvelle");

            this.Weapons.Add(weapon);
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
            double sumMaxDomages = 0.0;
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

        public void RepairShield(double repair)
        {
            CurrentShield -= repair;
        }

        public virtual void ShootTarget(Spaceship target)
        {
            int degatAInfliger = 0;

            foreach (Weapon w in Weapons)
                degatAInfliger += (int)w.Shoot();

            target.TakeDamages(degatAInfliger);
        }

        public bool BelongsPlayer
        {
            get => this.Player != null ? true : false;
        }

        public virtual void TakeDamages(double degatRecu)
        {
            if (_currentShield < MaxShield)
            {
                double capaciteRestanteBouclier = MaxShield - _currentShield;
                double degatAReporterSurStructure = Math.Max(0, degatRecu - capaciteRestanteBouclier);

                _currentShield += degatRecu - degatAReporterSurStructure;
                _currentStructure += degatAReporterSurStructure;
            }
            else
                _currentStructure += degatRecu;
        }
    }
}