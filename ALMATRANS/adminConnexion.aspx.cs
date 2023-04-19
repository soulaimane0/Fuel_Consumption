using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALMATRANS
{
    public partial class adminConnexion : System.Web.UI.Page
    {
        Db_ALMATRANSEntities dbAlma = new Db_ALMATRANSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnConn_Click1(object sender, EventArgs e)
        {
            try
            {
                var cnx = dbAlma.PS_Utilisateur(txtnom.Text, txtPasse.Text).FirstOrDefault();
                if (cnx != null)
                {
                    Session["role"] = "admin";
                    Session["nom"] = cnx.nom_Util.ToString();

                    txtnom.Text = "";
                    txtPasse.Text = "";
                    Response.Redirect("AcceuilPage.aspx");

                    
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Add", "" +
                    "swal('Informations Incorrectes !','Veuillez entrer le nom d\\'utilisateur et le mot de passe corrects.','info')", true);

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'> alert('"+ex.Message+"');</script>");

            }


        }
    }
}