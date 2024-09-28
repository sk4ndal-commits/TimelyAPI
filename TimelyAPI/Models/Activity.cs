// Models/Activity.cs


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimelyAPI.Models;

public class Activity
{
    // ids
    [Key]
    public string Id { get; set; }

    [Required]
    public string GoalId { get; set; }

    // props
    
    [Required]
    [MaxLength(50)]
    public string Description { get; set; } = null!;
    
    public bool IsCustom { get; set; }
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // navs
    [ForeignKey("GoalId")]
    public Goal Goal { get; set; }
    
    [InverseProperty("Activity")]
    public ICollection<TimeLog> TimeLogs { get; set; } = null!;
}