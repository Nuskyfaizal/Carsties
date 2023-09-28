using AuctionService.Data;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers;

public class BidPlacedConsumer : IConsumer<BidPlaced>
{
    private readonly AuctionDbContext _dbcontext;

    public BidPlacedConsumer(AuctionDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task Consume(ConsumeContext<BidPlaced> context)
    {
        Console.WriteLine("---> Consuming bid placed");

        var auction = await _dbcontext.Auctions.FindAsync(context.Message.AuctionId);

        if(auction.CurrentHighBid == null 
            || context.Message.BidStatus.Contains("Accepted") 
            && context.Message.Amount > auction.CurrentHighBid)
        {
            auction.CurrentHighBid = context.Message.Amount;
            await _dbcontext.SaveChangesAsync();
        }
    }
}
