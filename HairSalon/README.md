# _Eau Claire's Hair Salon_

#### _Web app with database that keeps track of stylists and their clients, 1.17.2020_

#### By _**Will Quanstrom**_

## Description

_A salon owner is able to add stylists to a database and have those stylists listed on their webiste. Then, they are able to add clients for each of those individual stylists and have those records stored and accessible through the web app._

## Setup/Installation Requirements

* _Clone from github repository._
* _Command in terminal "dotnet restore" to restore dependencies._
*_Open MySQL workbench._
*_Create a new schema in the connected server._
*_In the new schema, create a table for "stylist." Create columns as follows (StylistId serial PRIMARY KEY, Name VARCHAR(255), Details VARCHAR(255)). Click Apply to save table._
*_Create another table called "client". Create columns as follows (ClientId serial PRIMARY KEY, SylistId int, Name VARCHAR (255)). Click apply._
*_Open program file in VSCode. Go into appsettings.json and change database to equal the name of your schema._
* _Command "dotnet run"_
* _Open local host in web browser and navigate through website._

## Specifications
| Specs  | Example Input  | Example Output  | 
|---|---|---|
| Salon owner is directed to splash page  | "localhost:5000"  | "Welcome Claire"  | 
| Salon owner can click link to show list of stylists.  | "See a list of stylists" | "Sara Johnson -- Rodrigo Cortez -- Allison Smith"  | 
| Salon owner can click on each stylist name, and see their details, and a list of their clients.  | "Sara Johnson"  | "Specializes in coloring", "Judy Blume -- Ron Howard -- The Rock"  | 
|"Salon owner can add new clients to each stylist."|"Click here to add a new client for Sara Johnson"|Owner is redirected to form page where they can fill out a new client that is added to the stylist's list.|

## Known Bugs

_None at this time._

## Support and contact details

_wquanstr215@gmail.com_

## Technologies Used

_C#, ASP.NET Core MVC, Razor, SQL_

### License

*MIT license 2020*

Copyright (c) 2020 **_Will Quanstrom_**