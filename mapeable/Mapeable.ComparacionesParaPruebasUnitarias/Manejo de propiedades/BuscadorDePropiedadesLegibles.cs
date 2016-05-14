using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManejoDePropiedades
{
    public class BuscadorDePropiedadesLegibles
    {
        private Type elTipo;
        private IEnumerable<Propiedad> lasPropiedades;

        private IEnumerable<Propiedad> lasPropiedadesLegibles;
        public BuscadorDePropiedadesLegibles(Type elTipo)
        {
            this.elTipo = elTipo;
        }

        public IEnumerable<Propiedad> EncuentreLasPropiedadesLegibles()
        {
            ListeLasPropiedades();
            EncuentreLasLegibles();

            return lasPropiedadesLegibles;
        }

        private void ListeLasPropiedades()
        {
            BuscadorDePropiedadesPublicas elBuscador = new BuscadorDePropiedadesPublicas(elTipo);
            lasPropiedades = elBuscador.EncuentreLasPropiedadesPublicas();
        }

        private void EncuentreLasLegibles()
        {
            lasPropiedadesLegibles = lasPropiedades.Where(c => c.SePuedeLeer);
        }
    }
}