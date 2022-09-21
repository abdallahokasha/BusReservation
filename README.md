#### Bus Reservation System

Run the app using `dotnet run`

Update the database with created migrations `dotnet ef database update`

We can check existing API using [swagger](https://localhost:7032/swagger/index.html) after running the app.

We can also try it through [postman collection](https://github.com/abdallahokasha/BusReservation/blob/master/BusReservation.postman_collection.json) or the following `curl` request.

Add reservation request:
```
curl --location --request POST 'https://localhost:7032/api/1.0/Reservations/Add' \
--header 'token: gjSkeBTp0dMTJVsR70ZJmg==' \
--header 'Content-Type: application/json' \
--data-raw '{
  "userEmail": "abc@xyz.com",
  "seatsNumbers": [1, 2],
  "busNumber": 1
}'
```
Get frequent trip request:

```
curl --location --request GET 'https://localhost:7032/api/1.0/Reservations/FrequentUsersTrips' \
--header 'token: gjSkeBTp0dMTJVsR70ZJmg=='
```
