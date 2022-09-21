# The Estimator
[![Build and Test](https://github.com/ikarabulut/TheEstimator/actions/workflows/build-test.yml/badge.svg)](https://github.com/ikarabulut/TheEstimator/actions/workflows/build-test.yml)
[![Production Deployment](https://github.com/ikarabulut/TheEstimator/actions/workflows/deploy.yml/badge.svg)](https://github.com/ikarabulut/TheEstimator/actions/workflows/deploy.yml)

**I'll be back... to tell you that you way underestimated what you're about to estimate.**

This RESTful API was built to be used for a frontend app to generate different types of estimates.

**Estimates Supported:**

- [PERT Estimation](https://projectmanagementacademy.net/resources/blog/a-three-point-estimating-technique-pert/)
- [Triangulation](https://www.projectmanagement.com/contentPages/wiki.cfm?ID=368763&thisPageURL=/wikis/368763/3-Points-Estimating#1) 

***

### Hosted on Ubuntu server EC2

### Technologies used

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [PostgreSQL 14](https://www.postgresql.org/docs/14/index.html)
- [Nginx](https://nginx.org/en/docs/?_ga=2.117511050.245737080.1662998946-2117561888.1662998946)
- [Github actions](https://docs.github.com/en/actions)

### Requirements

- [.NET 6.0 Download page](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL 14 Download page](https://www.postgresql.org/download/)
  - Currently this app uses the default Username 'postgres' with no password. To alter the username locally, go to the appsettings.json and update 'database' in 'ConnectionStrings'
  - Ensure Postgres is running locally by following the [Official Documentation](https://www.postgresql.org/docs/14/server-start.html)
  - If you run into an authentication error you may need to update your postgres settings -> follow this [Stack Overflow](https://stackoverflow.com/questions/18664074/getting-error-peer-authentication-failed-for-user-postgres-when-trying-to-ge)
- [dotnet ef CLI tool](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
  - `dotnet tool install --global dotnet-ef`


***
### To make changes locally
Run the following commands to clone and build
```
git clone https://github.com/ikarabulut/TheEstimator.git
cd TheEstimator
dotnet build
```

Create database migrations [Migrations overview .net docs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
```
dotnet ef database update
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
#### Sample POST request for a saved estimate
```
curl -i -X POST http://localhost:{PORT}/pert
-h "Content-Type: application/json"
-d "{"mostlikely":"{VALUE}", "optimistic":"{VALUE}", "pessimistic":"{VALUE}"}"
```

#### Sample POST request for a quick estimate (Not saved)
```
curl -i -X POST http://localhost:{PORT}/pert/quick
-h "Content-Type: application/json"
-d "{"mostlikely":"{VALUE}", "optimistic":"{VALUE}", "pessimistic":"{VALUE}"}"
```


