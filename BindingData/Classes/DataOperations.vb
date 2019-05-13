Namespace Classes
    ''' <summary>
    ''' Simulate loading data from a file or database.
    ''' </summary>
    Public Class DataOperations

        Public Function LoadData() As List(Of Person)
            Dim Month = Now.Month
            Dim Year = Now.Year

            Return New List(Of Person)() From {
                    New Person With {.Id = 1, .FirstName = "Bob", .LastName = "Jones", .BirthDate = $"{Month}/2/{Year}"},
                    New Person With {.Id = 2, .FirstName = "Cathy", .LastName = "Adams", .BirthDate = $"{Month}/3/{Year}"},
                    New Person With {.Id = 3, .FirstName = "Dan", .LastName = "Gallagher", .BirthDate = $"{Month}/4/{Year}"},
                    New Person With {.Id = 4, .FirstName = "Ed", .LastName = "White", .BirthDate = $"{Month}/5/{Year}"},
                    New Person With {.Id = 5, .FirstName = "Frank", .LastName = "Le bow", .BirthDate = $"{Month}/10/{Year}"},
                    New Person With {.Id = 6, .FirstName = "George", .LastName = "Henderson", .BirthDate = $"{Month}/7/{Year}"},
                    New Person With {.Id = 7, .FirstName = "Hank", .LastName = "Bellow", .BirthDate = $"{Month}/8/{Year}"},
                    New Person With {.Id = 8, .FirstName = "Mary", .LastName = "Lily", .BirthDate = $"{Month}/9/{Year}"},
                    New Person With {.Id = 9, .FirstName = "Anne", .LastName = "Smith", .BirthDate = $"{Month}/1/{Year}"},
                    New Person With {.Id = 10, .FirstName = "Jane", .LastName = "House", .BirthDate = $"{Month}/10/{Year}"},
                    New Person With {.Id = 11, .FirstName = "Ken", .LastName = "Hicks", .BirthDate = $"{Month}/11/{Year}"},
                    New Person With {.Id = 12, .FirstName = "Larry", .LastName = "Payne", .BirthDate = $"{Month}/12/{Year}"}
                }

        End Function
    End Class
End Namespace