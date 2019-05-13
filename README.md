# Sorting-Filtering-Pagination-Extensions

A small set of Queryable Extensions to help implement sorting filtering and pagination.

## Basic Usage

Imagine you want to sort, filter and/or paginate a list of person objects.

```cs
public class Person
{
    public string ForeName { get; set; }
    public string SirName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}
```

First create a query object for the class you want to query.

```cs
public class PersonQueryObject : IQueryObject
{
    //Properties inherited from IQueryObject used for sorting and pagination
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public string SortBy { get; set; }
    public bool IsSortAscending { get; set; }

    //Properties we want to filter by
    public string ForeName { get; set; }
    public string SirName { get; set; }
    public string Email { get; set; }
}
```

The you can query any list of objects using the extension methods.
I mainly use these extension in Web- Api's. The client sends the QueryObject to the endpoint and the Api returns the result of the query.

```cs
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
```
