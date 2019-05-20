Imports System.Globalization

Namespace LanguageExtensions

    Public Module TimeSpanExtensions
        ''' <summary>
        ''' Validate all elements in a string array can be converted to a 
        ''' TimeSpan array
        ''' </summary>
        ''' <param name="sender">
        ''' String Array with at least one element
        ''' </param>
        ''' <returns>
        ''' True if all elements are valid TimeSpans, 
        ''' False is at least one element is not a valid TimeSpan
        ''' </returns>
        <Runtime.CompilerServices.Extension>
        Public Function CanConvertToTimeSpanArray(sender() As String) As Boolean
            Dim testValue As TimeSpan
            Return sender.All(Function(input) TimeSpan.TryParse(input, testValue))
        End Function
        ''' <summary>
        ''' Convert a TimeSpan array to a String array
        ''' </summary>
        ''' <param name="sender">
        ''' Integer array with one or more elements
        ''' </param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function TimeSpanArrayToStringArray(sender() As TimeSpan) As String()
            Return Array.ConvertAll(sender,
                                    Function(input)
                                        Return input.ToString()
                                    End Function)
        End Function
        ''' <summary>
        ''' Given a string array assumed to be all TimeSpan return
        ''' only those elements which are TimeSpan. If the string
        ''' array had five elements and only two elements could be
        ''' converted the length of the returning array will be a
        ''' length of 2.
        ''' </summary>
        ''' <param name="sender">
        ''' String Array with at least one element
        ''' </param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function ToTimeSpanArray(sender() As String) As TimeSpan()
            Return Array.ConvertAll(sender,
                                    Function(input)
                                        Dim value As TimeSpan
                                        Return New With
                                       {
                                           .IsTimeSpan = TimeSpan.TryParse(input, value),
                                           .Value = value
                                       }
                                    End Function).
                Where(Function(result) result.IsTimeSpan).
                Select(Function(result) result.Value).
                ToArray()
        End Function

        ''' <summary>
        ''' Given a string array assumed to be all TimeSpan return
        ''' all elements no matter if they can be converted. If
        ''' not convertible their value will default to 00:00:00
        ''' </summary>
        ''' <param name="sender">
        ''' String Array with at least one element
        ''' </param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function ToTimeSpanPreserveArray(sender() As String) As TimeSpan()
            Return Array.ConvertAll(sender,
                                    Function(input)
                                        Dim value As TimeSpan
                                        TimeSpan.TryParse(input, value)
                                        Return value
                                    End Function)
        End Function

        ''' <summary>
        ''' Convert TimeSpan into DateTime
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' Intended to be used when the date part does not matter
        ''' </remarks>
        <Runtime.CompilerServices.Extension>
        Public Function ToDateTime(sender As TimeSpan) As Date
            Return Date.ParseExact(sender.Formatted("hh:mm"), "H:mm", Nothing, DateTimeStyles.None)
        End Function
        ''' <summary>
        ''' Format a TimeSpan with AM PM
        ''' </summary>
        ''' <param name="sender">TimeSpan to format</param>
        ''' <param name="format">Optional format</param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function Formatted(sender As TimeSpan, Optional ByVal format As String = "hh:mm tt") As String
            Return Date.Today.Add(sender).ToString(format)
        End Function
    End Module
End Namespace