using System;

namespace RunDataLibrary
{
    public class City
    {
        public int CityId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
