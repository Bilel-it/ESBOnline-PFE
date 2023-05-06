<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Encadrementdet.ascx.cs" Inherits="ESPOnline.EnseignantsCUP.Encadrementdet" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style4
    {
        width: 453px;
    }
    .style5
    {
        width: 155px;
    }
    
    .style6
    {
        width: 195px;
    }
</style>
<style type="text/css">
    .rbWidth label
    {
        margin-right: 40px;
    }
</style>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
<script src="../Contents/Scripts/MaxLength.min.js" type="text/javascript"></script>
<style type="text/css">
    #Table1
    {
        background: #F0F0F0;
    }
    .style7
    {
        width: 187px;
        height: 54px;
    }
    .style8
    {
        width: 453px;
        height: 54px;
    }
    .style9
    {
        width: 155px;
        height: 54px;
    }
    .style10
    {
        height: 54px;
    }
    .style11
    {
        color: #FF0000;
    }
    .text-danger
    {
        color: #FF3300;
        font-weight: 700;
    }
</style>
<script type="text/javascript">
    $(function () {
        //Normal Configuration
        $("[id*=TextBox1]").MaxLength({ MaxLength: 10 });
    });
    //<![CDATA[
    var RadDateTimePicker1;
    var RadTimePicker1;
    function validate2(sender, args) {
        var label = document.getElementById('<%=Label2.ClientID%>');
        var Date4 = new Date(BirthDatePicker.get_selectedDate());
        var Date3 = new Date(RadDateTimePicker1.get_selectedDate());
        args.IsValid = true;
        if (Date4 < Date3) {
            label.innerText = "date erronée!!";
            args.IsValid = false;
        }
        else label.innerText = "";
    }
    function validate1(sender, args) {
        var Date3 = new Date(RadDateTimePicker1.get_selectedDate());
        var label = document.getElementById('<%=Label4.ClientID%>');
        args.IsValid = true;
        if (Date3 > Date.now()) {

            label.innerText = "date erronée!!";
            args.IsValid = false;
        }
        else label.innerText = "";
    }

    function validate(sender, args) {
        var label = document.getElementById('<%=Label1.ClientID%>');
        var Date1 = new Date(RadTimePicker1.get_selectedDate());
        var label2 = document.getElementById('<%=Label2.ClientID%>');
        var Date3 = new Date(RadDateTimePicker1.get_selectedDate());

        args.IsValid = true;

        if ((Date1.getHours() - Date3.getHours()) < 0) {
            //  alert("The second time value should be greater than the first!");
            // alert(Date1.getHours());
            label.innerText = "HEURE ERRONEE";
            args.IsValid = false;
        }
        else label.innerText = "";
    }

    function onLoadRadTimePicker1(sender, args) {
        RadTimePicker1 = sender;
    }

    function onLoadRadDateTimePicker1(sender, args) {
        RadDateTimePicker1 = sender;
    }

    function onLoadBirthDatePicker(sender, args) {
        BirthDatePicker = sender;
    }
     
