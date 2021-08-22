using System;
using DealOrNoDeal.ErrorMessages;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.BriefcaseTests
{
    [TestClass]
    public class TestBriefcaseConstructor
    {
        [TestMethod]
        public void ShouldNotAllowBriefcaseIdOneLessThanZero()
        {
            Model.Briefcase briefcase = null;
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcase = new Model.Briefcase(-1, 100);
            });

            Assert.IsNull(briefcase);
            Assert.AreEqual(ErrorMessages.BriefcaseErrorMessages.BriefCaseIdCannotBeLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotAllowBriefcaseIdWellLessThanZero()
        {
            Model.Briefcase briefcase = null;
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcase = new Model.Briefcase(-100, 100);
            });

            Assert.IsNull(briefcase);
            Assert.AreEqual(ErrorMessages.BriefcaseErrorMessages.BriefCaseIdCannotBeLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotAllowDollarAmountOneLessThanZero()
        {
            Model.Briefcase briefcase = null;
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcase = new Model.Briefcase(100, -1);
            });

            Assert.IsNull(briefcase);
            Assert.AreEqual(ErrorMessages.BriefcaseErrorMessages.DollarAmountCannotBeLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotAllowDollarAmountWellLessThanZero()
        {
            Model.Briefcase briefcase = null;
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcase = new Model.Briefcase(100, -100);
            });

            Assert.IsNull(briefcase);
            Assert.AreEqual(ErrorMessages.BriefcaseErrorMessages.DollarAmountCannotBeLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldAllowValidValuesAtMinimum()
        {
            var briefcase = new Briefcase(0, 0);

            Assert.AreEqual(0, briefcase.BriefcaseId);
            Assert.AreEqual(0, briefcase.DollarAmount);
        }

        [TestMethod]
        public void ShouldAllowValidValuesOneAboveMinimum()
        {
            var briefcase = new Briefcase(1, 1);

            Assert.AreEqual(1, briefcase.BriefcaseId);
            Assert.AreEqual(1, briefcase.DollarAmount);
        }

        [TestMethod]
        public void ShouldAllowValidValuesWellAboveMinimum()
        {
            var briefcase = new Briefcase(100, 100);

            Assert.AreEqual(100, briefcase.BriefcaseId);
            Assert.AreEqual(100, briefcase.DollarAmount);
        }

        [TestMethod]
        public void ShouldNotSetBriefcaseIdToOneBelowZero()
        {
            var briefcase = new Briefcase(100, 100);

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcase.BriefcaseId = -1;
            });

            Assert.AreEqual(BriefcaseErrorMessages.CannotSetBriefcaseIdToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBriefcaseIdToWellBelowZero()
        {
            var briefcase = new Briefcase(100, 100);

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcase.BriefcaseId = -100;
            });

            Assert.AreEqual(BriefcaseErrorMessages.CannotSetBriefcaseIdToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetDollarAmountToOneBelowZero()
        {
            var briefcase = new Briefcase(100, 100);

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcase.DollarAmount = -1;
            });

            Assert.AreEqual(BriefcaseErrorMessages.CannotSetDollarAmountToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetDollarAmountToWellBelowZero()
        {
            var briefcase = new Briefcase(100, 100);

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcase.DollarAmount = -100;
            });

            Assert.AreEqual(BriefcaseErrorMessages.CannotSetDollarAmountToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldSetBriefcaseIdAtMinimum()
        {
            var briefcase = new Briefcase(100, 100);
            Assert.AreEqual(100, briefcase.BriefcaseId);
            briefcase.BriefcaseId = 0;
            Assert.AreEqual(0, briefcase.BriefcaseId);
        }

        [TestMethod]
        public void ShouldSetBriefcaseIdOneAboveMinimum()
        {
            var briefcase = new Briefcase(100, 100);
            Assert.AreEqual(100, briefcase.BriefcaseId);
            briefcase.BriefcaseId = 1;
            Assert.AreEqual(1, briefcase.BriefcaseId);
        }

        [TestMethod] public void ShouldSetBriefcaseIdWellAboveMinimum()
        {
            var briefcase = new Briefcase(100, 100);
            Assert.AreEqual(100, briefcase.BriefcaseId);
            briefcase.BriefcaseId = 1000;
            Assert.AreEqual(1000, briefcase.BriefcaseId);
        }

        [TestMethod]
        public void ShouldSetDollarAmountAtMinimum()
        {
            var briefcase = new Briefcase(100, 100);
            Assert.AreEqual(100, briefcase.DollarAmount);
            briefcase.DollarAmount = 0;
            Assert.AreEqual(0, briefcase.DollarAmount);
        }

        [TestMethod]
        public void ShouldSetDollarAmountOneAboveMinimum()
        {
            var briefcase = new Briefcase(100, 100);
            Assert.AreEqual(100, briefcase.DollarAmount);
            briefcase.DollarAmount = 1;
            Assert.AreEqual(1, briefcase.DollarAmount);
        }

        [TestMethod]
        public void ShouldSetDollarAmountWellAboveMinimum()
        {
            var briefcase = new Briefcase(100, 100);
            Assert.AreEqual(100, briefcase.DollarAmount);
            briefcase.DollarAmount = 1000;
            Assert.AreEqual(1000, briefcase.DollarAmount);
        }
    }

}
