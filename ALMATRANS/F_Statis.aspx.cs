using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

namespace ALMATRANS
{
    public partial class F_Statis : System.Web.UI.Page
    {
        Db_ALMATRANSEntities dbAlma = new Db_ALMATRANSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DGStatis.DataSource = dbAlma.PS_DgvStatis().ToList();
                DGStatis.DataBind();
                remplireDdVcl();
                RemplirBarChart();

            }

        }


        public void RemplirBarChart()
        {
            var chartInf = dbAlma.PS_DgvStatis().ToArray();
            int tabSize = chartInf.Length;
            decimal[] qte = new decimal[tabSize];
            String[] date = new string[tabSize];
            var totalQte = 0.00;
            var totalPrix = 0.00;

            for (var i = 0; i < chartInf.Length; i++)
            {
                qte[i] = Convert.ToInt16(chartInf[i].Quantité.ToString());
                date[i] = chartInf[i].date_service.ToShortDateString().ToString();
                totalQte += float.Parse(chartInf[i].Quantité.ToString());
                totalPrix += float.Parse(chartInf[i].Prix_Total.ToString());
            }

            lblTotal.Text = "La Quantité Total : " + totalQte + " L";
            lblPrix.Text = "Le Prix Total : " + Math.Round(totalPrix,2) + " DH";
            
            BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = qte });
            BarChart1.CategoriesAxis = string.Join(",", date);
            BarChart1.ChartTitle = "Le Développement De La Consommation D’un Véhicule";
            BarChart1.Series[0].Name = "Quantité";
            
        }

        public void RemplirBarChartImmatricul()
        {
            var chartInf = dbAlma.PS_ImmStatis(DdVehicule.SelectedValue).ToArray();
            int tabSize = chartInf.Length;
            decimal[] qte = new decimal[tabSize];
            String[] date = new string[tabSize];

            var totalQte = 0.00;
            var totalPrix = 0.00;

            for (var i = 0; i < chartInf.Length; i++)
            {
                qte[i] = Convert.ToInt16(chartInf[i].Quantité.ToString());
                date[i] = chartInf[i].date_service.ToShortDateString().ToString();

                totalQte += float.Parse(chartInf[i].Quantité.ToString());
                totalPrix += float.Parse(chartInf[i].Prix_Total.ToString());
            }


            lblTotal.Text = "La Quantité Total : " + totalQte + " L";
            lblPrix.Text = "Le Prix Total : " + Math.Round(totalPrix, 2) + " DH";
            BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = qte });
            BarChart1.CategoriesAxis = string.Join(",", date);
            BarChart1.ChartTitle = "Le Développement De La Consommation D’un Véhicule";
            BarChart1.Series[0].Name = "Quantité";
        }

        public void remplireDdVcl()
        {
            var vclInfo = (dbAlma.Véhicule.Select(v => new
            {
                id_vcl = v.id_Vcl,
                immatric = v.immatriculation,
                id_imma = v.id_Vcl + " | " + v.immatriculation
            })).ToList();


            DdVehicule.DataSource = vclInfo;

            DdVehicule.DataTextField = "id_imma";
            DdVehicule.DataValueField = "immatric";

            DdVehicule.DataBind();

        }

        protected void DdVehicule_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemplirBarChartImmatricul();
        }

        protected void txtDateFin_TextChanged(object sender, EventArgs e)
        {
            RemplirBarChartDates();
        }

        private void RemplirBarChartDates()
        {
            try
            {
                if (DdVehicule.SelectedValue != null && txtDateDebut.Text != "" && txtDateFin.Text != "")
                {
                    var chartInf = dbAlma.PS_DateStatis(DdVehicule.SelectedValue, Convert.ToDateTime(txtDateDebut.Text), Convert.ToDateTime(txtDateFin.Text)).ToArray();
                    int tabSize = chartInf.Length;
                    decimal[] qte = new decimal[tabSize];
                    String[] date = new string[tabSize];

                    var totalQte = 0.00;
                    var totalPrix = 0.00;

                    for (var i = 0; i < chartInf.Length; i++)
                    {
                        qte[i] = Convert.ToInt16(chartInf[i].Quantité.ToString());
                        date[i] = chartInf[i].date_service.ToShortDateString().ToString();

                        totalQte += float.Parse(chartInf[i].Quantité.ToString());
                        totalPrix += float.Parse(chartInf[i].Prix_Total.ToString());
                    }


                    lblTotal.Text = "La Quantité Total : " + totalQte + " L";
                    lblPrix.Text = "Le Prix Total : " + Math.Round(totalPrix, 2) + " DH";
                    BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = qte });
                    BarChart1.CategoriesAxis = string.Join(",", date);
                    BarChart1.ChartTitle = "Le Développement De La Consommation D’un Véhicule";
                    BarChart1.Series[0].Name = "Quantité";
                }
                else
                {
                    Response.Write("<script type='text/javascript'> alert('Veullez selectionnez le matricule et la date !');</script>");
                }
                
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'> alert('"+ex.Message+"');</script>");

            }

        }
    }
}