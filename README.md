# RetailSample
.Net Retail Microservice  Sample

### .Net Core 6 Microservice Sample With C# .Net and Entityframework Core
* [Introduction](#Introduction)
* [Application Architecture](#Application-Architecture)
* [Development Environment](#Development-Environment)
* [Technologies](#Technologies)
* [Opensource Tools Used](#Opensource-Tools-Used)
* [Model Design](#Model-Design)
* [WebApi Endpoints](#WebApi-Endpoints)
* [Test Results](#Test-Results)
* [Postman Collection](#Postman-Collection)
* [How to run the application](#How-to-run-the-application)
---
## Introduction
This is a .Net Core sample application and an example of how to build and implement a microservices based back-end system for a simple automated banking feature like Balance, Deposit, Withdraw in ASP.NET Core Web API with C#.Net, Entity Framework and SQL Server. 

## Application Architecture

The application is built based on the microservice architecture. The Service architecture is as follows.

- **Customer Microservice** - Enables creating, updating, deleting and listing customers.
- **Invoice Microservice** - Creates invoice from bill, calculates discounts, listing invoices and delete invoice
- **API Gateway** - Gateway Api for Customer and Invoice Microservices

## Development Environment

- [.Net Core 6 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio .Net 2022](https://visualstudio.microsoft.com/downloads/)

## Technologies
- C#.NET
- ASP.NET WEB API Core

## Opensource Tools Used
- Automapper 
- EntityFramework Core
- XUnit 
- Ocelot

## Model Design

Customer Model Diagram

![Model Design](https://github.com/omerfarukkologlu/RetailSample/raw/main/diagram/Customer_Diagram.png)

Invoice Model Diagram

![Model Design](https://github.com/omerfarukkologlu/RetailSample/raw/main/diagram/Invoice_Diagram.png)

## WebApi Endpoints

### API Gateway Endpoints

1. Route: **"/customer"** [Get] - Get all customers
2. Route: **"/customer/{Id}"** [Get] - Get customer by Id
3. Route: **"/customer"** [Post] - Create customer
4. Route: **"/customer"** [Put] - Update customer
5. Route: **"/customer/{Id}"** [Delete] - Delete customer
6. Route: **"/invoice"** [Post] - Create invoice
7. Route: **"/invoice"** [Get] - Get all invoices
8. Route: **"/invoice/{Id}"** [Get] - Get invoice by Id
9. Route: **"/invoice/{Id}"** [Delete] - Delete invoice

### Customer Microservice Api Endpoints

1. Route: **"/api/customer"** [Get] - Get all customers
2. Route: **"/api/customer/{Id}"** [Get] - Get customer by Id
3. Route: **"/api/customer"** [Post] - Create customer
4. Route: **"/api/customer"** [Put] - Update customer
5. Route: **"/api/customer/{Id}"** [Delete] - Delete customer

### Invoice Microservice Api Endpoints

1. Route: **"/invoice"** [Post] - Create invoice
2. Route: **"/invoice"** [Get] - Get all invoices
3. Route: **"/invoice/{Id}"** [Get] - Get invoice by Id
4. Route: **"/invoice/{Id}"** [Delete] - Delete invoice

## Test Results
![Test Results](https://github.com/omerfarukkologlu/RetailSample/raw/main/diagram/Test_Results.png)

You can use "Run Tests" options in Visual Studio.

## Postman Collection

Download the postman collection from [here](https://www.getpostman.com/collections/215426f0cbb9bbd736da) to run the api endpoints through gateway

## How to run the application

1. Clone this repository, 
2. Open the solution (.sln) in Visual Studio 2022
3. Run the following projects in the solution
    - Customer.WebApi
    - Invoice.WebApi
    - Gateway.WebApi
