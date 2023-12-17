

namespace ExchangeCoin.Models
{
    public class ConvertProcess //Acá usamos un dto que creamos para esta consulta, ya que no queremos que nos quede User -> Contact -> User -> Contact, etc
    {
        public double ValorParaConvertir { get; set; }
        public double VelorConvertido { get; set; }
    }
}