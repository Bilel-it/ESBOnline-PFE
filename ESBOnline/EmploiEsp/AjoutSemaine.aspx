<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjoutSemaine.aspx.cs" Inherits="ESPOnline.EmploiEsp.AjoutSemaine" %>
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
    
    
</head>
<body>

    <form id="form1" runat="server">
    <div style="color:gray; font-weight: bold;">La liste des cours par jour</div>
    
           

        <h1><span class="style1">&nbsp;&nbsp;&nbsp;&nbsp; </span><span class="style2">Plan d&#39;etude Esprit par 
            classe</span></h1>
    <asp:dropdownlist id="ddclasse" runat="server" Height="40px" Width="100px" 
                AutoPostBack="True" AppendDataBoundItems="true"
                onselectedindexchanged="ddclasse_SelectedIndexChanged" 
                DataTextField="CODE_CL" DataValueField="CODE_CL"/>
    
    <br /><br />

    <table>
    <tr><td ><h3 class="style2">Emploi du Temps pour l'Année Universitaire</h3></td>
    <td><asp:Label ID="lblannee" runat="server" CssClass="style1"></asp:Label></td></tr>
    <tr>
    <td><asp:ImageButton ID="btnOK" runat="server" 
            ImageUrl="~/EDTCss/imagesemploi/actu.jpg"  align="right"
            ToolTip="Log In" TabIndex="3" 
         Height="19px" onclick="btnOK_Click1" 
                                                Width="36px"  /></td>
    <td><asp:ImageButton runat="server" ID="imgAddNew" ImageUrl="~/images/add.png" alt="" CausesValidation="false"
   Style="cursor: hand;" ImageAlign="Middle"  OnClientClick="return OpenPopWindow();"  ToolTip="add"
 /></td>
    <td><asp:DropDownList runat="server" ID="ddlnomenseig" 
         
         onselectedindexchanged="ddlnomenseig_SelectedIndexChanged" AutoPostBack="true"  AppendDataBoundItems="True">
          <asp:ListItem>--Veuillez choisir un enseignant-- </asp:ListItem>
                    </asp:DropDownList></td>

                    <td><asp:DropDownList runat="server" ID="DdlPromotion" 
         
          AutoPostBack="true"  AppendDataBoundItems="True" 
                            onselectedindexchanged="DdlPromotion_SelectedIndexChanged">
          <asp:ListItem>--Veuillez choisir une promotion-- </asp:ListItem>
                    </asp:DropDownList></td>
    </tr>
    <tr>
 <DayPilot:DayPilotCalendar
        ID="DayPilotCalendar1" 
        BusinessEndsHour="21"
        BusinessBeginsHour="8"
        ShowNonBusiness="false"
        runat="server" 
        ClientObjectName="dp"
        CssOnly="true"
        CssClassPrefix="calendar_green"
        HeaderHeight="30"
        HeaderDateFormat="D"
        CellDuration="30"
        CellHeight="15"
        DayBeginsHour="0"
        DayEndsHour="8"
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
 
     
     </tr>
     </table>
   
    </form>
</body>
</html>
