<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenEmp.aspx.cs" Inherits="ESPOnline.EmploiEsp.GenEmp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript" src="../Css-Template/js/jquery.min.js"></script>
    <script type="text/javascript" src="../Css-Template/js/image_slide.js"></script>
     <script type="text/javascript" src="../Css-Template/js/modernizr-1.5.min.js"></script>

      <link href="~/Media/layout.css" rel="stylesheet" type="text/css" />
    <link href='~/Themes/areas.css' rel="stylesheet" type="text/css" />
    <link href='~/Themes/calendar_green.css' rel="stylesheet" type="text/css" />
    <link href='~/Themes/navigator_green.css' rel="stylesheet" type="text/css" />
    <link href='~/Themes/menu_default.css' rel="stylesheet" type="text/css" />
    <link href='~/Themes/bubble_default.css' rel="stylesheet" type="text/css" />
    <script src="../Scripts/DayPilot/modal.js" type="text/javascript"></script>
    <script src="../Scripts/DayPilot/event_handling.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript" ></script>


    <style type="text/css">
    
    .container { 
 width:100%; }

.align-left { 
 float: left;
 width:50%; 
 height:20%;
 } 

 .align-right{
 float: right; 
 height:20%;
 width:50%
 }
    
    </style>
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
        .style3
        {
            font-size: large;
            color: #FFFFFF;
            height: 34px;
        }
        .style4
        {
            height: 34px;
        }
        .style5
        {
            font-size: medium;
            font-weight: bold;
            color: #800000;
            height: 34px;
        }
        .style7
        {
            font-size: large;
            font-weight: normal;
            color: #FF0000;
            height: 34px;
        }
        .style8
        {
            font-size: medium;
            color: #800000;
            height: 34px;
            font-family: "Times New Roman", Times, serif;
        }
        .style9
        {
            font-size: medium;
            font-weight: normal;
            color: #800000;
            height: 34px;
            font-family: "Times New Roman", Times, serif;
        }
        .style10
        {
            font-size: medium;
            font-weight: bold;
            color: #800000;
            height: 34px;
            font-family: "Times New Roman", Times, serif;
        }
        .style11
        {
            font-size: medium;
            font-weight: bold;
            color: #000000;
            height: 34px;
        }
        .style12
        {
            font-family: "Times New Roman", Times, serif;
        }
        .style13
        {
            color: black;
            font-family: "Times New Roman", Times, serif;
        }
        .style16
        {
            font-size: medium;
            height: 34px;
            font-family: "Times New Roman", Times, serif;
        }
        .style18
        {
            color: #FFFFFF;
        }
        .style19
        {
            font-size: large;
            color: #FFFFFF;
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

     <%--<link rel="stylesheet" type="text/css" href="../Stylesmaha/style.css" />--%>

     <style type="text/css">
    

table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #E80707;font-weight: bold;}
.GridItemStyle{background-color:#eeeeee;color: black;}
.GridAlternatingStyle{background-color:#dddddd;color: black;}
.GridSelectedStyle{background-color:#d6e6f6;color: black;}


.GridStyle
{
	border-bottom: white 2px ridge; 
	border-left: white 2px ridge; 
	background-color: white; 
	width: 100%; 
	border-top: white 2px ridge; 
	border-right: white 2px ridge; 
}
.ItemStyle {
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}

.ItemStyle td{
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}
.FixedHeaderStyle {
	BACKGROUND-COLOR:  #7591b1; 
	COLOR: #FFFFFF; 
	FONT-WEIGHT: bold;
	position:relative ;   
	top:expression(this.offsetParent.scrollTop);  
	z-index: 10;  
}
.Caption_1_Customer
{
	background-color:#beccda;
	color: #000000;
	width: 30%;
	height: 20px;
}

     
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DropDownList runat="server" ID="ddlcodclasse" 
         
          AutoPostBack="true"  AppendDataBoundItems="True" onselectedindexchanged="ddlcodclasse_SelectedIndexChanged" 
                            >
          <asp:ListItem>--Veuillez choisir la classe-- </asp:ListItem>
                    </asp:DropDownList>
    <h1>Generation Emploi Du Temps</h1>
     <asp:Button  runat="server"  ID="btnaddEMP" Text="Generation Emp Du Temps" BackColor="Maroon" 
                ForeColor="#CCCCCC" Height="40px" Width="195px" 
            onclick="btnaddEMP_Click" 
          style="font-weight: 100;  background-color: #999999; color: #800000;"/>

          <DayPilot:DayPilotCalendar
        ID="DayPilotCalendar1" 
        BusinessEndsHour="21"
        BusinessBeginsHour="8"
        ShowNonBusiness="false"

        Scale="Day"
  
        runat="server" 
        ClientObjectName="dp"
        CssOnly="true"
        CssClassPrefix="calendar_green"
        HeaderHeight="40"
        HeaderDateFormat="D"
        CellDuration="30"
        CellHeight="30"
        DayBeginsHour="0"
        DayEndsHour="5"
        HourWidth="100"
        TimeRangeSelectedHandling="JavaScript"
        TimeRangeSelectedJavaScript="create(start, end, resource);"
        EventMoveHandling="CallBack"
        EventResizeHandling="CallBack"
       
        EventClickHandling="JavaScript"
        EventClickJavaScript="edit(e)"
        ColumnMarginRight="0" 
        MoveBy="Top" 
        TimeFormat="Clock24Hours" HourHalfBorderColor="Red" 
        HourNameBorderColor="Maroon" HoverColor="#CC0000" 
        NonBusinessBackColor="#33CCCC" Days="6"
        DataStartField="start"  DataEndField="end"
         DataTextField="DESIGNATION" DataValueField="DESIGNATION" 
          EventDeleteJavaScript="if (confirm('Delete?')) { dpc.eventDeleteCallBack(e); }" 
        OnEventDelete="DayPilotCalendar1_EventDelete" 
         EventDeleteHandling="CallBack"

       />
    </div>
    </form>
</body>
</html>
