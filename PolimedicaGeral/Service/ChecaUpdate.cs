
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

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
                    velho = novo;
                }
            }
            return velho ;
        }
    }
}
