// Models/TimeLog.cs


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimelyAPI.Models;

public class TimeLog
{
    // ids
    [Key]
    public string Id { get; set; }
    
    [Required]
    public string ActivityId { get; set; }

    // props
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime StartTime { get; set; }
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime EndTime { get; set; }
    
    [Column(TypeName = "time")]
    public TimeSpan Duration => (EndTime - StartTime);
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    // navs
    [ForeignKey("ActivityId")]
    public Activity Activity { get; set; }
}