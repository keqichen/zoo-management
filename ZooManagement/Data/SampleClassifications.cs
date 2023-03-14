using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;
using System.Collections;

namespace ZooManagement.Data
{
    public static class SampleClassifications
    {
        //public const int NumberOfClassfications = 6;
        public static List<ClassificationModel> ClassificationsListGenerator()
        {
            List<ClassificationModel> sampleClassifications = new List<ClassificationModel>
            {
                new ClassificationModel("Mammal"),
                new ClassificationModel("Reptile"),
                new ClassificationModel("Invertebrate"),
                new ClassificationModel("Fish"),
                new ClassificationModel("Bird"),
                new ClassificationModel("Insect")
            };

            return sampleClassifications;
        }
    }
}
