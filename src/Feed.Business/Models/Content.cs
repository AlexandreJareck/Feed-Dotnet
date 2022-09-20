namespace Feed.Business.Models;

public class Content : Entity
{
    public Guid PostId { get; set; }
    public string Type { get; set; }
    public string Comment { get; set; }

    public Post Post { get; set; }
}
