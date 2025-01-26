using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities;

public class ProjectServicesEntity 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Required]
    public string Name { get; set; } = default!;

    [Required]
    public int Cost { get; set; } = default!;

    [Required]
    public string Description { get; set; } = default!;

    [Required]
    public int Project_Id { get; set; } = default!;

    [ForeignKey(nameof(Project_Id))]

    [JsonIgnore]
    public ProjectsEntity Project { get; set; } = default!;
}