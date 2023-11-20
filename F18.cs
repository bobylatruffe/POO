using System.Collections.Generic;

namespace Bozlak_Fatih_Tp1
{
    public class F18 : Spaceship, IAbility
    {
        public F18(string name) : base(15, 0, name)
        {
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            int indexOfTardis = spaceships.IndexOf(this);

            if (indexOfTardis == 0 && spaceships[1].BelongsPlayer)
                spaceships[1].TakeDamages(10);
            else if (indexOfTardis == spaceships.Count - 1 && spaceships[spaceships.Count - 2].BelongsPlayer)
                spaceships[spaceships.Count - 1].TakeDamages(10);
        }
    }
}