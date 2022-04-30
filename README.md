# Exchange
This project has been developed like a microservice architecture but just include one service for now. The project needs PostgreSQL and .Net 5.0. But don't worry about installment steps, there is no necessary to install all parts of these. This project needs only one requirement which is [Docker Desktop](https://www.docker.com/products/docker-desktop).

## Tech
- .Net 5.0
- PostgreSQL

## Build with Docker
[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)
- First of all we need to go `docker-compose.yml` 's path on our console.

     ![image](https://user-images.githubusercontent.com/38660944/153429140-2a93897b-b711-4b3b-9c5b-62eab8c613ee.png)
     
- We can start build and install parts,  to do that we just write below command.
  ```sh
  docker-compose up --build -d 
  ```
- This build time can take some time to install some images as I said, just wait until see below picture.

     ![image](https://user-images.githubusercontent.com/38660944/153429324-118125b7-196f-4b82-90a3-e313dacab4be.png)

- This step provides everything what we need for our system. When containers go up, Some seed datas will add simultaneously like products.

## About
- [PostgreSQL DB](http://localhost:26002) is running on   `localhost:26002`
- [PgAdmin for PostgreSQL](http://localhost:26003/) is running on `localhost:26003` with `username:admin@packaging` `password:admin`
- [Packaging](http://localhost:26101/swagger) is running on `localhost:26101`

## Test
  ![image](https://user-images.githubusercontent.com/38660944/153429737-1707d7b8-7c1b-4b8f-821b-ae8ad1d54630.png)  
  
  All of these API's can provide what we will need to do some tests.


