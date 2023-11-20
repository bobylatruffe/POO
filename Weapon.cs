using System;

namespace Bozlak_Fatih_Tp1
{
    public enum EWeaponType
    {
        Direct,
        Explosive,
        Guided
    }

    public class Weapon : IWeapon
    {
        private string _name;
        private double _minDamage;
        private double _maxDamage;
        private EWeaponType _eWeaponType;
        private double _reloadTime;
        private double _timeBeforeReload;

        public Weapon(string name, int minDamage, int maxDamage, EWeaponType eWeaponType, int reloadTime)
        {
            this._name = name;
            this._minDamage = minDamage;
            this._maxDamage = maxDamage;
            this._eWeaponType = eWeaponType;
            this._reloadTime = reloadTime;

            this._timeBeforeReload = _reloadTime;
        }

        public EWeaponType Type
        {
            get => this._eWeaponType;
            set => this._eWeaponType = value;
        }

        public double MinDamage
        {
            get => this._minDamage;
            set => this._minDamage = value;
        }

        public double MaxDamage
        {
            get => this._maxDamage;
            set => this._maxDamage = value;
        }

        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        public EWeaponType EWeaponType
        {
            get => _eWeaponType;
        }

        public double AverageDamage { get; }

        public double ReloadTime
        {
            get => this._reloadTime;
            set => _reloadTime = value;
        }

        public double TimeBeforReload { get; set; }

        public double TimeBeforeReload
        {
            get => this._timeBeforeReload;
            set => _timeBeforeReload = value;
        }

        public bool IsReload { get; }

        public double Shoot()
        {
            double degat = 0;

            if (this.TimeBeforeReload != 0)
            {
                Console.WriteLine("Entrain de recharger !");
                TimeBeforeReload--;
                return degat;
            }

            degat = new Random().Next((int)MinDamage, (int)(MaxDamage + 1.0));

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
            return
                $"{this.Name} " +
                $"(" +
                $"type={this.EWeaponType}, " +
                $"minDamage={this.MinDamage}, " +
                $"maxDamage={this.MaxDamage}, " +
                $"reloadTime={this.ReloadTime}, " +
                $"timeBeforeReload={this.TimeBeforeReload}" +
                $")";
        }
    }
}