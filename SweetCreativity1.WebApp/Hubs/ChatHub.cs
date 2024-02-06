// ChatHub.cs

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    public async Task SendMessage(string userId, string userName, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", userName, message);
    }
}



//// ChatHub.cs
//using Microsoft.AspNetCore.SignalR;
//using System.Threading.Tasks;

//public class ChatHub : Hub
//{
//    public async Task SendMessage(string user, string message, string orderId)
//    {
//        await Clients.Group(orderId).SendAsync("ReceiveMessage", user, message);
//    }

//    public async Task JoinOrderGroup(string orderId)
//    {
//        await Groups.AddToGroupAsync(Context.ConnectionId, orderId);
//    }
//}
//using Microsoft.AspNetCore.SignalR;

//namespace SweetCreativity1.WebApp.ChatHub
//{
//    public class ChatHub : Hub
//    {
//        public async Task Send(string name, string message)
//        {
//            // Call the SendAsync method to update clients.
//            await Clients.All.SendAsync("ReceiveMessage", name, message);
//        }
//    }
//}
