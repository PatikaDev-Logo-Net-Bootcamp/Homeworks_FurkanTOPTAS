using First.App.Console;
using First.App.Console.BuilderPattern;
using First.App.Core.Extensions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace First.App.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            string bootcamp = "İkinci Hafta";
            string nullValue = null;
            string emptyValue = string.Empty;
            int number = 4;

            bool isGreaterThan = number.IsGreaterThan();
            var result = nullValue.NullCheck();

            var text = InvoiceType.Customer.GetDisplayName();
            var people = InvoiceType.People.GetDescription();

            var test = InvoiceType.Company.ToString();

            var person = new Person
            {
                DateOfBirth = new DateTime(1992, 11, 11),
                Firstname = "Samet",
                Lastname = "Kayıkcı",
                Gender = Gender.Male,
                Id = Guid.NewGuid(),
                Job = "Software Eng."
            };
            person.ToString();

            var person2 = new PersonBuilder()
                .Create("Samet","Kayıkcı")
                .Gender(Gender.Male)
                .Job("Developer")
                .DateOfBirth(new DateTime(1992, 11, 11))
                .Build();


            System.Console.WriteLine(person2);
            //System.Console.WriteLine(person.ToString());      


        }

        public enum InvoiceType
        {
            [Display(Name = "Müşteri")]
            Customer,
            [Description("Kişiler")]
            People,
            Company
        }
     
    }
}
