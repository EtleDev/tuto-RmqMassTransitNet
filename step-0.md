# Step 0 - Play with RabbitMQ interface

---

___

## First steps on RabbitMQ

* Mount the stack with the following command :
`docker-compose up -d`
* With your favourite web browser, go to : `https://localhost:15672`
* Log in with :
  ```
  login : guest
  password : guest
  ```
* Welcome on RabbitMQ interface

## Presentation

## Pre-requisites
- docker
- docker compose
- Visual Studio OR Visual Studio Code
- .NET 6

## Step 0 - Play with RabbitMQ interface
0. Initilization docker-compose
1. Créer une file
2. Créer un exchange direct pour une file
3. Créer un exchange direct pour 2 files
4. Créer un exchange direct pour plusieurs files avec routing key
5. Créer un exchange topic avec routing key
6. Créer un exchange fanout
7. Enchainer plusieurs exchanges
8. Dead letter exchange
9. Dead letter exchange avec routing key
## Step 1 - Sending a message
1. Projet console
2. Evolution vers une API
## Step 2 - Receive a message
1. Projet console - point-to-point
2. Projet console - Publish/subscribe

## Step 3 - Answer a request - Request Pattern
1. API - console
## Step 4 - Advanced knowledge
1. Skipped_queue
2. Error_queue
3. Retry pattern
4. Consommer les erreurs