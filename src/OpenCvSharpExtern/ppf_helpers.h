#pragma once
// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
CVAPI(ExceptionStatus) ppf_match_3d_computeNormalsPC3d(const cv::Mat& PC, CV_OUT cv::Mat& PCNormals, const int NumNeighbors, const bool FlipViewpoint, const cv::Vec3f& viewpoint,
    int* returnValue)
{
    BEGIN_WRAP
        * returnValue = cv::ppf_match_3d::computeNormalsPC3d(PC, PCNormals, NumNeighbors, FlipViewpoint, viewpoint);
    END_WRAP
}
