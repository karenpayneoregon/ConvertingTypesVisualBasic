Namespace CodeModules
    Public Module WindowHelpers
        ''' <summary>
        ''' Center window by window handle
        ''' </summary>
        ''' <param name="pHandle">Handle of window to center on the screen</param>
        Public Sub CenterWindowOnScreen(pHandle As Window)

            Dim screenWidth As Double = SystemParameters.PrimaryScreenWidth
            Dim screenHeight As Double = SystemParameters.PrimaryScreenHeight
            Dim windowWidth As Double = pHandle.Width
            Dim windowHeight As Double = pHandle.Height

            pHandle.Left = (screenWidth / 2) - (windowWidth / 2)
            pHandle.Top = (screenHeight / 2) - (windowHeight / 2)
        End Sub
    End Module
End Namespace