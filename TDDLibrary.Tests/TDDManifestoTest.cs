using NUnit.Framework;

namespace TDDLibrary.Tests
{
    [TestFixture]
    public class TDDManifestoTest
    {
        private TDDManifesto lib;

        [SetUp]
        public void Setup()
        {
            lib = new();
        }

        [Test]
        public void FizzBuzz_InputIs1_Return1AsString()
        {
            //arrange
            int number = 1;

            //ACT
            string response = lib.fizzBuzz(number);

            //Assert
            Assert.AreEqual("1", response);
        }


        [Test]
        public void FizzBuzz_InputIs9_ReturnFizz()
        {
            //arrange
            int number = 9;

            //ACT
            string response = lib.fizzBuzz(number);

            //Assert
            Assert.AreEqual("Fizz", response);
        }

        [Test]
        public void FizzBuzz_InputIs15_ReturnFizzBuzz()
        {
            //arrange
            int number = 15;

            //ACT
            string response = lib.fizzBuzz(number);

            //Assert
            Assert.AreEqual("FizzBuzz", response);
        }


        [Test]
        public void StringCalculator_InputBlank_Returns0()
        {
            //Arrange
            string number = "";
            //Act
            int result = lib.StringCalculator(number);
            //Assert
            Assert.AreEqual(0, result);
        }
        [Test]
        public void StringCalculator_Input1_Returns1()
        {
            //Arrange
            string number = "1";
            //Act
            int result = lib.StringCalculator(number);
            //Assert
            Assert.AreEqual(1, result);
        }
        [Test]
        public void StringCalculator_Input123_Returns6()
        {
            //Arrange
            string number = "1,2,3";
            //Act
            int result = lib.StringCalculator(number);
            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void StringCalculator_Input123WithSpaces_Returns6()
        {
            //Arrange
            string number = "1\n2\n3";
            //Act
            int result = lib.StringCalculator(number);
            //Assert
            Assert.AreEqual(6, result);
        }
        [Test]
        public void StringCalculator_Input123WithSpacesAndCommas_Returns6()
        {
            //Arrange
            string number = "1,2\n3";
            //Act
            int result = lib.StringCalculator(number);
            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void StringCalculator_InputWithCommasAtEnd_ReturnsNegative1()
        {
            //Arrange
            string number = "1,2\n3,";
            //Act
            int result = lib.StringCalculator(number);
            //Assert
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void StringCalculator_Input123WithSepDeliminator_Returns6()
        {
            //Arrange
            string number = "//Sep\n1Sep2Sep3";
            //Act
            int result = lib.StringCalculator(number);
            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void PasswordValidator_InputLessThan8_ReturnsError()
        {
            string password = "A234567";

            ValidationResult result = lib.PasswordInputFieldValidation(password);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Password must be at least 8 characters", result.Error);
        }
        [Test]
        public void PasswordValidator_InputDoesContain2Numbers_ReturnsError()
        {
            string password = "ABCDEFGH";

            ValidationResult result = lib.PasswordInputFieldValidation(password);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("The password must contain at least 2 numbers", result.Error);
        }

        [Test]
        public void PasswordValidator_InputDoesContain2NumbersAndIsShort_ReturnsError()
        {
            string password = "ABCDEFG";

            ValidationResult result = lib.PasswordInputFieldValidation(password);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Password must be at least 8 characters\nThe password must contain at least 2 numbers", result.Error);
        }
        [Test]
        public void PasswordValidator_InputDoesNotContainCapitalLetter_ReturnsError()
        {
            string password = "abcdegh75";

            ValidationResult result = lib.PasswordInputFieldValidation(password);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("password must contain at least one capital letter", result.Error);
        }
        [Test]
        public void PasswordValidator_InputDoesNotContainSpecialLetter_ReturnsError()
        {
            string password = "abcde&Gh75";

            ValidationResult result = lib.PasswordInputFieldValidation(password);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("password must contain at least one special character", result.Error);
        }

        [Test]
        public void CitySearch_InputHasLessThan2Characters_ReturnsEmptyResult()
        {
            string search = "y";

            string[] citiesArray = lib.CitySearch(search);

            Assert.IsEmpty(citiesArray);
        }

        [Test]
        public void CitySearch_InputVA_ReturnsValenciaVancouver()
        {
            string search = "Va";

            string[] citiesArray = lib.CitySearch(search);
            string[] expected = new string[] { "Valencia", "Vancouver" };

            Assert.AreEqual(expected, citiesArray);
        }


        [Test]
        public void CitySearch_InputInPartOfName_ReturnsCity()
        {
            string search = "ape";

            string[] citiesArray = lib.CitySearch(search);
            string[] expected = new string[] { "Budapest" };

            Assert.AreEqual(expected, citiesArray);
        }

        [Test]
        public void CitySearch_InputIsasterisk_ReturnsAllCities()
        {
            string search = "*";

            string[] citiesArray = lib.CitySearch(search);
            string[] expected = new string[] { "Paris", "Budapest", "Skopje",
                "Rotterdam", "Valencia", "Vancouver", "Amsterdam", "Vienna", "Sydney",
                "New York City", "London", "Bangkok", "Hong Kong", "Dubai", "Rome", "Istanbul" };

            Assert.AreEqual(expected, citiesArray);
        }

        [Test]
        public void PointOfSale_Input12345_Returns725()
        {
            string barCode = "12345";

            string price = lib.PointOfSale(barCode);

            Assert.AreEqual("$7.25", price);
        }

        [Test]
        //2.Barcode ‘23456’ should display price ‘$12.50’
        public void PointOfSale_Input23456_Returns1250()
        {
            string barCode = "23456";

            string price = lib.PointOfSale(barCode);

            Assert.AreEqual("$12.50", price);
        }

        [Test]
        //3.Barcode ‘99999’ should display ‘Error: barcode not found’
        public void PointOfSale_Input99999_ReturnsError()
        {
            string barCode = "99999";

            string price = lib.PointOfSale(barCode);

            Assert.AreEqual("Error: barcode not found", price);
        }


        [Test]
        //4.Empty barcode should display ‘Error: empty barcode’
        public void PointOfSale_InputEmpty_ReturnsError()
        {
            string barCode = "";

            string price = lib.PointOfSale(barCode);

            Assert.AreEqual("Error: empty barcode", price);
        }
    }
}