﻿using System;
using SauceOps.Core.Options.Base;
using SauceOps.Core.OnDemand;
using SauceOps.Core.Util;
using OpenQA.Selenium.Safari;

namespace SauceOps.Core.Options.ConcreteProducts {
    internal class AppiumIOSOptions : BaseOptions {
        public AppiumIOSOptions(SaucePlatform platform, string testName) : base(testName) {
            Console.WriteLine(SauceOpsConstants.SETTING_UP, testName, SauceOpsConstants.IOS_ON_APPIUM);
            AddSauceLabsOptions(Enviro.SauceNativeApp);

            DebugMessages.PrintiOSOptionValues(platform);

            Console.WriteLine("Creating iOS Options");
            Opts = new SafariOptions()
            {
                BrowserVersion = platform.BrowserVersion,
                PlatformName = "iOS"
            };
            SauceOptions.Add(SauceOpsConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.Device);
            SauceOptions.Add(SauceOpsConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, platform.SanitisedLongVersion());
            SauceOptions.Add(SauceOpsConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation);
            
            Opts.AddAdditionalCapability(SauceOpsConstants.SAUCE_OPTIONS_CAPABILITY, SauceOptions);
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */