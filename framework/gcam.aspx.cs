using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data;

public partial class gcam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  

    }
    protected void cmdRun_Click(object sender, EventArgs e)
    {
        string endyear = cmbEndYear.Text;

        gcamws.GCAMSoapClient gcam = new gcamws.GCAMSoapClient();      

        //first update ebd year
        string s = gcam.update_stop_period(endyear);


        if (s == "Successfully updated")
        {
             lblWarn.Text = "End year is updated, do you still want to run GCAM? it could take upto 2 hours";
             cmdRun.Visible = false;
             cmdRun2.Visible = true;
             cmdNo.Visible = true;
        }
        else
            lblMsg.Text = s;
       


    }


    protected void cmdRun2_Click(object sender, EventArgs e)
    {
        gcamws.GCAMSoapClient gcam = new gcamws.GCAMSoapClient();

        //increase time span to avoid timeout error
        gcam.Endpoint.Binding.SendTimeout = new TimeSpan(02, 55, 00);

        
        lblMsg.Text = gcam.GCAM_Main();
        lblWarn.Text = "";
        cmdRun.Visible = true;
        cmdRun2.Visible = false;
        cmdNo.Visible = false;
    }
    protected void cmdNo_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblWarn.Text = "";
        cmdRun.Visible = true;
        cmdRun2.Visible = false;
        cmdNo.Visible = false;

    }
    protected void cmdDisplay_Click(object sender, EventArgs e)
    {
        if (cmbRegion.Text == "")
        {
            lblMsg.Text = "Select region to query data";
            goto Wuta;
        }

        //gcamws.GCAMSoapClient gcam = new gcamws.GCAMSoapClient();
        //DataSet ds = gcam.query_Gcam(cmbRegion.Text, cmbSector.Text, cmbTechno.Text);

        bindGridView();

    Wuta: ;


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        GridView1.PageIndex = e.NewPageIndex;
        bindGridView();
        
    }

    private void bindGridView( )
    {
        gcamws.GCAMSoapClient gcam = new gcamws.GCAMSoapClient();
        DataSet ds = gcam.query_Gcam(cmbRegion.Text, cmbSector.Text, cmbTechno.Text);

        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

}