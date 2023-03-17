namespace ZooManagement.Models.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
public class EnclosureModel
{
    public int Id {get;set;}
   
    public string Name {get;set;}
    public int  MaxNumber {get;set;}
    
    public IEunmerable<AnimalModel> AnimalList{get;set;}=new IEunmerable<AnimalModel>();

    public EnclosureModel(string name, int maxNumber){
        Name=name;
        MaxNumber=maxNumber;
    }
}