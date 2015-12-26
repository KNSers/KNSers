using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace Handle_KNSER.Hubs
{
    public class NotificationHub : Hub
    {
      
        public string  UserName { get; set; }
        public string Message { get; set; }

        public async Task NewPeopleJoinEvent(string name, string message)
        {
            Clients.All.addNotificationJoinEventToPage(new NotificationHub() { UserName = name, Message = message });
        }
    }
}