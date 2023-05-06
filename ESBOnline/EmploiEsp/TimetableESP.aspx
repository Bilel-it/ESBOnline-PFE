<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimetableESP.aspx.cs" Inherits="ESPOnline.EmploiEsp.TimetableESP" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head id="Head1" runat="server">
    <title>Telerik ASP.NET Example</title>
    <link rel="Stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
  
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
 
        <script type="text/javascript">
            /* <![CDATA[ */
            Sys.Application.add_load(function () {             
                demo.categoryPanelBar = $find('<%=RadPanelBar1.ClientID %>');
                demo.scheduler = $find('<%=RadScheduler1.ClientID %>');
                demo.calendar1 = $find('<%=RadCalendar1.ClientID %>');
            });
            /* ]]> */
        </script>
           <script type="text/javascript" src=""></script>
    </telerik:RadScriptBlock>
    <div class="demo-container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <telerik:RadSplitter runat="server" ID="RadSplitter1" Skin="Metro"
                    PanesBorderSize="0" Width="1000" Height="450">
                    <telerik:RadPane runat="Server" ID="leftPane" Width="220" Scrolling="None">
                        <telerik:RadSplitter runat="server" ID="RadSplitter2" 
                            Orientation="Horizontal" Width="100%">
                            <telerik:RadPane ID="RadPane1" runat="server" Height="180">
                                <telerik:RadCalendar runat="server" ID="RadCalendar1"  EnableMultiSelect="false"
                                    FocusedDate="2012/01/31" DayNameFormat="FirstTwoLetters" EnableNavigation="true"
                                    EnableMonthYearFastNavigation="true" Skin="Metro">
                                    <ClientEvents OnDateSelected="OnCalendar1DateSelected"
                                        OnCalendarViewChanged="OnCalendar1ViewChanged" />
                                </telerik:RadCalendar>
                            </telerik:RadPane>
                            <telerik:RadSplitBar ID="RadSplitBar1" runat="server" EnableResize="false" />
                            <telerik:RadPane ID="RadPane2" runat="server">
 
                                <telerik:RadPanelBar runat="server" ID="RadPanelBar1"  Width="100%" Skin="Metro"
                                    ExpandAnimation-Type="None" CollapseAnimation-Type="None" ExpandMode="SingleExpandedItem">
                                    <Items>
                                        <telerik:RadPanelItem runat="server" Text="My Calendars" Expanded="true">
                                            <Items>
                                                <telerik:RadPanelItem runat="server">
                                                    <ItemTemplate>
                                                        <div class="rpCheckBoxPanel">
                                                            <div class="qsf-chk-personal">
                                                                <label>
                                                                    <input id="chkPersonal" type="checkbox" title="Personal" onclick="rebindScheduler()"
                                                                        value="Personal" checked="checked" name="Personal" />
                                                                    <span>Personal</span>
                                                                </label>
                                                            </div>
                                                            <div class="qsf-chk-work">
                                                                <label>
                                                                    <input id="chkWork" type="checkbox" title="Work" onclick="rebindScheduler()" value="Work"
                                                                        checked="checked" name="Work" />
                                                                    <span>Work</span>
                                                                </label>
                                                            </div>
                                                        </div>
                                                        <telerik:RadButton runat="server" ID="Button1" Text="Group" OnClick="Button1_Click" 
                                                            Icon-PrimaryIconCssClass="qsf-btn-group" Skin="Metro" />
                                                        <span title="This button Groups RadScheduler by its Resources creating a separate calendar for each resource item and situating the appropriate appointments there."
                                                            class="qsf-btn-hint">?</span>
                                                    </ItemTemplate>
                                                </telerik:RadPanelItem>
                                            </Items>
                                        </telerik:RadPanelItem>
                                    </Items>
                                </telerik:RadPanelBar>
                            </telerik:RadPane>
                        </telerik:RadSplitter>
                    </telerik:RadPane>
                    <telerik:RadSplitBar runat="server" ID="RadSplitBar2" CollapseMode="Forward" EnableResize="false" />
                    <telerik:RadPane runat="Server" ID="rightPane" Scrolling="None">
                        <telerik:RadScheduler runat="server" ID="RadScheduler1"  Height="450" OverflowBehavior="Expand" OnLoad="RadScheduler1_Load"
                            OnClientAppointmentWebServiceInserting="OnClientAppointmentWebServiceInserting"
                            OnClientNavigationComplete="OnClientNavigationComplete"
                            OnClientAppointmentsPopulating="OnClientAppointmentsPopulating"
                            SelectedView="WeekView" ShowFooter="false" SelectedDate="2012-01-31"
                            DayStartTime="08:00:00" DayEndTime="21:00:00" FirstDayOfWeek="Monday" LastDayOfWeek="Friday"
                            EnableDescriptionField="true" AppointmentStyleMode="Default" Skin="Metro">
                            <WebServiceSettings Path="../WebService/SchedulerWebService.asmx" ResourcePopulationMode="ServerSide" />
                            <AdvancedForm Modal="true"></AdvancedForm>
                            <TimelineView UserSelectable="false"></TimelineView>
                            <AgendaView UserSelectable="true" />
                            <ResourceStyles>
                                <%--AppointmentStyleMode must be explicitly set to Default (see above) otherwise setting BackColor/BorderColor
                            will switch the appointments to Simple rendering (no rounded corners and gradients)--%>
                                <telerik:ResourceStyleMapping Type="Calendar" Text="Personal"
                                    BorderColor="#abd962" />
                                <telerik:ResourceStyleMapping Type="Calendar" Text="Work"
                                    BorderColor="#25a0da" />
                            </ResourceStyles>
                            <ResourceHeaderTemplate>
                                <div class="rsResourceHeader<%# Eval("Text") %>">
                                    <%# Eval("Text") %>
                                </div>
                            </ResourceHeaderTemplate>
                            <TimeSlotContextMenuSettings EnableDefault="true" />
                            <AppointmentContextMenuSettings EnableDefault="true" />
                            <Localization HeaderWeek="Work week" />
                        </telerik:RadScheduler>
                    </telerik:RadPane>
                </telerik:RadSplitter>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
 
    </form>
