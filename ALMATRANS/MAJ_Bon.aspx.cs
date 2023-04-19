using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALMATRANS
{
    public partial class MAJ_Bon : System.Web.UI.Page
    {
        Db_ALMATRANSEntities dbAlma = new Db_ALMATRANSEntities();
        static string global_filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                reset();
                remplireDdVcl();
            }
            DGBon.DataBind();
        }

        

        public void remplireDdVcl()
        {
            var vclInfo = (dbAlma.Véhicule.Select(v => new
            {
                id_vcl = v.id_Vcl,
                immatric = v.immatriculation,
                id_imma = v.id_Vcl+" | "+v.immatriculation
            })).ToList();


            ddIdVcl.DataSource = vclInfo;

            ddIdVcl.DataTextField = "id_imma";
            ddIdVcl.DataValueField = "id_vcl";

            ddIdVcl.DataBind();

        }

        bool checkIfBonexist()
        {
            try
            {
                var checkBon = dbAlma.PS_AffBonNum(int.Parse(txtNum.Text)).FirstOrDefault();
                if (checkBon != null)
                    return true;
                else
                    return false;
              
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                                "swal('Champ Vide !','Veuillez saisir l\\'identifiant du Bon !')", true);
                return false;
            }

        }

        public void AjoutBon()
        {
            //******
            string filepath = "~/Vehicules/no-pictures.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("Vehicules/" + filename));
            filepath = "~/Vehicules/" + filename;
            //******

            dbAlma.PS_AjouterBon(int.Parse(txtNum.Text), DateTime.Parse(txtdate.Text), txtNomStas.Text, int.Parse(ddIdVcl.SelectedValue),
                txtChauf.Text, float.Parse(txtQte.Text), Math.Round(float.Parse(txtPrixL.Text),2),
                Math.Round(float.Parse(txtPrixT.Text),2), filepath);

            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                            "swal('Bon Ajout !','Le Bon a été Ajoutée avec succès !','success')", true);
            DGBon.DataBind();
            remplireDdVcl();
            reset();

        }

        private void reset()
        {
            txtNum.Text = "";
            txtdate.Text = "";
            txtNomStas.Text = "";
            ddIdVcl.SelectedIndex = -1;
            txtChauf.Text = "";
            txtQte.Text = "";
            txtPrixL.Text = "";
            txtPrixT.Text = "";

            global_filepath = "~/Vehicules/no-pictures.png";
            //imgview.Attributes["src"] = global_filepath;



        }

        protected void btnAjout_Click(object sender, EventArgs e)
        {
            try
            {

                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (txtNum.Text != "" && txtdate.Text != "" && ddIdVcl.SelectedValue != null && txtQte.Text != "" && txtPrixL.Text != "" && filename!="" )
                {
                    if (checkIfBonexist())
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                        "swal('Bon existe déjà','Vous ne pouvez pas ajouter un autre Bon avec le même identifiant !','info')", true);

                    }
                    else
                    {
                        AjoutBon();
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                 "swal('Champ Vide !','Veuillez remlire tous les champs .')", true);
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script type='text/javascript'> alert('" + ex.Message + "');</script>");
            }
        }


        public void showInfo()
        {

            var bonInfo = dbAlma.PS_AffBonNum(Convert.ToInt32(txtNum.Text)).FirstOrDefault();

            txtNum.Text = bonInfo.Num_Bon.ToString();
            txtdate.Text = bonInfo.date_Bon.ToString("yyyy-MM-dd");
            txtNomStas.Text = bonInfo.nom_station;
            ddIdVcl.SelectedValue = bonInfo.id_Vcl.ToString();
            txtChauf.Text = bonInfo.nom_Chauf;
            txtQte.Text = bonInfo.Qté.ToString();
            txtPrixL.Text = bonInfo.prix_littre.ToString();
            txtPrixT.Text = bonInfo.prix_total.ToString();

            global_filepath = bonInfo.photo.ToString();
            //imgview.Attributes["src"] = global_filepath;
        }

        public void ModBon()
        {
            //******
            string filepath = "~/Vehicules/no-pictures.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

            if (filename == "" || filename == null)
            {
                filepath = global_filepath;
            }
            else
            {
                FileUpload1.SaveAs(Server.MapPath("Vehicules/" + filename));
                filepath = "~/Vehicules/" + filename;

            }

            //******

            dbAlma.PS_ModifierBon(int.Parse(txtNum.Text.Trim()), DateTime.Parse(txtdate.Text.Trim()), txtNomStas.Text.Trim(), int.Parse(ddIdVcl.SelectedValue),
                txtChauf.Text.Trim(), float.Parse(txtQte.Text), Math.Round(float.Parse(txtPrixL.Text), 2),
                Math.Round(float.Parse(txtPrixT.Text), 2), filepath);

            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                            "swal('Bon Modification !','Le Bon a été Modifiée avec succès !','success')", true);
            DGBon.DataBind();
            remplireDdVcl();
            reset();

        }


        protected void btnMod_Click(object sender, EventArgs e)
        {
            if (txtNum.Text != null && txtdate.Text != "" && ddIdVcl.SelectedValue != null && txtQte.Text != "" && txtPrixL.Text != "")
            {
                if (checkIfBonexist())
                {
                    try{

                        ModBon();

                    }
                    catch (Exception ex)
                    {

                        Response.Write("<script type='text/javascript'> alert('mod " + ex.Message + "');</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                    "swal('Le bon n\\'existe pas !','Veuillez entrer un bon qui existe.','info')", true);

                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                "swal('Champ Vide !','Veuillez remlire tous les champs .')", true);
            }

        }

        

        protected void txtPrixL_TextChanged(object sender, EventArgs e)
        {
            if (txtQte != null)
            {
                try
                {
                    float qte = float.Parse(txtQte.Text);
                    float prixL = float.Parse(txtPrixL.Text);
                    txtPrixT.Text = (qte * prixL).ToString("0.00");

                }
                catch (Exception)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                        "swal('Champ Vide !','Veuillez saisir la prix du litre .')", true);
                }
            }

        }

        protected void txtQte_TextChanged(object sender, EventArgs e)
        {
            
            if (txtPrixL != null)
            {
                try
                {
                    float prixL = float.Parse(txtPrixL.Text);
                    float qte = float.Parse(txtQte.Text);
                    txtPrixT.Text = (qte * prixL).ToString("0.00");
                }
                catch (Exception)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                        "swal('Champ Vide !','Veuillez saisir la quantité .')", true);
                }
            }

           
        }

        protected void btnAff_Click(object sender, EventArgs e)
        {
           
        }

        

        protected void btnAff_Click1(object sender, EventArgs e)
        {
            if (txtNum.Text != null)
            {
                if (checkIfBonexist())
                {
                    try
                    {
                        showInfo();

                    }
                    catch (Exception ex)
                    {

                        Response.Write("<script type='text/javascript'> alert('mod " + ex.Message + "');</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                    "swal('Le bon n\\'existe pas !','Veuillez entrer un identifiant qui existe.','info')", true);

                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                     "swal('Champ Vide !','Veuillez saisir l\\'identifiant du bon !')", true);
            }

        }



        public void SuppBon()
        {
            dbAlma.PS_SupprimerBon(Convert.ToInt32(txtNum.Text));
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
            "swal('Bon Suppression !','Le Bon a été Supprimée avec succès !','success')", true);

            DGBon.DataBind();
            remplireDdVcl();
            reset();
        }

        
        protected void btnSupp_Click(object sender, EventArgs e)
        {
            if (txtNum.Text != null || txtNum.Text != "")
            {
                if (checkIfBonexist())
                {
                    try
                    {
                        SuppBon();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("<script type='text/javascript'> alert('mod " + ex.Message + "');</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                    "swal('Le bon n\\'existe pas !','Veuillez entrer un bon qui existe.','info')", true);

                }
            }

        }

        protected void btnImpr_Click(object sender, EventArgs e)
        {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                    "swal('Pardon !','Ce n\\'est pas encore fini.')", true);

            //CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            //BonReport crystalReport = new BonReport();
            //Db_ALMATRANSEntities dbAlma = new Db_ALMATRANSEntities();
            //crystalReport.SetDataSource(from customer in dbAlma.Bons.Take(10)
            //                            select customer);
            //CrystalReportViewer1.ReportSource = crystalReport;
            //CrystalReportViewer1.RefreshReport();
        }
    }
}