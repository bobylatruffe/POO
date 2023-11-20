using System;
using System.Collections.Generic;

namespace Bozlak_Fatih_Tp1
{
    public class ViperMKII : Spaceship
    {
        public ViperMKII(string name) : base(10, 15, name)
        {
            this.InitDefaultWeapon();
        }

        public void InitDefaultWeapon()
        {
            this.AddWeapon(new Weapon("Mitralleuse", 6, 8, EWeaponType.Direct, 1));
            this.AddWeapon(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 2));
            this.AddWeapon(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
        }

        public override void ShootTarget(Spaceship target)
        {
            List<Weapon> disponniblePourTirer = new List<Weapon>();

            disponniblePourTirer.Clear();

            foreach (Weapon weapon in Weapons)
            {
                if (weapon.TimeBeforeReload == 0)
                    disponniblePourTirer.Add(weapon);
            }

            if (disponniblePourTirer.Count > 0)
                base.TakeDamages(disponniblePourTirer[new Random().Next(0, disponniblePourTirer.Count)].Shoot());
        }
    }
}