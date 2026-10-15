namespace PolimedicaGeral.Models
{
    public class Clientes
    {
        public int id { get; set; }
        public string Cliente { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string LojaPolimedica { get; set; } = null!;

    }
}
