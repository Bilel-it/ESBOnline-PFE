Partial Class MessageBox
    Inherits System.Web.UI.UserControl

    Public Shared IconInfo, IconExc, IconQues, IconError As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IconInfo = "Show Information Icon"
        IconExc = "Show Warning Icon"
        IconQues = "Show Question icon and buttons"
        IconError = "Show Error Icon"
    End Sub

    Public Sub Pop(ByVal Message As String, Optional ByVal Mode As Object = "IconInfo",
                   Optional ByVal Title As String = "ToolTrak Message")

        lblMsg.Text = Message

        If Mode = IconInfo Then
            image.ImageUrl = "~/imgs/info.png"
            no.Visible = False
            ok.Text = "Ok"
            lblTitle.Text = "ToolTrak Message"
        ElseIf Mode = IconExc Then
            image.ImageUrl = "~/imgs/exc.png"
            no.Visible = False
            ok.Text = "Ok"
            lblTitle.Text = "ToolTrak Message"
        ElseIf Mode = IconQues Then
            image.ImageUrl = "~/imgs/ques.png"
            no.Visible = True
            ok.Text = "Yes"
            lblTitle.Text = "Confirm Action.."
        ElseIf Mode = IconError Then
            image.ImageUrl = "~/imgs/error.png"
            no.Visible = False
            ok.Text = "Ok"
            lblTitle.Text = "An Error has Occured"
        End If

        If Title <> "" Then
            lblTitle.Text = Title
        End If

        PopUp.Show()
    End Sub

    Protected Sub no_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles no.Click
        PopUp.Hide()
    End Sub

End Class
