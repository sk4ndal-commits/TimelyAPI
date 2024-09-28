// Models/User.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TimelyAPI.Models;

public class User : IdentityUser
{
    // prop
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // navs
    [InverseProperty("User")]
    public ICollection<Goal>? Goals { get; set; }
    
    [InverseProperty("User")]
    public ICollection<Notification>? Notifications { get; set; }
    
    [InverseProperty("User")]
    public ICollection<Report>? Reports { get; set; }
}