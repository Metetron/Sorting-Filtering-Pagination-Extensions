using UnitTests.TestObjects;
using Xunit;
using Metetron.Helpers.SortingFilteringPagination.Filtering;
using System.Linq;

namespace UnitTests.Filtering
{
    public class IntegerFilteringTests
    {
        [Fact]
        public void ApplyGreaterFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyGreaterThanFilter(p => p.Age, 80);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyGreaterThanOrEqualToFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyGreaterThanOrEqualToFilter(p => p.Age, 80);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void ApplySmallerThanFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplySmallerThanFilter(p => p.Age, 20);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplySmallerThanOrEqualtoFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplySmallerThanOrEqualToFilter(p => p.Age, 20);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void ApplyEqualToFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualToFilter(p => p.Age, 10);

            Assert.Equal(1, result.Count());
        }
    }
}