
namespace PolimedicaGeral.Service
{
    public class ChecaUpdate
    {
        public string CheckUpdateString(string velho, string novo)
        {
            if (velho.Equals(novo)){}

            return novo;
        }

        public decimal CheckUpdateNumber(decimal velho, decimal novo)
        {
            if (velho == novo){}

            return novo;
        }
    }
}
