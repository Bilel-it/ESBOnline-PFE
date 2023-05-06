<%@ Page Title="" Language="C#" MasterPageFile="~/Enseignants/Ens.Master" AutoEventWireup="true" CodeBehind="EncadrementG.aspx.cs" Inherits="ESPOnline.Enseignants.EncadrementG" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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

       <%-- Script ******************///--%>

    <script type="text/javascript">
    function alert () {
        $("#alert_button").click(function () {
            jAlert('This is a custom alert box', 'Alert Dialog');
        });
    });
    </script>
    <script type="text/javascript">
        $('.form_datetime').datetimepicker({

            language: 'fr',
            startDate: '-0d',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            forceParse: 0,
            showMeridian: 1
        });
</script>
<script type="text/javascript">
    $('.form_time_start').datetimepicker({

        language: 'fr',
        weekStart: 0,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 1,
        minView: 0,
        maxView: 1,
        startDate: "8:00",
        endDate: "20.00",
        forceParse: 0

    });
</script>
<script type="text/javascript">
    $('.form_time_end').datetimepicker({

        language: 'fr',
        weekStart: 0,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 1,
        minView: 0,
        maxView: 1,
        startDate: "8:00",
        endDate: "20.00",
        forceParse: 0

    });
</script>
 <%-- Script ******************///--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                                 
 
     
  

     <div class="row">
            <div class="col-xs-3">
                
            </div>
            <div class="col-xs-6">
                
                <hr />
               
                <%--*****************************************************************************************************************************************--%>
                
               
                <div class="row">
                    <%--Classe--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label3" CssClass="control-label text-info h4" runat="server" Text="Classe :"></asp:Label>
                            </div>
                            
                            <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" AutoPostBack="True"
                                    EnableViewState="true" DataTextField="CODE_CL" DataValueField="CODE_CL" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ListSearchExtender ID="DropDownList2_ListSearchExtender" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList2">
                                </asp:ListSearchExtender>
                            </div>
                        </div>
                    </div>
                    <%--Module--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label22" CssClass="control-label text-info h4" runat="server" Text="Module :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownList5" CssClass="form-control" runat="server" DataTextField="DESIGNATION"
                                    DataValueField="CODE_MODULE" AutoPostBack="True" EnableViewState="true" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ListSearchExtender ID="DropDownList5_ListSearchExtender" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList5">
                                </asp:ListSearchExtender>
                            </div>
                        </div>
                    </div>
                    <%--type projet--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label4" CssClass="text-info h4" runat="server" Text="Type du projet :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="DropDownList4_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%--type Encadrement--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label1" CssClass="text-info h4" runat="server" Text="Type D'encadrement :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:DropDownList CssClass="form-control" ID="DropDownList12" runat="server" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="select_type_encadrement">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    
                    
                </div>
                <hr />
            </div>
            <div class="col-xs-3">
            </div>
        </div>
    
                <hr />



