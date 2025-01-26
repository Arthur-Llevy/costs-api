using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Api.Utils.Classes;

namespace Api.Domain.Entities;

public class ProjectsEntity 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Required]
    public string Name { get; set; } = default!;

    [Required]
    public int Budget { get; set; } = default;

    [Required]
    public int Costs { get; set; } = default!;

    public int Category_Id { get; set; } = default!;

    [Required]
    [ForeignKey(nameof(Category_Id))]
    public ProjectsCategory Category { get; set; } = default!;

    [JsonIgnore]
    public ICollection<ProjectServicesEntity> Services { get; set; } = default!;
}