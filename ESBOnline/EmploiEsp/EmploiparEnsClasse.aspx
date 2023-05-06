<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmploiparEnsClasse.aspx.cs" Inherits="ESPOnline.EmploiEsp.EmploiparEnsClasse"
MasterPageFile="~/Direction/Site2.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
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

    
</asp:content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
    <tr><td ><h3 class="style2">Emploi du Temps pour l'Année Universitaire:
    <asp:Label ID="lblannee" runat="server" CssClass="style1"></asp:Label></h3></td></tr>
    <tr>
  >

                    <td><asp:DropDownList runat="server" ID="DdlPromotion" 
         
          AutoPostBack="true"  AppendDataBoundItems="True" 
                            onselectedindexchanged="DdlPromotion_SelectedIndexChanged">
          <asp:ListItem>--Veuillez choisir la classe-- </asp:ListItem>
                    </asp:DropDownList></td>
    </tr>
    <tr align="center"><td><h3><asp:Label ID="lblempcl" runat="server"></asp:Label> <asp:Label ID="lblcodeclasss" runat="server"></asp:Label></h3>
 <h4> Semaine de : <asp:Label ID="lbldatedebut" runat="server"></asp:Label> &nbsp;au <asp:Label ID="lbldatefin" runat="server"></asp:Label></h4>
 
 </td></tr>
    <tr><td></td></tr>
    <tr>
    <td width="75%">
    <DayPilot:DayPilotCalendar
        ID="DayPilotCalendar1" 
        BusinessEndsHour="21"
        BusinessBeginsHour="8"
        ShowNonBusiness="false"
        runat="server" 
        ClientObjectName="dp"
        CssOnly="true"
        CssClassPrefix="calendar_green"
        HeaderHeight="40"
        HeaderDateFormat="D"
        CellDuration="30"
        CellHeight="30"
        DayBeginsHour="8"
        DayEndsHour="21"
        HourWidth="100"
        StartDate=" "
        TimeRangeSelectedHandling="JavaScript"
        TimeRangeSelectedJavaScript="create(start, end, resource);"
        EventMoveHandling="CallBack"
        EventResizeHandling="CallBack"
        EventSelectColor="BlueViolet"
        EventClickHandling="JavaScript"
        EventClickJavaScript="edit(e)"
        ColumnMarginRight="0" 
        MoveBy="Top"
         OnBeforeEventRender="DayPilotCalendar1_OnBeforeEventRender"

        TimeFormat="Clock24Hours" HourHalfBorderColor="Red" 
        HourNameBorderColor="Maroon" HoverColor="#CC0000" 
        NonBusinessBackColor="#33CCCC" Days="6"
        DataStartField="start"  DataEndField="end"
        
         DataTextField="DESIGNATION" DataValueField="DESIGNATION" 
         
         
         />
    
    </td>
 
     </tr>
     </table>
     <center>
     <asp:Button  runat="server"  ID="btnExPoRtToPDF" Text="Exporter en PDF" BackColor="Maroon" 
                ForeColor="#CCCCCC" Height="40px" Width="150px" 
           
          style="font-weight: 100;  background-color: #333333;" 
             onclick="btnExPoRtToPDF_Click"/>
     
     </center>
        
   </asp:Content>