Imports System.Reflection
Public Class BuscadorDePropiedadesPublicas

    Private elTipo As Type

    Public Sub New(elTipo As Type)
        Me.elTipo = elTipo
    End Sub

    Private lasPropiedades As IList(Of Propiedad)
    Public Function EncuentreLasPropiedadesPublicas() As IEnumerable(Of Propiedad)
        ObtengaLosMiembrosPublicosDeInstancia()
        EncuentreLosQueSonPropiedades()

        Return lasPropiedades
    End Function

    Dim miembrosPublicosDeInstancia() As MemberInfo
    Private Sub ObtengaLosMiembrosPublicosDeInstancia()
        Dim publicosYDeInstancia = BindingFlags.Public Or BindingFlags.Instance
        miembrosPublicosDeInstancia = elTipo.GetMembers(publicosYDeInstancia)
    End Sub

    Private Sub EncuentreLosQueSonPropiedades()
        InicialiceLaListaDePropiedades()
        For Each miembro In miembrosPublicosDeInstancia
            RegistreElMiembroSiEsUnaPropiedad(miembro)
        Next
    End Sub

    Private Sub InicialiceLaListaDePropiedades()
        lasPropiedades = New List(Of Propiedad)
    End Sub

    Private Sub RegistreLaPropiedad(unaPropiedad As PropertyInfo)
        Dim nuevaPropiedad As New Propiedad
        nuevaPropiedad.Nombre = unaPropiedad.Name
        nuevaPropiedad.Tipo = unaPropiedad.PropertyType.Name
        nuevaPropiedad.SePuedeEscribir = unaPropiedad.CanWrite
        nuevaPropiedad.SePuedeLeer = unaPropiedad.CanRead
        lasPropiedades.Add(nuevaPropiedad)
    End Sub

    Private Sub RegistreElMiembroSiEsUnaPropiedad(miembro As MemberInfo)
        If ElMiembroEsUnaPropiedad(miembro) Then
            RegistreLaPropiedad(miembro)
        End If
    End Sub

    Private Function ElMiembroEsUnaPropiedad(miembro As MemberInfo) As Boolean
        Return miembro.MemberType = MemberTypes.Property
    End Function

End Class