<asp:Panel ID="PanelHeadEncadrement" runat="server" Visible="false">
     <h3 class="text-center text-info"><strong>Suivi et Encadrement</strong></h3>
     </asp:Panel>
     <asp:Panel ID="PanelHeadEncadrementParGroupe" runat="server" Visible="false">
     <h3 class="text-center text-info"><strong>Suivi et Encadrement Par Groupe</strong></h3>
     <br />
     <%--***************************************************************************suivi par groupe************************************************************--%>
     <div class="row">
        <div class="col-xs-3">

            </div>
            <div class="col-xs-6">
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                            </div>
                    <div class="form-group pull-right">    
                    <asp:Button ID="LinkButton8" CssClass="btn btn-group btn-default" runat="server"  OnClick="LinkButton8_Click"
                                Text="Ajouter un Groupe"></asp:Button>

                                <asp:Button ID="LinkButton7" CssClass="btn btn-group btn-danger" runat="server"  
                                Text="Ajouter un Projet" onclick="LinkButton7_Click"></asp:Button>
                                
                    </div>
                    </div>
                    </div>
                    <hr />
                    <%--Nom Groupe--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label35" CssClass="control-label text-info h4" runat="server" Text="Nom Groupe :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownList8" CssClass="form-control" runat="server"  
                                    AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList8_SelectedIndexChanged1">
                                </asp:DropDownList>
                                <asp:ListSearchExtender ID="DropDownList8_ListSearchExtender" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList8">
                                </asp:ListSearchExtender>
                            </div>
                        </div>
                    </div>
                    </div>
                    <%-- liste Etudiant--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label42" CssClass="control-label text-info h4" runat="server" Text="Liste Etudiant :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownList13" CssClass="form-control" runat="server"  
                                    AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList13_SelectedIndexChanged">
                                </asp:DropDownList>
                                
                                <asp:ListSearchExtender ID="ListSearchExtender1" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList13"></asp:ListSearchExtender>
                            </div>
                        </div>
                    </div>
                    </div>
                    <%--Button--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <hr />
                            </div>
                            <div class="form-group pull-right">

                            
                                
                                <asp:Button ID="LinkButton9" CssClass="btn btn-group btn-danger" runat="server"  
                                Text="Affecter des etudiants" onclick="LinkButton9_Click"></asp:Button>
                                
                                <asp:Button ID="LinkButton6" CssClass="btn btn-group btn-default" runat="server"  OnClick="suivi_groupe"
                                Text="suivi du Groupe" Visible="false"></asp:Button>

                               
                                
                            </div>
                            <div class="form-group pull-left">
                            <asp:Panel ID="PanelLinkEvalEtudiant" runat="server" Visible="false" CssClass="panel-info">    
                             <asp:Button ID="LinkButton10" CssClass="btn btn-group btn-primary" runat="server"  OnClick="LinkButton10_Click"
                                Text="Evaluation Etudiant(e)"></asp:Button>
                                <br />
                                <asp:Button ID="LinkButton11" CssClass="btn btn-group btn-success" runat="server"  
                                Text="Suivi Etudiant" onclick="LinkButton11_Click"></asp:Button>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
    </div>
    </div>
    
    

     </asp:Panel>

     <asp:Panel ID="PanelEtudiant" runat="server" Visible="false">
    

        <div class="row">
        <div class="col-xs-3">
            </div>
            <div class="col-xs-6">
            
                    <%--Etudiant--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label40" CssClass="control-label text-info h4" runat="server" Text="Etudiant :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" DataTextField="NOM_ET"
                                    DataValueField="ID_ET" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ListSearchExtender ID="DropDownList3_ListSearchExtender" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList3">
                                </asp:ListSearchExtender>
                            </div>
                        </div>
                    </div>
                    <%--nom projet--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label23" CssClass="text-info h4" runat="server" Text="Titre du projet :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:DropDownList CssClass="form-control" ID="DropDownList7" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ListSearchExtender ID="DropDownList7_ListSearchExtender" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList7">
                                </asp:ListSearchExtender>
                            </div>
                        </div>
                    </div>
                    <%--status Etudiant--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="LabelStatusEtudiant" CssClass="control-label text-info h4" runat="server" Text="Status Etudiant :" Visible="false"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                <asp:Label ID="LabelAffectationEtudiant" CssClass="control-label text-danger" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                            
                        </div>
                    </div>
                    </div>
                    <div class="col-xs-3">
            </div>
                </div>
                </asp:Panel>


<%--Panel 2 button linkbutton--%>

         <div class="row">
            <div class="col-xs-3">
            </div>
            <div class="col-xs-6">
                <hr />
                <div class="row">
                    <div class="row">
                    
                        <div class="navbar-brand btn-group pull-right">
                        <asp:Button ID="LinkButton2" CssClass="btn btn-danger" runat="server" OnClick="LinkButton2_Click"
                                Text="Ajouter"></asp:Button>
                        <asp:Button ID="LinkButton3" CssClass="btn btn-default" runat="server" OnClick="LinkButton3_Click"
                                Text="Modifier"></asp:Button>
                        <asp:Button ID="LinkButton1" CssClass="btn btn-danger" runat="server" OnClick="LinkButton1_Click1" 
                                Text="Suivi"></asp:Button>
                         
                                
                        </div>
                    </div>                    
                </div>
             </div>
             <div class="col-xs-3">
            </div>
            </div>



<%--Panel 3 groupe par nom de projet--%>
        


<%--***********************************************************************************SUIVI evaluation**************************************************************************--%>

<asp:Panel ID="Panel3" runat="server" Visible="false" CssClass="panel-group">
    <div class="row">
    <div class="col-xs-3">
     </div>
    <div class="col-xs-6">
    <hr />
    <h2 class="text-danger text-center">Evaluation</h2>
    <hr />
        <asp:HiddenField ID="HiddenField1" runat="server" />

 

            <div class="form-group">
            <div class="form-inline">
            <div class="form-group">
            
                <asp:Label ID="Label24" CssClass="text-info h4" runat="server" Text="Heure debut :"></asp:Label>
   
<%--     <div class="col-xs-3">
     </div>--%>
                </div>
                <div class="form-group pull-right">
                <%--<asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeHolder="Date"></asp:TextBox>--%>
                <%--<div class="controls input-append date form_time_start" data-date="" data-date-format="hh:ii" data-link-format="hh:ii" data-link-field="dtp_input2">
                        <asp:TextBox  ID="TextBox2"  CssClass="form-control" runat="server" type="text" 
                            ReadOnly="True"></asp:TextBox>
                            <span class="add-on"><i class="icon-remove"></i></span>
					        <span class="add-on"><i class="icon-time"></i></span>
                        </div>--%>

                        <div class="controls input-append date form_time" data-date="" data-date-format="hh:ii" data-link-field="dtp_input2" data-link-format="hh:ii">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" CssClass="text-danger" ValidationGroup="ajouter_encadrement"></asp:RequiredFieldValidator>
                    <asp:TextBox  ID="TextBox2"  CssClass="form-control" runat="server" type="text" 
                            ReadOnly="True" placeHolder="Choisir heure début"></asp:TextBox>
                    <span class="add-on"><i class="icon-remove"></i></span>
					<span class="add-on"><i class="icon-th"></i></span>
                    <asp:HiddenField ID="dtp_input2" Value="" runat="server"></asp:HiddenField>
                        </div>
                        
            </div>
<script type="text/javascript">
    $('.form_time').datetimepicker({
        language: 'fr',
        startDate: '-1d',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 1,
        minView: 0,
        maxView: 1,
        forceParse: 0
    });
</script>

            </div>
            </div>
            <div class="form-group">
            <div class="form-inline">
            <div class="form-group">
            
                <asp:Label ID="Label25" CssClass="text-info h4" runat="server" Text="Heure fin :"></asp:Label>
                </div>
                <div class="form-group pull-right">
                <%--<asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeHolder="Date"></asp:TextBox>--%>
                <div class="controls input-append date form_time_end" data-date="" data-date-format="hh:ii" data-link-format="hh:ii" data-link-field="dtp_input3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox14" ErrorMessage="*" CssClass="text-danger" ValidationGroup="ajouter_encadrement"></asp:RequiredFieldValidator>
                        <asp:TextBox  ID="TextBox14"  CssClass="form-control" runat="server" type="text" 
                            ReadOnly="True" placeHolder="Choisir heure fin"></asp:TextBox>
                            <span class="add-on"><i class="icon-remove"></i></span>
					        <span class="add-on"><i class="icon-time"></i></span>
                            <asp:HiddenField ID="dtp_input3" Value="" runat="server"></asp:HiddenField>
                        </div>
            </div>

<script type="text/javascript">
    $('.form_time_end').datetimepicker({
        language: 'fr',
        startDate: '-1d',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 1,
        minView: 0,
        maxView: 1,
        forceParse: 0
    });
</script>

            </div>
            </div>
            <hr />

          <%--  ************************************************************************************************************************************* --%>
    
    <%--Avancement Technique--%>
    
            <div class="form-group">
            <div class="form-inline">
            <div class="form-group">
            
                <asp:Label ID="Label8" CssClass="text-info h4" runat="server" Text="Avancement Technique :"></asp:Label>
    <div class="col-xs-3">
        
    </div>
                </div>
                
                <div class="form-group pull-right">
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeHolder="%" ></asp:TextBox>
                </div>
                </div>
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox ID="TextBox19" runat="server" CssClass="form-control" Width= "50px" ></asp:TextBox>
                </div>
                </div>
                    <asp:SliderExtender ID="SliderExtender1" runat="server" BoundControlID="TextBox19" Enabled="true" Maximum="99" Minimum="0" Orientation="Horizontal" TargetControlID="TextBox3">
                    </asp:SliderExtender>
            </div>
            </div>
            </div>

            <%--Communication--%>
            <div class="form-group">
            
                <asp:Label ID="Label9" CssClass="text-info h4" runat="server" Text="Avancement de la communication :"></asp:Label>
                </div>
        
                <div class="form-group">
                <div class="form-inline">
                 <div class="form-group">
                <asp:Label ID="Label10" CssClass="text-muted h4" runat="server" Text="- Anglais :"></asp:Label>
                </div>
                 
                <div class="form-group pull-right"">
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeHolder="%" ></asp:TextBox>
                </div>
                </div>
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox ID="TextBox20" runat="server" CssClass="form-control" Width= "50px" ></asp:TextBox>
                </div>
                </div>
                <asp:SliderExtender ID="SliderExtender2" runat="server" BoundControlID="TextBox20" Enabled="true" Maximum="99" Minimum="0" Orientation="Horizontal" TargetControlID="TextBox4">
                    </asp:SliderExtender>
                </div>
                </div>
                </div>
                <div class="form-group">
                <div class="form-inline">
                 <div class="form-group">
                <asp:Label ID="Label11" CssClass="text-muted h4" runat="server" Text="- Français :"></asp:Label>
                </div>
                 
                <div class="form-group pull-right">
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeHolder="%" ></asp:TextBox>
                </div>
                </div>
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox ID="TextBox21" runat="server" CssClass="form-control" Width= "50px" ></asp:TextBox>
                <asp:SliderExtender ID="SliderExtender3" runat="server" BoundControlID="TextBox21" Enabled="true" Maximum="99" Minimum="0" Orientation="Horizontal" TargetControlID="TextBox6">
                    </asp:SliderExtender>

                </div>
                </div>
                </div>
                </div>
                </div>

            <%--Rédaction--%>
            <div class="form-group">
            
                <asp:Label ID="Label12" CssClass="text-info h4" runat="server" Text="Avancement de la rédaction :"></asp:Label>
                </div>

                <div class="form-group">
                <div class="form-inline">
                 <div class="form-group">
                <asp:Label ID="Label13" CssClass="text-muted h4" runat="server" Text="- Cahier de charge :"></asp:Label>
                </div>
                 
                <div class="form-group pull-right"">
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeHolder="%" ></asp:TextBox>
                </div>
                </div>
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox ID="TextBox22" runat="server" CssClass="form-control" Width= "50px" ></asp:TextBox>
                </div>
                </div>
                <asp:SliderExtender ID="SliderExtender4" runat="server" BoundControlID="TextBox22" Enabled="true" Maximum="99" Minimum="0" Orientation="Horizontal" TargetControlID="TextBox7">
                    </asp:SliderExtender>
                </div>
                </div>
                </div>
                <div class="form-group">
                <div class="form-inline">
                 <div class="form-group">
                <asp:Label ID="Label14" CssClass="text-muted h4" runat="server" Text="- Rapport final :"></asp:Label>
                </div>
                 
                <div class="form-group pull-right">
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeHolder="%" ></asp:TextBox>
                 </div>
                 </div>
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox ID="TextBox23" runat="server" CssClass="form-control" Width= "50px" ></asp:TextBox>
                </div>
                </div>
                <asp:SliderExtender ID="SliderExtender5" runat="server" BoundControlID="TextBox23" Enabled="true" Maximum="99" Minimum="0" Orientation="Horizontal" TargetControlID="TextBox8">
                    </asp:SliderExtender>
                </div>
                </div>
                </div>

                <%--Fin Rédaction--%>

                <%--Avancement Global--%>
                <div class="form-group">
            <div class="form-inline">
            <div class="form-group">
            
                <asp:Label ID="Label15" CssClass="text-info h4" runat="server" Text="Avancement global :"></asp:Label>
                </div>
                <div class="form-group pull-right">
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server"></asp:TextBox>
                   </div>
                 </div>
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox ID="TextBox24" runat="server" CssClass="form-control" Width= "50px"></asp:TextBox>
                </div>
                </div>
                <asp:SliderExtender ID="SliderExtender6" runat="server" BoundControlID="TextBox24" Enabled="true" Maximum="99" Minimum="0" Orientation="Horizontal" TargetControlID="TextBox9">
                    </asp:SliderExtender>
            </div>
            </div>
            </div>
            <%--Comportement--%>
             <div class="form-group">

            <div class="form-inline">
            <div class="form-group">
            
                <asp:Label ID="Label16" CssClass="text-info h4" runat="server" Text="Comportement :"></asp:Label>
                </div>
                <div class="form-group pull-right">
            <div class="radio-inline">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radio" 
                    Font-Size="Small" RepeatDirection="Horizontal">
            <asp:ListItem Value="M" Selected="True">Mauvais</asp:ListItem>
            <asp:ListItem Value="PM" >Plutôt mauvais</asp:ListItem>
            <asp:ListItem Value="PB">Plutôt bien</asp:ListItem>
            <asp:ListItem Value="B">Bien</asp:ListItem> 
        </asp:RadioButtonList>
        </div>
        </div>
        </div>
        </div>
           
        <br />
        <br />
        <h5 class="text-danger pull-right">* L'évaluation est en pourcentage (%)</h5>
        <br />
         
        <hr />    
    </div>
    <div class="col-xs-3">
    </div>
    </div>

   <%-- Observation Travail--%>
    <div class="row">

    <div class="col-xs-3">
    </div>
    <div class="col-xs-6">
            
            <hr />
            <%--Remarques et observations--%>
             <div class="form-group">
             <div class="container">
              <div class="form-inline">
            <div class="form-group pull-left">
            
                <asp:Label ID="Label17" CssClass="text-info h4" runat="server" Text="Remarques et observations :"></asp:Label>
                </div>
                <div class="form-group pull-right">
                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server"  MaxLength="2000"
                        placeHolder="Remarques et observations (2000 caractères maximum)" TextMode="MultiLine" 
                        Width="350px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox10" ErrorMessage="*" CssClass="text-danger" ValidationGroup="ajouter_encadrement"  ></asp:RequiredFieldValidator>
                </div>
            </div>
            </div>
            </div>

            <%--Travail demandé--%>
             <div class="form-group">
             <div class="container">
              <div class="form-inline">
            <div class="form-group pull-left">
            
                <asp:Label ID="Label18" CssClass="text-info h4" runat="server" Text="Travail demandé :"></asp:Label>
                </div>
                <div class="form-group pull-right">
                <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server"  MaxLength="2000"
                        placeHolder="Travail demandé (2000 caractères maximum)" TextMode="MultiLine" 
                        Width="350px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox11" ErrorMessage="*" CssClass="text-danger" ValidationGroup="ajouter_encadrement"  ></asp:RequiredFieldValidator>
                        
            </div>
            </div>
            </div>
            </div>
            <hr />
            <asp:Panel ID="PanelNoteDeGroupe" runat="server" Visible="false">
            <%-- Note de groupe--%>
                <div class="form-group">
            <div class="form-inline">
            <div class="form-group">
            
                <asp:Label ID="Label53" CssClass="text-info h4" runat="server" Text="Note de Groupe:"></asp:Label>
                </div>
                <div class="form-group pull-right">
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox CssClass="form-control" ID="TextBoxNoteGROUPE" runat="server"></asp:TextBox>
                   </div>
                 </div>
                <div class="form-group ">
                         <div class="col-xs-3">
                <asp:TextBox ID="TextBoxNote" runat="server" CssClass="form-control" Width= "50px"></asp:TextBox>
                </div>
                </div>
                <asp:SliderExtender ID="SliderExtender7" runat="server" BoundControlID="TextBoxNote" Enabled="true" Maximum="20" Minimum="0" Orientation="Horizontal" TargetControlID="TextBoxNoteGROUPE">
                    </asp:SliderExtender>
            </div>
            </div>
            </div>
            <hr />
             </asp:Panel>
    </div>
        
    <div class="col-xs-3">
    </div>
    </div>

    <div class="row">
    <div class="col-xs-3">
    </div>
     <div class="col-xs-6">
     <hr />
        <%-- Date nouvelle seance--%>
        
            <div class="form-group">
            <div class="form-inline">
            <div class="form-group">
            
                <asp:Label ID="Label6" CssClass="text-info h4" runat="server" Text="Date de la prochaine séance :"></asp:Label>
                </div>
                <div class="form-group pull-right">
                <%--<asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeHolder="Date"></asp:TextBox>--%>
                
                <div class="controls input-append date form_datetime"  data-date-format="dd/mm/yyyy - HH:ii p" data-link-field="dtp_input1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" CssClass="text-danger" ValidationGroup="ajouter_encadrement"></asp:RequiredFieldValidator>
                        <asp:TextBox  ID="TextBox1"  CssClass="form-control" runat="server" type="text" 
                            ReadOnly="True" placeHolder="Choisir la date"></asp:TextBox>
                            <span class="add-on"><i class="icon-remove"></i></span>
					        <span class="add-on"><i class="icon-th"></i></span>
                            <asp:HiddenField ID="dtp_input1" Value="" runat="server"></asp:HiddenField>
                        </div>
                        
                <script type="text/javascript">
                    $('.form_datetime').datetimepicker({

                        language: 'fr',
                        startDate: '-0d',
                        weekStart: 1,
                        todayBtn: 1,
                        autoclose: 1,
                        todayHighlight: 1,
                        startView: 2,
                        forceParse: 0,
                        showMeridian: 1
                    });
                </script>
            </div>
            </div>
            </div>
            <hr />
    </div>
    <div class="col-xs-3">
    </div>
    </div>
    <div class="row">
    <div class="col-xs-3"></div>
    <div class="col-xs-6">
    <br />
    <br />
    <div class="pull-right">
        <asp:Button ID="Button1" CssClass="btn btn-danger" runat="server" Text="Valider" ValidationGroup="ajouter_encadrement" 
            onclick="Button1_Click" />
    <asp:Button ID="Button2" CssClass="btn btn-default" runat="server" Text="Annuler" 
            onclick="Button2_Click" />
            <asp:Button ID="Button13" CssClass="btn btn-danger" runat="server" 
            Text="Validerr" ValidationGroup="ajouter_encadrement" 
            onclick="Button13_Click" />
    <asp:Button ID="Button14" CssClass="btn btn-default" runat="server" Text="Annulerr" 
            onclick="Button2_Click" />
    </div>
    <br />
    <br />
    </div>
        
    <div class="col-xs-3">

    </div>
    </div>

    </asp:Panel>



<%--***********************************************************************************Les Modals**************************************************************************--%>
<%--Script--%>
<script type="text/javascript" language="javascript">
    function openModalAjouter() {
        $('#creer_projet').modal('show');
    }
</script>


<script type="text/javascript" language="javascript">
    function openModalcreate_Groupe() {
        $('#Modal_Add_Groupe').modal('show');
    }
</script>

<script type="text/javascript" language="javascript">
    function openModalAjouterGP() {
        $('#creer_projet_gp').modal('show');
    }
</script>


    
<script type="text/javascript" language="javascript">
    function openModalModifier() {
        $('#modifier_projet').modal('show');
    }
</script>

<script type="text/javascript" language="javascript">
    function openModalgroupe_projet() {
        $('#groupe_projet').modal('show');
    }
</script>

<script type="text/javascript" language="javascript">
    function openModalEvaluationEtudiantGroup() {
        $('#eval_Etudiant').modal('show');
    }
</script>

<script type="text/javascript" language="javascript">
    function openModalAffecterGroupe() {
        $('#Affecter_Groupe').modal('show');
    }
</script>

<%--<script type="text/javascript" language="javascript">
    function openModalsuiviET() {
        $('#suivi_etudiant').modal('show');
    }
</script>--%>


<%--popup modal--%>





<%--MODIFIER UN PROJET--%>
                <div class="modal fade" id="modifier_projet" role="dialog">
                    <asp:Panel ID="panel2" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4>
                                    Modifer projet</h4>
                            </div>
                            <div class="modal-body">
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetProj"
                                    TypeName="ESPSuiviEncadrement.ESP_PROJET_DETAILS">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DropDownList7" Name="id" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource3">
                                    <ItemTemplate>
                                        <%--Id Projet--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label31" CssClass="text-info h4" runat="server" Text="Id projet :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                    <asp:TextBox CssClass="form-control" ID="TextBox18" runat="server" Enabled="false"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ID_PROJET")%>'></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Titre Projet--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label34" CssClass="text-info h4" runat="server" Text="Nom projet :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                    <asp:TextBox CssClass="form-control" ID="TextBox25" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NOM_PROJET")%>'></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Niveau Etudiant--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label33" CssClass="text-info h4" runat="server" Text="Niveau etudiant :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                <asp:Label CssClass="form-control" ID="TextBoxNiveau" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NIVEAU_ETUDIANT")%>'></asp:Label>

                                                </div>
                                            </div>
                                        </div>
                                        <%--Semestre--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label27" CssClass="text-info h4" runat="server" Text="Semestre :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                    <asp:RadioButtonList ID="RadioButtonList2" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "SEMESTRE")%>'
                                                        runat="server" CellPadding="5" CellSpacing="5" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True">1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Periode--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label32" CssClass="text-info h4" runat="server" Text="Periode :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                    <asp:RadioButtonList ID="RadioButtonList3" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "PERIODE")%>'
                                                        runat="server" CellPadding="5" CellSpacing="5" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True">1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Durée--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label28" CssClass="text-info h4" runat="server" Text="Durée :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                    <asp:DropDownList ID="DropDownList9" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "DUREE")%>'
                                                        CssClass="form-control" runat="server">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7</asp:ListItem>
                                                        <asp:ListItem>8</asp:ListItem>
                                                        <asp:ListItem>9</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Technologies--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label29" CssClass="text-info h4" runat="server" Text="Technologies :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                    <asp:DropDownList ID="DDlistTech2" CssClass="form-control" runat="server" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "TECHNOLOGIES")%>'
                                                        DataSourceID="SqlDataSourcetectnologies1" DataTextField="LIB_NOME" DataValueField="CODE_NOME">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSourcetectnologies1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                        SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '65')"></asp:SqlDataSource>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Methodologies--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label30" CssClass="text-info h4" runat="server" Text="Methodologies :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                    <asp:DropDownList ID="DDlistMethod2" CssClass="form-control" runat="server" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "METHODOLOGIE")%>'
                                                        DataSourceID="SqlDataSourceMethodologies1" DataTextField="LIB_NOME" DataValueField="CODE_NOME">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSourceMethodologies1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                        SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '64')"></asp:SqlDataSource>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Description--%>
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:Label ID="Label26" CssClass="text-info h4" runat="server" Text="Description :"></asp:Label>
                                                </div>
                                                <div class="form-group pull-right">
                                                    <asp:TextBox ID="TextBox15" CssClass="form-control" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIPTION_PROJET")%>'
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="modal-footer">
                                <div class="btn-group">
                                    <asp:Button ID="Button5" CssClass="btn btn-danger " runat="server" Text="Valider"
                                        OnClick="Button5_Click" />
                                    <asp:Button ID="Button6" CssClass="btn btn-default " runat="server" Text="Annuler" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>







