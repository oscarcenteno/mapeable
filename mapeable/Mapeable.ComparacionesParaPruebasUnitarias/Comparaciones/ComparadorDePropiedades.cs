using System.Collections.Generic;
using ManejoDePropiedades;
using System.Linq;

namespace Comparaciones
{
    public class ComparadorDePropiedades
    {
        private object elObjeto;

        private IEnumerable<Propiedad> lasPropiedades;
        public ComparadorDePropiedades(object elObjeto)
        {
            this.elObjeto = elObjeto;
            ObtengaLasPropiedadesDelTipo();
        }

        private void ObtengaLasPropiedadesDelTipo()
        {
            BuscadorDePropiedadesLegibles elBuscador = new BuscadorDePropiedadesLegibles(elObjeto.GetType());
            lasPropiedades = elBuscador.EncuentreLasPropiedadesLegibles();
        }

        public bool DetermineSiEsIgualQue(object otroObjeto)
        {
            bool todasSonIguales = false;
            todasSonIguales = true;

            foreach (Propiedad unaPropiedad in lasPropiedades)
            {
                bool esIgual = false;
                string elNombre = null;
                elNombre = unaPropiedad.Nombre;

                ComparadorDeUnaPropiedad elComparador = new ComparadorDeUnaPropiedad(elNombre, elObjeto.GetType());
                esIgual = elComparador.LaPropiedadEsIgual(elObjeto, otroObjeto);
                todasSonIguales = todasSonIguales & esIgual;
            }

            return todasSonIguales;
        }
    }
}