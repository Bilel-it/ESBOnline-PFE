using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESPSuiviEncadrement;
using Oracle.ManagedDataAccess.Types;
using Telerik.Web.UI;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Affectation2 : System.Web.UI.Page
    {
        string x;
        string y;
        string z;
       public string idmodule;
        public string anneedeb;
        OracleTransaction myTrans;
        public OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            x = Session["UP"].ToString().Trim();
            y = Session["Nom_ENS"].ToString().Trim();
            z = Session["ID_ENS"].ToString().Trim();
            //  anneedeb = DAL.AffectationDAO.Instance.getanneedeb();
            
            if(!IsPostBack)
            {
            #region grid1filte
            GridFilterMenu menu = RadGrid1.FilterMenu;
            int i = 0;
            while (i < menu.Items.Count)
            {
                if (menu.Items[i].Text == "NoFilter" ||
                    menu.Items[i].Text == "Contains" ||
                    menu.Items[i].Text == "EqualTo" ||
                    menu.Items[i].Text == "GreatherThan"
                   )
                {
                    i++;
                }
                else
                {
                    menu.Items.RemoveAt(i);
                }
            }
            foreach (RadMenuItem item in menu.Items)
            {
                if (item.Text == "Contains")
                {
                    item.Text = "Contient";
                }
                if (item.Text == "DoesNotContain")
                {
                    item.Text = "NeContientpPas";
                }
                if (item.Text == "EndsWith")
                {
                    item.Text = "SETerminePar";
                } if (item.Text == "EqualTo")
                {
                    item.Text = "EgalA";
                }
                if (item.Text == "NotEqualTo")
                {
                    item.Text = "NonEgalA";
                }
            }
            #endregion
            #region grid1filte
            GridFilterMenu menu2 = RadGrid2.FilterMenu;
            int k = 0;
            while (k < menu2.Items.Count)
            {
                if (menu2.Items[k].Text == "NoFilter" ||
                    menu2.Items[k].Text == "Contains" ||
                    menu2.Items[k].Text == "EqualTo" ||
                    menu2.Items[k].Text == "GreatherThan"
                   )
                {
                    k++;
                }
                else
                {
                    menu2.Items.RemoveAt(k);
                }
            }
            foreach (RadMenuItem item in menu2.Items)
            {
                if (item.Text == "Contains")
                {
                    item.Text = "Contient";
                }
                if (item.Text == "DoesNotContain")
                {
                    item.Text = "NeContientpPas";
                }
                if (item.Text == "EndsWith")
                {
                    item.Text = "SETerminePar";
                } if (item.Text == "EqualTo")
                {
                    item.Text = "EgalA";
                }
                if (item.Text == "NotEqualTo")
                {
                    item.Text = "NonEgalA";
                }
            }
            #endregion
            }
        }

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem filteringItem = e.Item as GridFilteringItem;
                //set dimensions for the filter textbox  
                TextBox box = filteringItem["CODE_MODULE"].Controls[0] as TextBox;
                box.Height = Unit.Pixel(30);
                TextBox box2 = filteringItem["DESIGNATION"].Controls[0] as TextBox;
                box2.Height = Unit.Pixel(30);
                //TextBox box3 = filteringItem["NUM_SEMESTRE"].Controls[0] as TextBox;
                //box3.Height = Unit.Pixel(30);
                
            }
        }
        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem filteringItem = e.Item as GridFilteringItem;
                //set dimensions for the filter textbox  
                TextBox box = filteringItem["CODE_CL"].Controls[0] as TextBox;
                box.Height = Unit.Pixel(30);
                TextBox box2 = filteringItem["NOM_ENS"].Controls[0] as TextBox;
                box2.Height = Unit.Pixel(30);
                TextBox box3 = filteringItem["NB_HEURES"].Controls[0] as TextBox;
                box3.Height = Unit.Pixel(30);
                TextBox box4 = filteringItem["CHARGE_P1"].Controls[0] as TextBox;
                box4.Height = Unit.Pixel(30);
                TextBox box7 = filteringItem["CHARGE_P2"].Controls[0] as TextBox;
                box7.Height = Unit.Pixel(30);

                TextBox box8 = filteringItem["NUM_SEMESTRE"].Controls[0] as TextBox;
                box8.Height = Unit.Pixel(30);
                TextBox box9 = filteringItem["LIB_NOME"].Controls[0] as TextBox;
                box9.Height = Unit.Pixel(30);
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedIndexes.Count == 0)
                RadGrid1.SelectedIndexes.Add(0);
            //if (RadGrid2.SelectedIndexes.Count == 0)
            //    RadGrid2.SelectedIndexes.Add(0);


        }
        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
        }
        //protected void RadGrid2_UpdateCommand(object source, GridCommandEventArgs e)
        //{
        //    GridEditableItem editedItem = e.Item as GridEditableItem;
        //    UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
        //    foreach (GridDataItem item in RadGrid1.SelectedItems)
        //    {
        //        idmodule = item["CODE_MODULE"].Text;
              

        //    }
        //    string TBEns1P1 = ((userControl.FindControl("TBEns1P1") as TextBox).Text);
        //    string TBEns1P2 = ((userControl.FindControl("TBEns1P2") as TextBox).Text);
        //    string TBEns2P1 = ((userControl.FindControl("TBEns2P1") as TextBox).Text);
        //    string TBEns2P2 = ((userControl.FindControl("TBEns2P2") as TextBox).Text);
        //    string TBEns3P1 = ((userControl.FindControl("TBEns3P1") as TextBox).Text);
        //    string TBEns3P2 = ((userControl.FindControl("TBEns3P2") as TextBox).Text);
        //    string TBEns4P1 = ((userControl.FindControl("TBEns4P1") as TextBox).Text);
        //    string TBEns4P2 = ((userControl.FindControl("TBEns4P2") as TextBox).Text);
        //    string TBEns5P1 = ((userControl.FindControl("TBEns5P1") as TextBox).Text);
        //    string TBEns5P2 = ((userControl.FindControl("TBEns5P2") as TextBox).Text);
           
        //    string nom_ens2 = ((userControl.FindControl("ddens2") as DropDownList).SelectedItem.Value);
        //    string nom_ens3 = ((userControl.FindControl("ddens3") as DropDownList).SelectedItem.Value);
        //    string nom_ens4 = ((userControl.FindControl("ddens4") as DropDownList).SelectedItem.Value);
        //    string nom_ens5 = ((userControl.FindControl("ddens5") as DropDownList).SelectedItem.Value);
        //    string nom_ens1 = ((userControl.FindControl("DropDownList1") as RadComboBox).SelectedItem.Value);
        //    string code_cl = editedItem["CODE_CL"].Text;
        //    con.Open();
        //    OracleCommand cmd = new OracleCommand(" UPDATE ESP_MODULE_PANIER_CLASSE_SAISO set id_ens='" + nom_ens1 + "', id_ens5='" + nom_ens5 + "',id_ens2='" + nom_ens2 + "',id_ens3='" + nom_ens3 + "',id_ens4='" + nom_ens4 + "', charge_ens1_P1='" + TBEns1P1 + "',charge_ens1_P2='" + TBEns1P2 + "',charge_ens2_P1='" + TBEns2P1 + "',charge_ens2_P2='" + TBEns2P2 + "',charge_ens3_P1='" + TBEns3P1 + "',charge_ens3_P2='" + TBEns3P2 + "',charge_ens4_P1='" + TBEns4P1 + "',charge_ens4_P2='" + TBEns4P2 + "',charge_ens5_P1='" + TBEns5P1 + "',charge_ens5_P2='" + TBEns5P2 + "' where code_cl='" + code_cl + "' and code_module='" + idmodule + "' and annee_deb='201'" );


        //    cmd.Connection = con;

        //    cmd.Transaction = myTrans;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        //myTrans.Commit();
        //        Label lblError2 = new Label();
        //        lblError2.Text = "Modification avec succée";
        //        lblError2.ForeColor = System.Drawing.Color.Green;
        //        RadGrid2.Controls.Add(lblError2);
        //    }
        //    catch (Exception ex)
        //    {
        //        Label lblError1 = new Label();

        //        lblError1.Text = "ERREUR";
        //        lblError1.ForeColor = System.Drawing.Color.Red;
        //        RadGrid2.Controls.Add(lblError1);
        //    }

            
             
        //}

        protected void RadGrid2_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            foreach (GridDataItem item in RadGrid1.SelectedItems)
            {
                idmodule = item["CODE_MODULE"].Text;


            }
            string TBEns1P1 = ((userControl.FindControl("TBEns1P1") as TextBox).Text);
            string TBEns1P2 = ((userControl.FindControl("TBEns1P2") as TextBox).Text);
            string TBEns2P1 = ((userControl.FindControl("TBEns2P1") as TextBox).Text);
            string TBEns2P2 = ((userControl.FindControl("TBEns2P2") as TextBox).Text);
            string TBEns3P1 = ((userControl.FindControl("TBEns3P1") as TextBox).Text);
            string TBEns3P2 = ((userControl.FindControl("TBEns3P2") as TextBox).Text);
            string TBEns4P1 = ((userControl.FindControl("TBEns4P1") as TextBox).Text);
            string TBEns4P2 = ((userControl.FindControl("TBEns4P2") as TextBox).Text);
            string TBEns5P1 = ((userControl.FindControl("TBEns5P1") as TextBox).Text);
            string TBEns5P2 = ((userControl.FindControl("TBEns5P2") as TextBox).Text);

            string nom_ens2 = ((userControl.FindControl("ddens2") as DropDownList).SelectedItem.Value);
            string nom_ens3 = ((userControl.FindControl("ddens3") as DropDownList).SelectedItem.Value);
            string nom_ens4 = ((userControl.FindControl("ddens4") as DropDownList).SelectedItem.Value);
            string nom_ens5 = ((userControl.FindControl("ddens5") as DropDownList).SelectedItem.Value);
            string nom_ens1 = ((userControl.FindControl("DropDownList1") as RadComboBox).SelectedItem.Value);
            string Type_ep = ((userControl.FindControl("type_ep") as DropDownList).SelectedItem.Value);
            TBEns1P1 = TBEns1P1.Replace(",", ".");
            TBEns1P2 = TBEns1P2.Replace(",", ".");
            TBEns2P1 = TBEns2P1.Replace(",", ".");
            TBEns2P2 = TBEns2P2.Replace(",", ".");
            TBEns3P1 = TBEns3P1.Replace(",", ".");
            TBEns3P2 = TBEns3P2.Replace(",", ".");
            TBEns4P1 = TBEns4P1.Replace(",", ".");
            TBEns4P2 = TBEns4P2.Replace(",", ".");
            TBEns5P1 = TBEns5P1.Replace(",", ".");
            TBEns5P2 = TBEns5P2.Replace(",", ".");
            string code_cl = editedItem["CODE_CL"].Text;
            con.Open();
            OracleCommand cmd = new OracleCommand(" UPDATE ESP_MODULE_PANIER_CLASSE_SAISO set id_ens='" + nom_ens1 + "',TYPE_EPREUVE='" + Type_ep + "', id_ens5='" + nom_ens5 + "',id_ens2='" + nom_ens2 + "',id_ens3='" + nom_ens3 + "',id_ens4='" + nom_ens4 + "', charge_ens1_P1=replace('" + TBEns1P1 + "','.',','),charge_ens1_P2=replace('" + TBEns1P2 + "','.',','),charge_ens2_P1=replace('" + TBEns2P1 + "','.',','),charge_ens2_P2=replace('" + TBEns2P2 + "','.',','),charge_ens3_P1=replace('" + TBEns3P1 + "','.',','),charge_ens3_P2=replace('" + TBEns3P2 + "','.',','),charge_ens4_P1=replace('" + TBEns4P1 + "','.',','),charge_ens4_P2=replace('" + TBEns4P2 + "','.',','),charge_ens5_P1=replace('" + TBEns5P1 + "','.',','),charge_ens5_P2=replace('" + TBEns5P2 + "','.',',') where code_cl='" + code_cl + "' and code_module='" + idmodule + "' and annee_deb='2015' ");


            cmd.Connection = con;

            cmd.Transaction = myTrans;
            try
            {
                cmd.ExecuteNonQuery();
                //myTrans.Commit();
                Label lblError2 = new Label();
                lblError2.Text = "Modification avec succès";
                lblError2.ForeColor = System.Drawing.Color.Green;
                RadGrid2.Controls.Add(lblError2);
            }
            catch (Exception ex)
            {
                Label lblError1 = new Label();

                lblError1.Text = "erreur";
                lblError1.ForeColor = System.Drawing.Color.Red;
                RadGrid2.Controls.Add(lblError1);
            }



        } 
    }
}