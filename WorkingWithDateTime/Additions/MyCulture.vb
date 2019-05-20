Imports System.Globalization

Namespace My
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
    Partial Friend Class _Culture
        ''' <summary>
        ''' Date separator for current culture
        ''' </summary>
        ''' <returns></returns>
        Public Function DateSeparator() As String
            Return CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator
        End Function
        ''' <summary>
        ''' Return the Time Separator for current culture
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TimeSeparator() As String
            Return CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator
        End Function
        Public Function CultureList() As CultureInfo()
            Return (
                From T In CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                Order By T.EnglishName).ToArray
        End Function
    End Class
    <HideModuleName()>
    Friend Module Custom_Culture
        Private ReadOnly Instance As New ThreadSafeObjectProvider(Of _Culture)
        ReadOnly Property Culture() As _Culture
            Get
                Return Instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace
