using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


public partial class gcam_exiomod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdRun_Click(object sender, EventArgs e)
    {
        string endyear = txtEndYear.Text;
        int arrLeng = Convert.ToInt16(endyear) - Convert.ToInt16(txtBeguinYear.Text) + 10;

        exiomodws.Exio_wsSoapClient exom = new exiomodws.Exio_wsSoapClient();
        //string s_out = string.Join(";", exom.Exiomod(endyear));

        //increase time span to avoid timeout error
        exom.Endpoint.Binding.SendTimeout = new TimeSpan(00,25,00);

        ArrayList myArrayList = new ArrayList();
        myArrayList.AddRange(exom.Exiomod(endyear));

        string[] out_array = myArrayList.ToArray(typeof(string)) as string[];        

        string[] Africa_x = new string[arrLeng]; //array for Africa GDP
        double[] Africa_y = new double[arrLeng];

        string[] Australia_NZ_x = new string[arrLeng]; //array for  Australia_NZ GDP
        double[] Australia_NZ_y = new double[arrLeng];
        int anz = 0;

        string[] Canada_x = new string[arrLeng]; //array for  Canada GDP
        double[] Canada_y = new double[arrLeng];
        int can = 0;

        string[] China_x = new string[arrLeng]; //array for  china GDP
        double[] China_y = new double[arrLeng];
        int chan = 0;

        string[] EEU_x = new string[arrLeng]; //array for  Eastern Europe GDP
        double[] EEU_y = new double[arrLeng];
        int eeu = 0;

        string[] FSU_x = new string[arrLeng]; //array for Former Soviet Union GDP
        double[] FSU_y = new double[arrLeng];
        int su = 0;

        string[] India_x = new string[arrLeng]; //array for India GDP
        double[] India_y = new double[arrLeng];
        int ind = 0;

        string[] Japan_x = new string[arrLeng]; //array for Japan GDP
        double[] Japan_y = new double[arrLeng];
        int jap = 0;

        string[] Korea_x = new string[arrLeng]; //array for Korea GDP
        double[] Korea_y = new double[arrLeng];
        int kor = 0;

        string[] Latin_x = new string[arrLeng]; //array for Latin America GDP
        double[] Latin_y = new double[arrLeng];
        int lat = 0;

        string[] Middle_x = new string[arrLeng]; //array for Middle East GDP
        double[] Middle_y = new double[arrLeng];
        int mid = 0;

        string[] South_x = new string[arrLeng]; //array for Southeast Asia GDP
        double[] South_y = new double[arrLeng];
        int sou = 0;

        string[] USA_x = new string[arrLeng]; //array for USA GDP
        double[] USA_y = new double[arrLeng];
        int us = 0;

        string[] Western_x = new string[arrLeng]; //array for Western Europe GDP
        double[] Western_y = new double[arrLeng];
        int wst = 0;

        for (int i = 0; i < out_array.Length; i++)
        {
            lstExio.Items.Add(out_array[i]);

            if (out_array[i] != null)
            {
                int j = out_array[i].Length;
                string strtemp = "";

                if (out_array[i].Length > 12)
                {
                    strtemp = out_array[i].Substring(0, 8);
                    if (strtemp == "Africa.2")
                    {
                        Africa_x[i] = out_array[i].Substring(7, 4);
                        Africa_y[i] = Convert.ToDouble(out_array[i].Substring(12, j - 12));
                    }
                }

                if (out_array[i].Length > 18)
                {
                    strtemp = out_array[i].Substring(0, 14);
                    if (strtemp == "Australia_NZ.2")
                    {
                        Australia_NZ_x[anz] = out_array[i].Substring(13, 4);
                        Australia_NZ_y[anz] = Convert.ToDouble(out_array[i].Substring(18, j - 18));
                        anz = anz + 1;
                    }
                }

                if (out_array[i].Length > 12)
                {
                    strtemp = out_array[i].Substring(0, 8);
                    if (strtemp == "Canada.2")
                    {
                        Canada_x[can] = out_array[i].Substring(7, 4);
                        Canada_y[can] = Convert.ToDouble(out_array[i].Substring(12, j - 12));
                        can = can + 1;
                    }
                }


                if (out_array[i].Length > 11)
                {
                    strtemp = out_array[i].Substring(0, 7);
                    if (strtemp == "China.2")
                    {
                        China_x[chan] = out_array[i].Substring(6, 4);
                        China_y[chan] = Convert.ToDouble(out_array[i].Substring(11, j - 11));
                        chan = chan + 1;
                    }
                }
                                

                if (out_array[i].Length > 20)
                {
                    strtemp = out_array[i].Substring(0, 16);
                    if (strtemp == "Eastern Europe.2")
                    {
                        EEU_x[eeu] = out_array[i].Substring(15, 4);
                        EEU_y[eeu] = Convert.ToDouble(out_array[i].Substring(20, j - 20));
                        eeu = eeu + 1;
                    }
                }

                //Former Soviet Union
                if (out_array[i].Length > 25)
                {
                    strtemp = out_array[i].Substring(0, 21);
                    if (strtemp == "Former Soviet Union.2")
                    {
                        FSU_x[su] = out_array[i].Substring(20, 4);
                        FSU_y[su] = Convert.ToDouble(out_array[i].Substring(25, j - 25));
                        su = su + 1;
                    }
                }

                //India
                if (out_array[i].Length > 11)
                {
                    strtemp = out_array[i].Substring(0, 7);
                    if (strtemp == "India.2")
                    {
                        India_x[ind] = out_array[i].Substring(6, 4);
                        India_y[ind] = Convert.ToDouble(out_array[i].Substring(11, j - 11));
                        ind = ind + 1;
                    }
                }

                //Japan
                if (out_array[i].Length > 11)
                {
                    strtemp = out_array[i].Substring(0, 7);
                    if (strtemp == "Japan.2")
                    {
                        Japan_x[jap] = out_array[i].Substring(6, 4);
                        Japan_y[jap] = Convert.ToDouble(out_array[i].Substring(11, j - 11));
                        jap = jap + 1;
                    }
                }

                //Korea
                if (out_array[i].Length > 11)
                {
                    strtemp = out_array[i].Substring(0, 7);
                    if (strtemp == "Korea.2")
                    {
                        Japan_x[kor] = out_array[i].Substring(6, 4);
                        Japan_y[kor] = Convert.ToDouble(out_array[i].Substring(11, j - 11));
                        kor = kor + 1;
                    }
                }

                //Latin America
                if (out_array[i].Length > 19)
                {
                    strtemp = out_array[i].Substring(0, 15);
                    if (strtemp == "Latin America.2")
                    {
                        Latin_x[lat] = out_array[i].Substring(14, 4);
                        Latin_y[lat] = Convert.ToDouble(out_array[i].Substring(19, j - 19));
                        lat = lat + 1;
                    }
                }

                //Middle East
                if (out_array[i].Length > 17)
                {
                    strtemp = out_array[i].Substring(0, 13);
                    if (strtemp == "Middle East.2")
                    {
                        Middle_x[mid] = out_array[i].Substring(12, 4);
                        Middle_y[mid] = Convert.ToDouble(out_array[i].Substring(17, j - 17));
                        mid = mid + 1;
                    }
                }

                //Southeast Asia
                if (out_array[i].Length > 20)
                {
                    strtemp = out_array[i].Substring(0, 16);
                    if (strtemp == "Southeast Asia.2")
                    {
                        South_x[sou] = out_array[i].Substring(15, 4);
                        South_y[sou] = Convert.ToDouble(out_array[i].Substring(20, j - 20));
                        sou = sou + 1;
                    }
                }

                //USA
                if (out_array[i].Length > 9)
                {
                    strtemp = out_array[i].Substring(0, 5);
                    if (strtemp == "USA.2")
                    {
                        USA_x[us] = out_array[i].Substring(4, 4);
                        USA_y[us] = Convert.ToDouble(out_array[i].Substring(9, j - 9));
                        us = us + 1;
                    }
                }

                //Western Europe
                if (out_array[i].Length > 20)
                {
                    strtemp = out_array[i].Substring(0, 16);
                    if (strtemp == "Western Europe.2")
                    {
                        Western_x[wst] = out_array[i].Substring(15, 4);
                        Western_y[wst] = Convert.ToDouble(out_array[i].Substring(20, j - 20));
                        wst = wst + 1;
                    }
                }


            }
                        
        }


        Chart1.Series[0].Points.DataBindXY(Africa_x, Africa_y);    
        Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line; 

        Chart1.Series[1].Points.DataBindXY(Australia_NZ_x, Australia_NZ_y);
        Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[2].Points.DataBindXY(Canada_x, Canada_y);
        Chart1.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[3].Points.DataBindXY(China_x, China_y);
        Chart1.Series[3].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[4].Points.DataBindXY(EEU_x, EEU_y);
        Chart1.Series[4].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[5].Points.DataBindXY(FSU_x, FSU_y);
        Chart1.Series[5].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[6].Points.DataBindXY(India_x, India_y);
        Chart1.Series[6].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[7].Points.DataBindXY(Japan_x, Japan_y);
        Chart1.Series[7].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[8].Points.DataBindXY(Korea_x, Korea_y);
        Chart1.Series[8].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[9].Points.DataBindXY(Latin_x, Latin_y);
        Chart1.Series[9].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[10].Points.DataBindXY(Middle_x, Middle_y);
        Chart1.Series[10].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[11].Points.DataBindXY(South_x, South_y);
        Chart1.Series[11].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[12].Points.DataBindXY(USA_x, USA_y);
        Chart1.Series[12].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        Chart1.Series[13].Points.DataBindXY(Western_x, Western_y);
        Chart1.Series[13].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;


        Chart1.Legends.Add("Africa");

       
    }
}