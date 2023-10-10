namespace TodoApiV6.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public class TodoDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }  
    public class TodoPutDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
