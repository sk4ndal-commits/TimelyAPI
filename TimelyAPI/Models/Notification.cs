using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimelyAPI.Models;

public class Notification
{
    // ids
    [Key]
    public string Id { get; set; }
    
    [Required]
    public string UserId { get; set; }
    
    // props
    [Required]
    [MaxLength(250)]
    public string Message { get; set; }
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime SentAt { get; set; }
    
    // navs
    [ForeignKey("UserId")]
    public User User { get; set; }
}