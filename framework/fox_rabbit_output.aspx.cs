using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Web.Services;
using System.Text;
using System.Reflection;

public partial class fox_rabbit_output : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdDisplay_Click(object sender, EventArgs e)
    {      
        
        int lp = 0; //variable for the total number of loop due to the defined time step
        //int ts = 1; //timestep
        int yr = 0; //for how long the model runs
        double[] x; // = new double[lp]; //array for row #
        double[] ry; // = new double[lp]; //array for rabbit pop each year
        double[] fy; // = new double[lp]; //array for fox pop each year

        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\prototype\framework\fmdb.accdb");
        string query = "SELECT * FROM q1 ORDER BY timestep ";
        DataSet ds = new DataSet();

        try
        {
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(query, connection);
            OleDbCommandBuilder cmdB = new OleDbCommandBuilder(da);

            da.Fill(ds);

            int cunt = ds.Tables[0].Rows.Count;

            if (cunt <= 0) //no data found with the criteria set
            {
                goto wuta;
            }
            else
            {
                yr = Convert.ToInt16(ds.Tables[0].Rows[0]["totalyear"].ToString());
                //ts = Convert.ToInt16(ds.Tables[0].Rows[0]["rabbit_ts"].ToString());

                lp = Convert.ToInt16(yr / 0.1); //Convert.ToInt16(yr / ts); //   Math.Truncate( yr / ts)); //total number of loop due to the defined time step
                //lp = lp +1;//to add one row for the initial population value

                 x = new double[lp]; //array for row #
                 ry = new double[lp]; //array for rabbit pop each year
                 fy = new double[lp]; //array for fox pop each year

                for (int i = 0; i < lp; i++)
                {
                   /*
                    double d = Convert.ToDouble(i * ts);
                    if (i > 0)
                        x[i] = Math.Round(d, 2);// Convert.ToDouble(d.ToString("#.##"));
                    else
                        x[0] = 0;
                    */
                    x[i] = Convert.ToDouble(ds.Tables[0].Rows[i]["timestep"].ToString());

                    ry[i] = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["rb1"].ToString()), 2);
                    fy[i] = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["r7"].ToString()), 2);


                }
             
            }

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }       


        Chart1.Series[0].Points.DataBindXY(x, ry);
        Chart1.Series[1].Points.DataBindXY(x, fy);

        Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
        Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;

    wuta: ;
         
  
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        Web_Service ExampleAPI = new Web_Service("http://localhost//rabws/"); 
        string r = "5000";
        string f = "45";

         ExampleAPI.PreInvoke();

         ExampleAPI.AddParameter("rabpop", r);                    // Case Sensitive! To avoid typos, just copy the WebMethod's signature and paste it
         ExampleAPI.AddParameter("foxpop", f);     // all parameters are passed as strings
         try
         {
             ExampleAPI.Invoke("pop_inc");                // name of the WebMethod to call (Case Sentitive again!)
         }
         finally { ExampleAPI.PosInvoke(); }
         
         TextBox1.Text = ExampleAPI.ResultString;

         /*

        WebServiceInvoker invoker = new WebServiceInvoker(new Uri("http://localhost//rabws/"));
 
        string service = "rabws";
        string method = "pop_inc";
 
        string[] args = new string[] { "5000", "45" };

 
        string result = invoker.InvokeMethod<string>(service, method, args);

        TextBox1.Text = result; 

       
        */





    }
}