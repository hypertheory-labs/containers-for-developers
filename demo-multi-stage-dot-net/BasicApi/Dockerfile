FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build
WORKDIR /src
COPY BasicApi.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish --no-restore -o /app


FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "./BasicApi"]