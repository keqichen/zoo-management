namespace ZooManagement.Models.Database;
using System.ComponentModel.DataAnnotations;
public class AddAnimalModel
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int SpeciesId { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int EnclosureId{get;set;}

    [Required]
    [StringLength(140)]
    public string Name { get; set; }

    [Required]
    [StringLength(140)]
    public string Sex { get; set; }

    [Required]
    [StringLength(140)]
    public string DateOfBirth { get; set; }

    [Required]
    [StringLength(140)]
    public string DateOfAcquirement { get; set; }
}