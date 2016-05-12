Imports System.Runtime.CompilerServices
Imports System.Linq.Expressions
Imports System.Reflection

Namespace Mapeos
    Module ExtensionesDelComponente

        <Extension>
        Function TransformadaANoGenerica(Of T, TProperty) _
            (func As Func(Of T, TProperty)) _
            As Func(Of Object, Object)

            Return Function(x) func(DirectCast(x, T))
        End Function

        <Extension>
        Function GetMember(laExpresion As LambdaExpression) As MemberInfo
            Dim memberExp = RemoveUnary(laExpresion.Body)

            If memberExp Is Nothing Then
                Return Nothing
            End If

            Return memberExp.Member
        End Function

        Function RemoveUnary(toUnwrap As Expression) As MemberExpression

            If (TypeOf toUnwrap Is UnaryExpression) Then
                Return CType(toUnwrap, UnaryExpression).Operand
            End If

            Return toUnwrap
        End Function
    End Module
End Namespace