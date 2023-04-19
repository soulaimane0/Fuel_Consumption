using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALMATRANS
{
    public partial class MasPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]==null)
            {
                lblFoot.Visible = true;
                lbtnVcl.Visible = false;
                LbtnBon.Visible = false;
                LbtnMarq.Visible = false;
                LbtnSts.Visible = false;

                LinkButton7.Visible = true;
                LbtnDec.Visible = false;
                LbtnHello.Visible = false;

                //Response.Redirect("AcceuilPage.aspx");
            }
            else if (Session["role"].Equals("admin"))
            {
                lblFoot.Visible = false;
                lbtnVcl.Visible = true;
                LbtnBon.Visible = true;
                LbtnMarq.Visible = true;
                LbtnSts.Visible = true;

                LinkButton7.Visible = false;
                LbtnDec.Visible = true;
                LbtnHello.Visible = true;
                LbtnHello.Text = "Bonjour " + Session["nom"].ToString();
            }
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminConnexion.aspx");
        }

        protected void LbtnDec_Click(object sender, EventArgs e)
        {
            Session["role"] = null;
            Session["nom"] = "";
            lblFoot.Visible = true;
            lbtnVcl.Visible = false;
            LbtnBon.Visible = false;
            LbtnMarq.Visible = false;
            LbtnSts.Visible = false;

            LinkButton7.Visible = true;
            LbtnDec.Visible = false;
            LbtnHello.Visible = false;

            Response.Redirect("AcceuilPage.aspx");
        }

        protected void LbtnMarq_Click(object sender, EventArgs e)
        {
            Response.Redirect("MAJ_Marque.aspx");

        }

        protected void lbtnVcl_Click(object sender, EventArgs e)
        {
            Response.Redirect("MAJ_Vehicule.aspx");

        }

        protected void LbtnBon_Click(object sender, EventArgs e)
        {
            Response.Redirect("MAJ_Bon.aspx");

        }

        protected void LbtnSts_Click(object sender, EventArgs e)
        {
            Response.Redirect("F_Statis.aspx");

        }

        protected void lblFoot_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminConnexion.aspx");
        }
    }
}