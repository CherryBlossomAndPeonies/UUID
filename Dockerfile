# Stage 1: Build the solution
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file and project files
COPY CodingTest.slnx ./
COPY SubsequenceLib/SubsequenceLib.csproj ./SubsequenceLib/
COPY SubsequenceLib.Tests/SubsequenceLib.Tests.csproj ./SubsequenceLib.Tests/

# Restore dependencies
RUN dotnet restore CodingTest.slnx

# Copy the rest of the source code
COPY . .

# Build and test the application inside the container
RUN dotnet build CodingTest.slnx -c Release --no-restore
RUN dotnet test CodingTest.slnx -c Release --no-build

# Stage 2: Publish / Runtime image (if your library is meant to be packed or used)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src
RUN dotnet publish SubsequenceLib/SubsequenceLib.csproj -c Release -o /app/publish

# Final runtime stage (using an aspnet or runtime image depending on needs)
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .