<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Chargement.aspx.cs" Inherits="ESPOnline.Administration.Chargement" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h3 class="text-center text-info"><strong>Configuration </strong></h3>
  </asp:Panel>
      <div class="row">
        <div class="col-xs-3">
        </div>
        <div class="col-xs-6">
            <div class="row">
                <div class="container">
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                         
                                   <br/>
                              </div>
                            </div>
                        </div>
                    
                    <div class="form-group">
                        <div class="form-inline">
                   
    <asp:Button ID="Button1" CssClass="btn btn-group-justified btn-success" runat="server"  onclick="Button1_Click" Text="Valider Jour Selectionner" />
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Button ID="Button2" CssClass="btn btn-group-justified btn-success" runat="server"  onclick="Button2_Click" Text="insert Séance" />
    <br />
    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" >
        <asp:ListItem>01</asp:ListItem>
        <asp:ListItem>02</asp:ListItem>
        <asp:ListItem>03</asp:ListItem>
        <asp:ListItem>04</asp:ListItem>
        <asp:ListItem>05</asp:ListItem>
        <asp:ListItem>06</asp:ListItem>
        <asp:ListItem>06</asp:ListItem>
        <asp:ListItem>07</asp:ListItem>
        <asp:ListItem>08</asp:ListItem>
        <asp:ListItem>09</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" >
        <asp:ListItem>2014</asp:ListItem>
        <asp:ListItem>2017</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
   <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" 
            Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px"
                NextPrevFormat="ShortMonth" OnPreRender="Calendar1_PreRender" Width="330px" 
                OnSelectionChanged="Calendar1_SelectionChanged" BorderStyle="Solid" 
            CellSpacing="1">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                    Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="#333399" Font-Bold="True"
                    Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>

         <br />
         <br />
         <asp:Button CssClass="btn-lg btn-danger" runat="server" ID="btnGetSelectedDate" Text="Get Selected Date" 
            onclick="btnGetSelectedDate_Click" Width="189px" Height="60px" /> <br />
                </div>
                  </div>
                    </div>
         <b>Selected Dates : </b><asp:Label runat="server" ID="lblDate" ></asp:Label>
                        </div>
                        </div>
                    </div>
                  <br />
                   
                    </asp:Panel>
                  
                    
        <div class="col-xs-3">
        </div>
  </div> 



   <asp:Panel ID="Panel1" runat="server">
  <h3 class="text-center text-info"><strong>Historiques d'Inscription </strong></h3>

  </asp:Panel>
                            <div class="form-group">
    
    </div>
      <div class="row">
        <div class="col-xs-3">
        </div>
        <div class="col-xs-6">
            <div class="row">
                <div class="container">
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                                  
     <asp:Button ID="Button4" CssClass="btn btn-danger" runat="server" Text="Valider" 
                                    ValidationGroup="ajouter_encadrement" onclick="Button4_Click" />
                                    <br>
                                    </br>
                                    <br></br>
                      
                               

     <asp:Button ID="LinkButton10" CssClass="btn btn-group-justified btn-primary" runat="server"  OnClick="LinkButton10_Click"
     Text="Supprimer date"></asp:Button> 


<script type="text/javascript" language="javascript">
    function openModalModifier() {
        $('#modifier_projet').modal('show');
    }
