Public Class frmImpData

    Private Sub TblShutOffBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.TblShutOffBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DHA_sampleDataSet)

    End Sub

    Private Sub frmImpData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DHA_sampleDataSet.tblShutOff' table. You can move, or remove it, as needed.
        Me.TblShutOffTableAdapter.Fill(Me.DHA_sampleDataSet.tblShutOff)

    End Sub
End Class