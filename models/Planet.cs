using System;
using System.Collections.Generic;
using Galaxies.enums;

namespace Galaxies.models
{
    class Planet: SpaceObject
    {
        PlanetType type;
        bool isHabitat;

        List<Moon> moons;

        public Planet(string name, PlanetType type, bool isHabitat): base(name)
        {
            this.type = type;
            this.isHabitat = isHabitat;
            this.moons = new List<Moon>();
        }

        public void addMoon(Moon moon)
        {
            this.moons.Add(moon);
        }

        public override void print()
        {
            Console.WriteLine(
            "        o  Name: {0}\n"+
            "           Type: {1}\n"+
            "           Support life: {2}\n"+
            "           Moons:", this.name, this.type, this.isHabitat == true ? "yes" : "no");

            this.moons.ForEach(moon => moon.print());
        }
    }
}