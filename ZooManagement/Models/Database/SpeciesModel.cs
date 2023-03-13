namespace ZooManagement.Models.Database;
public class SpeciesModel
{
    public int Id {get;set;}
    public string Name {get;set;}
    [ForeignKey("Classfication")]
    public int ClassificationId{get;set;}
    public ClassificationModel Classfication{get;set;}
}