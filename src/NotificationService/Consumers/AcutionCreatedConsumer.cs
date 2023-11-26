using Contracts;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Hubs;

namespace NotificationService.Consumers;
public class AcutionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public AcutionCreatedConsumer(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("--> auction created message recieved");

        await _hubContext.Clients.All.SendAsync("AuctionCreated", context.Message);
    }
}
