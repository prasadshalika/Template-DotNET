# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR ./app

# Expose the port your application will run on
EXPOSE 80
EXPOSE 443

# Copy the project file and restore any dependencies (use .csproj for the project name)
COPY ["*.csproj", "./"]
RUN dotnet restore "./template-dotnet.csproj"

# Copy the rest of the application code
COPY . ./

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Start the application
ENTRYPOINT ["dotnet", "template-dotnet.dll", "--environment = Development"]