﻿using System.Drawing;
using System.Windows.Forms;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Tests.WinForms;
using ApprovalTests.WinForms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Button = System.Windows.Forms.Button;

namespace ApprovalTests.MachineSpecific.Tests.WinForms
{
    [TestClass]
    [UseReporter(typeof(AllFailingTestsClipboardReporter), typeof(ImageReporter))]
    public class ApprovalsTest
    {
        [TestMethod]
        public void TestControlApproved()
        {
            ApprovalResults.UniqueForMachineName();
            WinFormsApprovals.Verify(new Button { BackColor = Color.LightBlue, Text = "Help" });
        }

        [TestMethod]
        public void TestFormApproval()
        {
            ApprovalResults.UniqueForMachineName();
            WinFormsApprovals.Verify(new Form());
        }

        [TestMethod]
				[UseReporter(typeof(TortoiseDiffReporter))]
				public void VerifyCompleteFormTest()
        {
            WinFormsApprovals.VerifyEventsFor(new DemoForm());
        }
    }
}