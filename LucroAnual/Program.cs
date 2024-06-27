using System;
using System.Linq;

namespace LucroAnual
{
    internal class Program
    {
        static void Main()
        {
            // array pra representar numero de dias do ano
            double[] faturamento = new double[365];

            // preenche array co valores aleatorios
            Random random = new Random();
            for (int i = 0; i < faturamento.Length; i++)
            {
                // valores fictício entre 0 e 1000, com alguns dias de faturamento zero
                faturamento[i] = random.NextDouble() < 0.2 ? 0 : random.Next(100, 1001);
            }

            CalcularEstatisticas(faturamento);
        }

        static void CalcularEstatisticas(double[] faturamento)
        {
            // filtrar dias com faturamento maior que zero
            var faturamentoFiltrado = faturamento.Where(valor => valor > 0).ToArray();

            if (faturamentoFiltrado.Length == 0)
            {
                Console.WriteLine("Todos os dias possuem faturamento zero.");
                return;
            }

            // calcular o menor e maior valor de faturamento
            double menorFaturamento = faturamentoFiltrado.Min();
            double maiorFaturamento = faturamentoFiltrado.Max();

            // calcular a média anual de faturamento
            double somaFaturamento = faturamentoFiltrado.Sum();
            int diasComFaturamento = faturamentoFiltrado.Length;
            double mediaFaturamento = somaFaturamento / diasComFaturamento;

            // contar o número de dias com faturamento acima da média
            int diasAcimaDaMedia = faturamentoFiltrado.Count(valor => valor > mediaFaturamento);

            // mostrar resultados
            Console.WriteLine($"Menor valor de faturamento: {menorFaturamento}");
            Console.WriteLine($"Maior valor de faturamento: {maiorFaturamento}");
            Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
        }
    }
}
