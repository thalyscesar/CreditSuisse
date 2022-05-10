using CreditSuisse.Interfaces;
using CreditSuisse.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using CreditSuisse.Utils;
using System.Threading;

namespace CreditSuisse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe a data de referencia:");
            var dateRef = Console.ReadLine().ToData();

            Console.WriteLine("Informe o numero de negociações:");
            var quantidadeNegociacao = Console.ReadLine().ToInt();

            Console.WriteLine("");
            Console.WriteLine("****************************************************************************************************");
            Console.WriteLine("");

            Client client = new Client();
            for (int i = 0; i < quantidadeNegociacao; i++)
            {

                Console.WriteLine("Informe o valor da negociação:");
                var valor = Console.ReadLine();

                Console.WriteLine("Informe o setor da negociação:");
                var setorNegociacao = Console.ReadLine();

                Console.WriteLine("Informe a data de negociacao:");
                var dataProximoPagamento = Console.ReadLine();

                Console.WriteLine("Pessoa politicamente exposta y/n?");
                var ehPep = Console.ReadLine().ToLower() == "y";

                var trade = new Trade(valor.ToDouble(), setorNegociacao, dataProximoPagamento.ToData(), ehPep);

                client.Add(trade);

                Console.WriteLine("");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("");
            }

            List<ICategoria> categorias = new List<ICategoria>();
            categorias.Add(new CategoriaAltoRisco());
            categorias.Add(new CategoriaPadrao());
            categorias.Add(new CategoriaMedia());
            categorias.Add(new CategoriaDefault());

            foreach (var trade in client.Trades)
            {

                foreach (var item in categorias)
                {
                    if (item.EhCategoriaEscolhida(trade))
                    {
                        Console.WriteLine(item.Categoria)
                    }
                }
            }
            Console.ReadKey();


        }
    }
}
