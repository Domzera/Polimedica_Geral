namespace PolimedicaGeral.Service
{
    public class CheckAddRoteiro
    {

        //Vai verificar se cada campo não está nulo ou vazio.
        public async Task<IResult> CheckRoteiro(string atributo,string nomeCampo)
        {
            if (String.IsNullOrEmpty(atributo)) // Checa se o campo ATRIBUTO está vazio ou nulo.
            {
                var erros = new Dictionary<string, string[]> // Cria um Texto de ERRO para o retorno.
                {
                    // A primeira STRING é 'nameof e a segunda é a mensagem de erro.
                    {nameof(atributo), new string[] { $"O campo {nomeCampo} não pode ser nulo ou vazio." }  }
                };
                return Results.ValidationProblem(erros); // Retorna o ERRO de validação.
            }
            Console.WriteLine($"Campo {nomeCampo} preenchido corretamente: {atributo}"); // Loga no console que o campo está correto.

            return Results.Ok(); // Retorna OK se o campo ATRIBUTO estiver preenchido corretamente.
        }
    }
}
