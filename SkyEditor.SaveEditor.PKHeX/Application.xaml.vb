Imports SkyEditor.UI.WPF
Class Application
    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        StartupHelpers.RunWPFStartupSequence(New WPFCoreSkyEditorPlugin(New PluginInfo))
    End Sub

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

End Class
