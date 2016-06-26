Imports SkyEditor.Core

Public Class PluginInfo
    Inherits SkyEditorPlugin

    Public Overrides ReadOnly Property Credits As String
        Get
            Return My.Resources.Language.Credits
        End Get
    End Property

    Public Overrides ReadOnly Property PluginAuthor As String
        Get
            Return My.Resources.Language.PluginAuthor
        End Get
    End Property

    Public Overrides ReadOnly Property PluginName As String
        Get
            Return My.Resources.Language.PluginName
        End Get
    End Property

    Public Overrides Sub Load(manager As PluginManager)
        MyBase.Load(manager)

        manager.LoadRequiredPlugin(New SkyEditor.SaveEditor.PluginDefinition, Me)
        manager.CurrentIOUIManager.RegisterIOFilter("main", My.Resources.Language.Gen6SaveFiles)
    End Sub
End Class
