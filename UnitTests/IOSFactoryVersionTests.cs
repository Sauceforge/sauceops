﻿using NUnit.Framework;
using SauceOps.Core.OnDemand;
using SauceOps.Core.Options;
using Shouldly;
using System.Collections;

namespace UnitTests
{
    [TestFixture]
    public class IOSFactoryVersionTests
    {
        [Test, TestCaseSource(typeof(IOSDataClass), "SupportedTestCases")]
        public void IsSupportedPlatformTest(SaucePlatform saucePlatform)
        {
            var factory = new OptionFactory(saucePlatform);
            var result = factory.IsSupportedPlatform();
            result.ShouldBeTrue();
        }

        //[Test, TestCaseSource(typeof(AndroidDataClass), "NotSupportedTestCases")]
        //public void IsNotSupportedPlatformTest(SaucePlatform saucePlatform)
        //{
        //    var factory = new OptionFactory(saucePlatform);
        //    var result = factory.IsSupportedPlatform();
        //    result.ShouldBeFalse();
        //}

        [Test, TestCaseSource(typeof(IOSDataClass), "SupportedTestCases")]
        public void AppiumIOSOptionTest(SaucePlatform saucePlatform)
        {
            var factory = new OptionFactory(saucePlatform);
            var opts = factory.CreateOptions("AppiumIOSOptionTest");
            opts.ShouldNotBeNull();
        }
    }
    public class IOSDataClass
    {
        public static IEnumerable SupportedTestCases
        {
            get
            {
                yield return new SaucePlatform("", "", "latest", "", "13.0", "", "", "iPhone XS Max Simulator", "portrait");
            }
        }

        //public static IEnumerable NotSupportedTestCases
        //{
        //    get
        //    {
        //        yield return new TestCaseData(new SaucePlatform("android", "android", "android", "10.0", "Google Pixel 3 GoogleAPI Emulator", "10.0.", "", "android", "landscape"));
        //    }
        //}
    }
}
