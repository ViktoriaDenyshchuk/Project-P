//using Microsoft.EntityFrameworkCore;
//using SweetCreativity.Reposotories.Interfaces;
//using SweetCreativity1.Core.Context;
//using SweetCreativity1.Core.Entities;
//using SweetCreativity1.Reposotories.Interfaces;
////using SweetCreativity1.Infrastructure.Data;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//public class ChatMessageReposotory : IChatMessageReposotory
//{
//    private SweetCreativity1Context _context;
//    public ChatMessageReposotory(SweetCreativity1Context context)
//    {
//        _context = context;
//    }

//    public IEnumerable<ChatMessage> GetMessages(string senderId, string receiverId)
//    {
//        // Логіка для отримання повідомлень з бази даних
//        return _context.ChatMessages
//            .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
//                        (m.SenderId == receiverId && m.ReceiverId == senderId))
//            .OrderBy(m => m.Timestamp)
//            .ToList();
//    }

//    public void SaveMessage(ChatMessage message)
//    {
//        // Логіка для збереження повідомлення у базі даних
//        _context.ChatMessages.Add(message);
//        _context.SaveChanges();
//    }
//    public void Save()
//    {
//        // Додайте логіку для збереження змін в базі даних (якщо потрібно)
//        _context.SaveChanges();
//    }
//}
