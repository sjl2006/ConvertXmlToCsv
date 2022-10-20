using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConvertXmlToCsvApp;

namespace XmlToCsvTest
{
    [TestClass]
    public class Validation_UnitTest
    {
        private readonly Validation validator = new ConvertXmlToCsvApp.Validation();
        private readonly ConvertXmlToCsv converter = new ConvertXmlToCsvApp.ConvertXmlToCsv();

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_MissingRow100()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase1_MissingRow100.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_MissingRow900()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase2_MissingRow900.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_MissingRow200()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase3_MissingRow200.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_MissingRow300()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase4_MissingRow300.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_RedundantRow100()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase5_RedundantRow100.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_RedundantRow900()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase6_RedundantRow900.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_WrongRow200()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase7_WrongRow200.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_WrongRow300()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase8_WrongRow300.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_WrongRowOrder200_300()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase9_WrongRowOrder200_300.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_InvalidData()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase10_InvalidData.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == false);
        }

        [TestMethod]
        public void TestcheckIfCSVIntervalDataValid_ValidData()
        {
            Boolean retCode;
            string InputXmlPath = @"../../../TestData/TestCase11_ValidData.xml";

            string CSVIntervalData = converter.getCSVIntervalDataFromXml(InputXmlPath);

            retCode = validator.checkIfCSVIntervalDataValid(CSVIntervalData);
            Assert.IsTrue(retCode == true);
        }
    }
}
