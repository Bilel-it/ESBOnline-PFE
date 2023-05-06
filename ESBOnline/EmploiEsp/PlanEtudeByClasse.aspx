<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanEtudeByClasse.aspx.cs" Inherits="ESPOnline..PlanEtudeByClasse" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #333333;
            background-color: #FFFFFF;
        }
        .style2
        {
            color: #444444;
            background-color: #FFFFFF;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<div style="color:gray; font-weight: bold;">La liste des cours par jour</div>
    <div style="border:1px solid red; padding: 10px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
      <asp:Calendar ID="Calendar1" runat="server" CssClass="calendar"  OnSelectionChanged="Calendar1_SelectionChanged"
                BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" 
                Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" 
                NextPrevFormat="ShortMonth" Width="330px">
                <TodayDayStyle BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" 
                    BackColor="#999999" ForeColor="White"></TodayDayStyle>
                <SelectedDayStyle BackColor="#333399" ForeColor="White" CssClass="selected"></SelectedDayStyle>
                <TitleStyle BackColor="#8D1919" BorderStyle="Solid" Font-Bold="True" 
                    Font-Size="12pt" ForeColor="White" Height="12pt"></TitleStyle>
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="RED" 
                    Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
            </asp:Calendar>
            <br />
     How many days to show:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged1" >
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem Selected="True">4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
    </asp:DropDownList> <br /><br /> 

        <h1><span class="style1">&nbsp;&nbsp;&nbsp;&nbsp; </span><span class="style2">Plan d&#39;etude Esprit par 
            classe</span></h1>
    <asp:dropdownlist id="ddclasse" runat="server" Height="40px" Width="100px" 
                AutoPostBack="True" AppendDataBoundItems="true"
                onselectedindexchanged="ddclasse_SelectedIndexChanged" 
                DataTextField="CODE_CL" DataValueField="CODE_CL"/>
    
    <br /><br />
        <DayPilot:DayPilotCalendar ID="DayCalendar1" runat="server"  Days="6" 
         BackColor="White" BorderColor="#000000" CssClassPrefix="calendar_default" 
         DayFontFamily="Tahoma" DayFontSize="10pt" DurationBarColor="Red" 

         EventBackColor="#FFFFFF" EventBorderColor="#000000" 

         EventClickHandling="Disabled" EventFontFamily="Tahoma" EventFontSize="8pt" 
         EventHoverColor="#8D3345" HourBorderColor="#EAD098" HourFontFamily="Tahoma" 
         HourFontSize="16pt" HourHalfBorderColor="#F3E4B1" HourNameBackColor="#9F2800" 
         HourNameBorderColor="#66FFFF" HoverColor="White" 

         NonBusinessBackColor="Maroon" StartDate=" "  

         DataStartField="start"  DataEndField="end"

         DataTextField="DESIGNATION" DataValueField="DESIGNATION" 
                style="color: #7D0000; background-color: #333333" 
                TimeFormat="Clock24Hours" />

                

    </ContentTemplate>
    </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>