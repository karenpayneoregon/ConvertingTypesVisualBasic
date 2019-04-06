Namespace Classes
    Public Class State
        ''' <summary>
        ''' State name
        ''' </summary>
        ''' <returns></returns>
        Public Property Name() As String
        ''' <summary>
        ''' State two letter abbreviation 
        ''' </summary>
        ''' <returns></returns>
        Public Property Code() As String
        ''' <summary>
        ''' For this code sample and in other usages setting
        ''' ToString to in this case Name when setting a list
        ''' of state to a control like a ComboBox there is no need
        ''' to set DisplayMember as ToString is the default for
        ''' what is displayed so in this case we set to show Name
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
End Namespace