using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CoinManager : ICoinService
    {
        private readonly ICoinDal _coinDal;

        public CoinManager(ICoinDal coinDal)
        {
            _coinDal = coinDal;
        }
        
        public async Task<Coin> AddAsync(Coin coin)
        {
            await _coinDal.AddAsync(coin);
            return coin;
        }
        
        public async Task<Coin> UpdateAsync(Coin coin)
        {
            if (IfCoinExist(coin))
            {
                await _coinDal.UpdateAsync(coin);
                return coin;
            }
            else
            {
                return await AddAsync(coin);
            }
        }

        private bool IfCoinExist(Coin coin)
        {
            return _coinDal.GetAllAsync()
                .Result
                .Any(c => c.Id == coin.Id);
        }
    }
}
