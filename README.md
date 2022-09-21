#### Bus Reservation System

Run the app using `dotnet run`

Update the database with created migrations `dotnet ef database update`

We can check existing API using [swagger](https://localhost:7032/swagger/index.html) after running the app.

Add reservation request example
```
curl --location --request POST 'https://localhost:7032/api/1.0/Reservations/Add' \
--header 'token: gjSkeBTp0dMTJVsR70ZJmg==' \
--header 'Content-Type: application/json' \
--data-raw '{
  "userEmail": "abc@xyz.com",
  "seatsNumbers": [
    1, 2
  ],
  "busNumber": 1
}'
```

