# The Estimator
[![Build and Test](https://github.com/ikarabulut/TheEstimator/actions/workflows/build-test.yml/badge.svg)](https://github.com/ikarabulut/TheEstimator/actions/workflows/build-test.yml)

**I'll be back... to tell you that you way underestimated what you're about to estimate.**

This RESTful API was built to be used for a frontend app to generate different types of estimates.

**Estimates Supported:**

- [PERT Estimation](https://projectmanagementacademy.net/resources/blog/a-three-point-estimating-technique-pert/)
- [Triangulation](https://www.projectmanagement.com/contentPages/wiki.cfm?ID=368763&thisPageURL=/wikis/368763/3-Points-Estimating#1) 

***

### Technologies used

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)

### Requirements

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download)

***
### To make changes locally
Run the following commands to clone and build
```
git clone https://github.com/ikarabulut/TheEstimator.git
cd TheEstimator
dotnet build
```
To run the server:
```
dotnet run --project ./src/TheEstimator
--or--
cd /src/TheEstimator
dotnet run
```

### Current Endpoints
While running the API locally (See above)

To generate a PERT estimate send a POST request to `localhost:{PORT}/pert`

**Required fields**
```
"mostlikely:"int"
"optimistic":"int"
"pessimistic":"int"
```
#### Sample POST request
```
curl -i -X POST http://localhost:{PORT}/pert
-h "content-Type: application/json"
-d "{"mostlikely":"{VALUE}", "optimistic":"{VALUE}", "pessimistic":"{VALUE}"}"
```


