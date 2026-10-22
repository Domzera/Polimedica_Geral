using Microsoft.EntityFrameworkCore;

namespace PolimedicaGeral.DTO
{
    public class RoteiroDto
    {
        public string Cliente { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Observacao { get; set; }
        [Precision(18, 2)]
        public Decimal Cartao { get; set; }
        public string LojaPolimedica { get; set; }
        public string PedidoNf { get; set; }
        [Precision(18, 2)]
        public Decimal DinheiroCheque { get; set; }
        [Precision(18, 2)]
        public Decimal Troco { get; set; }
        public string Vendedor { get; set; }
        public string Responsavel { get; set; }
        public DateOnly? Data { get; set; }
        public string Periodo { get; set; }
    }
}
