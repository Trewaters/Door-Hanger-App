Public Class frmCodes

    Private Sub TblCodesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.TblCodesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DHA_sampleDataSet)

    End Sub

    Private Sub frmCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DHA_sampleDataSet.tblCodes' table. You can move, or remove it, as needed.
        Me.TblCodesTableAdapter.Fill(Me.DHA_sampleDataSet.tblCodes)

    End Sub
End Class