﻿using RestSharp;
using SauceOps.Core.RestAPI.TestStatus.Base;
using SauceOps.Core.Util;

namespace SauceOps.Core.RestAPI.TestStatus {
    public class SauceLabsStatusNotifier : StatusNotifier {
        public override void NotifyStatus(string jobId, bool isPassed) {
            var request = BuildRequest(string.Format(SauceryConstants.JOB_REQUEST, UserName, jobId), Method.PUT);
            request.AddParameter("Application/Json", "{\"passed\":" + "\"" + (isPassed ? "true" : "false") + "\"}", ParameterType.RequestBody);
            EnsureExecution(request);
            //Client.Execute(request);


        }
    }
}
/*
 * Copyright Andrew Gray, Full Circle Solutions
 * Date: 10th August 2014
 * 
 */