</script>
<div class="modal fade" id="modifier_projet" role="dialog">
                   
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4>
                                    Historiques Inscription</h4>
                            </div>
                            <div class="modal-body">
                                
                                   <div class="row">
        <div class="col-xs-3">

          </div>
             <div class="col-xs-6">
         

           
              <div class="row">
                 <div class="container">
                     <div class="form-group">
                        <div class="form-inline">
                            <div class="form-inline">                    
                                  <br/>
                              </div>
                            </div>
                        </div>       
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" CssClass="control-label text-info h4" Text="Select Date :"></asp:Label>
                                      </div>
                                <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownList4" CssClass="form-control" runat="server" 
                                        DataSourceID="SqlDataSource1" DataTextField="DATE_INS" 
                                        DataValueField="DATE_INS" AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList4_SelectedIndexChanged">
                                </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                        
                                        SelectCommand="SELECT UNIQUE date_INS FROM &quot;ESP_CCNA3&quot; order by date_ins">
                                    </asp:SqlDataSource>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                        SelectMethod="listerESP_INSCRI" TypeName="BLL.ENTETE" 
                                        OldValuesParameterFormatString="original_{0}">
                                    </asp:ObjectDataSource>
                                  </div>
                            </div>
                        </div>
                       
 </br>
                           
                            <asp:Button ID="Button3" CssClass="btn btn-group-justified btn-primary" 
                         runat="server"  OnClick="LinkButton11_Click"
     Text="Enregistrer PDF" Width="200px"></asp:Button> 
                            </br>
                                <asp:GridView ID="GridView3"  runat="server" BackColor="#DEBA84" AutoGenerateColumns="False" 
                                    DataSourceID="SqlDataSource3" BorderStyle="Dotted" 
                         CaptionAlign="Bottom" CellSpacing="2" Font-Italic="True" 
                         DataKeyNames="NOM_JETON">
      
                                    <Columns>
                                        <asp:BoundField DataField="ADRESSE_ET" HeaderText="ADRESSE_ET" 
                                            SortExpression="ADRESSE_ET" />
                                        <asp:BoundField DataField="DATE_INS" HeaderText="DATE_INS" 
                                            SortExpression="DATE_INS" />
                                        <asp:BoundField DataField="HEURE_INS" HeaderText="HEURE_INS" 
                                            SortExpression="HEURE_INS" />
                                        <asp:BoundField DataField="NOM_JETON" HeaderText="NOM_JETON" 
                                            SortExpression="NOM_JETON" ReadOnly="True" />        
                                        
                                       
                                        
                                    </Columns>
      
  <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
    <HeaderStyle BackColor="#A8A8A8" Font-Bold="True" 
        ForeColor="#D80000" />
    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
    <RowStyle BackColor="	#E0E0E0" ForeColor="#606060" />
    <SelectedRowStyle BackColor="#FF0000" 
        ForeColor="#FF0000" />
    <SortedAscendingCellStyle BackColor="#FFF1D4" />
    <SortedAscendingHeaderStyle BackColor="#B95C30" />
    <SortedDescendingCellStyle BackColor="#F1E5CE" />
      
  
</asp:GridView>
                           
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                         ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                         
                         SelectCommand="SELECT &quot;ADRESSE_ET&quot;, &quot;DATE_INS&quot;, &quot;HEURE_INS&quot;, &quot;NOM_JETON&quot; FROM &quot;ESP_CCNA3&quot; WHERE (&quot;DATE_INS&quot; = :DATE_INS) ORDER BY &quot;HEURE_INS&quot;">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DropDownList4" Name="DATE_INS" 
                                                    PropertyName="SelectedValue" Type="DateTime" />
                                            </SelectParameters>
                     </asp:SqlDataSource>
                           
                                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                         SelectMethod="listerRESP_INSCRIPardate" TypeName="BLL.ENTETE">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DropDownList4" Name="date" 
                                                    PropertyName="SelectedValue" Type="DateTime" />
                                                <asp:Parameter Name="heure" Type="String" />
                                            </SelectParameters>
                     </asp:ObjectDataSource>
                           
                                     </div>
                            </div>
                        </div>
                                        
                        </div>
                            </div>
                            <div class="modal-footer">
                                                   
                        <div class="btn-group">
                                 <asp:Button ID="Button6" CssClass="btn btn-default " runat="server" Text="Annuler" />
                                </div>
                            </div>
                            
                            
                            </div>
                            </div>
    
                           
           <div class="col-xs-3">
        </div>
         
                             
                                <br />
                                <asp:Panel ID="Panel2" runat="server" Visible="False">
                               
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                                    DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" 
                                        GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="DATE_CERT" HeaderText="DATE_CERT" 
                                            SortExpression="DATE_CERT" ReadOnly="True" />
                                    </Columns>
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        DeleteCommand="delete from COMPT_CERT WHERE DATE_CERT= COMPT_CERT.DATE_CERT" 
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                        SelectCommand="select distinct DATE_CERT from compt_cert">
                                    </asp:SqlDataSource>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                    SelectMethod="listerCOMPT_CERT" TypeName="BLL.COMPT_CERTSERVICES">
                                </asp:ObjectDataSource>
                                 </asp:Panel>
         
                             
        </div>
    </div>
        <div class="col-xs-3">
        </div>
  </div>



</asp:Content>
