﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LegacyWrapper.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class LegacyDllImportAttribute : Attribute
    {
        public string LibraryName { get; private set; }
        public CallingConvention CallingConvention { get; set; }
        public CharSet CharSet { get; set; }

        public LegacyDllImportAttribute(string libraryName)
        {
            LibraryName = libraryName;
            CallingConvention = CallingConvention.StdCall;
            CharSet = CharSet.Auto;
        }
    }
}
