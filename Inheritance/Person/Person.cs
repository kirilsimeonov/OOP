using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name {
            get {
                return name;
            }

            set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                else
                {
                    name = value;
                }
            }
        }
        public virtual int Age {
            get {
                return age;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                else
                {
                    age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");
            return sb.ToString();
        }
    }
}
