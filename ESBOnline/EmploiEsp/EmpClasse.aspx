<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpClasse.aspx.cs" Inherits="ESPOnline.EmploiEsp.EmpClasse" 
MasterPageFile="~/Direction/Site2.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../DayPilotProJavaScriptTrial_7.9.1418/demo/themes/calendar_green.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
    <tr><td ><h3 class="style2">Emploi du Temps pour l'Année Universitaire</h3></td>
    <td><asp:Label ID="lblannee" runat="server" CssClass="style1"></asp:Label></td></tr>
    <tr>
    <td><asp:ImageButton ID="btnOK" runat="server" 
            ImageUrl="~/EDTCss/imagesemploi/actu.jpg"  align="right"
            ToolTip="Log In" TabIndex="3" 
         Height="19px" onclick="btnOK_Click1" 
                                                Width="36px"  /></td>
    <td><asp:ImageButton runat="server" ID="imgAddNew" ImageUrl="~/Css-Template/listimage/images/add.png" alt="" CausesValidation="false"
   Style="cursor: hand;" ImageAlign="Middle"  OnClientClick="return OpenPopWindow();"  ToolTip="add"
 /></td>
    <%--<td><asp:DropDownList runat="server" ID="ddlnomenseig" 
         
         onselectedindexchanged="ddlnomenseig_SelectedIndexChanged" AutoPostBack="true"  AppendDataBoundItems="True">
          <asp:ListItem>--Veuillez choisir un enseignant-- </asp:ListItem>
                    </asp:DropDownList></td>--%>

                    <td><asp:DropDownList runat="server" ID="DdlPromotion" 
         
          AutoPostBack="true"  AppendDataBoundItems="True" 
                            onselectedindexchanged="DdlPromotion_SelectedIndexChanged">
          <asp:ListItem>--Veuillez choisir la classe-- </asp:ListItem>
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
 
     
     </tr>
     </table>
        
   </asp:Content>