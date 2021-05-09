using System;
using System.Collections.Generic;
using Galaxies.enums;

namespace Galaxies.models
{
    class Galaxy: SpaceObject
    {
        GalaxyType type;
        double age;
        AgeLiteral ageLiteral;

        List<Star> stars;

        public Galaxy (string name, GalaxyType type, double age, AgeLiteral ageliteral): base(name)
        {
            this.type = type;
            this.age = age;
            this.ageLiteral = ageLiteral;
            this.stars = new List<Star>();
        }

        public void addStar(Star star){
            this.stars.Add(star);
        }

        public override void print()
        {
            Console.WriteLine(
            "--- Data for {0} galaxy --- \n" +
            "Type: {1}\n" +
            "Age: {2}{3}\n" +
            "Stars:", this.name, this.type, this.age, this.ageLiteral);

            this.stars.ForEach(star => star.print());

            Console.WriteLine("-- End of data for {0} galaxy ---", this.name);
        }
    }
}
