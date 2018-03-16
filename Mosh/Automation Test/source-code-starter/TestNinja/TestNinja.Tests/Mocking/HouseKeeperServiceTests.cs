using Moq;
using NUnit.Framework;
/**
* @Project Name: $projectname$ ： HouseKeeperServiceTests
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Tests.Mocking
* @Creation Time:  3/16/2018 12:57:00 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/16/2018 12:57:00 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class HouseKeeperServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IStatementGenerator> _statementGenerator;
        private HousekeeperService _service;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _xtraMessageBox;
        private Housekeeper _housekeeper;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private string _filename;

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper()
            {
                Email = "a",
                FullName = "b",
                Oid = 1,
                StatementEmailBody = "c"
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>()
            {
                _housekeeper
            }.AsQueryable);

            _filename = "fileName";
            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator
                .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                .Returns(() => _filename);

            _emailSender = new Mock<IEmailSender>();
            _emailSender.Setup(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            )).Throws<Exception>();


            _xtraMessageBox = new Mock<IXtraMessageBox>();
            _service = new HousekeeperService(
                _unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _xtraMessageBox.Object);
        }
        [Test]
        public void SendStatementEmails_WhenCalled_SaveStatement()
        {
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
                sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementEmails_HouseKeepersEmailIsNullOrWhiteSpace_ShouldNotSaveStatement(string email)
        {
            _housekeeper.Email = email;
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
                sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate), Times.Never);

        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _service.SendStatementEmails(_statementDate);

            VerifyEmailSend();
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementEmails_HouseKeepersEmailIsNullOrWhiteSpaceOrEmpty_ShouldNotSendStatementEmail(
            string statementFileName)
        {
            _filename = statementFileName;
            _service.SendStatementEmails(_statementDate);
            VerifyEmailNotSend();
        }
        [Test]
        public void SendStatementEmails_SendEmailFails_ThrowAnException()
        {
            _service.SendStatementEmails(_statementDate);

            VerifyIsMessageBoxShow();
        }

        private void VerifyIsMessageBoxShow()
        {
            _xtraMessageBox.Verify(xmb => xmb.Show(
                It.IsAny<string>(),
                It.IsAny<string>(),
                MessageBoxButtons.OK
            ));
        }

        private void VerifyEmailNotSend()
        {
            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            ), Times.Never);
        }

        private void VerifyEmailSend()
        {
            _emailSender.Verify(es => es.EmailFile(
                _housekeeper.Email,
                _housekeeper.StatementEmailBody,
                _filename,
                It.IsAny<string>()));
        }
    }
}
