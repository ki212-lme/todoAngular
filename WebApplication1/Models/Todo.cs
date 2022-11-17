namespace WebApplication1;

public class Todo
{
    public int Id { get; set; }
    public int Description { get; set; }
    public DateTime DateComplete { get; set; }
    public bool? IsCompleted { get; set; }
}