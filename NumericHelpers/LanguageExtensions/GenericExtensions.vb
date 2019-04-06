Imports System.ComponentModel
Imports System.Runtime
' 
Namespace LanguageExtensions
    Public Module GenericExtensions

        ''' <summary>
        ''' For generic interface IEnumerable&ltT&gt
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="source"></param>
        ''' <param name="separator"></param>
        ''' <returns></returns>
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
        ''' <summary>
        ''' For interface IEnumerable
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="separator"></param>
        ''' <returns></returns>
        <CompilerServices.Extension>
        Public Function FlattenToString(source As IEnumerable, separator As String) As String

            If source Is Nothing Then
                Throw New ArgumentException("Parameter source can not be null.")
            End If

            If String.IsNullOrWhiteSpace(separator) Then
                Throw New ArgumentException("Parameter separator can not be null or empty.")
            End If

            Dim array() As String = source.Cast(Of Object)().
                    Where(Function(item) item IsNot Nothing).
                    Select(Function(item) item.ToString()).
                    ToArray()

            Return String.Join(separator, array)

        End Function

        <CompilerServices.Extension>
        Public Function Convert(Of T)(source As String) As T

            Try
                Dim converter = TypeDescriptor.GetConverter(GetType(T))

                If converter IsNot Nothing Then
                    Return CType(converter.ConvertFromString(source), T)
                End If

                Return Nothing

            Catch e As NotSupportedException
                Return Nothing
            End Try

        End Function
        <CompilerServices.Extension>
        Public Function GenericTryParse(Of T)(sender As String, <InteropServices.Out()> ByRef value As T) As Boolean

            Dim converter = TypeDescriptor.GetConverter(GetType(T))

            If converter IsNot Nothing AndAlso converter.IsValid(sender) Then
                value = CType(converter.ConvertFromString(sender), T)
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
            Return sender.Split(","c).Select(
                Function(item) CType(System.Convert.ChangeType(item, GetType(TE)), TE)).ToArray()
        End Function
        ''' <summary>
        ''' Converts a string to a Nullable type as per T
        ''' </summary>
        ''' <typeparam name="T">Type to convert too</typeparam>
        ''' <param name="sender">String to work from</param>
        ''' <returns>Nullable of T</returns>
        ''' <example>
        ''' <code>
        ''' Dim value = "12".ToNullable(Of Integer)
        ''' If value.HasValue Then
        '''   - use value
        ''' Else
        '''   - do not use value
        ''' </code>
        ''' </example>
        <CompilerServices.Extension>
        Public Function ToNullable(Of T As Structure)(sender As String) As T?

            Dim result As New T?()

            Try
                If Not String.IsNullOrWhiteSpace(sender) Then
                    Dim converter As TypeConverter = TypeDescriptor.GetConverter(GetType(T))
                    result = CType(converter.ConvertFrom(sender), T)

                End If
            Catch
                ' don't care, caller should use HasValue before accessing the value.
            End Try

            Return result

        End Function
    End Module
End Namespace