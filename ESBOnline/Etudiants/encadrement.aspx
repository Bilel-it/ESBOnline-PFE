<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="encadrement.aspx.cs" Inherits="ESPOnline.Etudiants.encadrement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../Contents/jquery.js" type="text/javascript"></script>

    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>

    
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
        <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">

<div class="row">
<div class="col-xs-2">
                
            
</div>
            <div class="col-xs-8">
            <br />
           
            <div class="row">
                    <%--Classe--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Type D'encadrement:" CssClass="text-success h4"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                             <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" 
                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                 <asp:ListItem Selected="True" Value="0">Choisir</asp:ListItem>
                                 <asp:ListItem Value="1">Individuel</asp:ListItem>
                                 <asp:ListItem Value="2">Groupe</asp:ListItem>
                             </asp:DropDownList>
                             </div>
                         </div>
                    </div>
            </div>
 
                <asp:Panel ID="PanelIndiv" runat="server" Visible="false">
                <hr />
                <div class="row">
                <div class="col-xs-1"> </div>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Projet Individuel :" CssClass="text-danger"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" 
                                    AutoPostBack="True" DataTextField="NOM_PROJET" DataValueField="ID_PROJET" 
                                    onselectedindexchanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    </div>
                   
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <center>
                     
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                            CellPadding="3" DataSourceID="ObjectDataSource1">
                        <Columns>

                            <asp:BoundField DataField="ID_ENS" HeaderText="Nom de l'enseignant" 
                                SortExpression="ID_ENS" />
                                <asp:BoundField DataField="DATE_ENC" HeaderText="Date évaluation" 
                                SortExpression="DATE_ENC" />
                            <asp:BoundField DataField="CODE_CL" HeaderText="Classe" 
                                SortExpression="CODE_CL" />
                            
                            <asp:BoundField DataField="AV_TECH" HeaderText="Avancement téchnique" 
                                SortExpression="AV_TECH" />
                            <asp:BoundField DataField="AV_ANG" HeaderText="Avancement anglais" 
                                SortExpression="AV_ANG" />
                            <asp:BoundField DataField="AV_FR" HeaderText="Avancement français" SortExpression="AV_FR" />
                            <asp:BoundField DataField="AV_RAPPORT" HeaderText="Avancement rapport" 
                                SortExpression="AV_RAPPORT" />
                            <asp:BoundField DataField="AV_CC" HeaderText="Avancement compte rendu" SortExpression="AV_CC" />
                            <asp:BoundField DataField="COMPORTEMENT" HeaderText="comportement" 
                                SortExpression="COMPORTEMENT" />
                            <asp:BoundField DataField="REMARQUE_OBS" HeaderText="Remarque et Observation" 
                                SortExpression="REMARQUE_OBS" />
                            <asp:BoundField DataField="TRAVAUX_DEMANDE" HeaderText="Traveaux Demander" 
                                SortExpression="TRAVAUX_DEMANDE" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                            SelectMethod="GetProjetSuivi" TypeName="ESPSuiviEncadrement.ESP_ENCADDREMENT">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList2" Name="ID_PROJET" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </center>
                        
                    </asp:Panel>
                </asp:Panel>
                





















                <asp:Panel ID="PanelGroup" runat="server" Visible="false">
                <hr />
                <div class="row">
                <div class="col-xs-1"> </div>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Nom Du Groupe :" CssClass="text-danger"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control"  
                                    AutoPostBack="True" onselectedindexchanged="DropDownList3_SelectedIndexChanged1"
                            >
                              </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    </div>
                </asp:Panel>



                <asp:Panel ID="Panel3" runat="server" Visible="false">
                <center>
                 <asp:Label ID="Label4" runat="server" Text="Evaluation individuelle dans le groupe" CssClass="text-warning"></asp:Label>  
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" DataSourceID="ObjectDataSource2">
                    <Columns>
                        <asp:BoundField DataField="DATE_EVAL" HeaderText="Date évaluation" 
                            SortExpression="DATE_EVAL" />
                        <asp:BoundField DataField="ID_ENS" HeaderText="Nom de l'enseignant" 
                            SortExpression="ID_ENS" />
                        <asp:BoundField DataField="ABS_ET" HeaderText="Absence" 
                            SortExpression="ABS_ET" />
                        <asp:BoundField DataField="NOTE_ET" HeaderText="Note" 
                            SortExpression="NOTE_ET" />
                        <asp:BoundField DataField="REMARQUE" HeaderText="Remarque" 
                            SortExpression="REMARQUE" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                        SelectMethod="GetResultatSuiviEtudiantParGroupe" 
                        TypeName="ESPSuiviEncadrement.recherche" 
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList3" Name="ID_PROJET" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:SessionParameter Name="id_et" SessionField="ID_ET" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                
                <asp:Button ID="LinkButton1" CssClass="btn btn-primary pull-right" runat="server"
                                Text="Evaluation Du Groupe" onclick="LinkButton1_Click" Visible="false"></asp:Button>
                                </center>
                </asp:Panel>

            </div>
            <div class="col-xs-2">
            </div>
