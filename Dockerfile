# Use official .NET 8 runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set working directory inside the container
WORKDIR /app

# Copy published build files
COPY bin/Release/net8.0/publish/ .

# Expose port 80 for the app
EXPOSE 80

# Start the ASP.NET MVC application
ENTRYPOINT ["dotnet", "YourMvcApp.dll"]

