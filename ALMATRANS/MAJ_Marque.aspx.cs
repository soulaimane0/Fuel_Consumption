using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ALMATRANS
{
    public partial class MAJ_Marque : System.Web.UI.Page
    {
        Db_ALMATRANSEntities dbAlma = new Db_ALMATRANSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                chargerDGV();
        }

        private void chargerDGV()
        {
            var listMarq = dbAlma.PS_AffMarq();
            DGVMarq.DataSource = listMarq.ToList();
            DGVMarq.DataBind();
        }

        protected void btnAjout_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && txtNom.Text != "")
                {
                    if (checkIfMarkexist())
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                       "swal('Marque existe déjà','Vous ne pouvez pas ajouter un autre Marque avec le même identifiant !','info')", true);

                    }
                    else
                    {
                        ajouterMarqu();
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

        bool checkIfMarkexist()
        {
            try
            {
                var checkMarq = dbAlma.PS_AffMarqID(int.Parse(txtID.Text)).FirstOrDefault();
                if (checkMarq != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                Response.Write("<script type='text/javascript'> alert('" + ex.Message + "');</script>");
                return false;
            }

        }
        public void ajouterMarqu()
        {
            dbAlma.PS_AjouterMarq(int.Parse(txtID.Text), txtNom.Text);

            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
              "swal('Bon Ajout !','La marque a été Ajoutée avec succès !','success')", true);

            txtID.Text = "";
            txtNom.Text = "";
            chargerDGV();
        }

        protected void btnGO_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    if (checkIfMarkexist())
                    {
                        var marqInfo = dbAlma.PS_AffMarqID(int.Parse(txtID.Text)).FirstOrDefault();
                        txtNom.Text = marqInfo.nom_marque.ToString();

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                        "swal('La marque n\\'existe pas !','Veuillez entrer un identifiant qui existe.','info')", true);
                        txtNom.Text = "";
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                                "swal('Champ Vide !','Veuillez saisir l\\'identifiant de la marque !')", true);

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/javascript'> alert('"+ex.Message+"');</script>");

            }


        }

        protected void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && txtNom.Text != "")
                {
                    if (checkIfMarkexist())
                    {
                         modMarque();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                         "swal('La marque n\\'existe pas !','Veuillez entrer une marque qui existe.','info')", true);


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


        public void modMarque()
        {
            dbAlma.PS_ModifierMarq(int.Parse(txtID.Text), txtNom.Text);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
              "swal('Bonne Modification !','La marque a été Modifiée avec succès !','success')", true);
            txtID.Text = "";
            txtNom.Text = "";
            chargerDGV();
        }

        protected void btnSupp_Click(object sender, EventArgs e)
        {


            try
            {
                if (txtID.Text != "")
                {
                    if (checkIfMarkexist())
                    {
                        suppMarque();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                        "swal('La marque n\\'existe pas !','Veuillez entrer une marque qui existe.','info')", true);
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
             "swal('Champ Vide !','Veuillez saisir l\\'identifiant de la marque que vous souhaitez supprimer !')", true);
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script type='text/javascript'> alert('" + ex.Message + "');</script>");
            }
        }

        public void suppMarque()
        {
            dbAlma.PS_SupprimerMarq(int.Parse(txtID.Text));
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                          "swal('Bonne Suppression !','La marque a été Supprimée avec succès !','success')", true);
            txtID.Text = "";
            txtNom.Text = "";
            chargerDGV();

        }
    }
}