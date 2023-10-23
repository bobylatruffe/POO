namespace Bozlak_Fatih_Tp1
{
    public class Spaceship
    {
        private int _maxStructure;
        private int _currentStructure;

        private int _maxShield;
        private int _currentShield;

        private int _structureDammage;

        public Spaceship(int maxStructure, int maxShield)
        {
            this._maxStructure = maxStructure;
            this._maxShield = maxShield;
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

        public int StructureDommage
        {
            get => this.MaxStructure - this.CurrentStructure;
        }

        public int ShieldDammage
        {
            get => this.MaxShield - this.CurrentShield;
        }
    }
}