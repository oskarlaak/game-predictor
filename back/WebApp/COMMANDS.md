# tools
~~~bash
dotnet tool update --global dotnet-ef
dotnet tool update --global dotnet-aspnet-codegenerator
~~~

# migrations
~~~bash
dotnet ef database drop          -c AppDbContext -p DAL.App -s WebApp
# delete Migrations folder
dotnet ef migrations add Initial -c AppDbContext -p DAL.App -s WebApp
dotnet ef database update        -c AppDbContext -p DAL.App -s WebApp
~~~

# docker
~~~bash
docker build game-predictor-back .
docker tag   game-predictor-back oslaak/game-predictor-back
docker push                      oslaak/game-predictor-back
~~~
