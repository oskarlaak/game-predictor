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

# api controllers
~~~bash
dotnet aspnet-codegenerator controller -m Competition      -name CompetitionController      -dc AppDbContext -f -outDir Api -api
dotnet aspnet-codegenerator controller -m CompetitionStage -name CompetitionStageController -dc AppDbContext -f -outDir Api -api
dotnet aspnet-codegenerator controller -m CompetitionType  -name CompetitionTypeController  -dc AppDbContext -f -outDir Api -api
dotnet aspnet-codegenerator controller -m Game             -name GameController             -dc AppDbContext -f -outDir Api -api
dotnet aspnet-codegenerator controller -m GameDay          -name GameDayController          -dc AppDbContext -f -outDir Api -api
dotnet aspnet-codegenerator controller -m Prediction       -name PredictionController       -dc AppDbContext -f -outDir Api -api
dotnet aspnet-codegenerator controller -m ScoringRules     -name ScoringRulesController     -dc AppDbContext -f -outDir Api -api
~~~

# docker
~~~bash
docker build game-predictor-back .
docker tag   game-predictor-back oslaak/game-predictor-back
docker push                      oslaak/game-predictor-back
~~~
