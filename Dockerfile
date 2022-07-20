FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /app
COPY ["app", "/app"]
RUN dotnet publish "docker-test/docker-test.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base 
RUN addgroup -S gmnfrt && adduser -S -G gmnfrt mnfrt
WORKDIR /app
EXPOSE 8000
USER mnfrt
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "docker-test.dll"]
