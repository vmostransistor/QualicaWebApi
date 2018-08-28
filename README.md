# QualicaWebApi
Technical evaluation
Create a restful web API that uses C# .net core 2.1 SDK (or later). The API should perform the methods as described below. The data created and accessed through should be stored in a database. There is no user interface for this, it is only a web API and database.

Here is a list of methods that the API needs to perform:
API	Description	Request Body	Response Body	Response HTTP Code
GET /api/transaction	Get a list of all of the transactions in the database.
This should return the transactions in a JSON body	None	JSON array of all transactions	200 when successful
500 when an error occurs
GET /api/transaction/{id}	Get the transaction using the ID	None	A single transaction in JSON format	200 when successful
400 when the ID is invalid
500 when an error occurs
POST /api/transaction	Create a new transaction	A JSON object that contains all the fields needed by the transaction (see below for a definition of a transaction)	The newly created transaction object with it's ID field populated	201 when successful
400 when fields are invalid
500 when an error occurs
PUT /api/transaction/{id}	Update an existing transaction identified by the ID	The JSON object that contains the updated transaction object	None	200 when successful
400 when input is invalid
500 when an error occurs
DELETE /api/transaction/{id}	Delete a transaction as identified by the ID	None	None	200 when successful
400 when input is invalid
500 when an error occurs


Here is a suggested definition of a simplified transaction (you are welcome to adapt this)

Field Name	Field Type	Description
ID	integer	Uniquely identifies the transaction
Reference	String	A reference for the transaction
Transaction_date	DateTime	The date and time of the transaction
Amount	Double	The transaction amount
From_Account	GUID	The reference to the account that the transaction was taken from
To_Account	GUID	The reference to the account that the transaction was paid to
