using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;
using System.Collections;

namespace ZooManagement.Data
{
    public static class SampleAnimals
    {
        public const int NumberOfAnimals = 100;
        private static readonly List<string> Names = new List<string>
        {
            "Alice",
            "Bob",
            "Oliver",
            "Jane",
            "Tom",
            "Mandy",
            "James",
            "Betty",
            "Henry",
            "Janet"
        };
        public static string GetName(int index)
        {
            return Names[index];
        }
        private static AnimalModel CreateRandomAnimal(int index)
        {Random random=new Random();
            //var passwordSalt = SaltGenerator.GetSalt();
            return new AnimalModel 
            (
                random.Next(1,11),
                GetName(random.Next(0,10)),
                "female",
                DateTime.Now,
                DateTime.Now
            );
        }
        static List<AnimalModel> sampleAnimalList=new List<AnimalModel>();
        public static List<AnimalModel> AnimalListGenerator()
        {
            for(int i=0;i<NumberOfAnimals;i++)
            {
                var randomAnimal=CreateRandomAnimal(i);
                sampleAnimalList.Add(randomAnimal);
            }

            return sampleAnimalList;
        }
        
    }
}
