using UnitTests.TestObjects;
using Xunit;
using Metetron.Helpers.SortingFilteringPagination.Filtering;
using System.Linq;
using System;

namespace UnitTests.Filtering
{
    public class StringFilteringTests
    {
        [Fact]
        public void ApplyContainsFilter_FilterStringIsEmpty_ShouldNotFilterTheQueryable()
        {
            var result = TestData.People.ApplyContainsFilter(p => p.ForeName, "");

            Assert.Equal(TestData.People, result);
        }

        [Fact]
        public void ApplyContainsFilter_FilterIsNotContainedInProperty_ShouldReturnAnEmptyList()
        {
            var result = TestData.People.ApplyContainsFilter(p => p.ForeName, "xyz");

            Assert.Empty(result);
        }

        [Fact]
        public void ApplyContainsFilter_FilterIsContained_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyContainsFilter(p => p.ForeName, "J");

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyContainsFilter_StringComparisonTypeIsProvided_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyContainsFilter(p => p.SirName, "SMITH", StringComparison.OrdinalIgnoreCase);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyContainsFilter_StringComparisonTypeIsProvidedAndFilterIsEmpty_ShouldNotFilterTheQueryable()
        {
            var result = TestData.People.ApplyContainsFilter(p => p.ForeName, "", StringComparison.OrdinalIgnoreCase);

            Assert.Equal(TestData.People, result);
        }

        [Fact]
        public void ApplyEqualsFilter_FilterIsEmpty_ShouldNotFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualsFilter(p => p.ForeName, "");

            Assert.Equal(TestData.People, result);
        }

        [Fact]
        public void ApplyEqualsFilter_NoEntryMatchesTheFilter_ShouldReturnAnEmptyList()
        {
            var result = TestData.People.ApplyEqualsFilter(p => p.ForeName, "xyz");

            Assert.Empty(result);
        }

        [Fact]
        public void ApplyEqualsFilter_ThereAreEntriesThatMatchTheFilter_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualsFilter(p => p.ForeName, "Jane");

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyEqualsFilter_StringComparisonTypeIsProvided_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualsFilter(p => p.ForeName, "JANE", StringComparison.OrdinalIgnoreCase);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyEqualsFilter_StringComparisonTypeIsProvidedAndFilterIsEmpty_ShouldNotFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualsFilter(p => p.ForeName, "", StringComparison.OrdinalIgnoreCase);

            Assert.Equal(TestData.People, result);
        }
    }
}