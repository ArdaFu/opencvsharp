using System;
using OpenCvSharp.Flann;
using OpenCvSharp.Internal;

namespace OpenCvSharp.PpfMatch3d
{
    public enum IcpSamplingType
    {
        Uniform = 0,
        Gelfand = 1
    };

    public class ICP : DisposableCvObject
    {

        public ICP(int iterations, float tolerance = 0.05f, float rejectionScale = 2.5f, int numLevels = 6,
            IcpSamplingType sampleType = IcpSamplingType.Uniform, int numMaxCorr = 1)
        {
            NativeMethods.HandleException(
                NativeMethods.ppf_match_3d_ICP_new(iterations, tolerance, rejectionScale, numLevels, (int) sampleType,
                    numMaxCorr, out ptr));
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create Index");
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.ppf_match_3d_ICP_delete(ptr));
            base.DisposeUnmanaged();
        }

        public int RegisterModelToScene(Mat srcPc, Mat dstPc, out double residual, out Mat pose)
        {
            if (srcPc == null)
                throw new ArgumentNullException(nameof(srcPc));
            if (dstPc == null)
                throw new ArgumentNullException(nameof(dstPc));
            residual = 0;
            var returnValue = 0;

            pose = new Mat<double>(4, 4);
            NativeMethods.ppf_match_3d_ICP_registerModelToScene(ptr,
                srcPc.CvPtr, dstPc.CvPtr, ref residual, pose.Data, ref returnValue);

            GC.KeepAlive(this);
            GC.KeepAlive(srcPc);
            GC.KeepAlive(dstPc);
            return returnValue;
        }
    }

    public static class PpfMatch3d
    {
        public static int ComputeNormalsPC3d(Mat pc, out Mat pcNormals, int numNeighbors, bool flipViewpoint,
            Vec3f viewpoint)
        {
            pcNormals = new Mat(pc.Rows, pc.Cols + 3, pc.Type());
            var returnValue = 0;
            NativeMethods.HandleException(
                NativeMethods.ppf_match_3d_computeNormalsPC3d(pc.CvPtr, pcNormals.CvPtr, numNeighbors, flipViewpoint,
                    viewpoint, ref returnValue));
            GC.KeepAlive(pc);
            GC.KeepAlive(pcNormals);
            return returnValue;
        }
    }
}