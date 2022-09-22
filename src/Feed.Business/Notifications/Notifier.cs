﻿using Feed.Business.Interfaces;

namespace Feed.Business.Notifications;

public class Notifier : INotifier
{
    private List<Notification> _notifications;

    public Notifier()
    {
        _notifications = new List<Notification>();
    }

    public List<Notification> GetNotifications()
    {
        return _notifications;
    }

    public void Add(Notification notification)
    {
        _notifications.Add(notification);
    }

    public bool HaveNotification()
    {
        return _notifications.Any();
    }
}
