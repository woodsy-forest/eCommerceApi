# eCommerceApi #

Make more UnitTests for testing different combinations of output.

Make UnitTests to test different behavior of the API.

## Test the API ## 

using Postman:

POST: http://localhost:5000/api/customer

Body:
```json
{
	"user": "cat.owner@mmtdigital.co.uk",
	"customerId": "C34454"
} 
```
## To go in Production: ##
.add the source code in Azure DevOps using git/Visual Studio 2019;

.create a Build pipeline which:
  .dotnet build
  .dotnet test
  .dotnet publish
  .publish pipeline artifact
  
.create a Release pipeline with two stages: dev and prod, which:
    .set enviroment variables in appsettings.json
    .publish app
    
This is done automatically in dev after the build, while in prod the product manager has to approve it.
