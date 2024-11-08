# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the CSPROJ file and restore dependencies

COPY . .
RUN dotnet restore

WORKDIR /app
RUN dotnet publish -c Release -o out

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose port (adjust if your app uses a different port)
EXPOSE 80

RUN ls

# Set the entry point for the container
ENTRYPOINT ["dotnet", "Booking.App.dll"]
