namespace ZooManagement.Models.Database;
using System.ComponentModel.DataAnnotations;
public class AddSpeciesModel
{

    [Required]
    [StringLength(140)]
    public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int ClassificationId { get; set; }
}