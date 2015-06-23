using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HorizontalDifferentTs
/// </summary>
public class HorizontalDifferentTs
{
	public HorizontalDifferentTs()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public double[,] rabbit_fox_horizontal_diff_ts(float r, float r_ts, float f, float f_ts, int yr, string r_integ_method, string f_integ_method)
    {
        int ts_factor = 10; //time step factor, to define numer of loops in unit of time, e.g. if ts=0.1 then we will have 10 loops in each unit of time
        
        float ts;
        if (r_ts > f_ts)
            ts = f_ts;
        else if (r_ts > f_ts)
            ts = r_ts;
        else
            ts = r_ts;

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

        Rabbit rab = new Rabbit();
        Fox fx_m = new Fox();

        RungeKutta rk = new RungeKutta();

        //the system will loop for each time step
        //int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //total number of loop due to the defined year
        int lp = yr * ts_factor;

        lp = lp + 1;
       // r_result = new double[lp]; //array for rab
        //f_result = new double[lp]; //array for fox

        double[,] result = new double[lp, 2];

        double[] t = new double[3];
        t[1] = Convert.ToDouble(r_ts.ToString("#.####")); //time step of rabbit
        t[2] = Convert.ToDouble(f_ts.ToString("#.####")); //time step of fox

        int temp_r_ts = Convert.ToInt16(r_ts * ts_factor);
        int temp_f_ts = Convert.ToInt16(f_ts * ts_factor);

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
                    rx = rk.calc_Rabbit_Runge_Kutta(rx, ry, r_ts);

                }
                else
                    rx = rx + rab.rabbit_model(rx, ry) * r_ts;
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
                    fy = rk.calc_Fox_Runge_Kutta(fy, fx, f_ts);
                }
                else
                    fy = fy + fx_m.fox_model(fy, fx) * f_ts;
                //fy = fy + fox_with_diff_func(fy, fx) * f_ts;

                f = fy;
                fx = r;
            }

            if (m == 0) //if the time step meets ts of rabbit then copy value of f
                ry = f;

            //r_result[i] = r; // Convert.ToDouble(r.ToString("#.##"));
            result[i,0] = r;

            if (f >= 0)
                //f_result[i] = f;
                result[i, 1] = f;
            else //if fox pop <0 set it to 0
            {
                f = 0;
                //f_result[i] = 0;
                result[i, 1] = 0;
            }


            if (result[i, 0] < 0) // (r_result[i] < 0)
            {
                //r_result[i] = 0;//if rab pop<0 then set the pop value to 0 and quit
                //f_result[i] = 0;
                result[i, 0] = 0;//if rab pop<0 then set the pop value to 0 and quit
                result[i, 1] = 0;
                break;
            }

        }

        return result;

    }


   
}