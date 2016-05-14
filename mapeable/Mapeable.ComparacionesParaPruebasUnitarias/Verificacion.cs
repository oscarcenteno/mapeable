using Mapeable.Comparaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Mapeable.ComparacionesParaPruebasUnitarias
{
    public static class Verificacion
    {
        public static void SonIguales(object elResultadoEsperado, object elResultadoObtenido)
        {
            ComparadorBase elComparador = new ComparadorBase();
            if (!elComparador.EsIgualQue(elResultadoEsperado, elResultadoObtenido))
            {
                throw new AssertFailedException("Las propiedades son diferentes");
            }
        }

        public static void LasListasSonIguales(
            IEnumerable<object> elResultadoEsperado, 
            IEnumerable<object> elResultadoObtenido)
        {
            ComparadorBaseDeColecciones elComparador = new ComparadorBaseDeColecciones();
            if (!elComparador.EsIgualQueLaColeccion(elResultadoEsperado, elResultadoObtenido))
            {
                throw new AssertFailedException("Los elementos son diferentes");
            }
        }
    }
}