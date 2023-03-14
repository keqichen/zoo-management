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
    public Nullable<DateTime> DateOfBirth {get;set;}
    public Nullable<DateTime> DateOfAcquirement {get;set;}

    public AnimalModel (int speciesId,string name, string sex, Nullable<DateTime> dateOfBirth, Nullable<DateTime> dateOfAcquirement)
    {
        SpeciesId=speciesId; 
        Name=name;
        Sex=sex;
        DateOfBirth=dateOfBirth;
        DateOfAcquirement=dateOfAcquirement;
    }
}