using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;
using System.Collections;

namespace ZooManagement.Data
{
    public static class SampleSpecies
    {
        //public const int NumberOfAnimals = 100;
        public static List<SpeciesModel> SpeciesListGenerator()
        {
            List<SpeciesModel> sampleSpecies = new List<SpeciesModel>
            {
                new SpeciesModel("Tiger",1),
                new SpeciesModel("Lion",1),
                new SpeciesModel("Snail",3),
                new SpeciesModel("Squid",3),
                new SpeciesModel("Lizard",2),
                new SpeciesModel("Spider",6),
                new SpeciesModel("Eagle",5),
                new SpeciesModel("Parrot",5),
                new SpeciesModel("Clownfish",4),
                new SpeciesModel("Shark",4)
            };
            return sampleSpecies;
        }
        
    }
}
