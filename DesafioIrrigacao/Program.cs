using System;
using System.Collections.Generic;

namespace DesafioIrrigacao
{
    class Program
    {
        static void Main(string[] args)
        {
            //var mock = "5 6 3 2 N 3 4 1 4 5 3 4";

            Console.WriteLine("Formato de input: ");
            Console.WriteLine("tamanhoHortaX tamanhoHortaY posicaoRoboX posicaoRoboY orientacao quantidadeCanteiros (posicao canteiros)");

            var inputs = new DesafioInputs(Console.ReadLine());

            if (inputs.Valid == false)
            {
                Console.Read();
                return;
            }

            // Criar a horta.
            var horta = new Horta(inputs.TamanhoHorta);

            // Cria o robo. Posição inicial e orientação.
            var robo = new RobotPower(inputs.OrientacaoRobo, inputs.PosicaoRobo);

            // Faz a sequencia de comandos para irrigar todos os canteiros especificados
            var sequenciaComandos = horta.GerarSequenciaDeAcoesParaIrrigacao(robo, inputs.Canteiros);

            PrintCaminho(sequenciaComandos);

            Console.WriteLine($"Orientação Final: {robo.Orientacao}");
            Console.ReadLine();
        }

        static void PrintCaminho(string input)
        {
            Console.Write("Caminho: ");
            for(var i = 0; i < input.Length; i++)
            {
                if( i==0)
                {
                    Console.Write($"{input[i]}");
                }
                else
                {
                    Console.Write($" {input[i]}");
                }
            }

            Console.Write(Environment.NewLine);
        }
    }
}
