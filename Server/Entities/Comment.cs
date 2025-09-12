public class Comment
{
    public int Id { get; set; }

    public string Body { get; set; } = "";
    public int AuthorId { get; set; }
    public int SubForumId { get; set; }

 }