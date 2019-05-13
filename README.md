# Sorting-Filtering-Pagination-Extensions

A small set of Queryable Extensions to help implement sorting filtering and pagination.

## Basic Usage

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
