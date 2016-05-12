using Mapeable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComparacionesParaPruebasUnitarias
{
    public static class Verificacion
    {
        public static void SonIguales(object elEsperado, object elObtenido)
        {
            ComparadorBase elComparador = new ComparadorBase();
            if (!elComparador.EsIgualQue(elEsperado, elObtenido))
            {
                throw new AssertFailedException("Las propiedades son diferentes");
            }
        }

        public static void LasListasSonIguales(
            IEnumerable<object> elEsperado, 
            IEnumerable<object> elObtenido)
        {
            ComparadorBaseDeColecciones elComparador = new ComparadorBaseDeColecciones();
            if (!elComparador.EsIgualQueLaColeccion(elEsperado, elObtenido))
            {
                throw new AssertFailedException("Los elementos son diferentes");
            }
        }
    }
}
