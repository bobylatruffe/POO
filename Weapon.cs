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
        private EWeaponType _eWeaponType;

        public Weapon(string name, int minDamage, int maxDamage)
        {
            this._name = name;
            this._minDamage = minDamage;
            this._maxDamage = maxDamage;
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

        public string EWeaponType
        {
            get => _eWeaponType.ToString();
        }
    }
}