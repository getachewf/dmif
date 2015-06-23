using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace rabws
{
    public static class DllHelper
    {
        [DllImport(@"D:\prototype\rab_ws\rabws\rabws\rab.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?popgrowth@Rab@@QAEHHH@Z")]
        public static extern int popgrowth(int rab, int fox);
        [DllImport(@"D:\prototype\rab_ws\rabws\rabws\rab.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?popinc@Rab@@QAEMMM@Z")]
        public static extern float popinc(float rab, float fox);
        [DllImport(@"D:\prototype\rab_ws\rabws\rabws\rab.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?pop2@Rab@@QAEPAHHH@Z")]
        public static extern IntPtr pop2(int i, int yr);
        //[DllImport(@"D:\prototype\call_rab2\callrab\callrab\rab.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?pop@Rab@@QAE?AUpoparray@@HH@Z")]
        //public static extern poparray pop(int i, int yr);
        //[DllImport(@"D:\prototype\call_rab2\callrab\callrab\rab.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?popstr@Rab@@QAE?AV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@HH@Z")]
        //public static extern string popstr(int i, int yr);
    }
}