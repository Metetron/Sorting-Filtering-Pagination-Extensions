using UnitTests.TestObjects;
using Xunit;
using Metetron.Helpers.SortingFilteringPagination.Pagination;
using System;
using System.Linq;
using MockQueryable.Moq;

namespace UnitTests.Pagination
{
    public class PaginationTests
    {
        [Fact]
        public void ApplyPaging_QueryObjectIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => TestData.People.ApplyPaging(null));
        }

        [Fact]
        public void ApplyPaging_QueryObjectIsEmpty_ShouldPageTheDataWithDefaultValues()
        {
            var result = TestData.People.ApplyPaging(new PersonQuery());

            Assert.Equal(2, result.TotalNumberOfPages);
            Assert.Equal(10, result.ResultSet.Count());
        }

        [Fact]
        public void ApplyPaging_QueryObjectContainsPagingProperties_ShouldReturnTheRightPage()
        {
            var result = TestData.People.ApplyPaging(new PersonQuery { PageSize = 1, CurrentPage = 5 });

            Assert.Equal("Fn5", result.ResultSet.FirstOrDefault().ForeName);
            Assert.Equal(TestData.People.Count(), result.TotalNumberOfPages);
        }

        [Fact]
        public void ApplyPagingAsync_QueryObjectIsNull_ShouldTrowException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await TestData.People.ApplyPagingAsync(null));
        }

        [Fact]
        public async void ApplyPagingAsync_QueryObjectIsEmpty_ShouldPageTheDataWithDefaultValues()
        {
            var result = await TestData.People.BuildMock().Object.ApplyPagingAsync(new PersonQuery());

            Assert.Equal(2, result.TotalNumberOfPages);
            Assert.Equal(10, result.ResultSet.Count());
        }

        [Fact]
        public async void ApplyPagingAsync_QueryObjectContainsPagingProperties_ShouldReturnTheRightPage()
        {
            var result = await TestData.People.BuildMock().Object.ApplyPagingAsync(new PersonQuery { PageSize = 1, CurrentPage = 5 });

            Assert.Equal("Fn5", result.ResultSet.FirstOrDefault().ForeName);
            Assert.Equal(TestData.People.Count(), result.TotalNumberOfPages);
        }
    }
}