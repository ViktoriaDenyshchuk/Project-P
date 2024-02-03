using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Core.Entities
{
    public class ChatMessage
    {
        //    public int Id { get; set; }
        //    public string? SenderId { get; set; }
        //    public string? ReceiverId { get; set; }
        //    public string? Content { get; set; }
        //    public DateTime? Timestamp { get; set; }

        //// Нова властивість для ідентифікатора оголошення (замовлення)
        //public int? OrderId { get; set; }

        //// Додаємо навігаційні властивості
        //public User Sender { get; set; }
        //    public User Receiver { get; set; }

        //public virtual Order? Order { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TextMessage { get; set; }
        public DateTime CreatedAtMessage { get; set; } = DateTime.Now;

        public virtual User? User { get; set; }
        public string? UserId { get; set; }
        public virtual Order? Order { get; set; }
        public int? OrderId { get; set; }
    }
}
