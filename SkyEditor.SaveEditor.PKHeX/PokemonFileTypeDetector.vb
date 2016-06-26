Imports SkyEditor.Core
Imports SkyEditor.Core.IO

Public Class PokemonFileTypeDetector
    Implements IFileTypeDetector

    Public Function DetectFileType(File As GenericFile, Manager As PluginManager) As Task(Of IEnumerable(Of FileTypeDetectionResult)) Implements IFileTypeDetector.DetectFileType
        If PKHeX.SaveUtil.getSAVGeneration(File.RawData) <> -1 Then
            Return Task.FromResult({New FileTypeDetectionResult() With {.FileType = GetType(PKHeX.SaveFile), .MatchChance = 1}}.AsEnumerable)
        Else
            Return Task.FromResult((New List(Of FileTypeDetectionResult)).AsEnumerable)
        End If
    End Function
End Class
