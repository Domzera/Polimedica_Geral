using Microsoft.EntityFrameworkCore;

namespace PolimedicaGeral.Models
{
    public class Roteiro
    {
        public int Id { get; set; }
        public bool Entregue { get; set; }
        public DateOnly Data { get; set; }
        public string Cliente { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Observação { get; set; } = null!;
        [Precision(18, 2)]
        public Decimal Cartao { get; set; }
        public string Vendedor { get; set; } = null!;
        public bool Quitado { get; set; }
        public string Numero { get; set; } = null!;
        [Precision(18,2)]
        public Decimal Pagamento { get; set; }
        [Precision(18,2)]
        public Decimal Troco { get; set; }
        public string Responsavel { get; set; } = null!;
    }
}