<%--Modal CREER UN projet par Groupe--%>
                <div class="modal fade" id="Modal_Add_Groupe" role="dialog">
                    <asp:Panel ID="panel7" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4>
                                    Nouveau projet Par Groupe</h4>
                            </div>
                <div class="modal-body">
                            <h4 class="text-center text-success"><strong>Ajouter un Projet Par Groupe</strong></h4>
                    <%--NOM DU GROUPE--%>
                    <div class="form-group">
                            <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label37" CssClass="control-label text-info h4" runat="server" Text="Nom Du Groupe :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                                
                                <asp:TextBox runat="server" ID="textboxNomGroupe" CssClass="form-control" placeHolder="nom du groupe"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="textboxNomGroupe" ErrorMessage="*" CssClass="text-danger" ValidationGroup="addGP"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                   
                   <%--description du groupe--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label38" CssClass="control-label text-info h4" runat="server" Text="Sujet :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                            
                                <asp:TextBox runat="server" ID="textboxSujetPI" CssClass="form-control"  placeHolder="Sujet"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="textboxSujetPI" ErrorMessage="*" CssClass="text-danger" ValidationGroup="addGP"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    
                    <%--numero du groupe--%>
                    <div class="form-group">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:Label ID="Label39" CssClass="control-label text-info h4" runat="server" Text="Numéro du groupe :"></asp:Label>
                            </div>
                            <div class="form-group pull-right">
                               <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                   <asp:ListItem Selected="True" Value="choi">Choisir</asp:ListItem>
                                   <asp:ListItem>1</asp:ListItem>
                                   <asp:ListItem>2</asp:ListItem>
                                   <asp:ListItem>3</asp:ListItem>
                                   <asp:ListItem>4</asp:ListItem>
                                   <asp:ListItem>5</asp:ListItem>
                                   <asp:ListItem>6</asp:ListItem>
                                   <asp:ListItem>7</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="textboxSujetPI" ErrorMessage="*" CssClass="text-danger" ValidationGroup="addGP"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <%--Titre Projet--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label43" CssClass="text-info h4" runat="server" Text="Titre du projet :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">

                                        <asp:DropDownList ID="DropDownList17" CssClass="form-control" runat="server" >
                                        </asp:DropDownList>
                                        <asp:ListSearchExtender ID="ListSearchExtender2" runat="server" 
                                            Enabled="True" TargetControlID="DropDownList17">
                                        </asp:ListSearchExtender>


                                          
                                            
                                        </div>
                                    </div>
                                </div>
                   </div>
                            <div class="modal-footer">
                                <div class="btn-group">
                                   <asp:Button ID="Button11" CssClass="btn btn-danger" runat="server" 
                                Text="Ajouter" onclick="Button11_Click" ValidationGroup="addGP"></asp:Button>
                        
                                 <asp:Button ID="Button12" CssClass="btn btn-default" runat="server"
                                Text="cancel" OnClick="cancel_create_groupe"></asp:Button>
                                </div>
                            </div>
                        </div>
                      
                    </asp:Panel>
                </div>

























<%--CREER UN PROJET--%>
                <div class="modal fade" id="creer_projet" role="dialog">
                    <asp:Panel ID="panel1" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4>
                                    Nouveau projet</h4>
                            </div>
                            <div class="modal-body">
                            <asp:ValidationSummary ID="sum" runat="server" ValidationGroup="ajouter_projet"/>
                                <%--Titre Projet--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" CssClass="text-info h4" runat="server" Text="Titre du projet :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                           
                                            <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeHolder="Titre de projet"></asp:TextBox><br />
                                        </div>
                                    </div>
                                </div>
                                <%--Niveau Etudiant--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label33" CssClass="text-info h4" runat="server" Text="Niveau etudiant :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:Label ID="Label21" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <%--Semestre--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label27" CssClass="text-info h4" runat="server" Text="Semestre :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" CellPadding="5" CellSpacing="5"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <%--Periode--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label32" CssClass="text-info h4" runat="server" Text="Periode :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" CellPadding="5" CellSpacing="5"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <%--Durée--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" CssClass="text-info h4" runat="server" Text="Durée :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DropDownList6" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="Mois">Mois</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <%--Technologies--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label19" CssClass="text-info h4" runat="server" Text="Technologies :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DDlistTech" runat="server" CssClass="form-control" DataSourceID="SqlDataSourcetectnologies"
                                                DataTextField="LIB_NOME" DataValueField="CODE_NOME">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSourcetectnologies" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '65')"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                                <%--Methodologies--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label20" CssClass="text-info h4" runat="server" Text="Methodologies :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DDlistMethod" runat="server" CssClass="form-control" DataSourceID="SqlDataSourceMethodologies"
                                                DataTextField="LIB_NOME" DataValueField="CODE_NOME">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSourceMethodologies" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '64')"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                                <%--Description--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label26" CssClass="text-info h4" runat="server" Text="Description :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:TextBox ID="TextBox15" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="btn-group">
                                    <asp:Button ID="Button3" CssClass="btn btn-danger " runat="server" Text="Valider"
                                        OnClick="Button3_Click" />
                                    <asp:Button ID="Button4" CssClass="btn btn-default bottom-right" runat="server" Text="Annuler" />
                                </div>
                            </div>
                        </div>
                        <br />
                    </asp:Panel>
                </div>




 






