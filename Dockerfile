FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the fsproj and restore dependencies
COPY LaoAirline/LaoAirline.fsproj LaoAirline/
RUN dotnet restore "LaoAirline/LaoAirline.fsproj"

# Copy the remaining source code and build
COPY . .
WORKDIR "/src/LaoAirline"
RUN dotnet build "LaoAirline.fsproj" -c Release -o /app/build
RUN dotnet publish "LaoAirline.fsproj" -c Release -o /app/publish

# Use the lighter ASP.NET Core runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 8080 (standard for cloud hosting like Render/Railway)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "LaoAirline.dll"]
