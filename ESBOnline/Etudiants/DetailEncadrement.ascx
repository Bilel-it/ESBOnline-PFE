<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailEncadrement.ascx.cs" Inherits="ESPOnline.Etudiants.DetailEncadrement" %>
 
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .style1
    {
        width: 100%;
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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
     
<script src="../Contents/Scripts/MaxLength.min.js" type="text/javascript"></script>
 
<style type="text/css">
    #Table1
    {
        background: #F0F0F0;
    }
    .style7
    {
        width: 140px;
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
        color: #CC0066;
    }
    .style12
    {
        color: #660033;
    }
    .style13
    {
        width: 181px;
    }
    .style14
    {
        width: 181px;
        height: 54px;
    }
    </style>
    <%--<script type="text/javascript">
        function ShowLabelContent() {
            var name = document.getElementById("<%=Label1.ClientID %>").value;
         
            alert(name);
            if (name == "0") {
                name.value == "rr";
            } 
        }
        onclick = ShowLabelContent;
    </script>--%>
<%--<script type="text/javascript">
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
        args.IsValid = true;
        if (Date4 < Date.now()) {
            label.innerText = "date erronée!!";
            args.IsValid = false;
        }
    }
    function validate(sender, args) {
        var label = document.getElementById('<%=Label1.ClientID%>');
        var Date1 = new Date(RadTimePicker1.get_selectedDate());
        var label2 = document.getElementById('<%=Label2.ClientID%>');
        var Date3 = new Date(RadDateTimePicker1.get_selectedDate());

        args.IsValid = true;

        if ((Date1.getHours() - Date3.getHours()) < 0 || (Date3 > Date.now())) {
            //  alert("The second time value should be greater than the first!");
            // alert(Date1.getHours());
            label.innerText = "DATE ERRONEE";
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
     
    </script>--%>


<table class="style1" id="Table1">
    <tr>
        <td class="style6">
            <b>Encadrement Info:</b>
        </td>
        <td class="style13">
            &nbsp;</td>
        <td class="style13">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            Date et heure d&#39;encadrement:</td>
        <td class="style13">
                      
                      <asp:TextBox ID="TextBox3" Text='<%# DataBinder.Eval( Container, "DataItem.HEURE_DEB") %>' runat="server" ReadOnly="true"></asp:TextBox></td>
        <td class="style13">
                      

                            

 
                           
                        &nbsp;
                    </td>
        <td class="style5">
            Observation:</td>
        <td>
           <asp:TextBox ID="TextBox1" Text='<%# DataBinder.Eval( Container, "DataItem.REMARQUE_OBS") %>' ReadOnly="true"
                            MaxLength="5" runat="server" TextMode="MultiLine"   Rows="5" Columns="40" TabIndex="5"  >
                            <%--TextMode="MultiLine" Rows="5" Columns="40" TabIndex="5"--%>
                        </asp:TextBox></td>
    </tr>
    <tr>
        <td class="style6">
            Heure Fin:</td>
        <td class="style13">
            <asp:TextBox ID="TimePicker1" Text='<%# DataBinder.Eval( Container, "DataItem.HEURE_FIN") %>' runat="server" ReadOnly="true"></asp:TextBox></td>
        <td class="style13">
            
                       <%-- <telerik:RadTimePicker ID="RadTimePicker1" Width="218px" runat="server" ReadOnly="true"
                            DbSelectedDate='<%# Bind("HEURE_FIN") %>' Height="25px">
                            <DateInput DateFormat="HH:mm:ss" Label="" ToolTip="Heure Fin:">
                                <ClientEvents OnLoad="onLoadRadTimePicker1"></ClientEvents>
                            </DateInput>
                            <TimeView TimeFormat="HH:mm:ss">
                            </TimeView>
                        </telerik:RadTimePicker>--%>
                         
                         
                    </td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
        <b>    Avancement Info:</b>
        </td>
        <td class="style14">
            &nbsp;</td>
        <td class="style14">
          <%--  <asp:CustomValidator ID="CustomValidator1" EnableClientScript="true" runat="server"
                        ControlToValidate="RadTimePicker1" ClientValidationFunction="validate">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator2" EnableClientScript="true" runat="server"
                        ControlToValidate="BirthDatePicker" ClientValidationFunction="validate2">
                    </asp:CustomValidator>--%></td>
        <td class="style9">
                        Travail demandé:
                    </td>
        <td class="style10">
            <asp:TextBox ID="TextBox2" runat="server" Columns="40" Rows="5" TabIndex="5" ReadOnly="true"
                Text='<%# DataBinder.Eval( Container, "DataItem.TRAVAUX_DEMANDE") %>' 
                TextMode="MultiLine">
                        </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
           Avancement technique%:</td>
        <td class="style13">
                
               <telerik:RadNumericTextBox ID="RadNumericTextBox1" Type="Percent" MinValue="0" MaxValue="100" Text='<%# DataBinder.Eval( Container, "DataItem.AV_TECH") %>'
                    AllowOutOfRangeAutoCorrect="false" ShowSpinButtons="true" ValidationGroup="oppSub" ReadOnly="true"
                    runat="server" Height="20px" Width="60px">
                    <NumberFormat DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox></td>
        <td class="style13">
                
                
               
                &nbsp;<telerik:RadTextBox ID="RadTextBox4" runat="server" AutoPostBack="true" ReadOnly="true" Text='<%# DataBinder.Eval( Container, "DataItem.OBS_TECH") %>'
                  EmptyMessage="Remarques sur avancement technique" Height="26px" InvalidStyleDuration="100" 
                  Width="293px">
              </telerik:RadTextBox>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            </td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style13">
           
            &nbsp;</td>
        <td class="style13">
           
        </td>
        <td class="style5">
            Date de la prochaine séance:</td>
        <td>
        <asp:TextBox ID="TextBox4" Text='<%# DataBinder.Eval( Container, "DataItem.DATE_ENC") %>' runat="server" ReadOnly="true"></asp:TextBox>
            <%--<telerik:RadDatePicker ID="BirthDatePicker" runat="server" 
                DbSelectedDate='<%# Bind("DATE_ENC") %>'>
                <DateInput DateFormat="dd/MM/yy" DisplayDateFormat="dd/MM/yy" DisplayText="" 
                    LabelWidth="40%" type="text">
                    <ClientEvents OnLoad="onLoadBirthDatePicker" />
                </DateInput>
            </telerik:RadDatePicker>--%>
            
            </td>
    </tr>
    <tr>
        <td class="style6">
            Niveau&nbsp;
            Anglais:&nbsp;&nbsp;&nbsp;</td>
        <td class="style13">
          <strong>  <asp:Label ID="Label3" runat="server" Text='<%# Bind("LANG")%>' 
                CssClass="style11"></asp:Label> </strong></td>
        <td class="style13">
           
            &nbsp;<%--<asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal" 
DataSourceID="Sqlanglais" DataTextField="LIB_NOME" ValidationGroup="nivang"
 DataValueField="CODE_NOME"></asp:RadioButtonList>
 <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8"
    ControlToValidate="RadioButtonList1" Text="Valeur Requise!" 
    ValidationGroup="nivang">
</asp:RequiredFieldValidator>--%><telerik:RadTextBox ID="RadTextBox2" runat="server" AutoPostBack="true" ReadOnly="true"  Text='<%# DataBinder.Eval( Container, "DataItem.OBS_ANGLAIS") %>'
                  EmptyMessage="Remarques anglais" Height="26px" InvalidStyleDuration="100" 
                  Width="293px">
              </telerik:RadTextBox>
             <br />
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
        </td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;Niveau Français: </td>
        <td class="style13">
            <strong>
            <asp:Label ID="Label4" runat="server" Text='<%# Bind("LFR")%>' 
                CssClass="style12"></asp:Label>  </strong></td>
        <td class="style13">
            <span class="style12"><strong>&nbsp;</strong></span><telerik:RadTextBox ID="RadTextBox1" runat="server" AutoPostBack="true" ReadOnly="true" Text='<%# DataBinder.Eval( Container, "DataItem.OBS_FRANCAIS") %>'
                  EmptyMessage="Remarques français" Height="26px" InvalidStyleDuration="100" 
                  Width="293px">
              </telerik:RadTextBox>
            <br />
&nbsp;<br />

            </td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
          &nbsp;Conformité / Cahier de charge:</td>
        <td class="style13">
           <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
 
<asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" SelectedValue='<%#Eval("AV_CC")%>' CssClass="rbWidth"  OnDataBound="RadioButtonList1_DataBound"  Visible="false"
             >
             <%--  <asp:ListItem>
                </asp:ListItem>--%>
                <asp:ListItem Value="1" >OUI</asp:ListItem>
                <asp:ListItem Value="0" Text="NON">NON</asp:ListItem>
            </asp:RadioButtonList></td>
        <td class="style13">
            &nbsp;<telerik:RadTextBox ID="RadTextBox3" runat="server" AutoPostBack="true" ReadOnly="true" Text='<%# DataBinder.Eval( Container, "DataItem.OBS_CC") %>'
                  EmptyMessage="Remarques sur Cahier des charges" Height="26px" InvalidStyleDuration="100" 
                  Width="293px">
              </telerik:RadTextBox>
            <br />
            <br />
            </td>
        <td class="style5">
            &nbsp;</td>
        <td>
              <asp:SqlDataSource ID="Sqlanglais" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80')">
                                                </asp:SqlDataSource></td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;Avancement Rapport%: </td>
        <td class="style13">
            <telerik:RadNumericTextBox ID="txtrapp" Type="Percent" MinValue="0" MaxValue="100" Text='<%# DataBinder.Eval( Container, "DataItem.AV_RAPPORT") %>'
                AllowOutOfRangeAutoCorrect="false" ShowSpinButtons="true" ValidationGroup="oppSub" ReadOnly="true"
                runat="server" Height="20px" Width="60px">
                <NumberFormat DecimalDigits="0"></NumberFormat>
            </telerik:RadNumericTextBox></td>
        <td class="style13">
            &nbsp;<telerik:RadTextBox ID="RadTextBox5" runat="server" AutoPostBack="true" ReadOnly="true" Text='<%# DataBinder.Eval( Container, "DataItem.OBS_RAPPORT") %>'
                  EmptyMessage="Remarques Rapport" Height="26px" InvalidStyleDuration="100" 
                  Width="293px">
              </telerik:RadTextBox>
            
            <br />
            </td>
        <td class="style5">
            &nbsp;</td>
        <td align="right">
             
            &nbsp;
            <asp:Button ID="btnCancel" Text="Annuler" runat="server" CausesValidation="False"
                CommandName="Cancel"></asp:Button></td>
    </tr>
</table>