<%--evaluation etudiant par groupe eval_Et--%>
    <div class="modal fade" id="eval_Etudiant" role="dialog">
                    <asp:Panel ID="panel44" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4>évaluer <asp:Label ID="labelevalEtu" runat="server" Text="" CssClass="label-success"></asp:Label> dans le groupe <asp:Label ID="labelevalGroupe" runat="server" Text="" CssClass="label-success"></asp:Label></h4>
                            </div>
                            <div class="modal-body">

                            <%--ABS--%>
                                <div class="form-group">
                                        <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label44" CssClass="control-label text-info h4" runat="server" Text="Absence :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:RadioButtonList ID="RadioButtonList6" runat="server" CssClass="radio" 
                                                        Font-Size="Small" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="oui">oui</asp:ListItem>
                                                <asp:ListItem Value="non" Selected="True">Non</asp:ListItem> 
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                               <%--Note--%>
                                <div class="form-group">
                                        <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label36" CssClass="control-label text-info h4" runat="server" Text="Note :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                        <div class="col-xs-3">
                                            <asp:TextBox runat="server" ID="textboxNoteEval" CssClass="form-control"></asp:TextBox>
                                            <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" placeHolder="%" ></asp:TextBox>
                                            <asp:SliderExtender ID="SliderExtender8" runat="server" BoundControlID="TextBox16" Enabled="true" Maximum="20" Minimum="0" Orientation="Horizontal" TargetControlID="textboxNoteEval">
                                            </asp:SliderExtender>
                                        </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="textboxNoteEval" ErrorMessage="*" CssClass="text-danger" ValidationGroup="addGP"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div> 
                                


                                <%--remarque--%>
                                <div class="form-group">
                                        <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label41" CssClass="control-label text-info h4" runat="server" Text="Remarque :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxRemarque" runat="server"  MaxLength="2000"
                                            placeHolder="Remarques et observations (2000 caractères maximum)" TextMode="MultiLine" 
                                            Width="350px" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="textboxNoteEval" ErrorMessage="*" CssClass="text-danger" ValidationGroup="addGP"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div> 
                                <hr /> 
                               
                                


                            </div>
                            <div class="modal-footer">
                                <div class="btn-group">
                                    <asp:Button ID="Button15" CssClass="btn btn-danger "  runat="server" Text="Valider" OnClick="Button15_Click"/>
                                    <asp:Button ID="Button16" CssClass="btn btn-default " runat="server" Text="Annuler" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>

<%-- ajouter groupe projet --%>
                <div class="modal fade" id="creer_projet_gp" role="dialog">
                    <asp:Panel ID="panel6" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4>crée projet par groupe</h4>
                            </div>
                            <div class="modal-body">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ajouter_projet_g"/>
                                <%--Titre Projet--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label5" CssClass="text-info h4" runat="server" Text="Titre du projet :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                           
                                            <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeHolder="Titre de projet"></asp:TextBox><br />
                                        </div>
                                    </div>
                                </div>
                                
                                <%--Semestre--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label52" CssClass="text-info h4" runat="server" Text="Semestre :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:RadioButtonList ID="RadioButtonList4" runat="server" CellPadding="5" CellSpacing="5"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <%--Periode--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label54" CssClass="text-info h4" runat="server" Text="Periode :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:RadioButtonList ID="RadioButtonList5" runat="server" CellPadding="5" CellSpacing="5"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <%--Durée--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label55" CssClass="text-info h4" runat="server" Text="Durée :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DropDownList11" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="Mois">Mois</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <%--Technologies--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label56" CssClass="text-info h4" runat="server" Text="Technologies :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DropDownList14" runat="server" CssClass="form-control" DataSourceID="SqlDataSourcetectnologies"
                                                DataTextField="LIB_NOME" DataValueField="CODE_NOME">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '65')"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                                <%--Methodologies--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label57" CssClass="text-info h4" runat="server" Text="Methodologies :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DropDownList15" runat="server" CssClass="form-control" DataSourceID="SqlDataSourceMethodologies"
                                                DataTextField="LIB_NOME" DataValueField="CODE_NOME">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '64')"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                                <%--Description--%>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <asp:Label ID="Label58" CssClass="text-info h4" runat="server" Text="Description :"></asp:Label>
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:TextBox ID="TextBox13" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="btn-group">
                                    <asp:Button ID="Button9" CssClass="btn btn-danger " runat="server" Text="Valider" OnClick="Button9_Click"/>
                                    <asp:Button ID="Button10" CssClass="btn btn-default " runat="server" Text="Annuler" />
                                </div>
                            </div>
                        </div>
                   </asp:Panel>
                </div>


<%--Affecter Etudiant au Groupe--%>
                <div class="modal fade" id="Affecter_Groupe" role="dialog">
                    <asp:Panel ID="panel5" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4>Affecter Etudiant au groupe</h4>
                            </div>
                            <div class="modal-body">
                                
                                <h5>Affecter</h5>
                                <asp:DropDownList ID="DropDownList10" runat="server" CssClass="form-control" runat="server" DataTextField="NOM_ET"
                                    DataValueField="ID_ET">
                                </asp:DropDownList>
                                <h5>Dans le Groupe</h5>
                                <asp:DropDownList ID="DropDownList16" runat="server" CssClass="form-control" runat="server" DataTextField="NOM_GROUPE"
                                    DataValueField="ID_GROUPE_PROJET" >
                                </asp:DropDownList>
                                <h5>Du classe</h5>
                                <asp:Label ID="LabelGroupeClasse" runat="server" Text="" CssClass="label-success"></asp:Label>
                                
                            </div>
                            <div class="modal-footer">
                                <div class="btn-group">
                                    <asp:Button ID="Button7" CssClass="btn btn-danger " runat="server" Text="Valider" OnClick="Button7_Click"/>
                                    <asp:Button ID="Button8" CssClass="btn btn-default " runat="server" Text="Annuler" />
                                </div>
                            </div>
                        <//div>
                    </asp:Panel>
                </div>

                
</asp:Content>
