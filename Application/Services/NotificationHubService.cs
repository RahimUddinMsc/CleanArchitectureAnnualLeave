using Microsoft.AspNetCore.SignalR;

namespace Application.Services;
public class NotificationHubService<T>(IHubContext<T> hubContext) where T : Hub
{
    public async Task SendMessage(string username, string message)
    { 
        await hubContext.Clients.All.SendAsync("ReceiveMessage", username, message);
    }
}

