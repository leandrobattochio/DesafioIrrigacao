namespace DesafioIrrigacao
{
    /// <summary>
    /// Representa as ações de um robô.
    /// </summary>
    public interface IRobo
    {
        enOrientacao Orientacao { get; }
        Posicao Posicao { get; }

        string Irrigar(Posicao canteiro);
        string Andar();
        string Girar_Leste();
        string Girar_Oeste();
        string Girar_Norte();
        string Girar_Sul();
    }

    /// <summary>
    /// Implementa um robô.
    /// </summary>
    public class RobotPower : IRobo
    {
        public RobotPower(enOrientacao orientacao, Posicao posicao)
        {
            Orientacao = orientacao;
            Posicao = posicao;
        }

        public enOrientacao Orientacao { get; private set; }
        public Posicao Posicao { get; private set; }

        public string Andar()
        {
            var direcao = new Vetor(0, 0);

            switch(Orientacao)
            {
                case enOrientacao.Leste:
                    direcao = new Vetor(1, 0);
                    break;
                case enOrientacao.Oeste:
                    direcao = new Vetor(-1, 0);
                    break;

                case enOrientacao.Norte:
                    direcao = new Vetor(0, 1);
                    break;

                case enOrientacao.Sul:
                    direcao = new Vetor(0, -1);
                    break;
            }

            Posicao.AtualizarPosicao(direcao);

            return "M";
        }

        public string Irrigar(Posicao canteiro)
        {
            if(Posicao.X == canteiro.X && Posicao.Y == canteiro.Y)
            {
                return "I";
            }

            return "";
        }

        public string Girar_Leste()
        {
            if (Orientacao == enOrientacao.Leste) return "";

            string sequencia;
            if (Orientacao == enOrientacao.Sul)
                sequencia = "E";
            else if (Orientacao == enOrientacao.Norte)
                sequencia = "D";
            else
                sequencia = "EE";

            Orientacao = enOrientacao.Leste;

            return sequencia;
        }

        public string Girar_Oeste()
        {
            if (Orientacao == enOrientacao.Oeste) return "";

                string sequencia;
            if (Orientacao == enOrientacao.Sul)
                sequencia = "D";
            else if (Orientacao == enOrientacao.Norte)
                sequencia = "E";
            else
                sequencia = "EE";

            Orientacao = enOrientacao.Oeste;
            return sequencia;
        }


        public string Girar_Norte()
        {
            if (Orientacao == enOrientacao.Norte) return "";

            string sequencia;
            if (Orientacao == enOrientacao.Leste)
                sequencia = "E";
            else if (Orientacao == enOrientacao.Oeste)
                sequencia = "D";
            else
                sequencia = "EE";

            Orientacao = enOrientacao.Norte;
            return sequencia;
        }

        public string Girar_Sul()
        {
            if (Orientacao == enOrientacao.Sul) return "";

            string sequencia;
            if (Orientacao == enOrientacao.Leste)
                sequencia = "D";
            else if (Orientacao == enOrientacao.Oeste)
                sequencia = "E";
            else
                sequencia = "EE";

            Orientacao = enOrientacao.Sul;
            return sequencia;
        }
    }
}
