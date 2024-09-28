using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimelyAPI.Models;

public class Report
{
    // ids
    [Key]
    public string Id { get; set; }
    
    [Required]
    public string UserId { get; set; }
    
    // props
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    [Column(TypeName = "time")]
    public TimeSpan TotalHours { get; set; }
    
    // navs
    [ForeignKey("UserId")]
    public User User { get; set; }
}