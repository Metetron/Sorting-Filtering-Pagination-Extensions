using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnitTests.TestObjects;
using Xunit;
using Metetron.Helpers.SortingFilteringPagination.Sorting;

namespace UnitTests
{
    public class SortingTests
    {
        private static readonly Dictionary<string, Expression<Func<Person, object>>> columnMapping = new Dictionary<string, Expression<Func<Person, object>>>
        {
            ["forename"] = p => p.ForeName,
            ["sirname"] = p => p.SirName,
            ["email"] = p => p.Email
        };

        [Fact]
        public void ApplySorting_DictionaryIsNullAndQueryResultIsEmpty_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => TestData.People.ApplySorting(null, new PersonQuery()));
        }

        [Fact]
        public void ApplySorting_DictionaryAndQueryObjectAreNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => TestData.People.ApplySorting(null, null));
        }

        [Fact]
        public void ApplySorting_QueryObjectIsNullAndDictionaryIsEmpty_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => TestData.People.ApplySorting(new Dictionary<string, Expression<Func<Person, object>>>(), null));
        }

        [Fact]
        public void ApplySorting_QueryObjectDoesNotContainSortByProperty_ShouldNotSortTheQueryable()
        {
            var result = TestData.People.ApplySorting(columnMapping, new PersonQuery());

            Assert.Equal(TestData.People, result);
        }

        [Fact]
        public void ApplySorting_DictionaryDoesNotContainTheSpecifiedKey_ShouldNotSortTheQueryable()
        {
            var result = TestData.People.ApplySorting(columnMapping, new PersonQuery { SortBy = "xyz" });

            Assert.Equal(TestData.People, result);
        }

        [Fact]
        public void ApplySorting_SortAscending_ShouldSortTheQueryableInAscendingOrder()
        {
            var result = TestData.People.ApplySorting(columnMapping, new PersonQuery { SortBy = "forename", IsSortAscending = true });

            Assert.StartsWith("B", result.ToList().FirstOrDefault()?.ForeName);
        }

        [Fact]
        public void ApplySorting_SortDescending_ShouldSortTheQueryableInDescendingOrder()
        {
            var result = TestData.People.ApplySorting(columnMapping, new PersonQuery { SortBy = "forename", IsSortAscending = false });

            Assert.StartsWith("J", result.ToList().FirstOrDefault()?.ForeName);
        }
    }
}