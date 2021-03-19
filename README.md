## NanoSurvey

I decided to make modern architecture from microsoft:
https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures

## Table of contents
* [Architecture](#architecture)
* [How to start](#how-to-start)
* [Projects](#projects)
* [Technologies](#technologies)
* [Special thanks to](#special-thanks-to)

## Architecture
![Architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/media/image5-9.png)

## How to start
* create a database with using sql script
* start the project

## Projects
* NanoSurvey.API - API for UI
* NanoSurvey.Application - Independent business logic
* NanoSurvey.Infrastructure - Layer for working with data, frameworks, api
* NanoSurvey.Application.UnitTests - Unit tests for application layer

## Technologies
* EntityFrameworkCore - v5.0.4
* Moq - v4.16.1
* xUnit - v2.4.1
* AutoMapper - v10.1.1

## Special thanks to
Many thanks to the "Tiburon" company for the provided technical task :)
![Tiburon](https://hhcdn.ru/employer-logo/2897761.png)