FROM mcr.microsoft.com/dotnet/aspnet:5.0
LABEL version="1.0.1" desciption="Aplicacao ASP .NET Core MVC"
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "mvc1.dll"]


# docker build -t aspnetcoremvc/app1:1.0 .
# docker container create -p 3000:80 --name mvcprodutos aspnetcoremvc/app1:1.0
# docker container start mvcprodutos