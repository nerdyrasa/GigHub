using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class UserNotification
    {
        public Notification Notification { get; set; }
        public ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 1)]
        public int NotificationId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ApplicationUserId { get; set; }

        public bool IsRead { get; set; }

    }
}