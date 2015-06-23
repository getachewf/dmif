/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package fox;
/**
 *
 * @author BeleteG
 */
public class fox {
    
    public float pop_inc_float(float foxpop, float rabpop) {
        //TODO write your implementation code here:
        float inc=0;
        inc=(float)(0.01*0.01*foxpop*rabpop-0.2*foxpop);
        return inc;
    }
     public int pop_inc_int(int foxpop, int rabpop) {
        //TODO write your implementation code here:
        int inc=0;
        inc=(int)(0.01*0.01*foxpop*rabpop-0.2*foxpop);
        //if(inc<0)
            //inc=0;
        return inc;
    }
}
