using System.ComponentModel.DataAnnotations;

namespace WebApplication1;

public class Todo
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime? DateComplete { get; set; }
    //null=archived, true=completed,false= uncomplete
    public bool? IsCompleted { get; set; }
}