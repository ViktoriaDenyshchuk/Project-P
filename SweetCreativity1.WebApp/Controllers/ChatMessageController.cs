//using Microsoft.AspNetCore.Mvc;
//using SweetCreativity.Reposotories.Interfaces;
//using SweetCreativity1.Core.Entities;
//using SweetCreativity1.Reposotories.Interfaces;

//namespace SweetCreativity1.WebApp.Controllers
//{
//    public class ChatMessageController : Controller
//    {
//        private readonly IChatMessageReposotory _chatMessageReposotory;

//        public ChatMessageController(IChatMessageReposotory chatMessageReposotory)
//        {
//            _chatMessageReposotory = chatMessageReposotory;
//        }

//        [HttpPost]
//        public IActionResult SendMessage(ChatMessage message)
//        {
//            // Логіка для збереження повідомлення у базі даних
//            _chatMessageReposotory.SaveMessage(message);

//            // Повернення успішності відправлення повідомлення
//            return Ok();
//        }

//        // Додайте інші методи, які вам потрібні (отримання повідомлень, тощо)
//    }

//}
