using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ModuleOneAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] provinceList = new string[] { "AB", "BC", "ON", "MB", "QC", "SK", "NB", "NS", "PE", "NL", "NW", "YK", "NU" };
            List<string> countryList = BuildCountryList(); // Builds a country list from a CSV stored in project.

            // Build a student.
            Console.Write("Enter student first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter student last name: ");
            string lastName = Console.ReadLine();
            DateTime birthdate = GetBirthday(); // Gets a valid birthday.
            Console.Write("Enter student address line 1: ");
            string addressLine1 = Console.ReadLine();
            Console.Write("Enter student address line 2: ");
            string addressLine2 = Console.ReadLine();
            Console.Write("Enter student city: ");
            string city = Console.ReadLine();
            string province = GetProvince(provinceList); // Gets a valid Canadian province from user.
            string postalCode = GetPostalCode(); // Gets a valid Canadian postal code from user.
            string country = GetCountry(countryList); // Gets a valid country from user.
            Console.WriteLine("First name: {0}\tLast name: {1}\tBirthdate: {2}\tAddress Line 1: {3}\tAddress Line 2: {4}\tCity: {5}\tProvince: {6}\tPostal Code: {7}\t" +
                "Country: {8}", firstName, lastName, birthdate, addressLine1, addressLine2, city, province, postalCode, country);

            // Build a teacher
            Console.Write("Enter teacher first name: ");
            string teacherFirstName = Console.ReadLine();
            Console.Write("Enter teacher last name: ");
            string teacherLastName = Console.ReadLine();
            DateTime teacherBirthdate = GetBirthday(); // Gets a valid birthday.
            Console.Write("Enter teacher address line 1: ");
            string teacherAddressLine1 = Console.ReadLine();
            Console.Write("Enter teacher address line 2: ");
            string teacherAddressLine2 = Console.ReadLine();
            Console.Write("Enter teacher city: ");
            string teacherCity = Console.ReadLine();
            string teacherProvince = GetProvince(provinceList); // Gets a valid Canadian province from user.
            string teacherPostalCode = GetPostalCode(); // Gets a valid Canadian postal code from user.
            string teacherCountry = GetCountry(countryList); // Gets a valid country from user.
            Console.WriteLine("First name: {0}\tLast name: {1}\tBirthdate: {2}\tAddress Line 1: {3}\tAddress Line 2: {4}\tCity: {5}\tProvince: {6}\tPostal Code: {7}\t" +
                "Country: {8}", teacherFirstName, teacherLastName, teacherBirthdate, teacherAddressLine1, teacherAddressLine2, teacherCity, teacherProvince, teacherPostalCode, 
                teacherCountry);

            // Print UProgram information.
            Console.WriteLine("Program Name: Computer Engineering Technology\tDepartment Head: Joe Blow\tDegrees: PHD");

            // Print Degree Info
            Console.WriteLine("Degree Name: BSc\tCredits Required: 45");

            // Print Course Info.
            Console.WriteLine("Course Name: CMPE1600\tCredits: 3\tDuration in Weeks: 16\tTeacher: John Doe");
        }

        public static string GetCountry(List<string> countryList)
        {
            bool check = false;
            string country = "";

            // Loop until valid country name is entered.
            while (!check)
            {
                Console.Write("Enter country: ");
                country = Console.ReadLine().ToLower();

                // Check user input against list of countries.
                if (countryList.Contains(country))
                {
                    check = true;
                    continue;
                }
            }
            return country;
        }

        public static string GetPostalCode()
        {
            bool check = false; // Flag used to check for valid data input.
            string postalCode = "";

            // Loop until a valid postal code is entered.
            while (!check)
            {
                Console.Write("Enter postal code (XNX NXN): ");
                postalCode = Console.ReadLine();
                check = IsPostalCode(postalCode); // Check validity of postal code.
            }
            return postalCode;
        }

        public static string GetProvince(string[] provinceList)
        {
            bool check = false; // Flag used to check for valid data input.
            string province = "";

            // Loop until valid two letter province or territory abbreviation is entered.
            while (!check)
            {
                Console.Write("Enter province (XX): ");
                province = Console.ReadLine().ToUpper();

                // Check user input against list of provinces and territories.
                if (provinceList.Contains(province))
                {
                    check = true;
                }
            }
            return province;
        }

        // Builds list of countries from comma-separated list of countries.
        // Returns list of strings.
        public static List<string> BuildCountryList()
        {
            List<string> countryList = new List<string>();

            StreamReader reader = new StreamReader(@"C:\Users\colin\Source\Repos\ModuleOneAssignment\ModuleOneAssignment\country-keyword-list.csv");

            // Loop through each entry in file.
            while (!reader.EndOfStream)
            {
                countryList.Add(reader.ReadLine().ToLower()); // Add each country to a list.
            }
            reader.Close();

            return countryList;
        }

        // Function checks for valid Canadian postal code format.
        // Function returns true if provided string is a valid postal code.
        public static bool IsPostalCode(string postalCode)
        {
            //Canadian Postal Code in the format of "M3A 1A5"
            string pattern = "^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$";

            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (!(reg.IsMatch(postalCode)))
                return false;
            return true;
        }

        // Function returns a valid birthday.
        // Birthday must be in any valid format and must be in the past.
        static DateTime GetBirthday()
        {
            DateTime birthdate = DateTime.Today;
            bool check = false;

            // Will loop until a valid DateTime format is entered...
            while (!check)
            {
                Console.Write("Enter student birthday: ");
                check = DateTime.TryParse(Console.ReadLine(), out birthdate);

                // Check for invlid data entry - not a date.
                if (!check)
                {
                    continue;
                }

                // Birthday must have occured before today.
                if (birthdate.Date < DateTime.Today.Date)
                {
                    check = true;
                }
            }

            return birthdate;
        }
    }
}
