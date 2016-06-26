Imports System.Reflection
Imports SkyEditor.Core.IO
Imports SkyEditor.Core.Utilities
Imports SkyEditor.SaveEditor.PKHeXIntegration.ViewModels

Public Class PKHeXSaveFileOpener
    Implements IFileOpener

    Public Function OpenFile(fileType As TypeInfo, filename As String, provider As IOProvider) As Task(Of Object) Implements IFileOpener.OpenFile
        Dim rawFile = PKHeX.SaveUtil.getVariantSAV(provider.ReadAllBytes(filename))
        'Todo: use a more specific view model for Gen4, Gen5, and Gen6.
        Dim viewModel As New BasePkhexSaveWrapper
        viewModel.Model = rawFile
        viewModel.Filename = filename

        Return Task.FromResult(DirectCast(viewModel, Object))
    End Function

    Public Function SupportsType(fileType As TypeInfo) As Boolean Implements IFileOpener.SupportsType
        Return ReflectionHelpers.IsOfType(fileType, GetType(PKHeX.SaveFile).GetTypeInfo, False)
    End Function
End Class
