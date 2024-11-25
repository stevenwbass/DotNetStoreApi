$devAppSettings = (Get-Content '..\StoreApi\appSettings.Development.json' | Out-String | ConvertFrom-Json)
$storeConnectionString = $devAppSettings.ConnectionStrings.store
dotnet ef dbcontext scaffold $storeConnectionString Pomelo.EntityFrameworkCore.MySql -o Models -c StoreDbContext -f --no-onconfiguring