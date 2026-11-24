
namespace PolimedicaGeral.Service
{
    public class ChecaUpdate
    {
        public string CheckUpdateString(string velho, string novo)
        {
            if (!velho.Equals(novo))
            {
                if (!string.IsNullOrEmpty(novo))
                {
                    return novo;
                }
            }
                return velho;
        }

        public decimal CheckUpdateNumber(decimal velho, decimal novo)
        {
            if(!novo.Equals(0))
            {
                if(novo != velho)
                {
                    return novo;
                }
            }
            return velho;
        }

        public int ChecaUpdateInteger(int velho, int novo)
        {
            if (!novo.Equals(0))
            {
                if (novo != velho)
                {
                    return novo;
                }
            }
            return velho;
        }

        public DateOnly ChecaUpdateData(DateOnly? velha, DateOnly? nova)
        {
            if (!nova.Equals(0))
            {
                if(nova != velha)
                {
                    return (DateOnly)nova;
                }
            }
            return (DateOnly)velha;
        }
    }
}
