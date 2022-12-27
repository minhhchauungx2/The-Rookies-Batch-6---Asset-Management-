using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using CoreFramework.APICore;
using CoreFramework.Reporter.ExtentMarkup;

namespace CoreFramework.Reporter
{
    internal class HtmlReport
    {
        private static int testCaseIndex;
        private static ExtentReports _report;
        public static ExtentTest extentTestSuite;
        public static ExtentTest extentTestCase;

        public static ExtentReports createReport()
        {
            if (_report == null)
            {
                _report = createInstance();
            }
            return _report;
        } 
        public static ExtentReports createInstance()
        {
            HtmlReportDirectory.InitReportDirection();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(HtmlReportDirectory.REPORT_FILE_PATH);
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;
        }
        public static void flush()
        {
            if(_report != null)
            {
                _report.Flush(); 
            }    
        }   
        public static ExtentTest createTest(string className, string classDescription = "")
        //createTest: tạo ra một suite ở trong html
        {
            if (_report == null)  //kiểm tra xem có report chưa
            {
                _report = createInstance();
            }
            extentTestSuite = _report.CreateTest(className, classDescription);
            return extentTestSuite;
        }
        public static ExtentTest createNode(string className, string testcase, string description = "")
        {
            if (extentTestSuite == null) //kiểm tra xem có test chưa
            {
                extentTestSuite = createTest(className);
            }
            extentTestCase = extentTestSuite.CreateNode(testcase, description);
            return extentTestCase;
        }
        public static ExtentTest GetParent()
        {
            return extentTestSuite;
        }
        public static ExtentTest GetNode()
        {
            return extentTestCase;
        }
        public static ExtentTest GetTest()
        {
            if(GetNode() == null)
            {
                return GetParent();
            }    
            return GetNode();
        }
        public static void Pass(string des)
        {
            GetTest().Pass(des);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des)
        {
            GetTest().Fail(des);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des, string path)
        {
            GetTest().Fail(des).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des, string ex, string path)
        {
            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        //public static void MarkUpHtml()
        //{
        //    var htmlMarkup = HtmlInjection.CreateHtml();
        //    var m = MarkupHelper.CreateLabel(htmlMarkup, ExtentColor.Transparent);
        //    GetTest().Info(m);
        //}
        public static void CreateAPIRequestLog(APIRequest request, APIResponse response)
        {
            GetTest().Info(MarkupHelperPlus.CreateAPIRequestLog(request, response));
        }
    }
}
