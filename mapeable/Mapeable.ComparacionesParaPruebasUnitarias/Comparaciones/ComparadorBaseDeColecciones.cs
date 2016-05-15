using System;
using System.Linq;
using System.Collections.Generic;

namespace Comparaciones
{
    public class ComparadorBaseDeColecciones
    {
        private bool sonIguales;
        private IEnumerable<object> estaColeccion;

        private IEnumerable<object> laOtraColeccion;
        public bool EsIgualQueLaColeccion(IEnumerable<object> estaColeccion, 
            IEnumerable<object> laOtraColeccion)
        {
            this.estaColeccion = estaColeccion;
            this.laOtraColeccion = laOtraColeccion;

            CompareSiSonNulos();
            CompareLasColecciones();

            return sonIguales;
        }

        private void CompareSiSonNulos()
        {
            if (estaColeccion == null & laOtraColeccion == null)
            {
                sonIguales = true;
            }
        }

        private void CompareLasColecciones()
        {
            if (NoHayNulos() && SusTiposSonIguales() && SusTamanosSonIguales())
            {
                sonIguales = true;

                for (int i = 0; i <= estaColeccion.Count() - 1; i++)
                {
                    object unObjecto = null;
                    object otroObjecto = null;

                    unObjecto = estaColeccion.ElementAt(i);
                    otroObjecto = laOtraColeccion.ElementAt(i);

                    ComparadorBase elComparador = new ComparadorBase();
                    sonIguales = sonIguales & elComparador.EsIgualQue(unObjecto, otroObjecto);
                }
            }
        }

        private bool NoHayNulos()
        {
            bool hayNulos = false;
            hayNulos = estaColeccion == null | laOtraColeccion == null;
            return !hayNulos;
        }

        private bool SusTiposSonIguales()
        {
            bool sonElMismoTipo = false;
            if (NoHayNulos())
            {
                Type elTipodeEstaColeccion = estaColeccion.GetType();
                Type elTipoDeLaOtraColeccion = laOtraColeccion.GetType();
                sonElMismoTipo = Type.Equals(elTipodeEstaColeccion, elTipoDeLaOtraColeccion);
            }
            return sonElMismoTipo;
        }

        private bool SusTamanosSonIguales()
        {
            bool tienenElMismoTamano = false;
            if (NoHayNulos() & SusTiposSonIguales())
            {
                tienenElMismoTamano = DetermineSiTienenElMismoTamano();
            }
            return tienenElMismoTamano;
        }

        private bool DetermineSiTienenElMismoTamano()
        {
            bool tienenElMismoTamano = false;
            if (estaColeccion.Count() == laOtraColeccion.Count())
            {
                tienenElMismoTamano = true;
            }
            else {
                tienenElMismoTamano = false;
            }
            return tienenElMismoTamano;
        }

    }
}