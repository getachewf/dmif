using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using foxws;
using rabws;
using System.Web.UI.DataVisualization.Charting; 

public partial class _Default : System.Web.UI.Page 
{
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
    

    }
    protected void cmdRun_Click(object sender, EventArgs e)
    {
        
        int f= Convert.ToInt32(txtFox.Text);
        int r= Convert.ToInt32(txtRab.Text);
        int yr = Convert.ToInt32(txtYr.Text);

        /*

        foxws.foxws fproxy = new foxws.foxws();
        rabws.Service1 rproxy = new Service1();        

        lst.Items.Clear();
        lst.Items.Add(r.ToString() + ";" + f.ToString());

        double[] x = new double[yr];
        double[] ry = new double[yr];
        double[] fy = new double[yr];
        x[0] = 0;
        ry[0] = Convert.ToDouble(r);
        fy[0] = Convert.ToDouble(f);

        for (int i = 0; i < yr; i++)
        {
            
            r = r + rproxy.pop_increase(r, f);
            f = f + fproxy.pop_inc(f, r);
            lst.Items.Add(r.ToString() + ";" + f.ToString());

            x[i] = Convert.ToDouble(i);
            ry[i] = Convert.ToDouble(r);
            fy[i] = Convert.ToDouble(f);
        }

        for (int i = 0; i < yr; i++)
        {
            Chart1.Series[0].Points.DataBindXY(x, ry);
            Chart2.Series[0].Points.DataBindXY(x, fy);
        }

        Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
        Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;   
         * */

        
        double[,] result;
        if (cmbType.Text == "Horizontal")
        {
            result = horizontal(r, f, yr);
        }
        else
        {
            result = vertical(r, f, yr);
        }

        lst.Items.Clear();
        lst.Items.Add(r.ToString() + ";" + f.ToString());

        double[] x = new double[yr];
        double[] ry = new double[yr];
        double[] fy = new double[yr];

        for (int i = 0; i < yr; i++)
        {
            lst.Items.Add(result[i, 0].ToString() + ";" + result[i, 1].ToString());

            x[i] = Convert.ToDouble(i);
            ry[i] = result[i,0];
            fy[i] = result[i, 1];
        }

        for (int i = 0; i < yr; i++)
        {
            Chart1.Series[0].Points.DataBindXY(x, ry);
            Chart1.Series[1].Points.DataBindXY(x, fy);
            Chart2.Series[0].Points.DataBindXY(x, fy);
        }

        Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
        Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
        Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
         

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


    }

    protected double[,] horizontal(int r, int f, int yr)
    {

        foxws.foxws fproxy = new foxws.foxws();
        //rabws.Service1 rproxy = new Service1();
        rabws.rabws rproxy = new rabws.rabws();

        double[,] result = new double[yr,yr];

        result[0,0] = Convert.ToDouble(r);
        result[0,1] = Convert.ToDouble(f);

        for (int i = 0; i < yr; i++)
        {

            r = r + rproxy.pop_increase(r, f);
            f = f + fproxy.pop_inc(f, r);

            if (r <= 0 || f <= 0)
                break;

            result[i,0] = Convert.ToDouble(r);
            result[i,1] = Convert.ToDouble(f);

            
        }
        
        return result;

    }

    protected double[,] vertical(int r, int f, int yr)
    {

        //rabws.Service1 rproxy = new Service1();
        rabws.rabws rproxy = new rabws.rabws();
        foxws.foxws fproxy = new foxws.foxws();

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
   

}