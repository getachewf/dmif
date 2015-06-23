using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Rabbit
/// </summary>
public class Rabbit
{
	public Rabbit()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public float rabbit_model(float r, float f)
    {
       
       rabws.rabws rproxy = new rabws.rabws();
       r = rproxy.pop_inc(r, f);

      // r = Convert.ToSingle(0.5 * r - 0.01 * r * f);

        return r;
    }
}