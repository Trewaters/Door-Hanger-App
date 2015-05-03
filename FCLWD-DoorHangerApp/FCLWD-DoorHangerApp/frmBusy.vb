Public Class frmBusy

    Private Sub frmBusy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'slow down program so the form can print fully
        'This didn't help.
        'System.Threading.Thread.Sleep(1000)
    End Sub
End Class