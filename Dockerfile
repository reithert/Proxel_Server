FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ./target/* ./
# CMD ["dotnet", "./Proxel_Server.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet /Proxel_Server.dll
