using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Models.Enum;
using ExchangeCoinApi.Entities;

namespace ConversionDeMonedas.Helpers
{
    public class Totalconversiones
    {
        public int GetTotalconversiones(Subscription sub)
        {
            int totalconversiones = 0;

            if (sub == Subscription.Free)
            {
                totalconversiones = 10;
            }
            else if (sub == Subscription.Trial)
            {
                totalconversiones = 100;
            }
            else if (sub == Subscription.Pro)
            {
                totalconversiones = -1;
            }
            else
            {
                totalconversiones = 0;
            }
            return totalconversiones;
        }
    }
}
