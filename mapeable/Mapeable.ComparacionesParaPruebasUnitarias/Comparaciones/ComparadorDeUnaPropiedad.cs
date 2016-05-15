using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Comparaciones
{
    public class ComparadorDeUnaPropiedad
    {
        private PropertyInfo laPropiedadOrigen;
        private object elValor;
        private object elOtroValor;

        private bool esIgual;
        public ComparadorDeUnaPropiedad(string laPropiedad, Type elTipoDeLaClase)
        {
            BindingFlags losFiltros = BindingFlags.Instance | BindingFlags.Public;
            laPropiedadOrigen = elTipoDeLaClase.GetProperty(laPropiedad, losFiltros);
        }

        public bool LaPropiedadEsIgual(object unObjeto, object otroObjeto)
        {
            Type elTipo = unObjeto.GetType();

            if (EsUnEnumerableGenerico(elTipo))
            {
                ComparadorBaseDeColecciones elComparador = new ComparadorBaseDeColecciones();

                IEnumerable<object> estaColeccion = (IEnumerable<object>)unObjeto;
                IEnumerable<object> laOtraColeccion = (IEnumerable<object>)otroObjeto;

                esIgual = elComparador.EsIgualQueLaColeccion(estaColeccion, laOtraColeccion);
            }
            else
            {
                ObtengaElValor(unObjeto);
                ObtengaElOtroValor(otroObjeto);
                CompareLosValores();
            }

            return esIgual;
        }

        private void ObtengaElOtroValor(object unObjeto)
        {
            elValor = laPropiedadOrigen.GetValue(unObjeto, null);
        }

        private void ObtengaElValor(object otroObjeto)
        {
            elOtroValor = laPropiedadOrigen.GetValue(otroObjeto, null);
        }

        private void CompareLosValores()
        {
            Type elTipo = default(Type);
            elTipo = laPropiedadOrigen.PropertyType;

            if (elTipo.Equals(typeof(string)))
            {
                esIgual = string.Equals(elValor, elOtroValor);
            }
            else if (elTipo.IsClass)
            {
                ComparadorBase elComparador = new ComparadorBase();
                esIgual = elComparador.EsIgualQue(elValor, elOtroValor);
            }
            else {
                esIgual = object.Equals(elValor, elOtroValor);
            }
        }

        private bool EsUnEnumerableGenerico(Type elTipo)
        {
            if (typeof(IEnumerable<object>).IsAssignableFrom(elTipo))
                return true;
            else
                return false;
        }
    }
}