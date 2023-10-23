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
            string[] namesWeapons = new[] { "FuseeDirect", "FuseeExplosive", "FuseeGuidee" };
            Array eWeaponTypes = Enum.GetValues(typeof(EWeaponType));
            for (int i = 0; i < eWeaponTypes.Length; i++)
            {
                // Console.WriteLine(eWeaponTypes.GetValue(i));
                this._weapons.Add(
                    new Weapon(namesWeapons[i],
                        0,
                        200,
                        (EWeaponType)eWeaponTypes.GetValue(i)
                    )
                );
            }
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