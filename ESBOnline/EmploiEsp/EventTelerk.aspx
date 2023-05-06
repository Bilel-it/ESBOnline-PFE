<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventTelerk.aspx.cs" Inherits="ESPOnline.EmploiEsp.EventTelerk"
MasterPageFile="~/Direction/Site2.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title>Generation automatique emploi du temps</title>
   
     <link href="~/Media/layout.css" rel="stylesheet" type="text/css" />
    <link href="../DayPilotProJavaScriptTrial_7.9.1418/demo/themes/areas.css" rel="stylesheet" type="text/css" />
    <link href='../DayPilotProJavaScriptTrial_7.9.1418/demo/themes/calendar_green.css' rel="stylesheet" type="text/css" />
    <link href='../DayPilotProJavaScriptTrial_7.9.1418/demo/themes/navigator_green.css' rel="stylesheet" type="text/css" />
    <link href='../DayPilotProJavaScriptTrial_7.9.1418/demo/themes/menu_default.css' rel="stylesheet" type="text/css" />
    <link href='../DayPilotProJavaScriptTrial_7.9.1418/demo/themes/bubble_default.css' rel="stylesheet" type="text/css" />
    <script src="../Scripts/DayPilot/modal.js" type="text/javascript"></script>
    <script src="../Scripts/DayPilot/event_handling.js" type="text/javascript"></script>

      
    <script language='JavaScript' type='text/JavaScript'>

        function OpenPopWindow() {
            var url = "PopUpAjoutEmploi.aspx";

            window.open(url, "popUp", "width=480, height=500, top=0, left=0, menubar=no, resizable=no, " +
                        "scrollbars=yes, status=no", '');
        }
 
    </script>
    <style type="text/css">
        .style1
        {
            font-size: large;
            font-weight: bold;
            color: #800000;
        }
        .style2
        {
            font-size: large;
            color: #800000;
        }
    </style>


    <%--script of changing place in  calendar--%>
    <script type="text/javascript">
        var globalMouseX = 0;
        var globalMouseY = 0;
        var detectedMouseUp = false;
        var detectedSelectionChanged = false
        ASPxClientUtils.AttachEventToElement(document, "mousemove", createEventHandler("OnMouseMove"));
        ASPxClientUtils.AttachEventToElement(document, "mouseup", createEventHandler("OnMouseUp"));
        function OnMouseMove(evt) {
            globalMouseX = ASPxClientUtils.GetEventX(evt);
            globalMouseY = ASPxClientUtils.GetEventY(evt);
            detectedSelectionChanged = false;
            detectedMouseUp = false;
        }
        function OnMouseUp(evt) {
            detectedMouseUp = true;
            ShowToolTip();
        }
        function createEventHandler(funcName) {
            return new Function("event", funcName + "(event);");
        }
        function OnSelectionChanged(s, e) {
            if (!scheduler.isAllowEvent)
                return;
            detectedSelectionChanged = true;
            ShowToolTip();
        }
        function ShowToolTip() {
            if (detectedSelectionChanged && detectedMouseUp) {
                scheduler.ShowSelectionToolTip(globalMouseX, globalMouseY);
                detectedSelectionChanged = false;
                detectedMouseUp = false;
            }
        }
        function OnBeginCallback() {
            delete scheduler.isAllowEvent;
        }
        function OnEndCallback() {
            scheduler.isAllowEvent = true;
        }
        function OnControlInitialized() {
            scheduler.isAllowEvent = true;
        }
    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    
<body>
 <table>
    <tr><td ><h3 class="style2">Emploi du Temps pour l'Année Universitaire:
    <asp:Label ID="lblannee" runat="server" CssClass="style1"></asp:Label></h3></td></tr>
    <tr>
  

                    <td><asp:DropDownList runat="server" ID="DdlPromotion" 
         
          AutoPostBack="true"  AppendDataBoundItems="True" 
                            onselectedindexchanged="DdlPromotion_SelectedIndexChanged">
          <asp:ListItem>--Veuillez choisir la classe-- </asp:ListItem>
                    </asp:DropDownList></td>
    </tr>
    <tr align="center"><td><h3><asp:Label ID="lblempcl" runat="server"></asp:Label> <asp:Label ID="lblcodeclasss" runat="server"></asp:Label></h3>
 <h4> Semaine de : <asp:Label ID="lbldatedebut" runat="server"></asp:Label> &nbsp;au <asp:Label ID="lbldatefin" runat="server"></asp:Label></h4>
 
 </td></tr>
 </table>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
    <div class="demo-container no-bg">
        <telerik:RadWindowManager ID="Singleton" runat="server">
        </telerik:RadWindowManager>
        <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1">
            <telerik:RadScheduler runat="server" ID="RadScheduler1" ShowViewTabs="False" SelectedDate="2015-05-11"
                OnClientAppointmentInserting="appointmentInserting" DataSourceID="AppointmentsDataSource"
                OnClientAppointmentResizeEnd="appointmentResizeEnd" OnClientAppointmentMoveEnd="appointmentMoveEnd"
                DataKeyField="ID" DataSubjectField="Subject" DataStartField="Start" DataEndField="End"
                OnClientAppointmentMoveStart="OnClientAppointmentMoveStart" OnClientAppointmentResizeStart="OnClientAppointmentResizeStart"
                DataRecurrenceField="RecurrenceRule" 
                DataRecurrenceParentKeyField="RecurrenceParentID" EnableAdvancedForm="False">
                <TimeSlotContextMenuSettings EnableDefault="true"></TimeSlotContextMenuSettings>
                <AppointmentContextMenuSettings EnableDefault="true"></AppointmentContextMenuSettings>
            </telerik:RadScheduler>
        </telerik:RadAjaxPanel>
    </div>
    <asp:SqlDataSource ID="AppointmentsDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:TelerikConnectionString35 %>"
        SelectCommand="SELECT * FROM [ConfirmDialog_Appointments] WHERE ([Duration] IS NULL)"
        InsertCommand="INSERT INTO [ConfirmDialog_Appointments] ([Subject], [Start], [End], [RecurrenceRule], [RecurrenceParentID], [Duration]) VALUES (@Subject, @Start, @End, @RecurrenceRule, @RecurrenceParentID, @Duration)"
        UpdateCommand="UPDATE [ConfirmDialog_Appointments] SET [Subject] = @Subject, [Start] = @Start, [End] = @End, [RecurrenceRule] = @RecurrenceRule, [RecurrenceParentID] = @RecurrenceParentID, [Duration] = @Duration WHERE [ID] = @ID"
        DeleteCommand="DELETE FROM [ConfirmDialog_Appointments] WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Subject" Type="String"></asp:Parameter>
            <asp:Parameter Name="Start" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="End" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="RecurrenceRule" Type="String"></asp:Parameter>
            <asp:Parameter Name="RecurrenceParentID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Duration" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Subject" Type="String"></asp:Parameter>
            <asp:Parameter Name="Start" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="End" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="RecurrenceRule" Type="String"></asp:Parameter>
            <asp:Parameter Name="RecurrenceParentID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Duration" Type="Int32"></asp:Parameter>
        </InsertParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
        
   </asp:Content>