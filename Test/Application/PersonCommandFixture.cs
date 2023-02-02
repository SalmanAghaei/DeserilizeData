using Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    public class PersonCommandFixture : IDisposable
    {
        public PersonCreateDto validPersonCreate;
        public PersonCreateDto invalidDatePersonCreate;
        public PersonCommandFixture()
        {
             validPersonCreate = new PersonCreateDto
            {
                Allowance = 1000,
                BasicSalary = 1000,
                FirstName = "Test",
                LastName = "Test",
                Date = "14000201",
                Transportation = 55

            };
             invalidDatePersonCreate = new PersonCreateDto
            {
                Allowance = 1000,
                BasicSalary = 1000,
                FirstName = "Test",
                LastName = "Test",
                Date = "140890201",
                Transportation = 55

            };
        }
        public void Dispose()
        {
          
        }
    }
}
