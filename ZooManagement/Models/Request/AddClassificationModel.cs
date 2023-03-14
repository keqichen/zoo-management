namespace ZooManagement.Models.Database;
using System.ComponentModel.DataAnnotations;
public class AddClassificationModel
{
    
    [Required]
    [StringLength(140)]
    public string Name { get; set; }

   
}