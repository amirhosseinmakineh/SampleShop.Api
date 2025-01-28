# استفاده از ایمیج پایه ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# استفاده از ایمیج SDK برای کامپایل پروژه
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SampleShop.Api", "./"]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

# انتشار پروژه
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# ایجاد ایمیج نهایی
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleShop.Api.dll"]