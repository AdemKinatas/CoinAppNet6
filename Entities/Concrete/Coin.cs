using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Coin : IEntity
    {
        public string Id { get; set; }
        public string CoinName { get; set; }
        public string CoinIcon { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal RateOfChange { get; set; }
    }
}
