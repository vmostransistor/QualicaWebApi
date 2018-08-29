# QualicaWebApi
Created a restful web API that uses C# ASP.NET with EntityFramework. The data created and accessed is stored in a local database. There is no user interface for this, it is only a web API and database.

## GET /api/transaction
- Get a list of all of the transactions in the database. This should return the transactions in a JSON body
- Request: None
- Reply: JSON array of all transactions	
- Status: 200 when successful, 500 when an error occurs

## GET /api/transaction/{id}	
- Get the transaction using the ID	
- Request:None	
- Reply: A single transaction in JSON format	
- Status: 200 when successful, 400 when the ID is invalid, 500 when an error occurs

## POST /api/transaction
- Create a new transaction
- Request: A JSON object that contains all the fields needed by the transaction (see below for a definition of a transaction)	
- Reply: The newly created transaction object with it's ID field populated	
- Status: 201 when successful, 400 when fields are invalid, 500 when an error occurs

## PUT /api/transaction/{id}
- Update an existing transaction identified by the ID
- Request: The JSON object that contains the updated transaction object	
- Reply: None	
- Status: 200 when successful, 400 when input is invalid, 500 when an error occurs

## DELETE /api/transaction/{id}
- Delete a transaction as identified by the ID
- Request: None	
- Reply: None	
- Status: 200 when successful, 400 when input is invalid, 500 when an error occurs


## Model - Transaction

Field Name | Field Type | Description
--- | --- | ---
ID | integer | Uniquely identifies the transaction
Reference | String | A reference for the transaction
Transaction_date | DateTime | The date and time of the transaction
Amount | Double | The transaction amount
From_Account | GUID | The reference to the account that the transaction was taken from
To_Account | GUID | The reference to the account that the transaction was paid to

