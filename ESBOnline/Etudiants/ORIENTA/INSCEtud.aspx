<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true"
    CodeBehind="INSCEtud.aspx.cs" Inherits="ESPOnline.Etudiants.INSCEtud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
     <script type = "text/javascript">
         function Confirm() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("Do you want to save data?")) {
                 confirm_value.value = "Yes";
             } else {
                 confirm_value.value = "No";
             }
             document.forms[0].appendChild(confirm_value);
         }
    </script>
    <style type="text/css">
        .form-control
        {
            height: 22px;
        }
        .btn-success
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server">
        <h3 class="text-center text-info">
            <strong>Bienvenue à l&#39;Orientation session 2014/2015</strong>
        </h3>
        <%--<h3 class="text-center " style="color: #666666">
            <strong>Cette Page est deséactivé </strong>
        </h3>--%>
    </asp:Panel>
    <div class="row">
        <div class="col-xs-3">
        </div>
        <div class="col-xs-6">
            <div class="row">
                <div class="container">
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-inline">
                                <br />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label23" runat="server" CssClass="text-info h4" Text="Classe :"></asp:Label>
                                <asp:Label ID="LabCodeCl" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <br />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" CssClass="text-info h4" Text="choix Spécialité:"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownListSpec" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                    AutoPostBack="True" OnSelectedIndexChanged="DropDownListSpec_SelectedIndexChanged">
                                   <asp:ListItem>Choisir</asp:ListItem>
                                    <asp:ListItem>TELECOM</asp:ListItem>
                                  <asp:ListItem>INFORMATIQUE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    
                <br />
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label22" runat="server" CssClass="text-info h4" Text="choix 1:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" onselectedindexchanged="DropDownList5_SelectedIndexChanged" 
                                         >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label24" runat="server" CssClass="text-info h4" Text="choix 2:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList6" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" onselectedindexchanged="DropDownList6_SelectedIndexChanged" 
                                        >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                       
                      <%-- <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label26" runat="server" CssClass="text-info h4" Text="choix 4:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList8" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList4_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>--%>
                        <br />
                        <div class="navbar-brand btn-group pull-right">
                            <asp:Button ID="Button2" CssClass="btn btn-group-justified btn-success" runat="server"
                                Text="Valider"  Width="106px" onclick="Button2_Click" ></asp:Button>
                        </div>
                    </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" CssClass="text-info h4" Text="choix 1:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label12" runat="server" CssClass="text-info h4" Text="choix 2:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList2_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label13" runat="server" CssClass="text-info h4" Text="choix 3:"></asp:Label>
                                    
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList3_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                       <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label1244" runat="server" CssClass="text-info h4" Text="choix 4:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList4_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="navbar-brand btn-group pull-right">
                            <asp:Button ID="Button1" CssClass="btn btn-group-justified btn-success" runat="server"
                                Text="Valider"  Width="106px" onclick="Button1_Click"></asp:Button>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="P3Ainfo" runat="server" Visible="False">
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" CssClass="text-info h4" Text="choix 1:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfA1" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDChinfA1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" CssClass="text-info h4" Text="choix 2:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfA2" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDChinfA2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" CssClass="text-info h4" Text="choix 3:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfA3" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDChinfA3_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" CssClass="text-info h4" Text="choix 4:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfA4" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDChinfA4_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label14" runat="server" CssClass="text-info h4" Text="choix 5:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfA5" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DDChinfA5_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label15" runat="server" CssClass="text-info h4" Text="choix 6:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfA6" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DDChinfA6_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label16" runat="server" CssClass="text-info h4" Text="choix 7:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfA7" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DDChinfA7_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label17" runat="server" CssClass="text-info h4" Text="choix 8:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfA8" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DDChinfA8_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>




                        <br />
                        <div class="navbar-brand btn-group pull-right">
                            <asp:Button ID="BtnInfoA" CssClass="btn btn-group-justified btn-success" runat="server"
                                Text="Valider" OnClick="LinkButton11_Click" Width="106px"></asp:Button>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelATELECOM" runat="server" Visible="False">
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" CssClass="text-info h4" Text="choix 1:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChTelA1" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDChTelA1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label8" runat="server" CssClass="text-info h4" Text="choix 2:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChTelA2" runat="server" CssClass="form-control" Width="202px"  Height="30px" 
                                        AutoPostBack="True" OnSelectedIndexChanged="DDChTelA2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="navbar-brand btn-group pull-right">
                            <asp:Button ID="BtntelA" CssClass="btn btn-group-justified btn-success" runat="server"
                                Text="Valider" OnClick="LinkButton12_Click" Width="106px"></asp:Button>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelBTEL" runat="server" Visible="False">
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label9" runat="server" CssClass="text-info h4" Text="choix 1:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChTelB1" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDChTelB1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" CssClass="text-info h4" Text="choix 2:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChTelB2" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DDChTelB2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="navbar-brand btn-group pull-right">
                            <asp:Button ID="BtnTelB" CssClass="btn btn-group-justified btn-success" runat="server"
                                Text="Valider" OnClick="LinkButton13_Click" Width="106px"></asp:Button>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelBinfo" runat="server" Visible="False">
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label11" runat="server" CssClass="text-info h4" Text="choix 1:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfB1" runat="server" CssClass="form-control" 
                                        Width="202px"  Height="30px" 
                                        onselectedindexchanged="DDChinfB1_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-inline">
                                <div class="form-group">
                                    <asp:Label ID="Label26" runat="server" CssClass="text-info h4" Text="choix 2:"></asp:Label>
                                </div>
                                <div class="form-group pull-right">
                                    <asp:DropDownList ID="DDChinfB2" runat="server" CssClass="form-control" Width="202px"  Height="30px"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DDChinfB2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <br />
                        <div class="navbar-brand btn-group pull-right">
                                    <asp:Button ID="BtnInfB" CssClass="btn btn-group-justified btn-success" runat="server"
                                        Text="Valider" OnClick="LinkButton14_Click" Width="106px"></asp:Button>
                                </div>
                     
                    </asp:Panel>
                    <br />







                    <strong __designer:mapid="492">


                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                            
                            
                        SelectCommand="SELECT CH1, CH2, CH3, CH4,CH5, CH6, CH7, CH8, SPECIALITE, DATE_SAISIE FROM ESP_ORIENTATION WHERE ((ID_ET =:ID_ET) AND (ANNEE_DEB = '2014'))">
                            <SelectParameters>
                                <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                                
                            </SelectParameters>
                        </asp:SqlDataSource>


                    </strong>







                    <asp:DataList ID="DataList1" runat="server" CellPadding="4" 
                        DataSourceID="SqlDataSource1" ForeColor="Red" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" Font-Bold="False" 
                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                        Font-Underline="False" GridLines="Horizontal">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <ItemStyle BackColor="White" ForeColor="#333333" />
                        <ItemTemplate>
                           SPECIALITE:
                            <asp:Label ID="SPECIALITELabel" runat="server" 
                                Text='<%# Eval("SPECIALITE") %>' />
                            <br />
                            DATE SAISIE:
                            <asp:Label ID="DATE_SAISIELabel" runat="server" 
                                Text='<%# Eval("DATE_SAISIE") %>' />
                            <br />
                            Choix 1:
                            <asp:Label ID="CH1Label" runat="server" Text='<%# Eval("CH1") %>' />
                            <br />
                            Choix 2:
                            <asp:Label ID="CH2Label" runat="server" Text='<%# Eval("CH2") %>' />
                            <br />
                            Choix 3:
                            <asp:Label ID="CH3Label" runat="server" Text='<%# Eval("CH3") %>' />
                            <br />
                           Choix 4:
                            <asp:Label ID="CH4Label" runat="server" Text='<%# Eval("CH4") %>' />
                            <br />
                             Choix 5:
                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("CH5") %>' />
                            <br />
                            Choix 6:
                            <asp:Label ID="Label19" runat="server" Text='<%# Eval("CH6") %>' />
                            <br />
                            Choix 7:
                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("CH7") %>' />
                            <br />
                           Choix 8:
                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("CH8") %>' />
                            <br />
                           
                            <br />
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>







                   
                </div>
                
            </div>
    </div> </div>
</asp:Content>
