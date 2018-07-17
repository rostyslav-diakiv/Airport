# Airport
HomeTask #6. BSA 2018. .Net stream

#6 Task Tests

На основе созданного проекта (Аэропорт) необходимо покрыть код тестами

Used Test Frameworks: xUnit.Net, Moq

Для валидации моделей входящих запросов я использовал Fluent Validation
Все тесты валидации находяться в проекте Airport.Common.Tests

Для маппинга использовалась библиотека AutoMapper
Все тесты такие как проверка конфигурации маппера, примеры, 
тестовые маппинги находяться в проекте: Airport.BLL.Tests, папка: Mapper.Tests.

Тесты ApiController находяться в проекте Airport.WebApi.Tests, папка UnitTests.
Проверяеться логика тела методов контроллера.

Функциональные тесты, которые будут вызывають API и проверяют результат (т.е. имитируют реальные запросы от пользователей) находяться в проекте Airport.WebApi.Tests, папка IntergationTests.
Для имитации тестового окружения используеться Microsoft.AspNetCore.TestHost TestServer.
Для того чтобы выбрать какую Базу данны тестировать (InMemoryDatabase или тестовую на SqlServer) можно роскомментировать\закомментировать конфигурацию в методе ConfigureDatabase()
P.S. не забудьте поменять connection string

Тесты раннились использованием Test Explorer от Visual Studio и JetBrains Resharper - результаты одинаковые.