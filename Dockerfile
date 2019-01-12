FROM microsoft/dotnet:2.2-sdk as builder
COPY . /
WORKDIR /WebApi
RUN dotnet restore --no-cache
RUN dotnet publish --output /app/ -c Release --no-restore

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /app .


ENV ASPNETCORE_ENVIRONMENT Production
ENV DOTNET_RUNNING_IN_CONTAINER true

CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApi.dll