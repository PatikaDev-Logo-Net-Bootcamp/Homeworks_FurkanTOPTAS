using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Console
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Job { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return $"Person with id: {Id}  with date of birth  { DateOfBirth.ToLongDateString()} and name  {string.Concat(Firstname, " ", Lastname)} is a { Job }";
        }
    }
    public enum Gender
    {
        Male,
        Female
    }

}
