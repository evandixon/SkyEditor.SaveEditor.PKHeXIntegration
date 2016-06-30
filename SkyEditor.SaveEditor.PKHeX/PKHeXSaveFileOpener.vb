Imports System.Reflection
Imports SkyEditor.Core.IO
Imports SkyEditor.Core.Utilities
Imports SkyEditor.SaveEditor.PKHeXIntegration.ViewModels

Public Class PKHeXSaveFileOpener
    Implements IFileOpener

    Public Function OpenFile(fileType As TypeInfo, filename As String, provider As IOProvider) As Task(Of Object) Implements IFileOpener.OpenFile
        Dim rawFile = PKHeX.SaveUtil.getVariantSAV(provider.ReadAllBytes(filename))
        rawFile.FileName = filename
        'Todo: read DeSmuMe footer, if applicable
        Return Task.FromResult(DirectCast(rawFile, Object))
    End Function

    Public Function SupportsType(fileType As TypeInfo) As Boolean Implements IFileOpener.SupportsType
        Return ReflectionHelpers.IsOfType(fileType, GetType(PKHeX.SaveFile).GetTypeInfo, False)
    End Function
End Class
