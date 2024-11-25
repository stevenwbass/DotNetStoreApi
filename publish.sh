docker login docker.io

dotnet publish

cd ./StoreApi

docker build --tag 'ursteveb/dotnetstoreapi:v8-latest' .
docker push 'ursteveb/dotnetstoreapi:v8-latest'

cd ../