Imports System.ComponentModel
Imports System.Runtime

Namespace LanguageExtensions
    Public Module GenericExtensions

        ' for generic interface IEnumerable<T>
        <CompilerServices.Extension>
        Public Function FlattenToString(Of T)(source As IEnumerable(Of T), separator As String) As String
            If source Is Nothing Then
                Throw New ArgumentException("Parameter source can not be null.")
            End If

            If String.IsNullOrWhiteSpace(separator) Then
                Throw New ArgumentException("Parameter separator can not be null or empty.")
            End If

            Dim array() As String = source.
                    Where(Function(item) item IsNot Nothing).
                    Select(Function(item) item.ToString()).
                    ToArray()

            Return String.Join(separator, array)

        End Function
        ' for interface IEnumerable
        <CompilerServices.Extension>
        Public Function FlattenToString(source As IEnumerable, separator As String) As String
            If source Is Nothing Then
                Throw New ArgumentException("Parameter source can not be null.")
            End If

            If String.IsNullOrWhiteSpace(separator) Then

                Throw New ArgumentException("Parameter separator can not be null or empty.")
            End If

            Dim array() As String = source.Cast(Of Object)().
                    Where(Function(n) n IsNot Nothing).
                    Select(Function(n) n.ToString()).
                    ToArray()

            Return String.Join(separator, array)

        End Function

        <CompilerServices.Extension>
        Public Function Convert(Of T)(sender As String) As T
            Try

                Dim converter = TypeDescriptor.GetConverter(GetType(T))

                If converter IsNot Nothing Then
                    Return CType(converter.ConvertFromString(sender), T)
                End If

                Return Nothing

            Catch e As NotSupportedException
                Return Nothing
            End Try

        End Function
        <CompilerServices.Extension>
        Public Function GenericTryParse(Of T)(input As String, <InteropServices.Out()> ByRef value As T) As Boolean
            Dim converter = TypeDescriptor.GetConverter(GetType(T))

            If converter IsNot Nothing AndAlso converter.IsValid(input) Then
                value = CType(converter.ConvertFromString(input), T)
                Return True
            End If
            value = Nothing
            Return False
        End Function

        <CompilerServices.Extension>
        Public Function StringToType(Of T)(sender As String) As T
            Return CType(System.Convert.ChangeType(sender, GetType(T)), T)
        End Function
        <Runtime.CompilerServices.Extension>
        Public Function StringToType(Of T As ICollection(Of TE), TE)(sender As String) As TE()
            Return sender.Split(","c).Select(Function(item) CType(System.Convert.ChangeType(item, GetType(TE)), TE)).ToArray()
        End Function
    End Module
End Namespace