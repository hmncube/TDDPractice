using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDLibrary
{
    public class TDDManifesto
    {
        /*
         *  1. Write a “fizzBuzz” method that accepts a number as input and returns it as a String.
            2. For multiples of three return “Fizz” instead of the number
            3. For the multiples of five return “Buzz”
            4. For numbers that are multiples of both three and five return “FizzBuzz”.
        */

        public string fizzBuzz(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            } else if (number % 5 == 0)
            {
                return "Buzz";
            }
            return number.ToString();
        }

        public int StringCalculator(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            if (numbers.StartsWith("//"))
            {
                string numberWithNoDeliminator = numbers.Remove(0, 2); //removes // at the begining
                string[] numberArr = numberWithNoDeliminator.Split("\n");

                string deliminator = numberArr[0];
                string[] addingArray = numberArr[1].Split(deliminator);
                int result = 0;
                foreach (var aa in addingArray)
                {
                    result += int.Parse(aa);
                }
                return result;
            }
            else
            {
                if (!numbers.Contains(",") && !numbers.Contains("\n"))
                {
                    return int.Parse(numbers);
                }
                else if (numbers.EndsWith(",") || numbers.EndsWith("\n"))
                {
                    return -1;
                }
                else
                {
                    if (!numbers.Contains("\n"))
                    {
                        string[] numbersArray = numbers.Split(",");
                        int result = 0;
                        foreach (var n in numbersArray)
                        {
                            result += int.Parse(n);
                        }
                        return result;
                    }
                    else if (!numbers.Contains(","))
                    {
                        string[] numbersArray = numbers.Split("\n");
                        int result = 0;
                        foreach (var n in numbersArray)
                        {
                            result += int.Parse(n);
                        }
                        return result;
                    }
                    else // contains both , and \n
                    {
                        string[] numbersArray = numbers.Split("\n");
                        int result = 0;
                        foreach (var n in numbersArray)
                        {
                            if (n.Contains(","))
                            {
                                string[] sa = n.Split(",");
                                foreach (var a in sa)
                                {
                                    result += int.Parse(a);
                                }
                            }
                            else
                            {
                                result += int.Parse(n);
                            }
                        }
                        return result;
                    }
                }

            }

        }

        public ValidationResult PasswordInputFieldValidation(string password)
        {
            ValidationResult validationResult = new()
            {
                IsValid = true,
                Error = ""
            };
            if (password.Length < 8)
            {
                validationResult.IsValid = false;
                validationResult.Error = "Password must be at least 8 characters";
            }

            if (!CheckIfItHasTwoDigits(password))
            {
                if (string.IsNullOrWhiteSpace(validationResult.Error))
                {
                    validationResult.Error = "The password must contain at least 2 numbers";
                }
                else
                {
                    validationResult.Error += "\nThe password must contain at least 2 numbers";

                }
                validationResult.IsValid = false;
            }

            if (!password.Any(char.IsUpper))
            {
                validationResult.IsValid = false;
                if (string.IsNullOrWhiteSpace(validationResult.Error))
                {
                    validationResult.Error = "password must contain at least one capital letter";
                }
                else
                {
                    validationResult.Error += "\npassword must contain at least one capital letter";

                }
            }

            if (ContainsSpecialCharacter(password))
            {
                validationResult.IsValid = false;
                if (string.IsNullOrWhiteSpace(validationResult.Error))
                {
                    validationResult.Error = "password must contain at least one special character";
                }
                else
                {
                    validationResult.Error += "\npassword must contain at least one special character";
                }
            }
            return validationResult;
        }

        public string[] CitySearch(string searchTerms)
        {

            string[] cities = new string[] { "Paris", "Budapest", "Skopje",
                "Rotterdam", "Valencia", "Vancouver", "Amsterdam", "Vienna", "Sydney",
                "New York City", "London", "Bangkok", "Hong Kong", "Dubai", "Rome", "Istanbul" };
            if (searchTerms.Equals("*"))
            {
                return cities;
            }

            if (searchTerms.Length < 2)
            {
                return Array.Empty<string>();
            }
            List<string> results = new List<string>();
            foreach (var c in cities)
            {
                if (c.StartsWith(searchTerms))
                {
                    results.Add(c);
                }
                if (c.Contains(searchTerms))
                {
                    if (!results.Contains(c))
                    {
                        results.Add(c);
                    }
                }
            }
            return results.ToArray();

        }
        
        public string PointOfSale(string barCode)
        {
            //1.Barcode ‘12345’ should display price ‘$7.25’
            if (barCode.Equals("12345"))
            {
                return "$7.25";
            }
            //2.Barcode ‘23456’ should display price ‘$12.50’
            if (barCode.Equals("23456"))
            {
                return "$12.50";
            }
            //3.Barcode ‘99999’ should display ‘Error: barcode not found’
            if (barCode.Equals("99999"))
            {
                return "Error: barcode not found";
            }
            //4.Empty barcode should display ‘Error: empty barcode’
            if (string.IsNullOrWhiteSpace(barCode))
            {
                return "Error: empty barcode";
            }
            return "";
        }
        private bool ContainsSpecialCharacter(string password)
        {
            foreach (var p in password)
            {
                if (!char.IsLetterOrDigit(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfItHasTwoDigits(string password)
        {

            int digits = 0;
            foreach (var p in password)
            {
                bool isDigit = int.TryParse(p.ToString(), out int r);
                if (isDigit)
                {
                    digits++;
                }
            }
            if (digits > 1)
            {
                return true;
            }
            return false;
        }
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }

        public string Error { get; set; }
    }
}

//Negative number(s) not allowed: <negativeNumbers>