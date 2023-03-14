namespace ZooManagement.Models.Database;
using System.Collections.Generic;
//using System.Collections.IEnumerable;
public class ClassificationModel
{
    public int Id {get;set;}
    public string Name {get;set;}
    public ICollection<SpeciesModel> SpeciesList {get;set;} = new List<SpeciesModel>();

    public ClassificationModel (string name)
    {
        Name = name;
    }
}