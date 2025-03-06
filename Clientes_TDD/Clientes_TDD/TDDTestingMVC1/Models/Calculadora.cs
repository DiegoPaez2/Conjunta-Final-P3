namespace TDDTestingMVC1.Models
{
    public class Circulo
    {
        public double Radio { get; set; }

        public double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }
    }

}
