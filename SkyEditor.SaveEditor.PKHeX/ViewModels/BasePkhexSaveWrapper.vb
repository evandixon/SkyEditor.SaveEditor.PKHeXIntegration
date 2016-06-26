Imports System.ComponentModel
Imports SkyEditor.Core.IO
Imports SkyEditor.Core.UI
Imports SkyEditor.Core.Utilities

Namespace ViewModels
    Public Class BasePkhexSaveWrapper
        Inherits GenericViewModel(Of PKHeX.SaveFile)
        Implements ISavable
        Implements ISavableAs
        Implements INamed
        Implements INotifyPropertyChanged

#Region "Events"
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Public Event FileSaved As ISavable.FileSavedEventHandler Implements ISavable.FileSaved
#End Region

#Region "Properties"
        Public Property Filename As String
            Get
                Return Model.FilePath
            End Get
            Set(value As String)
                Model.FilePath = value
            End Set
        End Property

        Public Property OT As String
            Get
                Return Model.OT
            End Get
            Set(value As String)
                Model.OT = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(OT)))
            End Set
        End Property

        Public ReadOnly Property Name As String Implements INamed.Name
            Get
                If Not String.IsNullOrEmpty(Filename) Then
                    Return IO.Path.GetFileNameWithoutExtension(Filename)
                Else
                    Return Model.ToString
                End If
            End Get
        End Property
#End Region

        Public Sub Save(provider As IOProvider) Implements ISavable.Save
            provider.WriteAllBytes(Filename, Model.Write(Filename.ToLower.EndsWith(".dsv")))
            RaiseEvent FileSaved(Me, New EventArgs)
        End Sub

        Public Sub Save(Filename As String, provider As IOProvider) Implements ISavableAs.Save
            Me.Filename = Filename
            provider.WriteAllBytes(Filename, Model.Write(Filename.ToLower.EndsWith(".dsv")))
            RaiseEvent FileSaved(Me, New EventArgs)
        End Sub

        Public Function GetDefaultExtension() As String Implements ISavableAs.GetDefaultExtension
            Return ""
        End Function
    End Class

End Namespace
