#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV Logging__Console__FormatterName=simple
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PXLSchoolManagement/PXLSchoolManagement.csproj", "PXLSchoolManagement/"]
RUN dotnet restore "PXLSchoolManagement/PXLSchoolManagement.csproj"
COPY . .
WORKDIR "/src/PXLSchoolManagement"
RUN dotnet build "PXLSchoolManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PXLSchoolManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PXLSchoolManagement.dll"]