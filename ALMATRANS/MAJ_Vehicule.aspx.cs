using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALMATRANS
{
    public partial class MAJ_Vehicule : System.Web.UI.Page
    {
        Db_ALMATRANSEntities dbAlma = new Db_ALMATRANSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                remplirDGV();
                Reset();
                remplirDdList();
            }

        }

        bool checkIfVlexist()
        {
            try
            {
                var checkVcl = dbAlma.PS_AffVclID(int.Parse(txtID.Text)).FirstOrDefault();
                if (checkVcl != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                       "swal('Champ Vide !','Veuillez saisir l\\'identifiant du véhicule !')", true);
                return false;
            }

        }

        public void remplirDGV()
        {
            DGVcl.DataSource = dbAlma.PS_AffVcl().ToList();
            DGVcl.DataBind();
        }

        public void remplirDdList()
        {
            var getMarq = dbAlma.PS_AffMarq().ToList();
            ddIdMarq.DataSource = getMarq;
            ddIdMarq.DataTextField = "nom_marque";
            ddIdMarq.DataValueField = "id_marque";
            ddIdMarq.DataBind();
        }
        protected void btnAjout_Click(object sender, EventArgs e)
        {
            try
                {
                    if (txtID.Text != null && txtImm.Text != "" && ddIdMarq.SelectedValue != null && txtdateServ.Text != null)
                    {
                        if (checkIfVlexist())
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                                  "swal('Véhicule existe déjà','Vous ne pouvez pas ajouter un autre Véhicule avec le même identifiant !','info')", true);

                        }
                        else
                        {
                            ajoutVcl();
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

        public void checkImmatricule()
        {
            string imma = txtImm.Text;
            var checkImma = (dbAlma.Véhicule.Where(v=> v.immatriculation==imma)).FirstOrDefault<Véhicule>();

            if (checkImma != null)
            {
                ddIdMarq.Enabled = false;
                ddIdMarq.SelectedValue = checkImma.id_marque.ToString();
            }
            else
            {
                ddIdMarq.Enabled = true;
            }

        }
    

        public void ajoutVcl()
        {
            dbAlma.PS_AjouterVcl(int.Parse(txtID.Text), txtImm.Text, int.Parse(ddIdMarq.SelectedValue), DateTime.Parse(txtdateServ.Text));
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                         "swal('Bon Ajout !','Le Véhicule a été Ajoutée avec succès !','success')", true);
            remplirDGV();
            Reset();
        }

        private void Reset()
        {
            txtID.Text = "";
            txtImm.Text = "";
            ddIdMarq.SelectedIndex=-1;
            txtdateServ.Text = "";
        }

        protected void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != null && txtImm.Text != "" && ddIdMarq.SelectedValue != null && txtdateServ.Text != null)
                {
                    if (checkIfVlexist())
                    {
                        ModVcl();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                                "swal('Le véhicule n\\'existe pas !','Veuillez entrer un véhicule qui existe.','info')", true);
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                 "swal('Champ Vide !','Veuillez remlire tous les champs.')", true);
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script type='text/javascript'> alert('" + ex.Message + "');</script>");
            }
        }

        public void ModVcl()
        {
            dbAlma.PS_ModifierVcl(int.Parse(txtID.Text), txtImm.Text, int.Parse(ddIdMarq.SelectedValue), DateTime.Parse(txtdateServ.Text));
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
              "swal('Bonne Modification !','Le Véhicule a été Modifiée avec succès !','success')", true);
            remplirDGV();
            Reset();
        }

        protected void btnSupp_Click(object sender, EventArgs e)
        {
            //if (Page.IsPostBack)
            //{
                try
                {
                    if (txtID.Text != null)
                    {
                        if (checkIfVlexist())
                        {
                            SuppVcl();
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                             "swal('Le véhicule n\\'existe pas !','Veuillez entrer un véhicule qui existe.','info')", true);
                        }
                    }
                //else
                //{
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                //    "swal('Champ Vide !','Veuillez saisir l\\'identifiant du véhicule que vous souhaitez supprimer !')", true);

                //}
                }
                catch (Exception ex)
                    {
                    Response.Write("<script type='text/javascript'> alert('" + ex.Message + "');</script>");

                    }
            //}

        }

        public void SuppVcl()
        {
            dbAlma.PS_SupprimerVcl(int.Parse(txtID.Text));
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                      "swal('Bonne Suppression !','Le véhicule a été Supprimée avec succès !','success')", true);
            remplirDGV();
            Reset();
        }

        protected void btnGO_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != null)
                {
                    if (checkIfVlexist())
                    {
                        var rempTexts = dbAlma.PS_AffVclID(int.Parse(txtID.Text)).FirstOrDefault();
                        txtID.Text = rempTexts.id_Vcl.ToString();
                        txtImm.Text = rempTexts.immatriculation.ToString();
                        ddIdMarq.SelectedValue = rempTexts.id_marque.ToString();
                        txtdateServ.Text = rempTexts.date_service.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                                     "swal('Le véhicule n\\'existe pas !','Veuillez entrer un identifiant qui existe.','info')", true);
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                                    "swal('Champ Vide !','Veuillez saisir l\\'identifiant du véhicule !')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/javascript'> alert('"+ex.Message+"');</script>");
            }
        }

        protected void txtImm_TextChanged(object sender, EventArgs e)
        {
            checkImmatricule();
        }
    }

}