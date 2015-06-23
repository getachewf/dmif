using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HorizontalSameTs
/// </summary>
public class HorizontalSameTs
{
	public HorizontalSameTs()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public double[,] rabbit_fox_horizontal_same_ts(float r, float f, int yr, float ts, string r_integ_method, string f_integ_method)
    {
        int ts_factor = 10; //time step factor, to define numer of loops in unit of time, e.g. if ts=0.1 then we will have 10 loops in each unit of time
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
        Fox fx = new Fox();

        RungeKutta rk = new RungeKutta();

        //the system will loop according to the defined time step
        //int lp = Convert.ToInt16(Math.Truncate(yr / ts)); //total number of loop due to the defined time step
        //int lp = Convert.ToInt32(Math.Truncate(yr / 0.1)); //10 timestep in 1 year
        int lp = yr * ts_factor;

        lp = lp + 2;
        double[,] result = new double[lp, 2];

        float fr = r; //rabbit population for fox model


        for (int i = 1; i < lp; i++)
        {

            //if (i % (Convert.ToInt16(Math.Truncate(ts * 10))) == 0)
            if (i % (Convert.ToInt16(ts * ts_factor)) == 0)
            {
                //run rabbit model
                if (r_integ_method == "Runge-Kutta") // for Runge-Kutta integration of rabbit
                {
                    r = rk.calc_Rabbit_Runge_Kutta(r, f, ts);
                }
                else
                  //for euler integration
                    r = r + rab.rabbit_model(r, f) * ts;
                // r = r + rabbit_with_diff_func(r, f) * ts; //rabbit with px/(q+x) function than bx

                //run fox model
                if (f_integ_method == "Runge-Kutta") // for Runge-Kutta integration of fox model
                {
                    f = rk.calc_Fox_Runge_Kutta(f, fr, ts);
                }
                else
                    f = f + fx.fox_model(f, fr) * ts;
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

}