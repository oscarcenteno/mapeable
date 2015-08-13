Imports System.Runtime.CompilerServices

Public Module Extensiones

    <Extension>
    Public Function EsIgualQue(esteObjeto As Object, otroObjeto As Object) As Boolean

        Dim elComparador As New ComparadorBase()
        Dim sonIguales As Boolean
        sonIguales = elComparador.EsIgualQue(esteObjeto, otroObjeto)

        Return sonIguales

    End Function

    <Extension>
    Public Function EsIgualQueLaColeccion(estaColeccion As IEnumerable(Of Object),
                               otraColeccion As IEnumerable(Of Object)) As Boolean

        Dim elComparador As New ComparadorBaseDeColecciones()
        Dim sonIguales As Boolean
        sonIguales = elComparador.EsIgualQueLaColeccion(estaColeccion, otraColeccion)

        Return sonIguales

    End Function

End Module
