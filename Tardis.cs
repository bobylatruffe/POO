using System;
using System.Collections.Generic;

namespace Bozlak_Fatih_Tp1
{
    public class Tardis : Spaceship, IAbility
    {
        public Tardis(string name) : base(1, 0, name)
        {
        }


        public void UseAbility(List<Spaceship> spaceships)
        {
            int indexOfVaisseauRandom = new Random().Next(0, spaceships.Count - 1);

            Spaceship tmp = spaceships[indexOfVaisseauRandom];
            spaceships[spaceships.IndexOf(this)] = tmp;
            spaceships[indexOfVaisseauRandom] = this;
        }
    }
}