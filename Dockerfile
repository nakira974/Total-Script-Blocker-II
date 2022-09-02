FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Total_Script_Blocker_II/Total_Script_Blocker_II.csproj", "Total_Script_Blocker_II/"]
RUN dotnet restore "Total_Script_Blocker_II/Total_Script_Blocker_II.csproj"
COPY . .
WORKDIR "/src/Total_Script_Blocker_II"
RUN dotnet build "Total_Script_Blocker_II.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Total_Script_Blocker_II.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Total_Script_Blocker_II.dll"]
