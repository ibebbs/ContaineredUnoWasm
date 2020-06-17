FROM nventive/wasm-build:latest AS build
WORKDIR /src
COPY ["ContaineredUnoWasm.Shared/", "ContaineredUnoWasm.Shared/"]
COPY ["ContaineredUnoWasm.Wasm/", "ContaineredUnoWasm.Wasm/"]
RUN dotnet build "ContaineredUnoWasm.Wasm/ContaineredUnoWasm.Wasm.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "ContaineredUnoWasm.Wasm/ContaineredUnoWasm.Wasm.csproj" -c Release -o /app/publish

FROM nginx:alpine
EXPOSE 80
COPY --from=publish /app/publish /usr/share/nginx/html
COPY ["Docker/mime.types", "/etc/nginx/mime.types" ]