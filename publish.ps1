dotnet publish -o target
heroku container:push web -a proxel-server
heroku container:release web -a proxel-server