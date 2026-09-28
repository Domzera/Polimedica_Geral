using Microsoft.EntityFrameworkCore;

namespace PolimedicaGeral.DTO
{
    public class RoteiroDto
    {
        public DateOnly? Data { get; set; }
        public string? Cliente { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? Observação { get; set; }
        [Precision(18, 2)]
        public Decimal Cartao { get; set; }
        public string? Vendedor { get; set; }
        public string? Numero { get; set; }
        [Precision(18, 2)]
        public Decimal Pagamento { get; set; }
        [Precision(18, 2)]
        public Decimal Troco { get; set; }
        public string? Responsavel { get; set; }
    }
}
