# EShopMicroservices

Overview

This project demonstrates how to build scalable and robust microservices on the .NET platform. The implementation utilizes a wide range of modern tools, libraries, and patterns, including:

ASP.NET Web API

Docker

RabbitMQ and MassTransit for message-driven communication

gRPC for high-performance service communication

YARP API Gateway for reverse proxy and API composition

Databases: PostgreSQL, Redis, SQLite, SQL Server, and Marten

Architectural Patterns: CQRS, DDD, Vertical Slice Architecture, and Clean Architecture

All services adhere to the best practices of .NET 8 and are built for cloud-native environments.

Features

Microservices Architecture

This project contains multiple e-commerce modules and services, including:

1. Catalog Microservice

ASP.NET Core Minimal APIs with the latest .NET 8 and C# 12 features

Vertical Slice Architecture implemented with feature folders

CQRS using the MediatR library

Validation pipeline behaviors with MediatR and FluentValidation

Transactional document database support with the Marten library on PostgreSQL

Minimal API endpoint definitions with Carter

Cross-cutting concerns: logging, global exception handling, and health checks

Dockerfile and docker-compose for multi-container Docker environments

2. Basket Microservice

Built with ASP.NET 8 Web API, following RESTful API principles

CRUD operations using Redis as a distributed cache (basketdb)

Implements design patterns: Proxy, Decorator, and Cache-aside

Inter-service communication with Discount gRPC Service for product price calculations

Publishes BasketCheckout Queue using MassTransit and RabbitMQ

3. Discount Microservice

Built with ASP.NET gRPC Server

High-performance inter-service gRPC communication with the Basket microservice

Protobuf message definitions for gRPC services

Data persistence with Entity Framework Core and SQLite

SQLite containerization and database migration setup

Technologies Used

.NET 8 for microservices development

C# 12 for modern and clean coding standards

Docker for containerization

RabbitMQ and MassTransit for event-driven architecture

gRPC for service-to-service communication

YARP API Gateway for API composition and reverse proxy

Redis for distributed caching

PostgreSQL DocumentDB and SQLite for NoSQL and relational data storage

CQRS and MediatR for command-query separation

FluentValidation for input validation

Marten for transactional document database support
