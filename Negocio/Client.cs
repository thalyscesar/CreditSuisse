using CreditSuisse.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse.Negocio
{
    public class Client
    {
        private List<ITrade> _trades;
        public IReadOnlyCollection<ITrade> Trades => _trades;

        public Client()
        {
            _trades = new List<ITrade>();
        }

        public void Add(Trade trade)
        {
            _trades.Add(trade);
        }
    }
}
