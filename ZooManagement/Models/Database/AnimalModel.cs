namespace ZooManagement.Models.Database;
public class AnimalModel
{
    public int Id {get;set;}

    [ForeignKey("SpeciesModel")]
    public int SpeciesId {get;set;}
    public string Name {get;set;}
    public string Sex {get;set;}
    public string DateOfBirth {get;set;}
    public string DateOfAquirement {get;set;}
}