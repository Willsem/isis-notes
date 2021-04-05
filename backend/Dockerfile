# FROM mcr.microsoft.com/dotnet/sdk:5.0
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY /out/* .
ENTRYPOINT ["dotnet", "ISISNotesBackend.API.dll"]

EXPOSE 5000
