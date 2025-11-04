# HU2-C-Sharp.NET

## Descripcion:
Este repo es una api hecha con C# para un sistema de gestion de un colegio
Se usa una estructura por proyectos para facilitar y merjorar el mantinimiento y escalabilidad,
tambien se hicieron pruebas bacicas con Xunit

## Requerimientos:
- Editor de codigo o IDE de tu preferencia
- SDK 8

## Estructura de los proyectos:
```bash
.
├── docker-compose.yml
├── README.md
├── SchoolManagement.Api
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── Controllers
│   │   ├── CourseController.cs
│   │   ├── SectionController.cs
│   │   ├── StudentController.cs
│   │   └── TeacherController.cs
│   ├── Dockerfile
│   ├── Program.cs
│   ├── SchoolManagement.Api.csproj
│   └── SchoolManagement.Api.http
├── SchoolManagement.Application
│   ├── Interfaces
│   │   ├── IStudentService.cs
│   │   └── ITeacherService.cs
│   ├── SchoolManagement.Application.csproj
│   └── Services
│       ├── CourseService.cs
│       ├── SectionService.cs
│       ├── StudentService.cs
│       └── TeacherService.cs
├── SchoolManagement.Domain
│   ├── DTOs
│   │   ├── CourseCreateDto.cs
│   │   ├── CourseReadDto.cs
│   │   ├── SectionCreateDto.cs
│   │   └── SectionReadDto.cs
│   ├── Entities
│   │   ├── Course.cs
│   │   ├── Person.cs
│   │   ├── Section.cs
│   │   ├── Student.cs
│   │   └── Teacher.cs
│   ├── Interfaces
│   │   ├── ICourseRepository.cs
│   │   ├── ISectionRepository.cs
│   │   ├── IStudentRepository.cs
│   │   └── ITeacherRepository.cs
├── SchoolManagement-HU2.sln
├── SchoolManagement.Infraestructure
│   ├── Data
│   │   └── AppDbContext.cs
│   ├── Repositories
│   │   ├── CourseRepository.cs
│   │   ├── SectionRepository.cs
│   │   ├── StudentRepository.cs
│   │   └── TeacherRepository.cs
│   └── SchoolManagement.Infraestructure.csproj
└── SchoolManagement.Tests
    ├── Controllers
    │   └── StudentControllerTest.cs
    ├── Endpoints
    │   ├── CourseEndpointsTest.cs
    │   └── StudentEndpointsTest.cs
    ├── Entities
    │   ├── CourseTest.cs
    │   └── SudentTest.cs
    ├── GlobalUsings.cs
    ├── SchoolManagement.Tests.csproj
    └── Services
        ├── CourseServiceTest.cs
        └── StudentServiceTest.cs

```
## Diagramas:
Casos de uso:
![alt text](casos-uso-HU2.png)

Diagrama de clases:
![alt text](class-diagram.png)

Diagrama de referencias:
![alt text](diagrama-referencias.png)

## Roles:
[text](.idea/EVALUACION.md)

## Como ejecutar el proyecto:
