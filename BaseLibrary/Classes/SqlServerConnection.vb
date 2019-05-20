Imports BaseLibrary.Interfaces
Imports BaseLibrary.LanguageExtensions

Namespace Classes
    Public MustInherit Class SqlServerConnection
        Inherits BaseExceptionProperties
        Implements IConnection

        ''' <summary>
        ''' This points to your database server
        ''' </summary>
        Protected DatabaseServer As String = ""
        ''' <summary>
        ''' Gets or sets the name of the database associated with the connection.
        ''' </summary>
        Protected DefaultCatalog As String = ""
        ''' <summary>
        ''' Gets or sets a Boolean value that indicates whether User ID and Password are specified 
        ''' in the connection (when false) or whether the current Windows account credentials are used 
        ''' for authentication (when true).
        ''' </summary>
        Protected IntegratedSecurity As Boolean = True
        ''' <summary>
        ''' Valid user name located in the database
        ''' </summary>
        Protected UserAccountName As String
        ''' <summary>
        ''' Password associated with UserAccountName
        ''' </summary>
        Protected UserAccountPassword As String
        ''' <summary>
        ''' Returns a connection string for windows authentication or with user name and password
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property ConnectionString As String Implements IConnection.ConnectionString
            Get
                If HasUserNameAndPassword() Then
                    Return $"Data Source={DatabaseServer};Initial Catalog={DefaultCatalog};User Id={UserAccountName};Password = {UserAccountPassword}"
                Else
                    Return $"Data Source={DatabaseServer};Initial Catalog={DefaultCatalog};Integrated Security={IntegratedSecurity}"
                End If
            End Get
        End Property
        Private Function HasUserNameAndPassword() As Boolean
            Return Not UserAccountName.IsNullOrWhiteSpace() AndAlso Not UserAccountPassword.IsNullOrWhiteSpace()
        End Function
    End Class
End Namespace