using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Domain.Core.Notification
{
    public interface INotification
    {
        Task AddNotification(string key, string message);
        Task AddNotification(Notification notification);
        Task AddNotifications(IEnumerable<Notification> notifications);
        Task AddNotifications(ValidationResult notifications);
        IEnumerable<Notification> GetNotifications();
        bool HasNotifications();
    }
}
