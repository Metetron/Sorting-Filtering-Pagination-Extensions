using UnitTests.TestObjects;
using Xunit;
using Metetron.Helpers.SortingFilteringPagination.Filtering;
using System.Linq;

namespace UnitTests.Filtering
{
    public class FloatFilteringExtensions
    {
        [Fact]
        public void ApplyGreaterThanFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyGreaterThanFilter(p => p.Weight, 50.1f);

            Assert.Equal(8, result.Count());
        }

        [Fact]
        public void ApplyGreaterThanOrEqualToFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyGreaterThanOrEqualToFilter(p => p.Weight, 50.1f);

            Assert.Equal(9, result.Count());
        }

        [Fact]
        public void ApplySmallerThanFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplySmallerThanFilter(p => p.Weight, 50.1f);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void ApplySmallerThanOrEqualToFilter_WhenCalled_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplySmallerThanOrEqualToFilter(p => p.Weight, 50.1f);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void ApplyEqualToFilter_WhenCalledWithDefaultDelta_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualToFilter(p => p.Weight, 50.1f);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void ApplyEqualToFilter_WhenCalledWithCustomDelta_ShouldFilterTheQueryable()
        {
            var result = TestData.People.ApplyEqualToFilter(p => p.Weight, 50.0999f, 1e-12f);

            Assert.Empty(result);
        }
    }
}