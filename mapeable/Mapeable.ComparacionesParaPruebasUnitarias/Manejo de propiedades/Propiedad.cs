using System;
namespace ManejoDePropiedades
{
    public class Propiedad
    {
        public string Nombre { get; set; }
        public Type Tipo { get; set; }
        public bool SePuedeEscribir { get; set; }
        public bool SePuedeLeer { get; set; }
        public Type TipoDeLaClase { get; set; }

        public bool EsIgualQue(Propiedad otra)
        {
            bool sonIguales = false;

            if (Nombre.Equals(otra.Nombre) & Tipo.Equals(otra.Tipo))
            {
                sonIguales = true;
            }

            return sonIguales;
        }

    }
}