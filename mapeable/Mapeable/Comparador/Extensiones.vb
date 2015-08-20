Imports System.Runtime.CompilerServices

Public Module Extensiones

    <Extension>
    Public Function EsIgualQue(esteObjeto As Object, elOtroObjeto As Object) As Boolean

        Dim elComparador As New ComparadorBase()
        Dim sonIguales As Boolean
        sonIguales = elComparador.EsIgualQue(esteObjeto, elOtroObjeto)

        Return sonIguales

    End Function

    <Extension>
    Public Function EsIgualQueLaColeccion(estaColeccion As IEnumerable(Of Object),
                               laOtraColeccion As IEnumerable(Of Object)) As Boolean

        Dim elComparador As New ComparadorBaseDeColecciones()
        Dim sonIguales As Boolean
        sonIguales = elComparador.EsIgualQueLaColeccion(estaColeccion, laOtraColeccion)

        Return sonIguales

    End Function

End Module
