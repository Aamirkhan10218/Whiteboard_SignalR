using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WhiteBoard_SignalR
{
    public class WhiteBoardHub : Hub
    {
        public async Task JoinGroup(string groupName)
        {

            //  Groups.Add(Context.ConnectionId, groupName);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
           

        }
        public async Task JoinChat(string name, string groupName)
        {


            // Clients.Group(groupName).ChatJoined(name);
            await Clients.Group(groupName).SendAsync(name);

        }

        public async Task SendDraw(string drawObject, string sessionId, string groupName, string name)
        {
            //Clients.Group(groupName).HandleDraw(drawObject, sessionId, name);
            await Clients.Group(groupName).SendAsync("HandleDraw", drawObject, sessionId, name);
        }

        public async Task SendChat(string message, string groupName, string name)
        {
            //  Clients.Group(groupName).Chat(name, message);
            await Clients.Group(groupName).SendAsync("Chat", name, message);
        }
    }
}
