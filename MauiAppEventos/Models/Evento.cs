using System;

namespace MauiAppEventos.Models
{
    /// Entidade responsável por armazenar os dados do evento
    /// e realizar os cálculos do orçamento.
    public class Evento
    {
        // Armazena a identificação principal do contratante responsável pela reserva.
        public string NomeCliente { get; set; }

        // Define a categoria do evento escolhida pelo usuário.
        // Essa informação influencia diretamente os cálculos financeiros.
        public string TipoEvento { get; set; }

        // Representa a unidade física do buffet onde ocorrerá o evento.
        public string LocalSalao { get; set; }

        // Data inicial da utilização do espaço reservado.
        public DateTime DataInicio { get; set; }

        // Data final da utilização do espaço reservado.
        public DateTime DataTermino { get; set; }

        // Quantidade de participantes adultos informados no orçamento.
        public int QntAdultos { get; set; }

        // Quantidade de participantes crianças informados no orçamento.
        public int QntCriancas { get; set; }

        // Calcula dinamicamente o custo individual do adulto conforme o tipo de evento selecionado.
        public double CustoAdulto
        {
            get
            {
                switch (TipoEvento)
                {
                    case "Casamento":
                        return 140.00;

                    case "Aniversário de Casamento":
                        return 110.00;

                    case "Formatura":
                        return 90.00;

                    default:
                        return 70.00;
                }
            }
        }

        /// Crianças pagam metade do valor do adulto.
        public double CustoCrianca
        {
            get
            {
                return CustoAdulto / 2;
            }
        }

        /// <summary>
        /// Calcula automaticamente a duração da reserva.
        /// </summary>
        public int DuracaoDias
        {
            get
            {
                TimeSpan diferenca = DataTermino.Date - DataInicio.Date;

                int dias = diferenca.Days;

                return dias <= 0 ? 1 : dias;
            }
        }

        /// Calcula o valor total do orçamento.
        public double CustoTotal
        {
            get
            {
                double totalAdultos = QntAdultos * CustoAdulto;
                double totalCriancas = QntCriancas * CustoCrianca;

                return totalAdultos + totalCriancas;
            }
        }
    }
}