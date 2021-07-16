using System.Collections.Generic;

namespace DesafioIrrigacao
{
    public class Horta
    {
        public Tamanho Tamanho { get; private set; }

        public Horta(Tamanho tamanho)
        {
            Tamanho = tamanho;
        }

        public string GerarSequenciaDeAcoesParaIrrigacao(IRobo robo, IEnumerable<Posicao> canteiros)
        {
            var sequenciaComandos = "";

            foreach (var canteiro in canteiros)
            {
                sequenciaComandos += CaminharHorizontalmente(robo, canteiro);

                sequenciaComandos += CaminharVerticalmente(robo, canteiro);

                sequenciaComandos += robo.Irrigar(canteiro);
            }

            return sequenciaComandos;
        }

        /// <summary>
        /// Anda com o robô até alcançar a mesma coluna do destino do eixo Y
        /// </summary>
        /// <param name="robo"></param>
        /// <param name="canteiro"></param>
        /// <returns></returns>
        private string CaminharVerticalmente(IRobo robo, Posicao canteiro)
        {
            var sequenciaComandos = "";

            while (robo.Posicao.Y != canteiro.Y)
            {
                // Andar para a Direita (Leste)
                if (robo.Posicao.Y < canteiro.Y)
                {
                    sequenciaComandos += robo.Girar_Norte();
                    sequenciaComandos += robo.Andar();
                }
                else // Andar para Esquerda (Oeste)
                {
                    sequenciaComandos += robo.Girar_Sul();
                    sequenciaComandos += robo.Andar();
                }
            }

            return sequenciaComandos;
        }

        /// <summary>
        /// Anda com o robô até alcançar a mesma coluna do destino do eixo X
        /// </summary>
        /// <param name="robo"></param>
        /// <param name="canteiro"></param>
        /// <returns></returns>
        private string CaminharHorizontalmente(IRobo robo, Posicao canteiro)
        {
            var sequenciaComandos = "";
            while (robo.Posicao.X != canteiro.X)
            {
                // Andar para a Direita (Leste)
                if (robo.Posicao.X < canteiro.X)
                {
                    sequenciaComandos += robo.Girar_Leste();
                    sequenciaComandos += robo.Andar();
                }
                else // Andar para Esquerda (Oeste)
                {
                    sequenciaComandos += robo.Girar_Oeste();
                    sequenciaComandos += robo.Andar();
                }
            }

            return sequenciaComandos;
        }
    }
}
