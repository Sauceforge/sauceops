﻿using OpenQA.Selenium;
using SauceOps.Core.Util;
using System.Collections.Generic;

namespace SauceOps.Core.Options.Base
{
    internal abstract class BaseOptions {
        protected DriverOptions Opts = null;
        protected Dictionary<string, object> SauceOptions = null;
        private readonly string _testName;

        protected BaseOptions(string testName) {
            _testName = testName;
            SauceOptions = new Dictionary<string, object>
            {
                { SauceOpsConstants.SAUCE_USERNAME_CAPABILITY, Enviro.SauceUserName },
                { SauceOpsConstants.SAUCE_ACCESSKEY_CAPABILITY, Enviro.SauceApiKey },
                { SauceOpsConstants.SELENIUM_VERSION_CAPABILITY, SauceOpsConstants.LATEST_SELENIUM_VERSION },
                //This sets the Session column
                { SauceOpsConstants.SAUCE_SESSIONNAME_CAPABILITY, _testName },
                //This sets the Build column
                { SauceOpsConstants.SAUCE_BUILDNAME_CAPABILITY, Enviro.BuildName },
                //Improve performance on SauceLabs
                { SauceOpsConstants.SAUCE_VUOP_CAPABILITY, false }
            };
            //SauceOptions.Add(Constants.VISIBILITY_KEY, Constants.VISIBILITY_TEAM);
        }

        protected void AddSauceLabsOptions(string nativeApp) {
            if (nativeApp != null) {
                SauceOptions.Add(SauceOpsConstants.SAUCE_NATIVE_APP_CAPABILITY, nativeApp);
            }
        }

        public DriverOptions GetOpts() {
            return Opts;
        }

        //protected static string GetBrowser(string nativeApp) {
        //    return nativeApp != null ? "" : SauceryConstants.SAFARI_BROWSER;
        //}
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */