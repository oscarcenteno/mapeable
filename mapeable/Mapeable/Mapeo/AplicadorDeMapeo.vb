Imports System.Reflection

Class AplicadorDeMapeo(Of ClaseOrigen, ClaseDestino)

    Dim objetoOrigen As ClaseOrigen
    Dim objetoDestino As ClaseDestino

    Public Sub New(objetoOrigen As ClaseOrigen, objetoDestino As ClaseDestino)
        Me.objetoOrigen = objetoOrigen
        Me.objetoDestino = objetoDestino
    End Sub

    Dim elMapeo As MapeoDePropiedad(Of ClaseOrigen, ClaseDestino)
    Public Sub ApliqueElMapeo(elMapeo As MapeoDePropiedad(Of ClaseOrigen, ClaseDestino))
        Me.elMapeo = elMapeo

        ObtengaElValorOrigen()
        AsigneLaPropiedadAlDestino()

    End Sub

    Dim elValorOrigen As Object
    Private Sub ObtengaElValorOrigen()
        Dim elTipoDelOrigen As Type = objetoOrigen.GetType()
        Dim laPropiedadOrigen As PropertyInfo
        laPropiedadOrigen = elTipoDelOrigen.GetProperty(elMapeo.Origen.Nombre, BindingFlags.Public Or BindingFlags.Instance)
        elValorOrigen = laPropiedadOrigen.GetValue(objetoOrigen, Nothing)
    End Sub

    Private Sub AsigneLaPropiedadAlDestino()
        Dim elTipoDelDestino As Type = objetoDestino.GetType()
        Dim laPropiedadDestino As PropertyInfo
        laPropiedadDestino = elTipoDelDestino.GetProperty(elMapeo.Destino.Nombre, BindingFlags.Public Or BindingFlags.Instance)
        laPropiedadDestino.SetValue(objetoDestino, elValorOrigen, Nothing)
    End Sub

End Class