</script>
<table class="style1" id="Table1">
    <tr>
        <td class="style6">
            <b>Encadrement Info:</b>
        </td>
        <td class="style4">
            &nbsp;
        </td>
        <td class="style5">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style6">
            Date et heure d&#39;encadrement:
        </td>
        <td class="style4">
            <telerik:RadDateTimePicker ID="RadDateTimePicker1" Width="245px" runat="server" ControlToValidate="RadDateTimePicker1"
                ClientValidationFunction="validate" DbSelectedDate='<%# Bind("HEURE_DEB") %>'
                Height="26px">
                <TimeView CellSpacing="-1" Culture="fr-FR">
                </TimeView>
                <TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>
                <Calendar ID="Calendar2" runat="server" EnableKeyboardNavigation="true">
                </Calendar>
                <DateInput ToolTip="Date input" DateFormat="dd/MM/yy HH:mm:ss" Height="26px">
                    <ClientEvents OnLoad="onLoadRadDateTimePicker1"></ClientEvents>
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDateTimePicker>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="RadDateTimePicker1"
                ErrorMessage="date!!!!" Style="color: #FF0000"></asp:RequiredFieldValidator>
            &nbsp;
            <asp:Label ID="Label4" runat="server" Text="" Style="color: #FF0000"></asp:Label>
        </td>
        <td class="style5">
            Observation:
        </td>
        <td>
            <asp:TextBox ID="TextBox1" Text='<%# DataBinder.Eval( Container, "DataItem.REMARQUE_OBS") %>'
                MaxLength="5" runat="server" TextMode="MultiLine" Rows="5" Columns="40" TabIndex="5">
                            <%--TextMode="MultiLine" Rows="5" Columns="40" TabIndex="5"--%>
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Heure Fin:
        </td>
        <td class="style4">
            <telerik:RadTimePicker ID="RadTimePicker1" Width="218px" runat="server" DbSelectedDate='<%# Bind("HEURE_FIN") %>'
                Height="25px">
                <DateInput DateFormat="HH:mm:ss" Label="" ToolTip="Heure Fin:">
                    <ClientEvents OnLoad="onLoadRadTimePicker1"></ClientEvents>
                </DateInput>
                <TimeView TimeFormat="HH:mm:ss">
                </TimeView>
            </telerik:RadTimePicker>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="RadTimePicker1"
                ErrorMessage="Heure!!!" Style="color: #FF3300"></asp:RequiredFieldValidator>
            <asp:Label ID="Label1" runat="server" Text="" Style="color: #FF0000"></asp:Label>
        </td>
        <td class="style5">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style7">
            <b>Avancement Info:</b>
        </td>
        <td class="style8">
            <asp:CustomValidator ID="CustomValidator1" EnableClientScript="true" runat="server"
                ControlToValidate="RadTimePicker1" ClientValidationFunction="validate">
            </asp:CustomValidator>
            <asp:CustomValidator ID="CustomValidator3" EnableClientScript="true" runat="server"
                ControlToValidate="RadDateTimePicker1" ClientValidationFunction="validate1">
            </asp:CustomValidator>
            
            <asp:CustomValidator ID="CustomValidator2" EnableClientScript="true" runat="server"
                ControlToValidate="BirthDatePicker" ClientValidationFunction="validate2">
            </asp:CustomValidator>
        </td>
        <td class="style9">
            Travail demandé:
        </td>
        <td class="style10">
            <asp:TextBox ID="TextBox2" runat="server" Columns="40" Rows="5" TabIndex="5" Text='<%# DataBinder.Eval( Container, "DataItem.TRAVAUX_DEMANDE") %>'
                TextMode="MultiLine">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Avancement technique%:
        </td>
        <td class="style4">
            <telerik:RadNumericTextBox ID="RadNumericTextBox1" Type="Percent" MinValue="0" MaxValue="100"
                Text='<%# DataBinder.Eval( Container, "DataItem.AV_TECH") %>' AllowOutOfRangeAutoCorrect="false"
                ShowSpinButtons="true" ValidationGroup="oppSub" runat="server" Height="20px"
                Width="60px">
                <NumberFormat DecimalDigits="0"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                ControlToValidate="RadNumericTextBox1" ErrorMessage="*" CssClass="h5 text-danger" />
        </td>
        <td class="style5">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;
        </td>
        <td class="style4">
            <telerik:RadTextBox ID="RadTextBox4" runat="server"   Text='<%# DataBinder.Eval( Container, "DataItem.OBS_TECH") %>'
                EmptyMessage="Remarques sur avancement technique" Height="26px" InvalidStyleDuration="100"
                Width="293px">
            </telerik:RadTextBox>
        </td>
        <td class="style5">
            Date de la prochaine séance:
        </td>
        <td>
            <telerik:RadDatePicker ID="BirthDatePicker" runat="server" DbSelectedDate='<%# Bind("DATE_ENC") %>'>
                <DateInput DateFormat="dd/MM/yy" DisplayDateFormat="dd/MM/yy" DisplayText="" LabelWidth="40%"
                    type="text">
                    <ClientEvents OnLoad="onLoadBirthDatePicker" />
                </DateInput>
            </telerik:RadDatePicker>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="BirthDatePicker"
                ErrorMessage="Date!!!" CssClass="style11"></asp:RequiredFieldValidator>
            &nbsp;<asp:Label ID="Label2" runat="server" Text="" CssClass="style11"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Niveau&nbsp; Anglais*:&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style4">
             <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="rbWidth"
                AppendDataBoundItems="True" DataSourceID="Sqlanglais" DataTextField="LIB_NOME"
                ValidationGroup="nivang" DataValueField="CODE_NOME" SelectedValue='<%#Eval("AV_ANG")%>'>
                <asp:ListItem>
                </asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="RadioButtonList1"
                Text="Valeur Requise!" ValidationGroup="nivang" style="color: #FF0000">
            </asp:RequiredFieldValidator>
            <br />
            &nbsp;<telerik:RadTextBox ID="RadTextBox2" runat="server"   Text='<%# DataBinder.Eval( Container, "DataItem.OBS_ANGLAIS") %>'
                EmptyMessage="Remarques anglais" Height="26px" InvalidStyleDuration="100" Width="293px">
            </telerik:RadTextBox>
            &nbsp;&nbsp;&nbsp;<br />
        </td>
        <td class="style5">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;Niveau Français*:
        </td>
        <td class="style4">
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" CssClass="rbWidth"
                AppendDataBoundItems="True" DataSourceID="Sqlanglais" DataTextField="LIB_NOME"
                ValidationGroup="nivfran" DataValueField="CODE_NOME" SelectedValue='<%#Eval("AV_FR")%>'>
                <asp:ListItem>
                </asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="RadioButtonList2"
                Text="Valeur Requise!" ValidationGroup="nivfran" CssClass="style11">
            </asp:RequiredFieldValidator>&nbsp;<br />
            &nbsp;<telerik:RadTextBox ID="RadTextBox1" runat="server" EmptyMessage="Remarques français" Text='<%# DataBinder.Eval( Container, "DataItem.OBS_FRANCAIS") %>'
                Height="26px" InvalidStyleDuration="100" Width="293px">
            </telerik:RadTextBox>
            <br />
        </td>
        <td class="style5">
            &nbsp;
        </td>
        <td>
            &nbsp;
            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Modifier" 
                Visible="<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>" />
            <asp:Button ID="btnInsert" runat="server" CommandName="PerformInsert" 
                Text="Ajouter" 
                Visible="<%# DataItem is Telerik.Web.UI.GridInsertionObject %>" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                CommandName="Cancel" Text="Annuler" />
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;Conformité / Cahier de charge:
        </td>
        <td class="style4">
            &nbsp;&nbsp;
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" SelectedValue='<%#Eval("AV_CC")%>' CssClass="rbWidth"
                ValidationGroup="cc">
                <asp:ListItem>
                </asp:ListItem>
                <asp:ListItem Value="1" Selected="True">OUI</asp:ListItem>
                <asp:ListItem Value="0">NON</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="RadioButtonList3"
                Text="Valeur Requise!" ValidationGroup="cc" CssClass="style11">
            </asp:RequiredFieldValidator>
            &nbsp;<br />
            &nbsp;<telerik:RadTextBox ID="RadTextBox3" runat="server" EmptyMessage="Remarques sur Cahier de charge"  Text='<%# DataBinder.Eval( Container, "DataItem.OBS_CC") %>'
                Height="26px" InvalidStyleDuration="100" Width="293px">
            </telerik:RadTextBox>
            <br />
            <br />
        </td>
        <td class="style5">
            &nbsp;
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DATE_ENC") %>'
                Visible="false"></asp:Label>
            <asp:SqlDataSource ID="Sqlanglais" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80')"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;Avancement Rapport%:
        </td>
        <td class="style4">
            &nbsp;&nbsp;<telerik:RadNumericTextBox ID="txtrapp" Type="Percent" MinValue="0" MaxValue="100"
                Text='<%# DataBinder.Eval( Container, "DataItem.AV_RAPPORT") %>' AllowOutOfRangeAutoCorrect="false"
                ShowSpinButtons="true" ValidationGroup="oppSub" runat="server" Height="20px"
                Width="60px">
                <NumberFormat DecimalDigits="0"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                ControlToValidate="txtrapp" ErrorMessage="*" CssClass="h5 text-danger" />
            &nbsp;<br />
            <br />
            &nbsp;<telerik:RadTextBox ID="RadTextBox5" runat="server"  EmptyMessage="Remarques Rapport " Text='<%# DataBinder.Eval( Container, "DataItem.OBS_RAPPORT") %>' 
                Height="26px" InvalidStyleDuration="100" Width="293px">
            </telerik:RadTextBox>
            <br />
        </td>
        <td class="style5">
            &nbsp;
        </td>
        <td align="right" colspan="2">
            
        </td>
    </tr>
</table>

