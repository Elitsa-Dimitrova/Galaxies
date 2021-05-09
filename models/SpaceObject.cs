namespace Galaxies.models
{
    abstract class SpaceObject
    {
        protected string name;

        public abstract void print();
        public SpaceObject(string name)
        {
            this.name = name;
        }

    }
}