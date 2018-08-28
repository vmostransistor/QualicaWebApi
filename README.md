# QualicaWebApi
Technical evaluation
Created a restful web API that uses C# .net via ASP.NET and EntityFramework. The data created and accessed is stored in a local database. There is no user interface for this, it is only a web API and database.

# GET /api/transaction
- Get a list of all of the transactions in the database. This should return the transactions in a JSON body
- Request: None
- Reply: JSON array of all transactions	
- Status: 200 when successful, 500 when an error occurs

# GET /api/transaction/{id}	
- Get the transaction using the ID	
- Request:None	
- Reply: A single transaction in JSON format	
- Status: 200 when successful, 400 when the ID is invalid, 500 when an error occurs

# POST /api/transaction
- Create a new transaction
- Request: A JSON object that contains all the fields needed by the transaction (see below for a definition of a transaction)	
- Reply: The newly created transaction object with it's ID field populated	
- Status: 201 when successful, 400 when fields are invalid, 500 when an error occurs

# PUT /api/transaction/{id}
- Update an existing transaction identified by the ID
- Request: The JSON object that contains the updated transaction object	
- Reply: None	
- Status: 200 when successful, 400 when input is invalid, 500 when an error occurs

# DELETE /api/transaction/{id}
- Delete a transaction as identified by the ID
- Request: None	
- Reply: None	
- Status: 200 when successful, 400 when input is invalid, 500 when an error occurs


# Model - Transaction


public class Transaction
{
    public int ID { get; set; }
    public string Reference { get; set; }
    public DateTime Transaction_date { get; set; }
    public double Amount { get; set; }
    public Guid From_Account { get; set; }
    public Guid To_Account { get; set; }
}
