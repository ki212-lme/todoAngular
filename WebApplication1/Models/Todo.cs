using System.ComponentModel.DataAnnotations;

namespace WebApplication1;

public class Todo
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime? DateComplete { get; set; }
    public bool? IsCompleted { get; set; }
}