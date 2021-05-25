using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Mernis.KPSPublicSoapClient;

namespace MernisValidator.Data
{
    public class MernisService
    {
        public Task<bool> TcKimlikDogrula(User user)
        {
            bool dogrulamaSonucu = false;
            try
            {
                var mernisClient = new Mernis.KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
                var tcKimlikDogrulamaServisResponse = mernisClient.TCKimlikNoDogrulaAsync(long.Parse(user.TcKimlikNo), user.Ad, user.Soyad, user.DogumTarihi.Year).GetAwaiter().GetResult();
                dogrulamaSonucu = tcKimlikDogrulamaServisResponse.Body.TCKimlikNoDogrulaResult;
            }
            catch (Exception ex)
            {
                dogrulamaSonucu = false;
            }
            return Task.FromResult(dogrulamaSonucu);
        }
    }
}
