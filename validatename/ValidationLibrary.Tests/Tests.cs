using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValidationLibrary.Tests
{
    [TestFixture]
    public class Tests
    {
        private Type type;
        private Type paramType;
        private string methodName;

        [SetUp]
        public void Initial()
        {
            type = Type.GetType("ValidationLibrary.StringOperation, ValidationLibrary", false, true);
            paramType = typeof(string);
            methodName = "GetValidName";
        }

        [Test]
        public void GetValidNameMethodWithRightSignatureAndParameterIsExist()
        {
            //arrange
            string parameter = "nameToValidate";

            //act
            var actualMethod = GetMethod(methodName);

            var actualParameter = actualMethod.GetParameters().FirstOrDefault();
            if (actualParameter is null)
            {
                Assert.Fail("GetValidName method doesn't has any parameter");
            }
            if (actualParameter.Name != parameter)
            {
                Assert.Fail("GetValidName method doesn't has parameter of  'nameToValidate' name ");
            }
            if (actualParameter.ParameterType != paramType)
            {
                Assert.Fail("GetValidName method doesn't has parameter of string type ");
            }
        }

        #region Invoke

        [TestCase("hello world 2020year ^rt", 19)]
        [TestCase("<(￣︶￣)> ＼(＾▽＾)／ (o_O)", 2)]
        [TestCase("Dmy$tro   /Ponasenkov", 17)]
        public void GetValidNameWithInputStringReturnStringOfCorrectLength(string input, int expectedLength)
        {
            //act
            var actualMethod = GetMethod(methodName);
            var actualLength = ((string)actualMethod.Invoke(type, new object[] { input })).Length;

            //assert
            Assert.AreEqual(expectedLength, actualLength
                , message: "GetValidName return string of incorrect length");
        }

        [TestCase("voLodYmyr KlyCHko", "Volodymyr Klychko")]
        [TestCase("marshall mathers", "Marshall Mathers")]
        [TestCase("Nice Person", "Nice Person")]
        [TestCase("NICK COPELAND", "Nick Copeland")]
        public void GetValidNameReturnStringInRightRegister(string input, string expected)
        {
            //
            //act 
            var actualMethod = GetMethod(methodName);
            var actual = actualMethod.Invoke(type, new object[] { input });

            //assert
            Assert.AreEqual(expected, actual
                , message: "Case sensitivity logic in GetValidName method works incorrect");

        }

        [TestCase("Jam&es Ac575aster", "James Acaster")]
        [TestCase("(=^･ω･^=) Barnes", "Barnes")]
        [TestCase("Si6-w 123An7ita 67:/ Andersen", "Siw Anita Andersen")]
        public void GetValidNameRemoveAllNonLationSymbols(string input, string expected)
        {
            //
            //act 
            var actualMethod = GetMethod(methodName);
            var actual = actualMethod.Invoke(type, new object[] { input });

            //assert
            Assert.AreEqual(expected, actual
                , message: "GetValidName method doesn't remove non Latin symbols");
        }

        [TestCase("    Carl Bad", "Carl Bad")]
        [TestCase("Rick Flair    ", "Rick Flair")]
        [TestCase("Brock    Dalton", "Brock Dalton")]
        [TestCase("  Hello    World        Man  ", "Hello World Man")]
        public void GetValidNameWithBigWhitespacesReturnFormatedString(string input, string expected)
        {
            //act
            var actualMethod = GetMethod(methodName);
            var actual = actualMethod.Invoke(type, new object[] { input });

            //assert
            Assert.AreEqual(expected, actual
                , message: "GetValid method doesn't remove extra whitespaces ");
        }

        [TestCase("o", "O")]
        [TestCase("R", "R")]
        public void GetValidName(string input, string expected)
        {

            //act
            var actualMethod = GetMethod(methodName);
            var actual = ((string)actualMethod.Invoke(type, new object[] { input }));

            //assert
            Assert.AreEqual(expected, actual
                            , message: "GetValidName doesn't return string less or equal to 50 characters");
        }

        #endregion

        #region ExceptionTests
        [Test]
        public void GetValidNameThrowArgumentExceptionIfNameToValidateIsNull()
        {
            //arrange
            string input = null;

            //act
            var actualMethod = GetMethod(methodName);
            var act = Assert.Catch(() => actualMethod.Invoke(type, new object[] { input })).InnerException;

            if (act.GetType() != typeof(ArgumentException))
            {
                Assert.Fail("GetValidName should throw ArgumentException in case of NameToValidate is null");
            }
        }

        [TestCase("")]
        public void GetValidNameThrowArgumentExceptionIfNameToValidateIsEmptyOrWhiteSpace(string input)
        {
            //act
            var actualMethod = GetMethod(methodName);
            var act = Assert.Catch(() => actualMethod.Invoke(type, new object[] { input })).InnerException;

            //assert
            if (act.GetType() != typeof(ArgumentException))
            {
                Assert.Fail("GetValidName should throw ArgumentException in case of NameToValidate is empty or whitespace ");
            }
        }

        [TestCase("｀、ヽ｀ヽ｀、ヽ(ノ＞＜)ノ ｀、ヽ｀☂ヽ｀、ヽ")]
        [TestCase("888888")]
        [TestCase("?(№№::")]
        public void GetValidNameThrowArgumentExceptionIfReturnStringIsEmpty(string input)
        {
            //act
            var actualMethod = GetMethod(methodName);
            var act = Assert.Catch(() => actualMethod.Invoke(type, new object[] { input })).InnerException;

            //assert
            if (act.GetType() != typeof(ArgumentException))
            {
                Assert.Fail("GetValidName should throw ArgumentException in case of return string is null or empty");
            }
        }

        //This test isn't contained in the student repository
        [TestCaseSource("GetData")]
        public void GetValidNameReturnLimitValueForBigString(string input, string expected, int expectedLength)
        {

            //act
            var actualMethod = GetMethod(methodName);
            var actual = ((string)actualMethod.Invoke(type, new object[] { input }));

            //assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected, actual
                                , message: "GetValidName doesn't return string less or equal to 50 characters");
                Assert.AreEqual(expectedLength, actual.Length
                    , message: "GetValidName doesn't return string less or equal to 50 characters");
            });
        }

        #endregion

        private static IEnumerable<TestCaseData> GetData
        {
            get
            {
                yield return new TestCaseData(new object[] { "Belu54shi ro/se to g+reat-er pro0mine01nce with his supω6porti5ng roles in The Man with One Red Shoe (1985), About Last Night.",
                   "Belushi Rose To Greater Prominence With His Suppor"
                   ,50});
                yield return new TestCaseData(new object[] { "ost front-end% appli8ati*ns need to c-omm,,.cate with a+ s   erver over the HTTP protocol, in order to download or upload"
                    ,"Ost Frontend Appliatins Need To Commcate With A S",49 });

            }
        }
        private MethodInfo GetMethod(string name)
        {
            var actualMethod = type.GetMethod(name);
            if (actualMethod is null)
            {
                Assert.Fail("GetValidName method doesn't exist or it's name is incorrect");
            }
            if (actualMethod.ReturnType != typeof(string))
            {
                Assert.Fail("GetValidName method has incorrect type of return value");
            }
            return actualMethod;
        }
    }
}
