using UnitTests.TestObjects;
using Xunit;
using Metetron.Helpers.SortingFilteringPagination.Filtering;
using System.Linq;

namespace UnitTests.Filtering
{
    public class DoubleFilteringExtensions
    {
        [Fact]
        public void ApplyGreateThanFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyGreaterThanFilter(p => p.Height, 200.0d);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyGreaterThanOrEqualTo_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyGreaterThanOrEqualToFilter(p => p.Height, 202.8d);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplySmallerThanFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplySmallerThanFilter(p => p.Height, 200.0d);

            Assert.Equal(10, result.Count());
        }

        [Fact]
        public void ApplySmallerThanOrEqualToFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplySmallerThanOrEqualToFilter(p => p.Height, 100.1d);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyEqualToFilter_WhenCalledWithDefaultDelta_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualToFilter(p => p.Height, 100.1d);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyEqualToFilter_WhenCalledWithCustomDelta_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualToFilter(p => p.Height, 100.09999d, 1e-12);

            Assert.Empty(result);
        }
    }
}