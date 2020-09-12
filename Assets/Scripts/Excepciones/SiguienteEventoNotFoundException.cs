using System;

namespace Assets.Scripts.Excepciones
{
    public class SiguienteEventoNotFoundException : Exception
    {
        public SiguienteEventoNotFoundException(string message) : base(message)
        {
        }
    }
}