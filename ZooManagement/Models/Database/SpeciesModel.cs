namespace ZooManagement.Models.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
//using System.Collections.IEnumerable;
public class SpeciesModel
{
    public int Id {get;set;}
    public string Name {get;set;}

    [ForeignKey("Classfication")]
    public int ClassificationId{get;set;}
    public ClassificationModel Classfication{get;set;}
    public List<AnimalModel> AnimalList {get;set;} = new List<AnimalModel>();

    public SpeciesModel (string name,int classificationId)
    {
       
        Name=name;
        ClassificationId=classificationId;
    }
}