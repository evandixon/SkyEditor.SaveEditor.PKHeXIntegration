Imports SkyEditor.Core.Utilities

Namespace ViewModels
    Public Class InventoryItem
        Implements IClonable
        Public Property Name As String
        Public Property ItemID As Integer
        Public Property Quantity As Integer
        Public Property MaxQuantity As Integer

        Public Overrides Function ToString() As String
            Return $"{Name} ({Quantity})"
        End Function

        Public Function Clone() As Object Implements IClonable.Clone
            Dim out As New InventoryItem
            out.Name = Me.Name
            out.ItemID = Me.ItemID
            out.Quantity = Me.Quantity
            out.MaxQuantity = Me.MaxQuantity
            Return out
        End Function
    End Class
End Namespace

