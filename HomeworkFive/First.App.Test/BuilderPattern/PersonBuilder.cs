using System;

namespace First.App.Console.BuilderPattern
{
    public class PersonBuilder
    {
        private Person _person;

        public PersonBuilder Create(string firstName, string lastName)
        {
            _person = new Person
            {
                Firstname = firstName,
                Lastname = lastName,
                Id = Guid.NewGuid()
            };
            return this;

        }
        public PersonBuilder DateOfBirth(DateTime dob)
        {
            _person.DateOfBirth = dob;
            return this;
        }

        public PersonBuilder Gender(Gender gender)
        {
            _person.Gender = gender;
            return this;
        }

        public PersonBuilder Job(string job)
        {
            _person.Job = job;
            return this;
        }

        public Person Build()
        {
            return _person;
        }
    }
}
