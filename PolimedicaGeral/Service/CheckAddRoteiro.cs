namespace PolimedicaGeral.Service
{
    public class CheckAddRoteiro
    {
        public string ChecaString(string atributo, string nomeCampo)
        {
            //Verifica se os campos estão vazios
            if (string.IsNullOrEmpty(atributo))
            {
                //Se estiver vazio adiciona a mensagem com o nome do Campo na string
                return $"O {nomeCampo} não pode ser vazio.\n";
            }
            //Se estiver preenchido retorna vazio para continuar a verificação
            return "";
        }
        public decimal SetDecimal(Decimal atributo) {
            //Verifica se o valor veio VAZIO ou com ZERO
            if(atributo.Equals("") || atributo == 0)
            {
                //Se o valor for VAZIO ou ZERO, ele recebe 0,0 para ser salvo sem problemas no BD
                return 0.0m;
            }
            // Se ele vier com valor, ele é retornado sem problemas
            return atributo;
        }
    }
}
