using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities;

public class ProjectsCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Required]
    public string Name { get; set; } = default!;

    [JsonIgnore]
    public ICollection<ProjectsEntity> Projects { get; set; } = default!;
}