namespace ZooManagement.Models.Database;
using System.ComponentModel.DataAnnotations.Schema;
public class AnimalModel
{
    public int Id {get;set;}
    [ForeignKey("Species")]
    public int SpeciesId {get;set;}
    public SpeciesModel Species {get;set;}
    public string Name {get;set;}
    public string Sex {get;set;}
    public string DateOfBirth {get;set;}
    public string DateOfAcquirement {get;set;}

    public AnimalModel (int speciesId,string name, string sex, string dateOfBirth,string dateOfAcquirement)
    {
        SpeciesId=speciesId;
        Name=name;
        Sex=sex;
        DateOfBirth=dateOfBirth;
        DateOfAcquirement=dateOfAcquirement;
    }
}