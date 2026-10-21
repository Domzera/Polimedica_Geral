
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
            if (velho != novo)
            {
                if (novo.Equals(""))
                {
                    return novo=0;
                }
                return novo;
            }

            return velho;
        }
    }
}
