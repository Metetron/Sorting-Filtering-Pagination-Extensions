using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Metetron.Helpers.SortingFilteringPagination.QueryObjects;
using Metetron.Helpers.SortingFilteringPagination.Filtering;
using Metetron.Helpers.SortingFilteringPagination.Sorting;
using Metetron.Helpers.SortingFilteringPagination.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Controllers
{
    [ApiController]
    [Route("/api/people")]
    public class PersonController : Controller
    {
        private static List<Person> people = new List<Person>
        {
            new Person{ ForeName = "Jane", SirName = "Doe", Email = "jane.doe@domain.com", Age = 20},
            new Person{ForeName = "Bob", SirName = "Smith", Email = "bob.smith@abc.com", Age = 30}
        };

        private static Dictionary<string, Expression<Func<Person, object>>> columnMapping = new Dictionary<string, Expression<Func<Person, object>>>
        {
            ["forename"] = p => p.ForeName,
            ["sirname"] = p => p.SirName,
            ["email"] = p => p.Email
        };

        [HttpGet]
        public ActionResult<QueryResult<Person>> GetPeople(PersonQueryObject personQueryObj)
        {
            var filteredPeople = people
                .AsQueryable()
                .ApplyContainsFilter(p => p.ForeName, personQueryObj.ForeName)
                .ApplyContainsFilter(p => p.SirName, personQueryObj.SirName, StringComparison.OrdinalIgnoreCase)
                .ApplyEqualsFilter(p => p.Email, personQueryObj.Email);

            var sortedPeople = filteredPeople
                .ApplySorting(columnMapping, personQueryObj);

            var result = sortedPeople
                .ApplyPaging(personQueryObj);

            return Ok(Json(result).Value);
        }
    }
}