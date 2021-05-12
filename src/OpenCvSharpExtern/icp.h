#pragma once
// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ppf_match_3d_ICP_new(
    const int iterations, const float tolerence, const float rejectionScale, const int numLevels, const int sampleType, const int numMaxCorr, cv::ppf_match_3d::ICP** returnValue)
{
    BEGIN_WRAP
        * returnValue = new cv::ppf_match_3d::ICP(iterations, tolerence, rejectionScale, numLevels, sampleType, numMaxCorr);
    END_WRAP
}

CVAPI(ExceptionStatus) ppf_match_3d_ICP_delete(cv::ppf_match_3d::ICP* obj)
{
    BEGIN_WRAP
        delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ppf_match_3d_ICP_registerModelToScene(cv::ppf_match_3d::ICP* obj,
    const cv::Mat& srcPC, const cv::Mat& dstPC, CV_OUT double& residual, CV_OUT cv::Matx44d& pose, int* returnValue)
{
    BEGIN_WRAP
        * returnValue = obj->registerModelToScene(srcPC, dstPC, residual, pose);
    END_WRAP
}