Imports System.Reflection

Public Class BuscadorDePropiedadesEscribibles

    Private elTipo As Type

    Public Sub New(elTipo As Type)
        Me.elTipo = elTipo
    End Sub

    Private lasPropiedadesEscribibles As IList(Of Propiedad)
    Public Function EncuentreLasPropiedadesEscribibles() As IEnumerable(Of Propiedad)
        ObtengaLosMiembrosPublicosDeInstancia()
        ListeLosQueSonPropiedades()
        ListeLasPropiedadesEscribibles()

        Return lasPropiedadesEscribibles
    End Function

    Dim miembrosPublicosDeInstancia() As MemberInfo
    Private Sub ObtengaLosMiembrosPublicosDeInstancia()
        miembrosPublicosDeInstancia = elTipo.GetMembers(Reflection.BindingFlags.Public _
                                                        Or Reflection.BindingFlags.Instance)
    End Sub

    Dim lasPropiedades As IList(Of PropertyInfo)
    Private Sub ListeLosQueSonPropiedades()
        InicialiceLaListaDePropiedades()
        For Each miembro In miembrosPublicosDeInstancia
            RegistreElMiembroSiEsUnaPropiedad(miembro)
        Next
    End Sub

    Private Sub InicialiceLaListaDePropiedades()
        lasPropiedades = New List(Of PropertyInfo)
    End Sub

    Private Sub ListeLasPropiedadesEscribibles()
        InicialiceLaListaDeEscribibles()
        For Each unaPropiedad In lasPropiedades
            RegistreSiLaPropiedadEsEscribible(unaPropiedad)
        Next
    End Sub

    Private Sub InicialiceLaListaDeEscribibles()
        lasPropiedadesEscribibles = New List(Of Propiedad)
    End Sub

    Private Sub RegistreSiLaPropiedadEsEscribible(unaPropiedad As PropertyInfo)
        If LaPropiedadEsEscribible(unaPropiedad) Then
            RegistreComoUnaPropiedadEscribible(unaPropiedad)
        End If
    End Sub

    Private Function LaPropiedadEsEscribible(unaPropiedad As PropertyInfo) As Boolean
        Return unaPropiedad.CanWrite
    End Function

    Private Sub RegistreComoUnaPropiedadEscribible(unaPropiedad As PropertyInfo)
        Dim nuevaPropiedad As New Propiedad
        nuevaPropiedad.Nombre = unaPropiedad.Name
        nuevaPropiedad.Tipo = unaPropiedad.PropertyType.Name
        lasPropiedadesEscribibles.Add(nuevaPropiedad)
    End Sub

    Private Sub RegistreElMiembroSiEsUnaPropiedad(miembro As MemberInfo)
        If ElMiembroEsUnaPropiedad(miembro) Then
            RegistreComoUnaPropiedad(miembro)
        End If
    End Sub

    Private Function ElMiembroEsUnaPropiedad(miembro As MemberInfo) As Boolean
        Return miembro.MemberType = MemberTypes.Property
    End Function

    Private Sub RegistreComoUnaPropiedad(miembro As MemberInfo)
        lasPropiedades.Add(miembro)
    End Sub

End Class
