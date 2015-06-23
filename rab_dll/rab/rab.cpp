#include "rab.h"


//Rab::Rab()
//{
//}

__declspec(dllexport) int  Rab::popgrowth(int rabpop, int foxpop)
{
    //dX/dt = aX - bXY

    return (0.5*rabpop - 0.01*rabpop*foxpop);
}

__declspec(dllexport) int*  Rab:: pop2(int initpoo, int yr)
{

    static int array[1000];

    array[0]=initpoo;

    for(int i=1; i<yr; i++)
    {
        array[i] =array[i-1] + 0.5*array[i-1];

    }

    return array;
}


__declspec(dllexport) poparray  Rab:: pop(int initpoo, int yr)
{

    poparray a;

    a.values[0]=initpoo;

    for(int i=1; i<yr; i++)
    {
        a.values[i] =a.values[i-1] + 0.5*a.values[i-1];

    }

    return a;
}

__declspec(dllexport) string  Rab:: popstr(int initpoo, int yr)
{

    string s, temp;

   // poparray a;

   // a.values[0]=initpoo;
    int p=initpoo;

    for(int i=1; i<yr; i++)
    {
       // a.values[i] =a.values[i-1] + popgrowth(a.values[i-1]);
        //int j=a.values[i];

        p= p + 0.5*p;
        temp=std::to_string(static_cast<long long>(p));
        s= s.append(temp);
        s= s.append(";");
    }

    return s;
}

__declspec(dllexport) float  Rab::popinc(float rabpop, float foxpop)
{
    //dX/dt = aX - bXY

    return (0.5*rabpop - 0.01*rabpop*foxpop);
}
