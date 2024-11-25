docker login

dotnet publish --self-contained

Set-Location ./StoreApi

docker build --tag 'ursteveb/dotnetstoreapi:v8-latest' .
docker push 'ursteveb/dotnetstoreapi:v8-latest'

Set-Location ../