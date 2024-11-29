# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0@sha256:6c4df091e4e531bb93bdbfe7e7f0998e7ced344f54426b7e874116a3dc3233ff

WORKDIR /Docker
COPY /bin/Release/net8.0/linux-arm64 .

ENV ASPNETCORE_URLS https://+:5000
EXPOSE 5000
 
ENTRYPOINT ["dotnet", "/Docker/StoreApi.dll"]