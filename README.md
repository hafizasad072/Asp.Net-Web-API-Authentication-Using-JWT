# Asp.Net-Web-API-Authentication-Using-JWT

## JWT.WebAPI
Write Contrller to Get JWT Token by passing username and password. JWT Token generated using username. I alos write custom filter for autheticate Web API request on books controller.

## Helper Model
In this library we have business classes for login and books.

## DB
This library contain EDMX, DB Context and Entity classes.

## Sample Request

### Get Tocken
 Request Type: POST  
 URL: http://localhost:60917/api/Token/GetToken  
 Body data: {'Username':'username','Password':'pass'}

### Get Books
Request Type: GET  
URL: http://localhost:60917/api/AttendanceConfig/GetAllSetup  
 Request Header: Authorization = Bearer Generated Token here

