# RIT Automation

Тестовое задание

## Как запустить проект?

1. Скачать проект с github
2. Открыть файл RIT.Api.sln в удобной для вас Ide
3. Зайти в appsettings.json
4. По ключу "Postgresql" вставить вашу строку подключения к PostreSQL
5. Открыть консоль и перейти в каталог \RIT.DATA
6. Ввести команду для применения миграции: dotnet ef database update -s ..//RIT.Api
7. Запустить проект
