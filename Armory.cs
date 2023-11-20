using System;
using System.Collections.Generic;

namespace Bozlak_Fatih_Tp1
{
    public class Armory
    {
        private List<Weapon> _weapons = new List<Weapon>();

        public Armory()
        {
            this.Init();
        }

        public List<Weapon> Weapons
        {
            get => this._weapons;
        }

        private void Init()
        {
            this._weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.Direct, 2));
            this._weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 2));
            this._weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
            this._weapons.Add(new Weapon("Mitralleuse", 6, 8, EWeaponType.Direct, 1));
            this._weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 2));
            this._weapons.Add(new Weapon("Misille", 4, 100, EWeaponType.Direct, 4));
        }

        public void ViewArmory()
        {
            foreach (Weapon weapon in this.Weapons)
            {
                Console.WriteLine(weapon.ToString());
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            _weapons.Add(weapon);
        }

        public bool RemoveWeapon(Weapon weapon)
        {
            return _weapons.Remove(weapon);
        }
    }
}