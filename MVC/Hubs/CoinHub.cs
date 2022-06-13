using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace MVC.Hubs
{
    public class CoinHub : Hub
    {
        private readonly ICoinService _coinService;

        public CoinHub(ICoinService coinService)
        {
            _coinService = coinService;
        }

        public async Task SendCoin(string id, string coinName, string coinIcon, decimal currentPrice, decimal rateOfChange)
        {
            await Clients.All.SendAsync("ReceiveCoin", id, coinName, coinIcon, currentPrice, rateOfChange);

            Coin coin = new Coin
            {
                Id = id,
                CoinName = coinName,
                CoinIcon = coinIcon,
                CurrentPrice = currentPrice,
                RateOfChange = rateOfChange
            };

            await _coinService.UpdateAsync(coin);
        }
    }
}
