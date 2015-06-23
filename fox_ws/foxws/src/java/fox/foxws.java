/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package fox;

import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

/**
 *
 * @author BeleteG
 */
@WebService(serviceName = "foxws")
public class foxws {

    /**
     * This is a sample web service operation
     */
   /* @WebMethod(operationName = "hello")
    public String hello(@WebParam(name = "name") String txt) {
        return "Hello " + txt + " !";
    }
*/
    /**
     * Web service operation
     */
    @WebMethod(operationName = "pop_inc")
    public int pop_inc(int foxpop, int rabpop) {

        int inc;
        
        fox fx= new fox();
        
        inc= fx.pop_inc_int(foxpop, rabpop);

        return inc;
    }
    
    @WebMethod(operationName = "foxpop_inc")
    public float foxpop_inc(float foxpop, float rabpop) {
        
        float inc;
        
        //call fox class
        fox fx= new fox();       
        
        inc=fx.pop_inc_float(foxpop, rabpop);
        
        return inc;
    }
    
    
}
