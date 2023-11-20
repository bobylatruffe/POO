using System;

namespace Bozlak_Fatih_Tp1
{
    public enum EWeaponType
    {
        Direct,
        Explosive,
        Guided
    }

    public class Weapon
    {
        private string _name;
        private int _minDamage;
        private int _maxDamage;
        private readonly EWeaponType _eWeaponType;
        private int _reloadTime;
        private int _timeBeforeReload;

        public Weapon(string name, int minDamage, int maxDamage, EWeaponType eWeaponType, int reloadTime)
        {
            this._name = name;
            this._minDamage = minDamage;
            this._maxDamage = maxDamage;
            this._eWeaponType = eWeaponType;
            this._reloadTime = reloadTime;

            this._timeBeforeReload = _reloadTime;
        }

        public int MinDamage
        {
            get => this._minDamage;
        }

        public int MaxDamage
        {
            get => this._maxDamage;
        }

        public string Name
        {
            get => this._name;
        }

        public EWeaponType EWeaponType
        {
            get => _eWeaponType;
        }

        public int ReloadTime
        {
            get => this._reloadTime;
            set => _reloadTime = value;
        }

        public int TimeBeforeReload
        {
            get => this._timeBeforeReload;
            set => _timeBeforeReload = value;
        }

        public int Shoot()
        {
            int degat = 0;

            if (this.TimeBeforeReload != 0)
            {
                Console.WriteLine("Entrain de recharger !");
                TimeBeforeReload--;
                return degat;
            }

            degat = new Random().Next(MinDamage, MaxDamage + 1);

            switch (EWeaponType)
            {
                case EWeaponType.Direct:
                    if (new Random().Next(0, 10) == 0)
                        degat = 0;
                    break;

                case Bozlak_Fatih_Tp1.EWeaponType.Explosive:
                    this.ReloadTime *= 2;
                    degat *= 2;
                    if (new Random().Next(0, 4) == 0)
                        degat = 0;
                    break;

                case Bozlak_Fatih_Tp1.EWeaponType.Guided:
                    degat = MinDamage;
                    break;
            }

            TimeBeforeReload = ReloadTime;

            return degat;
        }

        public override string ToString()
        {
            return $"{this.Name} (type={this.EWeaponType}, minDamage={this.MinDamage}, maxDamage={this.MaxDamage})";
        }
    }
}