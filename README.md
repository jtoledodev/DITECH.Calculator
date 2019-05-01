# DITECH.Calculator
Implementación del servicio de calculadora HTTP/REST 

### Pre-requisitos

* NET core 2.1.2
* Visual Dtudio Community 2019

## Capas

### Calculator.Api

Componente de servicios

### Calculator.Api.Consumer

Componente usado por la aplicacion de escritorio para el llamado de servicios 

### Calculator.Api.Core

Logica del negocio

### Calculator.CConsole

Programa de consola capaz de hacer peticiones HTTP

### Calculator.Entities

Modelo con las variables usadas en el sistema

## Componentes Usados

Para el llamado de los servicios se usa la libreria RestSharp (http://restsharp.org/)
El guardado de las operaciones se registra con el componente litedb (https://www.litedb.org)
los logs del accesos se uso serilog (https://github.com/serilog/serilog)

Las variables de configuración de estos componentes se encuentran en el proyecto "Calculator.Api" en el archivo "appsettings.json"

## Ejecutar

Antes de ejecutar verificar la url de llamado http desde la aplicacion de consola 
La url se encuentra en "Calculator.Api" en "propiedades" en el archivo "launchSettings.json"

Para ejecutar la aplicacion se deben ejecutar los siguientes pasos:

Ingresar a las propiedades de la solución y seleccionar 
* Propiedades cumunes
* Proyecto de inico

Seleccionar proyectos de inicio mutiples

* Para los proyectos "Calculator.Api" y "Calculator.CConsole" escoger la opcion iniciar

* Para los demas dejar ninguna

* Finalmente ejecutar la solución



