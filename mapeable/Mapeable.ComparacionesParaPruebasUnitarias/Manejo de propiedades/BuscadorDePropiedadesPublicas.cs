using System;
using System.Collections.Generic;
using System.Reflection;

namespace ManejoDePropiedades
{
    public class BuscadorDePropiedadesPublicas
    {
        private Type elTipo;
        MemberInfo[] losMiembrosPublicosDeInstancia;

        private IList<Propiedad> lasPropiedades;
        public BuscadorDePropiedadesPublicas(Type elTipo)
        {
            this.elTipo = elTipo;
        }

        public IEnumerable<Propiedad> EncuentreLasPropiedadesPublicas()
        {
            ObtengaLosMiembrosPublicosDeInstancia();
            EncuentreLosQueSonPropiedades();

            return lasPropiedades;
        }

        private void ObtengaLosMiembrosPublicosDeInstancia()
        {
            dynamic losFiltros = BindingFlags.Public | BindingFlags.Instance;
            losMiembrosPublicosDeInstancia = elTipo.GetMembers(losFiltros);
        }

        private void EncuentreLosQueSonPropiedades()
        {
            InicialiceLaListaDePropiedades();
            foreach (MemberInfo miembro in losMiembrosPublicosDeInstancia)
            {
                RegistreElMiembroSiEsUnaPropiedad(miembro);
            }
        }

        private void InicialiceLaListaDePropiedades()
        {
            lasPropiedades = new List<Propiedad>();
        }

        private void RegistreLaPropiedad(PropertyInfo unaPropiedad)
        {
            Propiedad nuevaPropiedad = new Propiedad();
            nuevaPropiedad.Nombre = unaPropiedad.Name;
            nuevaPropiedad.Tipo = unaPropiedad.PropertyType;
            nuevaPropiedad.SePuedeEscribir = unaPropiedad.CanWrite;
            nuevaPropiedad.SePuedeLeer = unaPropiedad.CanRead;
            lasPropiedades.Add(nuevaPropiedad);
        }

        private void RegistreElMiembroSiEsUnaPropiedad(MemberInfo miembro)
        {
            if (ElMiembroEsUnaPropiedad(miembro))
            {
                PropertyInfo laPropiedad = (PropertyInfo)miembro;
                RegistreLaPropiedad(laPropiedad);
            }
        }

        private bool ElMiembroEsUnaPropiedad(MemberInfo miembro)
        {
            return miembro.MemberType == MemberTypes.Property;
        }
    }
}