</body>
</html><%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head id="Head2" runat="server">
    <title>Telerik ASP.NET Example</title>
    <link rel="Stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form2" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager2" />
    <telerik:RadSkinManager ID="RadSkinManager2" runat="server" ShowChooser="true" />
  
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
 
        <script type="text/javascript">
            /* <![CDATA[ */
            Sys.Application.add_load(function () {             
                demo.categoryPanelBar = $find('<%=RadPanelBar1.ClientID %>');
                demo.scheduler = $find('<%=RadScheduler1.ClientID %>');
                demo.calendar1 = $find('<%=RadCalendar1.ClientID %>');
            });
            /* ]]> */
        </script>
           <script type="text/javascript" src=""></script>
    </telerik:RadScriptBlock>
    <div class="demo-container">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <telerik:RadSplitter runat="server" ID="RadSplitter3" Skin="Metro"
                    PanesBorderSize="0" Width="1000" Height="450">
                    <telerik:RadPane runat="Server" ID="RadPane3" Width="220" Scrolling="None">
                        <telerik:RadSplitter runat="server" ID="RadSplitter4" 
                            Orientation="Horizontal" Width="100%">
                            <telerik:RadPane ID="RadPane4" runat="server" Height="180">
                                <telerik:RadCalendar runat="server" ID="RadCalendar2"  EnableMultiSelect="false"
                                    FocusedDate="2012/01/31" DayNameFormat="FirstTwoLetters" EnableNavigation="true"
                                    EnableMonthYearFastNavigation="true" Skin="Metro">
                                    <ClientEvents OnDateSelected="OnCalendar1DateSelected"
                                        OnCalendarViewChanged="OnCalendar1ViewChanged" />
                                </telerik:RadCalendar>
                            </telerik:RadPane>
                            <telerik:RadSplitBar ID="RadSplitBar3" runat="server" EnableResize="false" />
                            <telerik:RadPane ID="RadPane5" runat="server">
 
                                <telerik:RadPanelBar runat="server" ID="RadPanelBar2"  Width="100%" Skin="Metro"
                                    ExpandAnimation-Type="None" CollapseAnimation-Type="None" ExpandMode="SingleExpandedItem">
                                    <Items>
                                        <telerik:RadPanelItem runat="server" Text="My Calendars" Expanded="true">
                                            <Items>
                                                <telerik:RadPanelItem runat="server">
                                                    <ItemTemplate>
                                                        <div class="rpCheckBoxPanel">
                                                            <div class="qsf-chk-personal">
                                                                <label>
                                                                    <input id="chkPersonal" type="checkbox" title="Personal" onclick="rebindScheduler()"
                                                                        value="Personal" checked="checked" name="Personal" />
                                                                    <span>Personal</span>
                                                                </label>
                                                            </div>
                                                            <div class="qsf-chk-work">
                                                                <label>
                                                                    <input id="chkWork" type="checkbox" title="Work" onclick="rebindScheduler()" value="Work"
                                                                        checked="checked" name="Work" />
                                                                    <span>Work</span>
                                                                </label>
                                                            </div>
                                                        </div>
                                                        <telerik:RadButton runat="server" ID="Button1" Text="Group" OnClick="Button1_Click" 
                                                            Icon-PrimaryIconCssClass="qsf-btn-group" Skin="Metro" />
                                                        <span title="This button Groups RadScheduler by its Resources creating a separate calendar for each resource item and situating the appropriate appointments there."
                                                            class="qsf-btn-hint">?</span>
                                                    </ItemTemplate>
                                                </telerik:RadPanelItem>
                                            </Items>
                                        </telerik:RadPanelItem>
                                    </Items>
                                </telerik:RadPanelBar>
                            </telerik:RadPane>
                        </telerik:RadSplitter>
                    </telerik:RadPane>
                    <telerik:RadSplitBar runat="server" ID="RadSplitBar4" CollapseMode="Forward" EnableResize="false" />
                    <telerik:RadPane runat="Server" ID="RadPane6" Scrolling="None">
                        <telerik:RadScheduler runat="server" ID="RadScheduler2"  Height="450" OverflowBehavior="Scroll" OnLoad="RadScheduler1_Load"
                            OnClientAppointmentWebServiceInserting="OnClientAppointmentWebServiceInserting"
                            OnClientNavigationComplete="OnClientNavigationComplete"
                            OnClientAppointmentsPopulating="OnClientAppointmentsPopulating"
                            SelectedView="WeekView" ShowFooter="false" SelectedDate="2012-01-31"
                            DayStartTime="08:00:00" DayEndTime="21:00:00" FirstDayOfWeek="Monday" LastDayOfWeek="Friday"
                            EnableDescriptionField="true" AppointmentStyleMode="Default" Skin="Metro">
                            <WebServiceSettings Path="../WebService/SchedulerWebService.asmx" ResourcePopulationMode="ServerSide" />
                            <AdvancedForm Modal="true"></AdvancedForm>
                            <TimelineView UserSelectable="false"></TimelineView>
                            <AgendaView UserSelectable="true" />
                            <ResourceStyles>
                                <%--AppointmentStyleMode must be explicitly set to Default (see above) otherwise setting BackColor/BorderColor
                            will switch the appointments to Simple rendering (no rounded corners and gradients)--%>
                                <telerik:ResourceStyleMapping Type="Calendar" Text="Personal"
                                    BorderColor="#abd962" />
                                <telerik:ResourceStyleMapping Type="Calendar" Text="Work"
                                    BorderColor="#25a0da" />
                            </ResourceStyles>
                            <ResourceHeaderTemplate>
                                <div class="rsResourceHeader<%# Eval("Text") %>">
                                    <%# Eval("Text") %>
                                </div>
                            </ResourceHeaderTemplate>
                            <TimeSlotContextMenuSettings EnableDefault="true" />
                            <AppointmentContextMenuSettings EnableDefault="true" />
                            <Localization HeaderWeek="Work week" />
                        </telerik:RadScheduler>
                    </telerik:RadPane>
                </telerik:RadSplitter>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
 
    </form>
</body>
</html>