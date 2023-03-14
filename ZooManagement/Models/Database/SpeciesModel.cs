namespace ZooManagement.Models.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
//using System.Collections.IEnumerable;
public class SpeciesModel
{
    public int Id {get;set;}
    public string Name {get;set;}

    [ForeignKey("Classification")]
    public int ClassificationId{get;set;}
    public ClassificationModel Classification{get;set;}
    public List<AnimalModel> AnimalList {get;set;} = new List<AnimalModel>();
}