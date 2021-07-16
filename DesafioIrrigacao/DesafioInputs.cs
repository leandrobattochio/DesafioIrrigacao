using System;
using System.Collections.Generic;

namespace DesafioIrrigacao
{
    public class DesafioInputs
    {
        public Tamanho TamanhoHorta { get; private set; }
        public Posicao PosicaoRobo { get; private set; }
        public enOrientacao OrientacaoRobo { get; private set; }
        public ICollection<Posicao> Canteiros { get; private set; }

        public bool Valid { get; private set; }

        public DesafioInputs(string inputLine)
        {
            var parts = inputLine.Split(' ');

            if (parts.Length < 6)
            {
                Console.WriteLine("O input não esta no formato esperado.");
                Console.WriteLine("Formato esperado: \"tamanhoHortaX tamanhoHortaY posicaoRoboX posicaoRoboY orientacaoRobo quantidadeCanteiros ((canteiroX canteiroY) * quantidadeCanteiros)\"");

                Valid = false;
                return;
            }

            ParseTamanhoHorta(parts);

            if (!Valid) return;

            ParseRobo(parts);

            if (!Valid) return;

            ParseCanteiros(parts);

            if (!Valid) return;

            Valid = true;
        }

        private void ParseTamanhoHorta(string[] parts)
        {
            try
            {
                var tamanhoHortaX = int.Parse(parts[0]);
                var tamanhoHortaY = int.Parse(parts[1]);

                if (tamanhoHortaX <= 0 || tamanhoHortaY <= 0)
                {
                    Console.WriteLine("Verifique o tamanho informado da horta. Não pode ser negativo ou igual a zero.");
                    Valid = false;
                    return;
                }
                TamanhoHorta = new Tamanho(tamanhoHortaX, tamanhoHortaY);
            }
            catch (FormatException)
            {
                Console.WriteLine("Certifique-se que os tamanhos informados da horta são numeros.");
                Valid = false;
                return;
            }
            Valid = true;
        }

        private void ParseRobo(string[] parts)
        {
            try
            {
                var posicaoRoboX = int.Parse(parts[2]);
                var posicaoRoboY = int.Parse(parts[3]);

                if ((posicaoRoboX > TamanhoHorta.X || posicaoRoboX < 0) ||
                    (posicaoRoboY > TamanhoHorta.Y || posicaoRoboY < 0))
                {
                    Console.WriteLine("A posicao informada para o robo nao e valida. Ele precisa estar dentro dos limites da horta.");
                    Valid = false;
                    return;
                }

                PosicaoRobo = new Posicao(posicaoRoboX, posicaoRoboY);
            }
            catch (FormatException)
            {
                Console.WriteLine("Certifique-se que a posicao informada para o robo sao numeros.");
                Valid = false;
                return;
            }

            var inputOrientacao = parts[4];
            if (inputOrientacao == "N")
            {
                OrientacaoRobo = enOrientacao.Norte;
            }
            else if (inputOrientacao == "S")
            {
                OrientacaoRobo = enOrientacao.Sul;
            }
            else if (inputOrientacao == "L")
            {
                OrientacaoRobo = enOrientacao.Leste;
            }
            else if (inputOrientacao == "O")
            {
                OrientacaoRobo = enOrientacao.Oeste;
            }
            else
            {
                OrientacaoRobo = enOrientacao.Indefinida;
            }

            if (OrientacaoRobo == enOrientacao.Indefinida)
            {
                Console.WriteLine("Digite uma orientação válida para o robo: \"N S L O\"");
                Valid = false;
                return;
            }
            Valid = true;
        }

        private void ParseCanteiros(string[] parts)
        {
            var quantidadeCanteiros = int.Parse(parts[5]);

            if ((6 + (quantidadeCanteiros * 2)) > parts.Length)
            {
                Console.WriteLine("A quantidade de Canteiros não coincide com as posicoes informadas.");
                Valid = false;
                return;
            }

            Canteiros = new List<Posicao>(quantidadeCanteiros);

            for (var i = 6; i < parts.Length; i += 2)
            {
                var canteiro = new Posicao(int.Parse(parts[i]), int.Parse(parts[i + 1]));
                Canteiros.Add(canteiro);
            }
            Valid = true;
        }
    }
}
