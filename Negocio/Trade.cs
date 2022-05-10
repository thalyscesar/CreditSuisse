using CreditSuisse.Interfaces;
using CreditSuisse.Negocio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse.Negocio
{
    public class Trade : ITrade
    {
        public Trade(double value, string clientSector, DateTime nextPaymentDate, bool isPoliticallyExposed = false)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
            IsPoliticallyExposed = isPoliticallyExposed;
        }

        public double Value { get; private set; }
        public string ClientSector { get; private set; }
        public DateTime NextPaymentDate { get; private set; }

        public bool IsPoliticallyExposed { get; private set; }
    }

    public interface ICategoria
    {
        bool EhCategoriaEscolhida(ITrade trade);
        string Categoria { get; }
    }

    public class CategoriaAltoRisco : ICategoria
    {
        public string Categoria => "AltoRisco";

        public bool EhCategoriaEscolhida(ITrade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Private";
        }
    }

    public class CategoriaPadrao : ICategoria
    {
        public string Categoria => "Padrao";

        public bool EhCategoriaEscolhida(ITrade trade)
        {
            return DateTime.Now.Subtract(trade.NextPaymentDate).TotalDays > 30;
        }
    }

    public class CategoriaMedia : ICategoria
    {
        public string Categoria => "Media";

        public bool EhCategoriaEscolhida(ITrade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Publico";
        }
    }

    public class CategoriaDefault : ICategoria
    {
        public string Categoria => "Não encontrou a categoria";

        public bool EhCategoriaEscolhida(ITrade trade)
        {
            return true;
        }
    }
}
