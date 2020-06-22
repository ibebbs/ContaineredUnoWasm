To build WASM project in container with configuration:

docker build -f .\ContaineredUnoWasm\ContaineredUnoWasm.Wasm\Dockerfile --build-arg HELLO_PERSON=CommandLine . -t ibebbs/ContaineredUnoWasm:latest
docker run -p 8070:80 ibebbs/ContaineredUnoWasm:latest