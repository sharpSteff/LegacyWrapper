using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LegacyWrapper.Common.Attributes;

namespace LegacyWrapperTest.Integration.Interface
{
    // We assume the following dll functions in our Test.dll here: 
    // Every function is supposed to return the input parameter unchanged.
    //
    // function TestStdCall(const AParam: Integer): Integer; stdcall;
    // function TestNormalFunc(const AParam: Integer): Integer;
    // function TestPCharHandling(const AParam: PChar): PChar; stdcall;
    // function TestPWideCharHandling(const AParam: PWideChar): PWideChar; stdcall;
    //
    // These procedures are expected to increment their parameters by 1:
    //
    // procedure TestVarParamHandling(var AParam: Integer); stdcall;      
    // procedure TestMultipleVarParamsHandling(var AParam1: Integer; var AParam2: Integer); stdcall;

    [LegacyDllImport("TestDll.dll")]
    public interface ITestDll : IDisposable
    {
        [LegacyDllMethod(CallingConvention = CallingConvention.StdCall)]
        UInt32 TestStdCall(UInt32 AParam);

        [LegacyDllMethod(CallingConvention = CallingConvention.StdCall)]
        UInt32 TestNormalFunc(UInt32 AParam);

        [LegacyDllMethod(CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        string TestPCharHandling(string AParam);

        [LegacyDllMethod(CallingConvention = CallingConvention.StdCall)]
        string TestPWideCharHandling(string AParam);

        // These procedures are expected to increment their parameters by 1:

        [LegacyDllMethod(CallingConvention = CallingConvention.StdCall)]
        void TestVarParamHandling(ref UInt32 AParam);

        [LegacyDllMethod(CallingConvention = CallingConvention.StdCall)]
        void TestMultipleVarParamsHandling(ref UInt32 AParam1, ref UInt32 AParam2);

        /// <summary>
        /// This Method exists to test how the WrapperClient handles a non existent library.
        /// </summary>
        [LegacyDllMethod(CallingConvention = CallingConvention.StdCall)]
        void TestNonExistingLibrary();

        /// <summary>
        /// This Method exists to test how the WrapperClient handles a non existent function.
        /// </summary>
        [LegacyDllMethod(CallingConvention = CallingConvention.StdCall)]
        void TestNonExistingFunction();
    }

    public interface ITestDllWithoutAttribute : IDisposable
    {
        [LegacyDllMethod]
        void MethodWithAttribute();
    }

    [LegacyDllImport("User32.dll")]
    public interface ITestDllWithAttribute : IDisposable
    {
        void MethodWithoutAttribute();
    }

    [LegacyDllImport("User32.dll")]
    interface ITestDllWithProtectedInterface : IDisposable
    {
        void MethodWithoutAttribute();
    }
}
