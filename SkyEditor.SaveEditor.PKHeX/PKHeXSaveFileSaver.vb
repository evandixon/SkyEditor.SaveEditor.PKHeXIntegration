Imports SkyEditor.Core.IO

Public Class PKHeXSaveFileSaver
    Implements IFileSaver

    Public Function GetDefaultExtension(model As Object) As String Implements IFileSaver.GetDefaultExtension
        'Todo: implement default extension
        Return Nothing
    End Function

    Public Function Save(model As Object, provider As IOProvider) As Task Implements IFileSaver.Save
        Throw New NotSupportedException
    End Function

    Public Function Save(model As Object, filename As String, provider As IOProvider) As Task Implements IFileSaver.Save
        'Todo: replace "False" with "filename.ToLower.EndsWith(".dsv"))"
        provider.WriteAllBytes(filename, DirectCast(model, PKHeX.SaveFile).Write(False))
        Return Task.CompletedTask()
    End Function

    Public Function SupportsSave(model As Object) As Boolean Implements IFileSaver.SupportsSave
        Return False
    End Function

    Public Function SupportsSaveAs(model As Object) As Boolean Implements IFileSaver.SupportsSaveAs
        Return TypeOf model Is PKHeX.SaveFile
    End Function
End Class
