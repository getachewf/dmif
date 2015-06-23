using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Fox
/// </summary>
public class Fox
{
	public Fox()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public float fox_model(float f, float r)
    {
        foxws.foxws fproxy = new foxws.foxws();
        f = fproxy.foxpop_inc(f, r);

       // f = Convert.ToSingle(0.01 * 0.01 * f * r - 0.2 * f);

        return f;
    }
}