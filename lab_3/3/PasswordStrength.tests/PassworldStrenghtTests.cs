using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;

namespace PasswordStrengthTests
{
    [TestClass]
    public class GetPasswordTests
    {
        [TestMethod]
        public void ParseArgsTests_CorrectInput_ReturnTrue()
        {
            // Act
            string[] args = new string[] { "passmydog" };
            string password = "";

            bool result = Program.ParseArgs(args, ref password);

            // Assert
            Assert.IsTrue(result);
        }

    }
    [TestClass]
    public class CheckLetterAndCheckDigitTests
    {
        [TestMethod]
        public void CheckDigit_WithNumber_ShouldReturnTrue()
        {
            char number = '1';
            bool res = PasswordStrength.Program.CheckDigit(number);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void CheckLowerCase_WithLowerCaseLetter_ShouldReturnTrue()
        {
            char letter = 'a';
            bool res = PasswordStrength.Program.CheckLowerCase(letter);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void CheckUpperCase_WithUpperCaseLetter_ShouldReturnTrue()
        {
            char letter = 'A';
            bool res = PasswordStrength.Program.CheckUpperCase(letter);
            Assert.AreEqual(true, res);
        }
    }
    [TestClass]
    public class CheckPasswordTests
    {
        [TestMethod]
        public void CheckPassword_WithEmptyPassword_ShouldReturnFalse()
        {
            string emptyString = "";
            bool result = PasswordStrength.Program.CheckPassword(emptyString);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckPassword_WithNotDigitOrNotLetterPassword_ShouldReturnTrue()
        {
            string wrongPassword = "tg_34b";
            bool result = PasswordStrength.Program.CheckPassword(wrongPassword);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckPassword_WithRightPassword_ShouldReturnTrue()
        {
            string rightPassword = "Qwert1a";
            bool result = PasswordStrength.Program.CheckPassword(rightPassword);
            Assert.AreEqual(true, result);
        }
    }
    [TestClass]
    public class CheckDuplicatesTests
    {
        
        [TestMethod]
        public void CheckDupticates_WithStringWithoutDuplicates_ShouldReturnZero()
        {
            string str = "qwer1";
            int resultNumber = PasswordStrength.Program.CheckDuplicates(str);
            int expectedNumber = 0;
            Assert.AreEqual(expectedNumber, resultNumber);
        }
    }
    [TestClass]
    public class GetStrengthTests
    {
        [TestMethod]
        public void GetInitialStrength_WithPasswordLength()
        {
            int passwordLength = 4;
            int resultStrength = PasswordStrength.Program.GetInitialStrength(passwordLength);
            int expectedStrength = 16;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void GetStrengthForCaseLetters_WithNumberOfUpperLetters()
        {
            int passwordLength = 4;
            int numberOfUpperCase = 2;
            int resultStrength = PasswordStrength.Program.GetStrengthForCaseLetters(passwordLength, numberOfUpperCase);
            int expectedStrength = 4;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void GetStrengthForCaseLetters_WithNumberOfLowerLetters()
        {
            int passwordLength = 4;
            int numberOfLowerCase = 2;
            int resultStrength = PasswordStrength.Program.GetStrengthForCaseLetters(passwordLength, numberOfLowerCase);
            int expectedStrength = 4;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void GetStrengthForDigits_WithDigits()
        {
            int numberOfDigits = 4;
            int resultStrength = PasswordStrength.Program.GetInitialStrength(numberOfDigits);
            int expectedStrength = 16;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void GetStrengthForPasswordWithOnlyDigitsOrLetters_WithNoDigits()
        {
            int passwordLength = 4;
            int numberOfDigits = 0;
            int numberOfUpperCase = 2;
            int numberOfLowerCase = 2;
            int resultStrength = PasswordStrength.Program.GetStrengthForPasswordWithOnlyDigitsOrLetters(passwordLength, numberOfLowerCase,
                numberOfUpperCase, numberOfDigits);
            int expectedStrength = 4;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
    }
    [TestClass]
    public class GetPasswordStrengthTests
    {
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithOnlyNumbers()
        {
            string password = "123";
            int expectedStrength = 21;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithOnlyLowerCase()
        {
            string password = "qwer";
            int expectedStrength = 12;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithOnlyUpperCase()
        {
            string password = "QWER";
            int expectedStrength = 12;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithSomeUpperCase()
        {
            string password = "qWEr";
            int expectedStrength = 20;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithNumbersAndLowerCaseLetters()
        {
            string password = "qw12";
            int expectedStrength = 28;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithNumbersAndUpperCaseLetters()
        {
            string password = "QW12";
            int expectedStrength = 28;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        
        [TestMethod]
        public void GetPasswordStrength_WithStrongPassword()
        {
            string password = "qw12ErT";
            int expectedStrength = 54;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
    }
}