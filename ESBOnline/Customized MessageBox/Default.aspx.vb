Partial Class _Default
    Inherits System.Web.UI.Page

    Dim MsgStyle As String

    Private Property FontInfo As Object

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If cboStyle.SelectedIndex = 0 Then
            MsgStyle = "IconInfo"
        ElseIf cboStyle.SelectedIndex = 1 Then
            MsgStyle = "IconExc"
        ElseIf cboStyle.SelectedIndex = 2 Then
            MsgStyle = "IconQues"
        ElseIf cboStyle.SelectedIndex = 3 Then
            MsgStyle = "IconError"
        End If

        PopMsg.Pop(txtMessage.Text, MsgStyle, txtTitle.Text)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        PopMsg.Pop("An error occoured! Pls check and resolve!", IconError, "Error")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        PopMsg.Pop("I love CodeProject! Really a developers website..", FontInfo, "Wow!")
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        PopMsg.Pop("Do you want to continue registration?", IconQues, "Confirm")
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        PopMsg.Pop("Complete all fields in the registration form!", IconExc, "InComplete Data")
    End Sub

    Private Function IconQues() As Object
        Throw New NotImplementedException
    End Function

    Private Function IconExc() As Object
        Throw New NotImplementedException
    End Function

    Private Function IconError() As Object
        Throw New NotImplementedException
    End Function

    Private Function PopMsg() As Object
        Throw New NotImplementedException
    End Function

End Class
