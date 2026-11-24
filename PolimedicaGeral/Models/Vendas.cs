using Microsoft.EntityFrameworkCore;

namespace PolimedicaGeral.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserType { get; set; }
        public DateOnly? Data { get; set; }
        public string? Conta { get; set; }
        [Precision (18, 2)]
        public Decimal Valor { get; set; }
        public int QuantAtend { get; set; }
    }
}
