using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentTracking
{
    public class Student
    {
        private static int lastGeneratedId = 0;
        private readonly int _id;
        private string _name;
        private string _major;
        private DateTime _startDate;
        private DateTime _graduationDate;
        private string _state;
        private string _country;
        private string _email;
        private string _phoneNumber;
        private string _mailingAddress;
        private bool _restrict;
        public List<string> activityLog = new List<string>();

        //parameterized constructor:
        public Student(string name, string major, DateTime startDate, DateTime graduationDate, string state, string country, string email, string phoneNumber, string mailingAddress)
        {
            Name = name;
            Major = major;
            StartDate = startDate;
            GraduationDate = graduationDate;
            State = state;
            Country = country;
            Email = email;
            PhoneNumber = phoneNumber;
            MailingAddress = mailingAddress;

            _id = generateID();
        }
        //default constructor:
        public Student()
        {
            Name = "John Doe";
            Major = "Unknown";
            StartDate = DateTime.Now;
            GraduationDate = DateTime.Now.AddYears(4);
            State = "Unknown";
            Country = "Unknown";
            Email = "jdoe@uni.edu";
            PhoneNumber = "1 111 111 1111";
            MailingAddress = "Unknown";
        }

        //properties

        public bool RestrictInfo
        {
            get { return _restrict; }
            set { _restrict = value; LogActivity(nameof(RestrictInfo)); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; LogActivity(nameof(Name)); }
        }
        public string Major
        {
            get
            {
                if (_restrict)
                {
                    return "Restricted";
                }
                else
                {
                    return _major;
                }
            }
            set { _major = value; LogActivity(nameof(Major)); }
        }
        public DateTime StartDate
        {
            get
            {
                if (_restrict)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return _startDate;
                }
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Start Date cannot be in the future.");
                }
                _startDate = value;
                LogActivity(nameof(StartDate));
            }
        }
        public DateTime GraduationDate
        {
            get
            {
                if (_restrict)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return _graduationDate;
                }
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Graduation date must be in the future.");
                }
                _graduationDate = value;
                LogActivity(nameof(GraduationDate));
            }
        }
        public string State
        {
            get
            {
                if (_restrict)
                {
                    return "Restricted";
                }
                else
                {
                    return _state;
                }
            }
            set { _state = value; LogActivity(nameof(State)); }
        }
        public string Country
        {
            get
            {
                if (_restrict)
                {
                    return "Restricted";
                }
                else
                {
                    return _country;
                }
            }
            set { _country = value; LogActivity(nameof(Country)); }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                if (Regex.IsMatch(value, pattern))
                {
                    _email = value;
                    LogActivity(nameof(Email));
                }
                else
                {
                    throw new ArgumentException("Invalid _email format.");
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                if (_restrict)
                {
                    return "Restricted";
                }
                else
                {
                    return _phoneNumber;
                }
            }
            set
            {
                string pattern = @"^\+?\d{1,3}\s?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$";

                if (Regex.IsMatch(value, pattern))
                {
                    _phoneNumber = value;
                    LogActivity(nameof(PhoneNumber));
                }
                else
                {
                    throw new ArgumentException("Invalid phone number format.");
                }
            }
        }
        public string MailingAddress
        {
            get
            {
                if (_restrict)
                {
                    return "Restricted";
                }
                else
                {
                    return _mailingAddress;
                }
            }
            set { _mailingAddress = value; LogActivity(nameof(MailingAddress)); }
        }

        public int Id
        {
            get { return _id; }
        }

        private int generateID()
        {
            return ++lastGeneratedId;
        }

        private void LogActivity(string propertyName)
        {
            activityLog.Add($"Field '{propertyName}' was set at {DateTime.Now}");
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            var s1 = new Student();
            var s2 = new Student("Bart Babson", "Computer Engineering", new DateTime(2023, 12, 24), new DateTime(2027, 12, 31), "WY", "USA", "bbabson@uni.edu", "1 234 567 8901", "123 Homebound Way");
            var s3 = new Student("Carla Carlson", "Engineering", new DateTime(2022, 10, 15), new DateTime(2026, 10, 30), "CA", "USA", "ccarlson@uni.edu", "1 234 567 8901", "456 Oak Street");
            var s4 = new Student("David Davis", "Mathematics", new DateTime(2022, 9, 1), new DateTime(2026, 9, 15), "NY", "USA", "ddavis@uni.edu", "1 234 567 8901", "789 Maple Avenue");
            var s5 = new Student("Emily Evans", "Biology", new DateTime(2023, 5, 10), new DateTime(2027, 5, 25), "TX", "USA", "eevans@uni.edu", "1 234 567 8901", "101 Pine Lane");
            var s6 = new Student("Frank Fisher", "History", new DateTime(2023, 8, 20), new DateTime(2028, 8, 31), "MA", "USA", "ffisher@uni.edu", "1 234 567 8901", "202 Cedar Road");
            var s7 = new Student("Grace Green", "Psychology", new DateTime(2022, 3, 5), new DateTime(2026, 3, 20), "IL", "USA", "ggreen@uni.edu", "1 234 567 8901", "303 Elm Street");
            var s8 = new Student("Henry Harris", "English", new DateTime(2023, 6, 15), new DateTime(2027, 6, 30), "FL", "USA", "hharris@uni.edu", "1 234 567 8901", "404 Walnut Drive");
            var s9 = new Student("Ivy Irwin", "Chemistry", new DateTime(2023, 4, 30), new DateTime(2028, 5, 15), "WA", "USA", "iirwin@uni.edu", "1 234 567 8901", "505 Birch Boulevard");
            var s10 = new Student("Jack Johnson", "Physics", new DateTime(2022, 7, 8), new DateTime(2026, 7, 20), "OH", "USA", "jjohnson@uni.edu", "1 234 567 8901", "606 Oakwood Avenue");
            s1.Name = "morgan dickerson";
            s9.RestrictInfo = true;
            while (true)
            {
                string input;

                Console.WriteLine("Please follow the directory below:");
                Console.WriteLine("");
                Console.WriteLine("Type 'print' to print all students information.");
                Console.WriteLine("");
                Console.WriteLine("Type 'exit' to exit the program");
                Console.WriteLine("");

                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "print":
                        foreach (var student in new[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 })
                        {
                            Console.WriteLine($"Student ID: {student.Id}");
                            Console.WriteLine($"Name: {student.Name}");
                            Console.WriteLine($"Major: {student.Major}");
                            Console.WriteLine($"Start Date: {student.StartDate}");
                            Console.WriteLine($"Graduation Date: {student.GraduationDate}");
                            Console.WriteLine($"State: {student.State}");
                            Console.WriteLine($"Country: {student.Country}");
                            Console.WriteLine($"Email: {student.Email}");
                            Console.WriteLine($"Phone Number: {student.PhoneNumber}");
                            Console.WriteLine($"Mailing Address: {student.MailingAddress}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("Type 'log' to view the change log or 'exit' to exit.");
                        input = Console.ReadLine();
                        switch (input.ToLower())
                        {
                            case "log":
                                Console.WriteLine("Change Log:");
                                foreach (var student in new[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 })
                                {
                                    Console.WriteLine($"Activity Log for {student.Name}:");
                                    foreach (var logEntry in student.activityLog)
                                    {
                                        Console.WriteLine(logEntry);
                                    }
                                    Console.WriteLine();
                                }
                                break;
                            case "exit":
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }
                        break;
                    case "exit":
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }

        }
    }
}