#ifndef RAB_H
#define RAB_H

#include <string>
using namespace std;

#include "rab_global.h"
#include "poparray.h"

//class RABSHARED_EXPORT Rab {
    class  Rab {
public:
    //Rab();
    __declspec(dllexport) int  popgrowth(int rabpoo, int foxpop);
    __declspec(dllexport) int* pop2(int initpoo, int yr);
    __declspec(dllexport) poparray pop(int initpoo, int yr);
    __declspec(dllexport) string popstr(int initpoo, int yr);
    __declspec(dllexport) float  popinc(float rabpoo, float foxpop);


};

#endif // RAB_H
