using System;
namespace Comparaciones
{
    public class ComparadorBase
    {
        public bool EsIgualQue(object unObjeto, object otroObjeto)
        {
            if (AmbosSonNulos(unObjeto, otroObjeto))
            {
                return true;
            }
            else {
                return DetermineSiSonIgualesPorTipoYPropiedad(unObjeto, otroObjeto);
            }
        }

        private bool DetermineSiSonIgualesPorTipoYPropiedad(object unObjeto, object otroObjeto)
        {
            if (NoHayNulos(unObjeto, otroObjeto))
            {
                return DetermineSiSonIgualesPorTipo(unObjeto, otroObjeto);
            }
            else {
                return false;
            }
        }

        private bool DetermineSiSonIgualesPorTipo(object unObjeto, object otroObjeto)
        {
            if (TienenElMismoTipo(unObjeto, otroObjeto))
            {
                return DetermineSiSusPropiedadesSonIguales(unObjeto, otroObjeto);
            }
            else {
                return false;
            }
        }

        private static bool AmbosSonNulos(object unObjeto, object otroObjeto)
        {
            return unObjeto == null & otroObjeto == null;
        }

        private bool TienenElMismoTipo(object unObjeto, object otroObjeto)
        {
            Type unTipo = ObtengaElTipo(unObjeto);
            Type otroTipo = ObtengaElTipo(otroObjeto);

            return SusTiposSonElMismo(unTipo, otroTipo);
        }

        private static bool SusTiposSonElMismo(Type unTipo, Type otroTipo)
        {
            return Type.Equals(unTipo, otroTipo);
        }

        private static Type ObtengaElTipo(object unObjeto)
        {
            return unObjeto.GetType();
        }

        private bool NoHayNulos(object unObjeto, object otroObjeto)
        {
            return !(unObjeto == null | otroObjeto == null);
        }

        private bool DetermineSiSusPropiedadesSonIguales(object unObjeto, object otroObjeto)
        {
            return new ComparadorDePropiedades(unObjeto).DetermineSiEsIgualQue(otroObjeto);
        }
    }
}