</div>

</asp:Panel>


<script type="text/javascript" language="javascript">
    function openModalSuiviGroupe() {
        $('#Suivi_Groupe').modal('show')
    }
</script>



    <div class="modal swing" id="Suivi_Groupe" role="dialog">
                    <asp:Panel ID="panel44" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                              <h4 class="text-info">Suivi du groupe : </h4><asp:Label ID="Label5" runat="server" Text="" class="text-success"></asp:Label>
                            </div>
                            <div class="modal-body">
                            <div class="pre-scrollable">
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                        DataSourceID="ObjectDataSource3" 
        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
        CellPadding="4" GridLines="Horizontal">
                                        <Columns>

                                            <asp:BoundField DataField="NOM_GROUPE" HeaderText="Groupe" 
                                                SortExpression="NOM_GROUPE" />

                                            <asp:BoundField DataField="ID_ENS" HeaderText="Enseignant" 
                                                SortExpression="ID_ENS" />
                                            <asp:BoundField DataField="CODE_CL" HeaderText="Classe" 
                                                SortExpression="CODE_CL" />
                                            <asp:BoundField DataField="DATE_ENC" HeaderText="Date encadrement" 
                                                SortExpression="DATE_ENC" />
                                            <asp:BoundField DataField="AV_TECH" HeaderText="AV technique" 
                                                SortExpression="AV_TECH" />
                                            <asp:BoundField DataField="AV_ANG" HeaderText="AV Anglais" 
                                                SortExpression="AV_ANG" />
                                            <asp:BoundField DataField="AV_FR" HeaderText="AV Français" SortExpression="AV_FR" />
                                            <asp:BoundField DataField="AV_RAPPORT" HeaderText="AV Rapport" 
                                                SortExpression="AV_RAPPORT" />
                                            <asp:BoundField DataField="AV_CC" HeaderText="AV Compte rendu" SortExpression="AV_CC" />
                                            <asp:BoundField DataField="COMPORTEMENT" HeaderText="COMPORTEMENT" 
                                                SortExpression="COMPORTEMENT" />
                                            <asp:BoundField DataField="REMARQUE_OBS" HeaderText="REMARQUE_OBS" 
                                                SortExpression="REMARQUE_OBS" />
                                            <asp:BoundField DataField="TRAVAUX_DEMANDE" HeaderText="TRAVAUX demander" 
                                                SortExpression="TRAVAUX_DEMANDE" />
                                            <asp:BoundField DataField="NOTE_GROUPE" HeaderText="NOTE_GROUPE" 
                                                SortExpression="NOTE_GROUPE" />
                                           
                                            
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#487575" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#275353" />
                                    </asp:GridView>
                            </div>
                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                        SelectMethod="GetProjetSuiviparGroupe" 
                                        TypeName="ESPSuiviEncadrement.ESP_ENCADREMENT_GP">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList3" Name="id_proj" 
                                                PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                               
                            </div>
                            <div class="modal-footer">
                                <div class="btn-group">
                                    <asp:Button ID="Button16" CssClass="btn btn-default " runat="server" Text="Annuler" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>

<br />


   
    
</asp:Content>




                           