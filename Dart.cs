namespace Bozlak_Fatih_Tp1
{
    public class Dart : Spaceship
    {
        public Dart(string name) : base(10, 3, name)
        {
            this.InitDefaultWeapon();
        }

        public void InitDefaultWeapon()
        {
            this.AddWeapon(new Weapon("Laser", 2, 3, EWeaponType.Direct, 0));
        }

        public override void AddWeapon(Weapon weapon)
        {
            if (weapon.EWeaponType == EWeaponType.Direct)
            {
                weapon.ReloadTime = 0;
            }

            base.AddWeapon(weapon);
        }
    }
}