Imports System.ComponentModel
Imports SkyEditor.Core.UI

Namespace ViewModels
    Public Class Gen6GeneralViewModel
        Inherits GenericViewModel(Of PKHeX.SaveFile)
        Implements INotifyPropertyChanged

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Public Property OT As String
            Get
                Return Model.OT
            End Get
            Set(value As String)
                If Not Model.OT = value Then
                    Model.OT = value
                    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(OT)))
                End If
            End Set
        End Property

    End Class

End Namespace
