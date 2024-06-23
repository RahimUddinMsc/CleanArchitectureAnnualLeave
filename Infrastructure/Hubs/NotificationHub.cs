using Application.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class NotificationHub : Hub
{
    public async Task SendMessage(string userName, string messageContent)
    {

        var context = Context.GetHttpContext();
        var notificationHub = Context.GetHttpContext()?.RequestServices.GetService<NotificationHubService<NotificationHub>>();
        

        _ = notificationHub ?? throw new InvalidOperationException("NotificationHub instance is null. Unable to send message.");

        await notificationHub.SendMessage(userName, messageContent);
    }
}
