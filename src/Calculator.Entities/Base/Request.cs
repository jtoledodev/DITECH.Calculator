using System;

namespace Calculator.Entities.Base
{
    public abstract class Request
    {
        public string IdSeguimiento { get; set; }

        public DateTime FechaOperacion { get; set; }

        public virtual RegistroDiario ToRegistroDiario(string resultado)
        {
            var result = new RegistroDiario
            {
                IdSeguimiento = IdSeguimiento,
                FechaHora = DateTime.Now,
                Operacion = this.GetType().Name.Replace("Request", string.Empty),
                Calculo = $"{this.ToString()} = {resultado}"
            };

            return result;
        }
    }
}