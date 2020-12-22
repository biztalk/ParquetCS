# Refs

[Convert Data to Apache Parquet Format](https://faragta.com/c-sharp/convert-data-to-apache-parquet.html)   
[Apache Parquet for .Net Platform](https://github.com/aloneguid/parquet-dotnet)  
[CSV Parsing In .NET Core](https://dotnetcoretutorials.com/2018/08/04/csv-parsing-in-net-core/)  
[Query Parquet files using serverless SQL pool in Azure Synapse Analytics](https://docs.microsoft.com/en-us/azure/synapse-analytics/sql/query-parquet-files)  
[Dremio Azure Quickstart](https://docs.dremio.com/deployment/azure/azure-deploy.html#step-3-configure-the-dremio-deployment)  
[.NET for Apache® Spark™](https://github.com/dotnet/spark/blob/master/docs/getting-started/macos-instructions.md)  
[Apache Arrow - Reading and Writing the Apache Parquet Format](https://arrow.apache.org/docs/python/parquet.html#)  

```
import pyarrow.parquet as pq
table2 = pq.read_table('ParquetRW/Data/auto.parquet')
table2.to_pandas()
```

```
from pyarrow import json
fn = '/Users/David/repo/ParquetCS/ParquetRW/Data/my_data.json'
table = json.read_json(fn)
table
table.to_pandas()
```



# Setup

```
dotnet new sln -n ParquetCS -o ParquetCS && cd ParquetCS 
dotnet new console -n ParquetRW -o ParquetRW
dotnet sln ./ParquetCS.sln add ./ParquetRW/ParquetRW.csproj 

dotnet add ./ParquetRW/ParquetRW.csproj package CsvHelper
dotnet add ./ParquetRW/ParquetRW.csproj package Parquet.Net

```