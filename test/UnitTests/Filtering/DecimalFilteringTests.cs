using UnitTests.TestObjects;
using Xunit;
using Metetron.Helpers.SortingFilteringPagination.Filtering;
using System.Linq;

namespace UnitTests.Filtering
{
    public class DecimalFilteringTests
    {
        [Fact]
        public void ApplyGreaterThanFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyGreaterThanFilter(p => p.TestDecimal, 10.0m);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void ApplyGreaterThanOrEqualToFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyGreaterThanOrEqualToFilter(p => p.TestDecimal, 11.5m);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplySmallerThanFilter_WhenCalled_ShouldFiterTheQueryable()
        {
            var result = TestData.People.ApplySmallerThanFilter(p => p.TestDecimal, 5.8m);

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public void ApplySmallerThanOrEqualToFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplySmallerThanOrEqualToFilter(p => p.TestDecimal, 5.8m);

            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void ApplyEqualToFilter_WhenCalledWithDefaultDelta_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualToFilter(p => p.TestDecimal, 5.8m);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyEqualToFilter_WhenCalledWithCustomDelta_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualToFilter(p => p.TestDecimal, 5.7999m, 1e-12m);

            Assert.Empty(result);
        }
    }
}