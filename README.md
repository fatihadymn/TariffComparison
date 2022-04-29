# TariffComparison
This project has been developed like a microservice architecture but just include one service for now. The project needs PostgreSQL and .Net 5.0 but don't worry about installment steps, there is no necessary to install all parts of these. This project needs only one requirement which is [Docker Desktop](https://www.docker.com/products/docker-desktop).

## Tech
- .Net 5.0
- PostgreSQL

## Build with Docker
[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)
- First of all we need to go `docker-compose.yml` 's path on our console.

     ![image](https://user-images.githubusercontent.com/38660944/165913810-643f802c-f64a-4bdf-9da2-b0eb6a544451.png)
     
- We can start build and install parts,  to do that we just write below command.
  ```sh
  docker-compose up --build -d 
  ```
- This build time can take some time to install some images as I said, just wait until see below picture.

     ![image](https://user-images.githubusercontent.com/38660944/165913928-0ff37524-3d15-4fa4-a077-4b9ab29b053e.png)

- This step provides everything what we need for our system. When containers go up, Some seed datas will add simultaneously like basic tariff and packaged tariff.

## About
- [PostgreSQL DB](http://localhost:56002) is running on   `localhost:56002`
- [PgAdmin for PostgreSQL](http://localhost:56003/) is running on `localhost:56003` with `username:admin@tariffcomparison` `password:admin`
- [TariffComparison](http://localhost:56101/swagger) is running on `localhost:56101`

## Test  
  ![image](https://user-images.githubusercontent.com/38660944/165914455-6cf95f96-6ee0-494a-a7a3-4f752d22e5d3.png)
  
  We have just one API and it calculate the tariff annual costs.


