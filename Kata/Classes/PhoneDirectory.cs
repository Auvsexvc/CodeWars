using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Classes
{
    [TestFixture]
    public static class PhoneDirectoryTests
    {
        private static string dr = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010\n"
        + "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n :+1-321-512-2222 <Paul Dive> Sequoia Alley PQ-67209\n"
        + "+1-741-984-3090 <Peter Reedgrave> _Chicago\n :+1-921-333-2222 <Anna Stevens> Haramburu_Street AA-67209\n"
        + "+1-111-544-8973 <Peter Pan> LA\n +1-921-512-2222 <Wilfrid Stevens> Wild Street AA-67209\n"
        + "<Peter Gone> LA ?+1-121-544-8974 \n <R Steell> Quora Street AB-47209 +1-481-512-2222\n"
        + "<Arthur Clarke> San Antonio $+1-121-504-8974 TT-45120\n <Ray Chandler> Teliman Pk. !+1-681-512-2222! AB-47209,\n"
        + "<Sophia Loren> +1-421-674-8974 Bern TP-46017\n <Peter O'Brien> High Street +1-908-512-2222; CC-47209\n"
        + "<Anastasia> +48-421-674-8974 Via Quirinal Roma\n <P Salinger> Main Street, +1-098-512-2222, Denver\n"
        + "<C Powel> *+19-421-674-8974 Chateau des Fosses Strasbourg F-68000\n <Bernard Deltheil> +1-498-512-2222; Mount Av.  Eldorado\n"
        + "+1-099-500-8000 <Peter Crush> Labrador Bd.\n +1-931-512-4855 <William Saurin> Bison Street CQ-23071\n"
        + "<P Salinge> Main Street, +1-098-512-2222, Denve\n" + "<P Salinge> Main Street, +1-098-512-2222, Denve\n";

        [Test]
        public static void test1()
        {
            Console.WriteLine("Phone");
            testing(PhoneDirectory.Phone(dr, "48-421-674-8974"), "Phone => 48-421-674-8974, Name => Anastasia, Address => Via Quirinal Roma");
            testing(PhoneDirectory.Phone(dr, "1-921-512-2222"), "Phone => 1-921-512-2222, Name => Wilfrid Stevens, Address => Wild Street AA-67209");
            testing(PhoneDirectory.Phone(dr, "1-908-512-2222"), "Phone => 1-908-512-2222, Name => Peter O'Brien, Address => High Street CC-47209");
            testing(PhoneDirectory.Phone(dr, "1-541-754-3010"), "Phone => 1-541-754-3010, Name => J Steeve, Address => 156 Alphand St.");
            testing(PhoneDirectory.Phone(dr, "1-121-504-8974"), "Phone => 1-121-504-8974, Name => Arthur Clarke, Address => San Antonio TT-45120");
            testing(PhoneDirectory.Phone(dr, "1-498-512-2222"), "Phone => 1-498-512-2222, Name => Bernard Deltheil, Address => Mount Av. Eldorado");
            testing(PhoneDirectory.Phone(dr, "1-098-512-2222"), "Error => Too many people: 1-098-512-2222");
            testing(PhoneDirectory.Phone(dr, "5-555-555-5555"), "Error => Not found: 5-555-555-5555");
        }

        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }

    internal class PhoneDirectory
    {
        private enum ErrorCode
        {
            NotFound, TooMany
        }

        public static string Phone(string strng, string num)
        {
            List<Contact> contacts = new();

            foreach (var item in strng.Split('\n').ToList())
            {
                if (item.Length > 0)
                {
                    Contact contact = new(item);
                    contacts.Add(contact);
                }
            }

            var filterResult = contacts.Where(c => c.Number.Contains(num));

            if (filterResult.Count() == 1)
            {
                return Messages.Success(filterResult.SingleOrDefault());
            }
            else if (filterResult.Count() > 1)
            {
                if (filterResult.Where(c => c.Number == num).Count() == 1)
                {
                    return Messages.Success(filterResult.FirstOrDefault(c => c.Number == num));
                }
                return Messages.Failure(ErrorCode.TooMany, num);
            }
            else
            {
                return Messages.Failure(ErrorCode.NotFound, num);
            }
        }

        private static string NormalizeWhiteSpace(string input, char normalizeTo = ' ')
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder();
            bool skipped = false;

            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!skipped)
                    {
                        output.Append(normalizeTo);
                        skipped = true;
                    }
                }
                else
                {
                    skipped = false;
                    output.Append(c);
                }
            }

            return output.ToString().TrimStart().TrimEnd();
        }

        private static class Messages
        {
            public static string Success(Contact contact)
            {
                return $"Phone => {contact.Number}, Name => {contact.Name}, Address => {contact.Address}";
            }

            public static string Failure(ErrorCode code, string num)
            {
                switch (code)
                {
                    case ErrorCode.TooMany:
                        return $"Error => Too many people: {num}";

                    default:
                        return $"Error => Not found: {num}";
                }
            }
        }

        private class Contact
        {
            public string Name { get; set; }
            public string Number { get; set; }
            public string Address { get; set; }

            public Contact(string str)
            {
                Number = string.Concat(str.SkipWhile(c => c != '+').TakeWhile(c => c != ' ').ToArray());
                str = str.Replace(Number, " ");
                Number = NormalizeWhiteSpace(string.Concat(Number.Select(c => char.IsNumber(c) || c == '-' ? c : ' ')));

                Name = string.Concat(str.SkipWhile(c => c != '<').TakeWhile(c => c != '>').ToArray());
                str = str.Replace(Name, "");
                Name = NormalizeWhiteSpace(string.Concat(Name.Select(c => char.IsLetterOrDigit(c) || c == '.' || c == '\'' ? c : ' ')));

                Address = str;
                Address = NormalizeWhiteSpace(string.Concat(Address.Select(c => char.IsLetterOrDigit(c) || c == '.' || c == '-' || c == '\'' ? c : ' ')));
            }
        }
    }
}