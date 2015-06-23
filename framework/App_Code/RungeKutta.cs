using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RungeKutta
/// </summary>
public class RungeKutta
{
	public RungeKutta()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public float calc_Rabbit_Runge_Kutta(float r, float f, float ts)
    {
        Rabbit rab = new Rabbit();
        Fox fx = new Fox();

        float k1 = 0;
        float k2 = 0;
        float k3 = 0;
        float k4 = 0;

        float m1 = 0;
        float m2 = 0;
        float m3 = 0;

        //k1 = rproxy.pop_inc(r, f); //f(y)
        k1 = rab.rabbit_model(r, f);
        m1 = fx.fox_model(f, r);
        float tmp = r + (ts / 2) * k1;
        float tmp2 = f + (ts / 2) * m1;

        //k2 = rproxy.pop_inc((tmp), f); //f(y+(h/2)k1)
        k2 = rab.rabbit_model((tmp), tmp2);
        m2 = fx.fox_model((tmp2), tmp);
        tmp = r + (ts / 2) * k2;
        tmp2 = f + (ts / 2) * m2;

        //k3 = rproxy.pop_inc((tmp), f); //f(y+(h/2)k2)
        k3 = rab.rabbit_model((tmp), tmp2);
        m3 = fx.fox_model((tmp2), tmp);
        tmp = r + ts * k3;
        tmp2 = f + ts * m3;

        //k4 = rproxy.pop_inc((tmp), f); //f(y+ hk3)
        k4 = rab.rabbit_model((tmp), tmp2);

        //y + h*(k1 + 2 * k2 + 2 * k3 + k4)/6
        r = r + ts * (k1 + 2 * k2 + 2 * k3 + k4) / 6; 
        return r;

    }

    public float calc_Fox_Runge_Kutta(float f, float r, float ts)
    {
        Rabbit rab = new Rabbit();
        Fox fx = new Fox();

        float k1 = 0;
        float k2 = 0;
        float k3 = 0;
        float k4 = 0;

        float n1 = 0;
        float n2 = 0;
        float n3 = 0;

        k1 = fx.fox_model(f, r); //f(y)
        n1 = rab.rabbit_model(r, f);
        float tmp = f + (ts / 2) * k1;
        float tmp2 = r + (ts / 2) * n1;

        k2 = fx.fox_model((tmp), tmp2); //f(y+(h/2)k1)
        n2 = rab.rabbit_model(tmp2, tmp);
        tmp = f + (ts / 2) * k2;
        tmp2 = r + (ts / 2) * n2;

        k3 = fx.fox_model((tmp), tmp2); //f(y+(h/2)k2)
        n3 = rab.rabbit_model(tmp2, tmp);
        tmp = f + ts * k3;
        tmp2 = r + (ts / 2) * n3;

        k4 = fx.fox_model((tmp), tmp2); //f(y+ hk3)

        f = f + ts * (k1 + 2 * k2 + 2 * k3 + k4) / 6; //y + h*(k1 + 2 * k2 + 2 * k3 + k4)/6
        return f;

    }

}