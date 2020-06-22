FROM unoplatform/wasm-build:latest AS build
WORKDIR /src

COPY ["ContaineredUnoWasm/ContaineredUnoWasm.Wasm/ContaineredUnoWasm.Wasm.csproj", "ContaineredUnoWasm/ContaineredUnoWasm.Wasm/ContaineredUnoWasm.Wasm.csproj"]
RUN dotnet restore "ContaineredUnoWasm/ContaineredUnoWasm.Wasm/ContaineredUnoWasm.Wasm.csproj"

COPY ["ContaineredUnoWasm/ContaineredUnoWasm.Shared/", "ContaineredUnoWasm/ContaineredUnoWasm.Shared/"]
COPY ["ContaineredUnoWasm/ContaineredUnoWasm.Wasm/", "ContaineredUnoWasm/ContaineredUnoWasm.Wasm/"]
RUN dotnet build "ContaineredUnoWasm/ContaineredUnoWasm.Wasm/ContaineredUnoWasm.Wasm.csproj" -c Release -o /app/build

FROM build AS publish
ARG HELLO_PERSON
RUN dotnet publish "ContaineredUnoWasm/ContaineredUnoWasm.Wasm/ContaineredUnoWasm.Wasm.csproj" -c Release -o /app/publish /p:HelloPerson=$HELLO_PERSON

FROM ibebbs/wasm-serve:latest
EXPOSE 80
COPY --from=publish /app/publish /usr/share/nginx/html