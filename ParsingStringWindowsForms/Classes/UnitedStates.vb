Imports System.IO
Imports BaseLibrary
Imports BaseLibrary.Classes

Namespace Classes
    Public Class UnitedStates
        Inherits BaseExceptionProperties
        ''' <summary>
        ''' Read all US state names and abbreviations into a list.
        ''' </summary>
        ''' <returns>List of state names for United States</returns>
        ''' <remarks>
        ''' In an application there may be many states which would be
        ''' better to stored in a database if the application would
        ''' benefit from a database other than just for this.
        ''' </remarks>
        Public Function AmericaStates() As List(Of State)

            mHasException = False

            Dim stateNameList As List(Of State)
            Dim fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "States.csv")

            If File.Exists(fileName) Then
                Try
                    stateNameList = (
                        From line In IO.File.ReadAllLines(fileName)
                        Where line.Length > 0 Let items = line.Split(","c)
                        Select New State With
                            {
                                .Name = items(0),
                                .Code = items(1)
                            }).
                        ToList

                    stateNameList.Insert(0, New State() With {.Name = "Select", .Code = ""})

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    mHasException = True
                    mLastException = ex
                End Try

            End If

            ' ReSharper disable once VBWarnings::BC42104
            ' Here we may not have a list of state which is fine
            ' as assertion will be done by the caller.
            Return stateNameList

        End Function
        Public Function FranceStates() As List(Of State)
            Throw New NotImplementedException
        End Function
        Public Function GermanyStates() As List(Of State)
            Throw New NotImplementedException
        End Function
        Public Function MexicoStates() As List(Of State)
            Throw New NotImplementedException
        End Function
        Public Function JapenStates() As List(Of State)
            Throw New NotImplementedException
        End Function
    End Class
End Namespace