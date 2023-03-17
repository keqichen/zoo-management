using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;
using System.Collections;

namespace ZooManagement.Data
{
    public static class SampleEnclosure
    {
        //public const int NumberOfAnimals = 100;
        public static List<EnclosureModel> SampleEnclosureGenerator()
        {
            List<EnclosureModel> sampleEnclosures = new List<EnclosureModel>
            {
                new EnclosureModel("Lion",10),
                new EnclosureModel("Aviary",50),
                new EnclosureModel("Reptile",40),
                new EnclosureModel("Giraffe",6),
                new EnclosureModel("Hippo",10)
               
            };
            return sampleEnclosures;
        }
        
    }
}
