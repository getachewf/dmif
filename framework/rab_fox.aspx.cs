using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using foxws;
using rabws;
using System.Web.UI.DataVisualization.Charting;
using System.Threading;
using System.Globalization;
using System.Data.OleDb;
using System.Data ;
using System.Diagnostics;

public partial class rab_fox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

    }
    protected void cmdRun_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        if (txtRab.Text == "")
        {
            lblMsg.Text = "Enter rabbit population";
            goto Wuta;
        }
            
        if (txtFox.Text == "")
        {
            lblMsg.Text = "Enter fox population";
            goto Wuta;
        }

        if (txtYr.Text == "")
        {
            lblMsg.Text = "Enter number of excutions";
            goto Wuta;
        }
                
        int r = Convert.ToInt32(txtRab.Text);
        int f = Convert.ToInt32(txtFox.Text);        
        int yr = Convert.ToInt32(txtYr.Text);


        float r_ts = Convert.ToSingle(cmbTsRab.Text);
        r_ts = (float)(Math.Round((double)r_ts, 4));     

        float f_ts = Convert.ToSingle(cmbTsFox.Text);
        f_ts = (float)(Math.Round((double)f_ts, 4));

        string r_integ_method = cmbRabIntMethod.Text; //integration method used by rabbit model
        string f_integ_method = cmbFoxIntMethod.Text; //integration method used by fox model
        

        lst.Items.Clear();

        double[,] result;
        double[] r_result = {0, 1 };
        double [] f_result = {0, 1};
        //double[] rx_result = { 0, 1 };
        //double[] ry_result = { 0, 1 };
        //double[] fx_result = { 0, 1 };
        //double[] fy_result = { 0, 1 };

        if (cmbType.Text == "Horizontal")
        {
            if (r_ts == f_ts) //time step is the same
            {
                //string ts1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");

               //result = horizontal_same_ts(r, f, yr, r_ts, r_integ_method, f_integ_method);
                //result = rabbit_fox_model(r, f, yr, r_ts, r_integ_method, f_integ_method); //both rabbit and fox in one model
               //result = hybrid_horizontal_same_ts(r, f, yr, r_ts, r_integ_method, f_integ_method); //run at ts=0.1 but exchange data at ts=1,2,3, ..
                    
                //string ts2 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
               //double d = Convert.ToDouble(ts2) - Convert.ToDouble(ts1);        

               HorizontalSameTs hsts = new HorizontalSameTs();
               result = hsts.rabbit_fox_horizontal_same_ts(r, f, yr, r_ts, r_integ_method, f_integ_method);

                display_same_ts(result, r, f, yr, r_ts);
            }
            else  //time step is different
            {
                //string ts1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                //horizontal_different_ts(r, r_ts, f, f_ts, yr, out r_result, ref f_result, ref rx_result, ref ry_result, ref fx_result, ref fy_result, r_integ_method, f_integ_method);
               // horizontal_different_ts(r, r_ts, f, f_ts, yr, out r_result, ref f_result, r_integ_method, f_integ_method);
               //horizontal_diff_2_ts(r, r_ts, f, f_ts, yr, out r_result, ref f_result, r_integ_method, f_integ_method);
                //horizontal_diff_ts(r, r_ts, f, f_ts, yr, out r_result, ref f_result, r_integ_method, f_integ_method);

                //string ts2 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                //double d = Convert.ToDouble(ts2) - Convert.ToDouble(ts1); 


                //display_diff_ts(r, r_ts, f, f_ts, yr, ref  r_result, ref  f_result);


                HorizontalDifferentTs hdts = new HorizontalDifferentTs();
                result= hdts.rabbit_fox_horizontal_diff_ts(r, r_ts, f, f_ts, yr, r_integ_method, f_integ_method);

                if (r_ts >= f_ts) //use the smallest time step for generating graph
                    display_same_ts(result, r, f, yr, f_ts);
                else
                    display_same_ts(result, r, f, yr, r_ts);
            }

        }
        else
        {
            result = vertical(r, f, yr);

            display_same_ts(result, r, f, yr, r_ts);

        }

        
        /*
        double plotY = 50.0;
        double plotY2 = 200.0;
        if(Chart1.Series["Series1"].Points.Count > 0)
        {
        plotY = Chart1.Series["Series1"].Points[Chart1.Series["Series1"].Points.Count - 1].YValues[0];
        plotY2 = Chart1.Series["Series2"].Points[Chart1.Series["Series1"].Points.Count - 1].YValues[0];
        }
        Random random = new Random();
        for (int pointIndex = 0; pointIndex < 20000; pointIndex++)
        {
            plotY = plotY + (float)(random.NextDouble() * 10.0 - 5.0);
            Chart1.Series["Series1"].Points.AddY(plotY);

            plotY2 = plotY2 + (float)(random.NextDouble() * 10.0 - 5.0);
            Chart1.Series["Series2"].Points.AddY(plotY2);
        }
        Chart1.Series["Series1"].ChartType = SeriesChartType.Line;
        Chart1.Series["Series2"].ChartType = SeriesChartType.Line;
         */


        Wuta:;


    }

    
    protected void display_same_ts(double[,] result, float r, float f, int yr, float ts)
    {
        int ts_factor = 10; //ts_factor determine the number of loops in each units of time, e.g. in a year
        if (ts >= 0.1)
        {
            ts_factor = 10;
        }
        else if (ts >= 0.009) //>=0.01
        {
            ts_factor = 100;
        }
        else if (ts >= 0.0009) //>=0.001
            ts_factor = 1000;

        //ts_factor = 1000;

        //int lp = Convert.ToInt16(Math.Truncate(yr / ts)); //total number of loop due to the defined time step
        //int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //10 timestep in one year
        int lp = yr * ts_factor;

        lp = lp + 1;//to add one row for the initial population value

        if (cmbType.Text == "Vertical")
            lp = yr +1;
        
        double[] x = new double[lp]; //array for row #
        double[] ry = new double[lp]; //array for rabbit pop each year
        double[] fy = new double[lp]; //array for fox pop each year

        x[0] = 0;
        ry[0] = r;
        fy[0] = f;
        lst.Items.Add(x[0] + " ; " + ry[0].ToString() + " ; " + fy[0].ToString());

        for (int i = 1; i < lp ; i++)
        {            
            //double d = Convert.ToDouble(i * 0.1);
            double d = Convert.ToDouble(i) / Convert.ToDouble(ts_factor);

            if (i > 0)
                x[i] = Math.Round(d, 4);// Convert.ToDouble(d.ToString("#.##"));

            if (Double.IsNaN(result[i, 0]) || Double.IsPositiveInfinity(result[i, 0]) || Double.IsNaN(result[i, 1]) || Double.IsPositiveInfinity(result[i, 1]))
            {
                //if population value is NAN or infinity then skip it in the graph
            }
            else
            {

                ry[i] = result[i, 0]; // Math.Round(result[i, 0], 2);
                fy[i] = result[i, 1]; // Math.Round(result[i, 1], 2);
            }

            lst.Items.Add(x[i] + " ; " + result[i, 0].ToString() + " ; " + result[i, 1].ToString());           

            
            
        }

        

        Chart1.Series[0].Points.DataBindXY(x, ry);
        Chart1.Series[1].Points.DataBindXY(x, fy);
        Chart2.Series[0].Points.DataBindXY(ry, fy);
        Chart3.Series[0].Points.DataBindXY(x, ry);
        Chart4.Series[0].Points.DataBindXY(x, fy);

         
        Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        Chart3.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        Chart4.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        
        

    }
      
    
    protected double[,] horizontal_same_ts(float r, float f, int yr, float ts, string r_integ_method, string f_integ_method)
    {
        //ts = Convert.ToSingle(0.1);
        

        foxws.foxws fproxy = new foxws.foxws();
        //rabws.Service1 rproxy = new Service1();
        rabws.rabws rproxy = new rabws.rabws();

        //the system will loop according to the defined time step
        //int lp = Convert.ToInt16(Math.Truncate(yr / ts)); //total number of loop due to the defined time step
        int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //10 timestep in 1 year
        lp = lp+2;
        double[,] result = new double[lp, 2];

        float fr = r; //rabbit population for fox model


        for (int i = 1; i < lp; i++)
        {

            //if (i % (Convert.ToInt16(Math.Truncate(ts * 10))) == 0)
            if (i % (Convert.ToInt16(ts*10)) == 0)
            {
                //run rabbit model
                if (r_integ_method == "Runge-Kutta") // for Runge-Kutta integration of rabbit
                {
                    //r = calc_Rabbit_Runge_Kutta(r, f, ts);
                    r = diff_Rabbit_Runge_Kutta(r, f, ts);
                }
                else                   
                   //r = r + rproxy.pop_inc(r, f) * ts; //for euler integration
                   r = r + rabbit_model(r, f) * ts;
                   // r = r + rabbit_with_diff_func(r, f) * ts; //rabbit with px/(q+x) function than bx

                //run fox model
                if (f_integ_method == "Runge-Kutta") // for Runge-Kutta integration of fox model
                {
                    //f = calc_Fox_Runge_Kutta(f, fr, ts);
                    f = diff_Fox_Runge_Kutta(f, fr, ts);
                }
                else                   
                   //f = f + fproxy.foxpop_inc(f, fr) * ts; //for euler integration
                  f = f + fox_model(f, fr) * ts;
                    //f = f + fox_with_diff_func(f, fr) * ts; //fox with px/(q+x) function than bx

                fr = r; //update current rabbit population for fox model

                if (r < 0)
                    result[i, 0] = 0;
                else
                    result[i, 0] = r;   //Convert.ToDouble(r.ToString("#.##"));

                if (f < 0)
                    result[i, 1] = 0;
                else
                    result[i, 1] = f;   // Convert.ToDouble(f.ToString("#.##"));       

                if (result[i, 0] < 0) //(result[i, 0] < 1)
                {
                    result[i, 0] = 0; //if pop<0 then set the pop value to 0
                    result[i, 1] = 0;
                    break;
                }
            }
            else
            {
                if (r < 0) //(result[i, 0] < 1)
                {
                    result[i, 0] = 0; //if pop<0 then set the pop value to 0
                    result[i, 1] = 0;
                    break;
                }
                else
                {
                    result[i, 0] = r;
                    result[i, 1] = f;
                }

            }
        }

        return result;

    }

    protected void horizontal_different_ts(float r, float r_ts, float f, float f_ts, int yr, out double[] r_result, ref double[] f_result, string r_integ_method, string f_integ_method)
    {

        foxws.foxws fproxy = new foxws.foxws();
        rabws.rabws rproxy = new rabws.rabws();

        //the system will loop for each time step
        int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //total number of loop due to the defined year
        lp = lp + 1;
        r_result = new double[lp]; //array for rab
        f_result = new double[lp]; //array for fox

        //rx_result = new double[lp];
        //ry_result = new double[lp];
        //fx_result = new double[lp];
        //fy_result = new double[lp];

        double[] t = new double[3];
        t[1] = Convert.ToDouble(r_ts.ToString("#.##")); //time step of rabbit
        t[2] = Convert.ToDouble(f_ts.ToString("#.##")); //time step of fox

        int temp_r_ts = Convert.ToInt16(r_ts * 10);
        int temp_f_ts = Convert.ToInt16(f_ts * 10);

        float rx = r; //recent value of rabbit population for rabbit model
        float ry = f; //recent value of fox population for rabbit model

        float fx = r; //recent value of rabbit population for fox model
        float fy = f; //recent value of fox population for fox model

        for (int i = 1; i < lp; i++)
        {

            double tmp = Convert.ToDouble(i * 0.1);
            if (i == 0) //t[0] is current time step for the loop since each loop is time step
                t[0] = 0;
            else
                t[0] = Convert.ToDouble(tmp.ToString("#.##"));

            //now for rabbit model
            int m = i % temp_r_ts; //m for maintaining result of % operation
            if (m == 0 && i > 0) //check if the current time step is valid to run rabit model
            {
                if (r_integ_method == "Runge-Kutta") // Runge-Kutta integration of rabbit model
                {
                    rx = calc_Rabbit_Runge_Kutta(rx, ry, r_ts);
                }
                else
                    //rx = rx + rproxy.pop_inc(rx, ry) * r_ts;
                rx = rx + rabbit_model(rx, ry) * r_ts;

                r = rx; //update recent value of r using recent output of rx
                ry = f; //copy recent pop of fox for next run

            }            
            r_result[i] = r; // Convert.ToDouble(r.ToString("#.##"));

            //now for fox model
            int n = i % temp_f_ts; //n for maintaining result of % operation
            if (n == 0 && i > 0) //check if the current time step is valid to run fox model
            {
                if (f_integ_method == "Runge-Kutta") // for Runge-Kutta integration of fox model
                {
                    fy = calc_Fox_Runge_Kutta(fy, fx, f_ts);
                }
                else
                    //fy = fy + fproxy.foxpop_inc(fy, fx) * f_ts;
                fy = fy + fox_model(fy,fx) * f_ts;

                //update recent fox pop value
                if (fy >= 0)
                {
                    f = fy;                    
                }
                else //if fox pop <0 set it to 0
                {
                    fy = 0;
                    f = 0;
                }

                //copy recent rabbit pop for next run
                fx = r;

            }
            f_result[i] = f;

            if (n == 0 && m == 0) //if both models run then rabbit should copy recent value of fox since it is already run before fox
            {
                ry = f;
            }

            //rx_result[i] = rx;
            //ry_result[i] = ry;
            //fx_result[i] = fx;
            //fy_result[i] = fy;

            //if rab pop<0 then set the pop value to 0 and quit
            if (r_result[i] < 0)
            {
                r_result[i] = 0;
                f_result[i] = 0;
                break;
            }

        }


    }

    protected void horizontal_diff_2_ts(float r, float r_ts, float f, float f_ts, int yr, out double[] r_result, ref double[] f_result, string r_integ_method, string f_integ_method)
    {

        foxws.foxws fproxy = new foxws.foxws();
        rabws.rabws rproxy = new rabws.rabws();

        //the system will loop for each time step
        int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //total number of loop due to the defined year
        lp = lp + 1;
        r_result = new double[lp]; //array for rab
        f_result = new double[lp]; //array for fox

        double[] t = new double[3];
        t[1] = Convert.ToDouble(r_ts.ToString("#.##")); //time step of rabbit
        t[2] = Convert.ToDouble(f_ts.ToString("#.##")); //time step of fox

        int temp_r_ts = Convert.ToInt16(r_ts * 10);
        int temp_f_ts = Convert.ToInt16(f_ts * 10);

        float rx = r;
        float ry = f;
        float fx = r;
        float fy = f;


        for (int i = 1; i < lp; i++)
        {
                       
            int m = i % temp_r_ts; //m for maintaining result of % operation
            if (m == 0 && i > 0) //check if the current time step is valid to run rabit model
            {

                if (r_integ_method == "Runge-Kutta") // Runge-Kutta integration of rabbit model
                {
                    rx = calc_Rabbit_Runge_Kutta(rx, ry, r_ts);

                }
                else
                    //rx = rx + rproxy.pop_inc(rx, ry) * r_ts;
                    rx = rx + rabbit_model(rx, ry) * r_ts;
                    //rx = rx + rabbit_with_diff_func(rx, ry) * r_ts;

                r = rx;
            }
            
           
            int n = i % temp_f_ts;
            if (n == 0 && i > 0) //check if the current time step is valid to run fox model
            {
                if (m == 0)
                    fx = r;

                if (f_integ_method == "Runge-Kutta") // for Runge-Kutta integration of fox model
                {
                    fy = calc_Fox_Runge_Kutta(fy, fx, f_ts);
                }
                else
                    //fy = fy + fproxy.foxpop_inc(fy, fx) * f_ts;                    
                   fy = fy + fox_model(fy, fx) * f_ts;
                   //fy = fy + fox_with_diff_func(fy, fx) * f_ts;

                f = fy;
                fx = r;
            }

            if(m==0) //if the time step meets ts of rabbit then copy value of f
              ry = f;           

            r_result[i] = r; // Convert.ToDouble(r.ToString("#.##"));

            if (f >= 0)
                f_result[i] = f;
            else //if fox pop <0 set it to 0
            {
                f = 0;
                f_result[i] = 0;
            }


            if (r_result[i] < 0)
            {
                r_result[i] = 0;//if rab pop<0 then set the pop value to 0 and quit
                f_result[i] = 0;
                break;
            }

        }


    }


    protected void horizontal_diff_ts(float r, float r_ts, float f, float f_ts, int yr, out double[] r_result, ref double[] f_result, string r_integ_method, string f_integ_method)
    {

        foxws.foxws fproxy = new foxws.foxws();
        rabws.rabws rproxy = new rabws.rabws();

        //the system will loop for each time step
        int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //total number of loop due to the defined year
        lp = lp + 1;
        r_result = new double[lp]; //array for rab
        f_result = new double[lp]; //array for fox

        double[] t = new double[3]; 
        t[1] = Convert.ToDouble(r_ts.ToString("#.##")); //time step of rabbit
        t[2] = Convert.ToDouble(f_ts.ToString("#.##")); //time step of fox

        int temp_r_ts = Convert.ToInt16(r_ts * 10);
        int temp_f_ts = Convert.ToInt16(f_ts * 10);

        for (int i = 1; i < lp; i++)
        {
            
            double tmp = Convert.ToDouble(i * 0.1);
            if (i == 0) //t[0] is current time step for the loop since each loop is time step
                t[0] = 0; 
            else
                t[0] = Convert.ToDouble(tmp.ToString("#.##"));

             
            int m = i % temp_r_ts; //m for maintaining result of % operation

            if (m == 0 && i>0) //check if the current time step is valid to run rabit model
            {

                if (r_integ_method == "Runge-Kutta") // Runge-Kutta integration of rabbit model
                {
                    r = calc_Rabbit_Runge_Kutta(r, f, r_ts);

                }
                else
                   //r = r + rproxy.pop_inc(r, f) * r_ts;
                   r = r + rabbit_model(r, f) * r_ts;
                
            }
            r_result[i] = r; // Convert.ToDouble(r.ToString("#.##"));

            m = i % temp_f_ts;
            if (m == 0 && i>0) //check if the current time step is valid to run fox model
            {
                if (f_integ_method == "Runge-Kutta") // for Runge-Kutta integration of fox model
                {
                    f = calc_Fox_Runge_Kutta(f, r, f_ts);
                }
                else
                    //f = f + fproxy.foxpop_inc(f, r) * f_ts;
                    f = f + fox_model(f,r) * f_ts;
                
            }
            if (f >= 0)
                f_result[i] = f;
            else //if fox pop <0 set it to 0
               {
                f = 0;
                f_result[i] = 0;
               }


            if (r_result[i] < 0) 
            {
                r_result[i] = 0;//if rab pop<0 then set the pop value to 0 and quit
                f_result[i] = 0;
                break;
            }

        }


    }

    protected void display_diff_ts(float r, float r_ts, float f, float f_ts, int yr, ref double[] r_result, ref double[] f_result)
    {

        int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //total number of loop due to the defined time step
        lp = lp + 1;

        double[] x = new double[lp]; //array for row #

        x[0] = 0;
        r_result[0] = Math.Round((double)r, 2);
        f_result[0] = Math.Round((double)f, 2);
        lst.Items.Add(x[0] + " ; " + r_result[0].ToString() + " ; " + f_result[0].ToString());

        for (int i = 1; i < lp ; i++)
        {
            
            double d = Convert.ToDouble(i * 0.1);
            if(i>0)
              x[i] = Convert.ToDouble(d.ToString("#.##"));
            if (Double.IsNaN(r_result[0]) || Double.IsPositiveInfinity(r_result[0]) || Double.IsNaN(f_result[0]) || Double.IsPositiveInfinity(f_result[0]))
            {
                //if population value is NAN or infinity then skip it in the graph
            }
            else
            {
                r_result[i] = r_result[i]; // Math.Round(r_result[i], 2);
                f_result[i] = f_result[i]; // Math.Round(f_result[i], 2);
            }

            lst.Items.Add(x[i] + " ; " + r_result[i].ToString() + " ; " + f_result[i].ToString() );

        }

        
        Chart1.Series[0].Points.DataBindXY(x, r_result);
        Chart1.Series[1].Points.DataBindXY(x, f_result);
        Chart2.Series[0].Points.DataBindXY(r_result, f_result);
        Chart3.Series[0].Points.DataBindXY(x, r_result);
        Chart4.Series[0].Points.DataBindXY(x, f_result);

        Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line; // .Column;
        Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        Chart3.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        Chart4.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

    }

    protected double[,] vertical(int r, int f, int yr)
    {

        //rabws.Service1 rproxy = new Service1();
        rabws.rabws rproxy = new rabws.rabws();
        foxws.foxws fproxy = new foxws.foxws();

        yr = yr + 1;

        int[] rab = rproxy.pop_list(r, yr);


        double[,] result = new double[yr, yr];

        result[0, 0] = Convert.ToDouble(r);
        result[0, 1] = Convert.ToDouble(f);

        for (int i = 0; i < yr; i++)
        {

            //r = r + rproxy.pop_increase(r, f);
            f = f + fproxy.pop_inc(f, r);

            if (r <= 0 || f <= 0)
                break;

            result[i, 0] = Convert.ToDouble(rab[i]);
            result[i, 1] = Convert.ToDouble(f);


        }

        return result;

    }

    protected void lst_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmbTs_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {

        //find new identifier for this group of data
        string idnt= findmaxidentifier();

        //now insert this group of data with its identifier
        string db = @"D:\prototype\framework\fmdb.accdb";
        string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + db;
        OleDbConnection c = new OleDbConnection(cs);

        try
        {
            c.Open();
            string s = "insert into tbloutput (totalyear, ts, rabbit_ts, fox_ts, rabbit_pop, fox_pop, identifier) values (@totalyear, @ts, @rabbit_ts, @fox_ts, @rabbit_pop, @fox_pop, @identifier)";

            foreach (ListItem item in lst.Items) //substring the value on list box into timestap, rabbit, and fox values
            {
                using (OleDbCommand cmd = new OleDbCommand(s, c))
                {
                    int l = 0;
                    string str = item.ToString();
                    l = str.Length;

                    string substr="",  ts="", rab="", fox="";
                    int pos = 0;


                    for (int i = 0; i < l; i++)
                    {
                        if (str.Substring(i, 1) == ";")
                        {
                            if (pos == 0)
                            {
                                ts = substr;
                            }
                            else if (pos == 1)
                                rab = substr;

                            substr = "";
                            pos = pos + 1;
                        }
                        else
                        {
                            substr = substr + str.Substring(i, 1);

                        }
                        
                    }
                    fox = substr;

                   cmd.Parameters.AddWithValue("@totalyear", txtYr.Text);
                   //cmd.Parameters.AddWithValue("@timestep", ts);
                   cmd.Parameters.AddWithValue("@ts", Convert.ToDouble(ts));
                   cmd.Parameters.AddWithValue("@rabbit_ts", cmbTsRab.Text);
                   cmd.Parameters.AddWithValue("@fox_ts", cmbTsFox.Text);
                   cmd.Parameters.AddWithValue("@rabbit_pop", rab);
                   cmd.Parameters.AddWithValue("@fox_pop", fox);
                   cmd.Parameters.AddWithValue("@identifier", idnt);
                   cmd.ExecuteNonQuery();                
                }
            }

            lblMsg.Text = "Data Saved; Identifier No=" + idnt;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            c.Close();
        }
    }

    public string findmaxidentifier()
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\prototype\framework\fmdb.accdb");
        string query = "SELECT identifier FROM tbloutput ORDER BY identifier DESC";
        DataSet ds = new DataSet();

        string s = "";

         try
        {
        
          connection.Open();
          OleDbDataAdapter da = new OleDbDataAdapter(query, connection);
          OleDbCommandBuilder cmdB = new OleDbCommandBuilder(da);

          da.Fill(ds);

          int cunt = ds.Tables[0].Rows.Count;
          if (cunt <= 0)
          {
                  s = "1";
          }
          else
          {
              if (ds.Tables[0].Rows[0]["identifier"] == DBNull.Value)
              {
                  s = "1";
              }
              else
              {
                  int i = Convert.ToInt16(ds.Tables[0].Rows[0]["identifier"].ToString());
                  s = Convert.ToString(i + 1);
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
        
        return s;

    }

    public float diff_Rabbit_Runge_Kutta(float r, float f, float ts)
    {
        //rabws.rabws rproxy = new rabws.rabws();

        float k1 = 0;
        float k2 = 0;
        float k3 = 0;
        float k4 = 0;

        float m1 = 0;
        float m2 = 0;
        float m3 = 0;

        //k1 = rproxy.pop_inc(r, f); //f(y)
        k1 = rabbit_model(r, f);
        m1 = fox_model(f, r);
        float tmp = r + (ts / 2) * k1;        
        float tmp2 = f + (ts / 2) * m1;

        //k2 = rproxy.pop_inc((tmp), f); //f(y+(h/2)k1)
        k2 = rabbit_model((tmp), tmp2);
        m2 = fox_model((tmp2), tmp);
        tmp = r + (ts / 2) * k2;        
        tmp2 = f + (ts / 2) * m2;

        //k3 = rproxy.pop_inc((tmp), f); //f(y+(h/2)k2)
        k3 = rabbit_model((tmp), tmp2);
        m3 = fox_model((tmp2), tmp);
        tmp = r + ts * k3;       
        tmp2 = f + ts * m3;

        //k4 = rproxy.pop_inc((tmp), f); //f(y+ hk3)
        k4 = rabbit_model((tmp), tmp2);


        r = r + ts * (k1 + 2 * k2 + 2 * k3 + k4) / 6; //y + h*(k1 + 2 * k2 + 2 * k3 + k4)/6
        return r;

    }

    public float diff_Fox_Runge_Kutta(float f, float r, float ts)
    {
        //foxws.foxws fproxy = new foxws.foxws();

        float k1 = 0;
        float k2 = 0;
        float k3 = 0;
        float k4 = 0;

        float n1 = 0;
        float n2 = 0;
        float n3 = 0;

        k1 = fox_model(f, r); //f(y)
        n1 = rabbit_model(r, f);
        float tmp = f + (ts / 2) * k1;
        float tmp2 = r + (ts / 2) * n1;

        k2 = fox_model((tmp), tmp2); //f(y+(h/2)k1)
        n2 = rabbit_model(tmp2, tmp);
        tmp = f + (ts / 2) * k2;
        tmp2 = r + (ts / 2) * n2;

        k3 = fox_model((tmp), tmp2); //f(y+(h/2)k2)
        n3 = rabbit_model(tmp2, tmp);
        tmp = f + ts * k3;
        tmp2 = r + (ts / 2) * n3;

        k4 = fox_model((tmp), tmp2); //f(y+ hk3)

        f = f + ts * (k1 + 2 * k2 + 2 * k3 + k4) / 6; //y + h*(k1 + 2 * k2 + 2 * k3 + k4)/6
        return f;

    }

    public float calc_Rabbit_Runge_Kutta(float r, float f, float ts)
    {
        rabws.rabws rproxy = new rabws.rabws();

        float k1 = 0;
        float k2 = 0;
        float k3 = 0;
        float k4 = 0;

        k1 = rproxy.pop_inc(r, f); //f(y)
        float tmp = r + (ts / 2) * k1;
        k2 = rproxy.pop_inc((tmp), f); //f(y+(h/2)k1)
        tmp = r + (ts / 2) * k2;
        k3 = rproxy.pop_inc((tmp), f); //f(y+(h/2)k2)
        tmp = r + ts * k3;
        k4 = rproxy.pop_inc((tmp), f); //f(y+ hk3)

        r = r + ts*(k1 + 2 * k2 + 2 * k3 + k4) / 6; //y + h*(k1 + 2 * k2 + 2 * k3 + k4)/6
        return r;

    }

    public float calc_Fox_Runge_Kutta(float f, float r, float ts)
    {
        foxws.foxws fproxy = new foxws.foxws();

        float k1 = 0;
        float k2 = 0; 
        float k3 = 0;
        float k4 = 0;

        k1 = fproxy.foxpop_inc(f, r); //f(y)
        float tmp = f + (ts / 2) * k1;
        k2 = fproxy.foxpop_inc((tmp), r); //f(y+(h/2)k1)
        tmp = f + (ts / 2) * k2;
        k3 = fproxy.foxpop_inc((tmp), r); //f(y+(h/2)k2)
        tmp = f + ts * k3;
        k4 = fproxy.foxpop_inc((tmp), r); //f(y+ hk3)

        f = f + ts*(k1 + 2 * k2 + 2 * k3 + k4) / 6; //y + h*(k1 + 2 * k2 + 2 * k3 + k4)/6
        return f;

    }

    public float rabbit_with_diff_func(float r, float f)
    {
        //r = Convert.ToSingle(0.5 * r - 0.01 * r * f);

          r = Convert.ToSingle(0.5 * r - f * 100*r*r/(5000*5000 + r*r) );


        return r;
    }

    public float fox_with_diff_func(float f, float r)
    {

        f = Convert.ToSingle(0.01 * f * 100 * r * r / (5000 * 5000 + r * r) - 0.2 * f);
 

        return f;
    }

    public float fox_model(float f, float r)
    {
        //string ts1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");

        f = Convert.ToSingle(0.01 * 0.01 * f * r  - 0.2 * f);

        //string ts2 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //double d = Convert.ToDouble(ts2) - Convert.ToDouble(ts1);

        return f;
    }

    public float rabbit_model(float r, float f)
    {
        //string ts1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");

        r = Convert.ToSingle(0.5*r - 0.01*r*f);

        //string ts2 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //double d = Convert.ToDouble(ts2) - Convert.ToDouble(ts1);

        return r;
    }


    protected double[,] rabbit_fox_model(float r, float f, int yr, float ts, string r_integ_method, string f_integ_method)
    {
         
        //the system will loop according to the defined time step
        //int lp = Convert.ToInt16(Math.Truncate(yr / ts)); //total number of loop due to the defined time step
        int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //10 timestep in 1 year
        lp = lp + 2;
        double[,] result = new double[lp, 2];


        for (int i = 1; i < lp; i++)
        {

            //if (i % (Convert.ToInt16(Math.Truncate(ts * 10))) == 0)
            if (i % (Convert.ToInt16(ts * 10)) == 0)
            {
                    float r_new = Convert.ToSingle(0.5 * r - 0.01 * r * f);
                    r = r + r_new * ts;

                    float f_new = Convert.ToSingle(0.01 * 0.01 * f * r - 0.2 * f);
                    f = f + f_new * ts;

                if (r < 0)
                    result[i, 0] = 0;
                else
                    result[i, 0] = r;   //Convert.ToDouble(r.ToString("#.##"));

                if (f < 0)
                    result[i, 1] = 0;
                else
                    result[i, 1] = f;   // Convert.ToDouble(f.ToString("#.##"));       

                if (result[i, 0] < 0) //(result[i, 0] < 1)
                {
                    result[i, 0] = 0; //if pop<0 then set the pop value to 0
                    result[i, 1] = 0;
                    break;
                }
            }
            else
            {
                if (r < 0) //(result[i, 0] < 1)
                {
                    result[i, 0] = 0; //if pop<0 then set the pop value to 0
                    result[i, 1] = 0;
                    break;
                }
                else
                {
                    result[i, 0] = r;
                    result[i, 1] = f;
                }

            }
        }

        return result;

    }

    protected double[,] hybrid_horizontal_same_ts(float r, float f, int yr, float ts, string r_integ_method, string f_integ_method)
    {
        //objective: the two models run with ts=0.1 but they exchange data at multiple of 1

        foxws.foxws fproxy = new foxws.foxws();
        rabws.rabws rproxy = new rabws.rabws();

        //the system will loop according to the defined time step
        //int lp = Convert.ToInt16(Math.Truncate(yr / ts)); //total number of loop due to the defined time step
        int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //10 timestep in 1 year
        lp = lp + 2;
        double[,] result = new double[lp, 2];

        float rx = r;
        float ry = f;
        float fx = r;
        float fy = f;

        for (int i = 1; i < lp; i++)
        {

            if (i % (Convert.ToInt16(ts * 10)) == 0)
            {
                

                //run rabbit model
                if (r_integ_method == "Runge-Kutta") // for Runge-Kutta integration of rabbit
                {
                    r = calc_Rabbit_Runge_Kutta(r, f, ts);

                }
                else
                    rx = rx + rproxy.pop_inc(rx, ry) * ts; //for euler integration
                   //r = r + rabbit_model(r, f) * ts;

                //run fox model
                if (f_integ_method == "Runge-Kutta") // for Runge-Kutta integration of fox model
                {
                    f = calc_Fox_Runge_Kutta(f, r, ts);
                }
                else
                    fy = fy + fproxy.foxpop_inc(fy, fx) * ts; //for euler integration
                  //f = f + fox_model(f, r) * ts;    

                if ((i % 10) == 0)  //when ts is 1,2,3, ... then the models exchange data
                {
                    ry = f;
                    fx = r;
                }

                r = rx;
                f = fy;

                if (r < 0)
                    result[i, 0] = 0;
                else
                    result[i, 0] = r;   //Convert.ToDouble(r.ToString("#.##"));

                if (f < 0)
                    result[i, 1] = 0;
                else
                    result[i, 1] = f;   // Convert.ToDouble(f.ToString("#.##"));       

                if (result[i, 0] < 0) //(result[i, 0] < 1)
                {
                    result[i, 0] = 0; //if pop<0 then set the pop value to 0
                    result[i, 1] = 0;
                    break;
                }
            }
            else
            {
                if (r < 0) //(result[i, 0] < 1)
                {
                    result[i, 0] = 0; //if pop<0 then set the pop value to 0
                    result[i, 1] = 0;
                    break;
                }
                else
                {
                    result[i, 0] = r;
                    result[i, 1] = f;
                }

            }
        }

        return result;

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
    }
    protected void Chart1_Load(object sender, EventArgs e)
    {

    }
}