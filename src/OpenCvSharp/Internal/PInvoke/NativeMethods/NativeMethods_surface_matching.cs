using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using OpenCvSharp.Flann;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal
{
    static partial class NativeMethods
    {
        #region ICP

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ppf_match_3d_ICP_new(
            [In] int iterations, [In] float tolerance, [In] float rejectionScale, [In] int numLevels, [In] int sampleType, [In] int numMaxCorr,
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ppf_match_3d_ICP_delete(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ppf_match_3d_ICP_registerModelToScene(
            IntPtr obj, IntPtr srcPC, IntPtr dstPC, ref double residual, IntPtr pose, ref int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ppf_match_3d_computeNormalsPC3d(IntPtr PC, IntPtr PCNormals,
            [In] int NumNeighbors, [In] bool FlipViewpoint, [In]Vec3f viewpoint,
            ref int returnValue);

        #endregion


    }
}