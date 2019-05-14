using System.Collections.Generic;
using System.Linq;

namespace UnitTests.TestObjects
{
    public class TestData
    {
        public static readonly IQueryable<Person> People = new List<Person>
        {
            new Person{ForeName = "Fn1", SirName = "Sn1", Email = "p1@domain.com", Age = 10, Height = 100.1, Weight = 30.1f, TestDecimal = 1.1m},
            new Person{ForeName = "Fn2", SirName = "Sn2", Email = "p2@domain.com", Age = 20, Height = 150.2, Weight = 60.1f, TestDecimal = 2.3m},
            new Person{ForeName = "Fn3", SirName = "Sn3", Email = "p3@domain.com", Age = 30, Height = 160.3, Weight = 50.1f, TestDecimal = 3.5m},
            new Person{ForeName = "Fn4", SirName = "Sn4", Email = "p4@domain.com", Age = 40, Height = 166.4, Weight = 55.2f, TestDecimal = 4.7m},
            new Person{ForeName = "Fn5", SirName = "Sn5", Email = "p5@domain.com", Age = 50, Height = 157.5, Weight = 78.4f, TestDecimal = 5.8m},
            new Person{ForeName = "Fn6", SirName = "Sn6", Email = "p6@domain.com", Age = 60, Height = 180.6, Weight = 90.1f, TestDecimal = 6.9m},
            new Person{ForeName = "Fn7", SirName = "Sn7", Email = "p7@domain.com", Age = 70, Height = 190.7, Weight = 96.8f, TestDecimal = 7.1m},
            new Person{ForeName = "Fn8", SirName = "Sn8", Email = "p8@domain.com", Age = 80, Height = 202.8, Weight = 103.5f, TestDecimal = 8.2m},
            new Person{ForeName = "Fn9", SirName = "Sn9", Email = "p9@domain.com", Age = 90, Height = 140.9, Weight = 45.1f, TestDecimal = 9.3m},
            new Person{ForeName = "Jane", SirName = "Doe", Email = "jane.doe@domain1.com", Age = 30, Height = 178.9, Weight = 60.9f, TestDecimal = 10.4m},
            new Person{ForeName = "Bob", SirName = "Smith", Email = "bob.smith@xyz.com", Age = 40, Height = 167.2, Weight = 58.4f, TestDecimal = 11.5m}
        }.AsQueryable();
    }
}