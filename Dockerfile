FROM mcr.microsoft.com/dotnet/sdk:6.0 AS sdk
WORKDIR /img-app
COPY ["app", "/img-app"]
RUN dotnet publish "docker-test/docker-test.csproj" -c Release -o /img-app/img-publish
RUN dotnet publish "tests/tests.csproj" -c Release -o /img-app/img-tests
RUN dotnet test /img-app/img-tests/tests.dll

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS alp 
RUN addgroup -S gmnfrt && adduser -S -G gmnfrt mnfrt
WORKDIR /cont-app
EXPOSE 8000
USER mnfrt
COPY --from=sdk /img-app/img-publish cont-publish
CMD ["dotnet", "cont-publish/docker-test.dll"]
