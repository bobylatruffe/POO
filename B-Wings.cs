namespace Bozlak_Fatih_Tp1
{
    public class BWings : Spaceship
    {
        public BWings(string name) : base(30, 0, name)
        {
            this.InitDefaultWeapon();
        }

        public void InitDefaultWeapon()
        {
            this.AddWeapon(new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 0));
        }

        public override void AddWeapon(Weapon weapon)
        {
            if (weapon.EWeaponType == EWeaponType.Explosive)
            {
                weapon.ReloadTime = 0;
            }

            base.AddWeapon(weapon);
        }
    }
}