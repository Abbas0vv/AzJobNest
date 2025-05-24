using AzJobNest.Database.Abstracts;

namespace AzJobNest.Database.DomainModels;

public class Notification : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public AzJobNestUser User { get; set; }
    public int UserId { get; set; }
    public BroadcastMessage BroadcastMessage { get; set; }
    public int? BroadcastMessageId { get; set; }

    public DateTime CreatedAt { get; set; }
}
