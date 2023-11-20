using System;

namespace Bozlak_Fatih_Tp1
{
    public class Rocinante : Spaceship
    {
        public Rocinante(string name) : base(3, 5, name)
        {
        }

        public override void TakeDamages(int degatRecu)
        {
            if (new Random().Next(0, 2) == 0)
            {
                base.TakeDamages(degatRecu);
            }
        }
    }
}