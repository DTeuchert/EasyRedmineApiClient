# EasyRedmineApiClient
[![NuGet](https://img.shields.io/nuget/v/EasyRedmineApiClient.svg)](https://nuget.org/packages/EasyRedmineApiClient)

EasyRedmineApiClient is a .NET rest client for [EasyRedmine API](https://www.easyredmine.com/resources/rest-api).

## Main features

- Targets .NET Standard 2.0
- Fully async
- Thread safe.
- Multi core paging.
- Simple and natural to use.
- Handles URL encoding for you

## Quick start

### Authenticate

```csharp
// if you have auth token:
var client =  new EasyRedmineClient("https://easyredmine.example.com", "your_private_token");
```

### Use it

```csharp
// get all projects
var projects = await client.Projects.GetAllAsync();

// get project details including trackers and time entries
var project = await client.Projects.GetAsync(1, options: o =>
{
    o.IncludeTrackers = true;
    o.IncludeTimeEntryActivities = true;
});

// create a new time entry.
await client.TimeEntries.CreateAsync(new CreateTimeEntryRequest(new TimeEntryRequest(1, "8", "2023-10-5", 4)));
```