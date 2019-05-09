Namespace TestClasses
    Public Class TestBase
        Protected ReadOnly ImperfectStringArrayForConvertingToTimeSpan() As String =
                               {
                                   "0",
                                   "14",
                                   "1:2:3",
                                   "0:0:0.250",
                                   "10.20:30:40.50",
                                   "99.23:59:59.9999999",
                                   "0023:0059:0059.0099",
                                   "23:0:0",
                                   "24:0:0",
                                   "0:59:0",
                                   "0:60:0",
                                   "0:0:59",
                                   "0:0:60",
                                   "10:",
                                   "10:0",
                                   ":10",
                                   "0:10",
                                   "10:20:",
                                   "10:20:0",
                                   ".123",
                                   "0.12:00",
                                   "10.",
                                   "10.12",
                                   "10.12:00"}
    End Class
End Namespace