// Models/Goal.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimelyAPI.Enums;

namespace TimelyAPI.Models;

public class Goal
{
    // ids
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    public string UserId { get; set; } = null!;

    // props
    [MaxLength(50)]
    public required string Description { get; set; }
    
    [MaxLength(100)]
    public required string Reason { get; set; }
    
    [Required]
    [Column(TypeName = "time")]
    public TimeSpan TargetHours { get; set; }
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    // navs
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    
    [InverseProperty("Goal")]
    public ICollection<Activity> Activities { get; set; } = null!;
}