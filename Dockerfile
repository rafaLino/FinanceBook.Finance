#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FinanceBook.Finance.API/FinanceBook.Finance.API.csproj", "FinanceBook.Finance.API/"]
RUN dotnet restore "FinanceBook.Finance.API/FinanceBook.Finance.API.csproj"
COPY . .
WORKDIR "/src/FinanceBook.Finance.API"
RUN dotnet build "FinanceBook.Finance.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceBook.Finance.API.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "FinanceBook.Finance.API.dll"]
CMD ASPNETCORE_URLS=https://*:$PORT dotnet FinanceBook.Finance.API.dll