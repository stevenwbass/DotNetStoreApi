docker login docker.io

dotnet publish --self-contained -r linux-arm64

cd ./StoreApi

docker build --tag 'ursteveb/dotnetstoreapi:v8-latest' .
docker push 'ursteveb/dotnetstoreapi:v8-latest'

cd ../