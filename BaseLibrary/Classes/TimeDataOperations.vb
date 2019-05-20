Imports System.Data.SqlClient

Namespace Classes
    Public Class TimeDataOperations
        Inherits SqlServerConnection

        Public Sub New()
            ' Change this to your server name or .\SQLEXPRESS
            DatabaseServer = "KARENS-PC"
            DefaultCatalog = "DateTimeDatabase"
        End Sub
        Public Function ReadHours() As List(Of TimeSpanItem)
            Dim timeList As New List(Of TimeSpanItem)

            Dim selectStatement As String = "SELECT id,TimeValue FROM dbo.HoursTable"

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn}
                    cmd.CommandText = selectStatement

                    cn.Open()

                    Dim reader = cmd.ExecuteReader()
                    While reader.Read()
                        timeList.Add(New TimeSpanItem() With
                                        {
                                            .Id = reader.GetInt32(0),
                                            .TimeSpan = reader.GetTimeSpan(1)
                                        })
                    End While
                End Using
            End Using

            Return timeList

        End Function
    End Class
End Namespace