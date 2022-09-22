using Feed.Business.Notifications;

namespace Feed.Business.Interfaces;

public interface INotifier
{
    bool HaveNotification();
    List<Notification> GetNotifications();
    void Add(Notification notification);
}
