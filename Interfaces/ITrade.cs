using CreditSuisse.Negocio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse.Interfaces
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
        bool IsPoliticallyExposed { get; }
    }
}
