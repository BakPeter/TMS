# TMS

TMS is a Ticket Management System.
The systems comprised of BE, FE, Infrastructure, and Docs.

## Table of content

- [BE](#be)
- [FE](#fe)
- [Infrastruture](#infrasturutre)
- [Docs](#docs)

## BE

**[`^ top ^`](#tms)** | **[`^ Table of content ^`](#table-of-content)**

Comprised of two main parts implemented in .net8

- BFF - Backend For Frontend

  REST Api

  Implements Clean Architecture, SOLID principles.

  Comprised of 3 files:

  - TMS.BFF.exe

    REST API

  - TMS.Core.dll

    Contrains all the abstraction and models

  - TMS.Infrastructure

    Conatins Abstractions implemetations, additioanl required Types and extension method for service IOC registrations

- Reposity

  Generic Repository Implementation

  Implements Clean Architecture, SOLID principles.

  Comprised of 2 files:

  - Repository.Core.dll

    Contrains all the abstraction and models

  - Repository.Infrastructure

    Conatins Abstractions implemetations, additioanl required Types and extension method for service IOC registrations

  - Requirements:

    - IOC registraion of an implemention of `interface IRepositoryAdapter<TEntity> where TEntity : class`

      This is the repoisty type, could be cached, sql, no sql etc.
      No Default implementation, and its a must.

    - IOC registraion of an implementions of `interface IEntityValidator<TEntity> where TEntity : class.
      Repository entity type validations.
      If no validator register, no validation will be executed when updating the repository

## FE

**[`^ top ^`](#tms)** | **[`^ Table of content ^`](#table-of-content)**

Web based GUI

Implemented in Angular 20.

Implements routing

Comprised 0f 3 Componets:

- ticket-viewer

  for single Ticket rendring

- tickets-viewer
  uses ticket-viewer component every ticket, for a list of tickets rendering

- add-new-ticket

  for new tickets form rendering
  NOT IMPLEMENTED

## Infrastruture

**[`^ top ^`](#tms)** | **[`^ Table of content ^`](#table-of-content)**

App deployment to docker using docker-compose
NOT IMPLEMENTED

## Docs

- TMS.drawio - preliminary BE designs

**[`^ top ^`](#tms)** | **[`^ Table of content ^`](#table-of-content)**
