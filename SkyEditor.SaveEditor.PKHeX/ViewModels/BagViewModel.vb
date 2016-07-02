Imports System.Collections.ObjectModel
Imports SkyEditor.Core.UI
Imports SkyEditor.SaveEditor.UI.WPF.ViewModelComponents

Namespace ViewModels
    Public Class BagViewModel
        Inherits GenericViewModel(Of PKHeX.SaveFile)
        Implements IInventory

        Public Property ItemSlots As IEnumerable(Of IItemSlot) Implements IInventory.ItemSlots

        Public Overrides Sub SetModel(model As Object)
            MyBase.SetModel(model)

            Dim names = PKHeX.Util.getStringList("items", "en")
            Dim b As New List(Of IItemSlot)
            Dim s As PKHeX.SaveFile = model
            For Each slot In s.Inventory
                Dim items As New ObservableCollection(Of InventoryItem)
                For Each item In slot.Items
                    If Not item.Index = 0 Then
                        Dim n As New InventoryItem
                        n.ItemID = item.Index
                        n.MaxQuantity = slot.MaxCount
                        n.Quantity = item.Count
                        n.Name = names(item.Index)

                        items.Add(n)
                    End If
                Next
                b.Add(New ItemSlot(Of InventoryItem)(slot.Type.ToString, items, slot.Items.Count()))
            Next
            ItemSlots = b
        End Sub

    End Class
End Namespace

