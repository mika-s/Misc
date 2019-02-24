# SQL Cheat Sheet

Based on T-SQL for Microsoft SQL Server.

## Shortcuts in SSMS

| Name                  | Description                                                                        |
|-----------------------|------------------------------------------------------------------------------------|
| CTRL+E or F5          | Highlighted code is executed.                                                      |
| ALT+F1                | Metadata is shown for highlighted table. Shows all objects if nothing highlighted. |
| CTRL+R                | Show/hide the query results.                                                       |
| CTRL+SHIFT+R          | Refresh the cache.                                                                 |

## Change database

```sql
USE databaseName
```

## Declaring variables

```sql
DECLARE @varaibleName1 INT
DECLARE @variableName2 VARCHAR(30)
```

## Initialize variables

```sql
SET @variableName1 = 1
SET @variableName2 = 'asdf'
```

## Declare and initialize at the same time

```sql
DECLARE @variableName1 INT = 1
```

## Execute stored procedures

```sql
EXECUTE uspStoredProc1 @arg1 = 123, @arg2 = 'asdf', @arg3 = @myVar
EXEC uspStoredProc1 @arg1 = 123, @arg2 = 'asdf', @arg3 = @myVar
```

Executing and storing return value:

```sql
EXEC @rc = uspUpdateCity @city
```

## Query

### Simple

```sql
SELECT *
FROM tableX
WHERE columnY = 'asdf'
```

### Store selected values in variable

```sql
DECLARE @firstName VARCHAR(30)

SELECT
    @firstName = firstName
FROM accounts
WHERE
    id = 1234
```

### Rename column in displayed result

```sql
SELECT
    CompDtNameAL AS [Money sent]
FROM accounts
```

### Top X

```sql
SELECT TOP 100 *
FROM accounts
```

### Order by

```sql
SELECT *
FROM accounts
ORDER BY id DESC
```

```sql
SELECT *
FROM accounts
ORDER BY id ASC
```

### Like

Use ```LIKE``` to do simple text searches in a column. ```%``` is a wildcard (like *).

```sql
SELECT
    firstName,
    lastName
FROM accounts
WHERE address LIKE 'Karl Johans gate%'
```

Use `[]` to escape special characters. E.g. `[%]`. To change escape character, use e.g.
`ESCAPE '\'`.

```sql
SELECT * FROM accounts WHERE parameter LIKE '%\[street\]' ESCAPE '\' 
```

Other wildcard characters:

- `_` : Any single character.
- `[]` : Any single character within the specified range.
- `[^]` : Any single character not within the specified range.

### Between two dates

```sql
SELECT *
FROM accounts
WHERE LastLoginDateTime BETWEEN '2018-01-01 00:00:00' AND '2018-02-28 23:59:59'
```

## Delete

To delete all rows in a table, use ```TRUNCATE TABLE```, not delete, as this is faster  
and uses fewer resources.

### Simple delete with where clause

```sql
DELETE FROM accounts WHERE id = 2
```

### Delete with left join

When using join with delete you have to use FROM twice. See [this](https://stackoverflow.com/questions/8011197/how-can-a-sql-query-have-two-from-clauses)
Q&A on Stack Overflow to see why.

```sql
DELETE FROM accounts
	FROM accounts a
	LEFT JOIN customer c ON a.customerid = c.id
WHERE a.id = 2
```

## Copy tables

### Where new table doesn't exist

```sql
SELECT * INTO newtable
FROM oldtable
WHERE condition
```

### Where new table exists already

```sql
INSERT INTO newtable SELECT * FROM oldtable WHERE condition
```

## Joins

### Inner join

To get data that is linked to other tables.

```sql
SELECT *
FROM accounts a
INNER JOIN accounttypes at ON a.accounttype = at.accounttype
```

### Left outer join

Getting elements that are in A, but not B.

```sql
SELECT ao.*
FROM accountsOld ao
	LEFT JOIN accounts a ON ao.id = a.id
WHERE a.id IS NULL
```

### Right outer join

## Inserting

```sql
INSERT INTO accounts (firstName, lastName, age) VALUES ('Ola', 'Nordmann', 22)
```

## Updating

Update one column:

```sql
UPDATE accounts SET address1 = 'Karl Johansgate 7' WHERE AccountID = 123
```

Update multiple columns:

```sql
UPDATE accounts
SET
    address1 = 'Karl Johansgate 1',
    address2 = 'C/O The King'
WHERE AccountID = 1
```

## Transactions

Rollback a transaction:

```sql
BEGIN TRANSACTION

ROLLBACK TRANSACTION
```

Commit a transaction:

```sql
BEGIN TRANSACTION

COMMIT TRANSACTION
```

## Creating

### Table

Basic ordinary table:

```sql
CREATE TABLE employees  
(  
    id int IDENTITY(1,1),  
    firstName varchar(20),  
    lastName  varchar(30),  
    birthDate date
)
```

## Stored procedures

- Has to return a value.

## Functions

- Don't put business logic in functions.

## Dynamic SQL

Dynamic SQL is when the queries to execute are built dynamically.

The ordinary method:

```sql
DECLARE @id	int = 200

SET @SqlCommand = N'SELECT *
	FROM employees
	WHERE id = ' + id

EXECUTE (@SqlCommand)
```

The parameterized version:

```sql
DECLARE @id  int = 200
DECLARE @age int = 25

SET @SqlCommand = N'SELECT *
	FROM employees
	WHERE id = @id AND age > @age' 

EXECUTE sp_executesql @SqlCommand,
	N'@id int, @age int',
	@id, @age
```

Table and schema names can not be parameterized. The ordinary method
has to be used for these cases.

## Test scripts

```sql
BEGIN TRANSACTION TestTransaction

DECLARE @TestNumber INT
DECLARE @ExpectedReturn INT

SET @TestNumber     = 1
SET @ExpectedReturn = 0

IF @Results != @ExpectedReturn
	RAISERROR('Test %d failed on result value. Expected: %d, received: %d', 16, @TestNumber, @TestNumber, @ExpectedReturn, @Results)

ROLLBACK TRANSACTION TestTransaction
```

## Debugging

The following functions can help with debugging:

- `ERROR_PROCEDURE()`
- `ERROR_LINE()`
- `ERROR_MESSAGE()`

They can be used to pinpoint where the error is located.

## Prevent insert to table from being rolled back

http://www.sqlservercentral.com/blogs/steve_jones/2010/09/21/table-variables-and-transactions/

## Special functions

### COALESCE

Evaluates the arguments in order and returns the current value of the first expression that initially does not
evaluate to NULL. For example, `SELECT COALESCE(NULL, NULL, 'third_value', 'fourth_value');` returns the third value
because the third value is the first value that is not null.

### CONVERT

[Documentation](https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql?view=sql-server-2017)


```sql
CONVERT(type, variable)
```

Example:

```sql
DECLARE @StoreId INT = 1234

PRINT CONVERT(varchar, @StoreId)
```

Length can also be specified: `varchar(100)`.

`CONVERT` has a third optional parameter that can be used to format the new varchar. This can, for example, be
used for datetimes:

```sql
PRINT CONVERT(VARCHAR, GETDATE(), 101) -- 08/15/2018
PRINT CONVERT(VARCHAR, GETDATE(), 111) -- 2018/08/15
```

### CAST

[Documentation](https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql?view=sql-server-2017)

`CAST` is pretty much the same as `CONVERT`. `CAST` is ANSI-SQL, while `CONVERT` is not. `CONVERT` has an optional
third parameter that can be used to format varchars, usually datetimes. `CAST` does not.

Example:

```sql
CAST(9.5 AS int)
CAST(123 AS varchar)
```

### ISNULL

Return the value in the second argument if the first is NULL:

```sql
ISNULL(variable, replace_value)
```

Example:

```sql
ISNULL(@OptionalValue, '')
```

## Special tables

```sql
#localTemporaryTable
##globalTemporaryTable
```

## Built-in functions

| Name                      | Description                                      |
|---------------------------|--------------------------------------------------|
| IF                        |                                                  |
| RAISERROR                 | Raise an error.                                  |
| SUM                       | Sum all the values in a column.                  |
| GETDATE                   | Get the current DB system timestamp as datetime. |
| ROW_NUMBER                | Get the row number (in a select for example).    |
| DATEDIFF                  | Difference between two datetimes.                |
| SYSTEM_USER               | Returns the username.                            |
| NEWID						| Generate uniqueidentifier.					   |
| DB_NAME					| Name of the database.							   |

Get days between a date and today:

```sql
SELECT DATEDIFF(day, '2017-11-23 13:13:33.000', GETDATE())
```

## Global variables

| Name              | Description                                      |
|-------------------|--------------------------------------------------|
| @@SERVERNAME      | Name of the server.                              |
| @@ROWCOUNT        | Number of rows affected in the last operation.   |


## Delete temporary table if it exists already

Place this at the top of the procedure.

```sql
IF OBJECT_ID('tempdb..#Params') IS NOT NULL DROP TABLE #Params
```

## sqlcmd

[sqlcmd on MS Docs](https://docs.microsoft.com/en-us/sql/tools/sqlcmd-utility)

## bcp

[bcp on MS Docs](https://docs.microsoft.com/en-us/sql/tools/bcp-utility)

*The bulk copy program utility (bcp) bulk copies data between an instance of Microsoft SQL Server and a data file in a user-specified format.*

```sh
cmd /k bcp "SELECT data FROM DatabaseName.dbo.TableName WHERE id=1" queryout C:\out\data.xml -e C:\out\err.dat -w -T -S servername
```

### Run script on server

```
sqlcmd -S servername -i script.sql
```

## Relationships

### One-to-one

### One-to-many

### Many-to-many

- Junction table.

## Normal forms

### First normal form (1NF)

**No repeating groups.**

[Wikipedia](https://en.wikipedia.org/wiki/First_normal_form)

- Eliminate repeating groups in individual tables.
- Create a separate table for each set of related data.
- Identify each set of related data with a primary key

- Atomic data.

**E.g. a customer table with telephone numbers:**

Table that doesn't comply with 1NF:

| CustomerID | FirstName   | LastName  | TelephoneNo                             |
|------------|-------------|-----------|-----------------------------------------|
| 1          | "Nick Pete" | "Stevens" | "555-861-2025, 192-122-1111"            |
| 2          | "Susan"     | "Smith"   | "(555) 403-1659 Ext. 53; 182-929-2929"  |
| 3          | "Alan"      | "Walker"  | "555-808-9633"                          |

Table that complies with 1NF:

| CustomerID | FirstName   | LastName  | TelephoneNo                             |
|------------|-------------|-----------|-----------------------------------------|
| 1          | "Nick Pete" | "Stevens" | "555-861-2025"                          |
| 1          | "Nick Pete" | "Stevens" | "192-122-1111"                          |
| 2          | "Susan"     | "Smith"   | "(555) 403-1659 Ext. 53"                |
| 2          | "Susan"     | "Smith"   | "182-929-2929"                          |
| 3          | "Alan"      | "Walker"  | "555-808-9633"                          |

The CustomerID is no longer unique. To uniquely identify a row we have to use a 
combination of CustomerID and telephone number.

### Second normal form (2NF)

**Each column must depend on the *entire* primary key.**

[Wikipedia](https://en.wikipedia.org/wiki/Second_normal_form)

A relation is in 2NF if it is in 1NF and every non-prime attribute of the relation
is dependent on the whole of every candidate key.

### Third normal form 

**Each column must depend on *directly* on the primary key.**

### Boyce-Codd normal form (BCNF or 3.5NF)

[Wikipedia](https://en.wikipedia.org/wiki/Boyce%E2%80%93Codd_normal_form)

Slightly stronger version of the 3NF.

### Fourth normal form

### Fifth normal form

### Sixth normal form

### Domain-key normal form

## Indexes

* [Clustered and non-clustered index on MSDN](https://docs.microsoft.com/en-us/sql/relational-databases/indexes/clustered-and-nonclustered-indexes-described?view=sql-server-2017)
* [What do clustered and non-clustered index actually mean (Stack Overflow)](https://stackoverflow.com/questions/1251636/what-do-clustered-and-non-clustered-index-actually-mean)

*An index is an on-disk structure associated with a table or view that speeds retrieval of rows from  
the table or view.*

If the table has no clustered index it is called a heap.

### Clustered index

*Clustered indexes sort and store the data rows in the table or view based on their key values.  
These are the columns included in the index definition. There can be only one clustered index per  
table, because the data rows themselves can be stored in only one order.*

*The only time the data rows in a table are stored in sorted order is when the table contains a  
clustered index. When a table has a clustered index, the table is called a clustered table.  
If a table has no clustered index, its data rows are stored in an unordered structure called a heap.*

### Non-clustered index

*Nonclustered indexes have a structure separate from the data rows. A nonclustered index contains  
the nonclustered index key values and each key value entry has a pointer to the data row that  
contains the key value.*

*The pointer from an index row in a nonclustered index to a data row is called a row locator.  
The structure of the row locator depends on whether the data pages are stored in a heap or a  
clustered table. For a heap, a row locator is a pointer to the row. For a clustered table, the  
row locator is the clustered index key.*

## Keys

## ACID

[Wikipedia](https://en.wikipedia.org/wiki/ACID)

From Wikipedia:

*ACID is a set of properties of database transactions intended to guarantee validity even in the  
event of errors, power failures, etc. In the context of databases, a sequence of database operations  
that satisfies the ACID properties, and thus can be perceived as a single logical operation on the data,  
is called a transaction.*

### Atomicity

*Atomicity requires that each transaction be "all or nothing": if one part of the transaction fails, then  
the entire transaction fails, and the database state is left unchanged. An atomic system must guarantee  
atomicity in each and every situation, including power failures, errors and crashes. To the outside world,  
a committed transaction appears (by its effects on the database) to be indivisible ("atomic"), and an  
aborted transaction does not happen.*

### Consistency

*The consistency property ensures that any transaction will bring the database from one valid state to  
another. Any data written to the database must be valid according to all defined rules, including  
constraints, cascades, triggers, and any combination thereof. This does not guarantee correctness  
of the transaction in all ways the application programmer might have wanted (that is the responsibility  
of application-level code), but merely that any programming errors cannot result in the violation of  
any defined rules.*

### Isolation

*The isolation property ensures that the concurrent execution of transactions results in a system  
state that would be obtained if transactions were executed sequentially, i.e., one after the other.  
Providing isolation is the main goal of concurrency control. Depending on the concurrency control  
method (i.e., if it uses strict – as opposed to relaxed – serializability), the effects of an  
incomplete transaction might not even be visible to another transaction.*

### Durability

*The durability property ensures that once a transaction has been committed, it will remain so,  
even in the event of power loss, crashes, or errors. In a relational database, for instance, once  
a group of SQL statements execute, the results need to be stored permanently (even if the database  
crashes immediately thereafter). To defend against power loss, transactions (or their effects)  
must be recorded in a non-volatile memory.*

### Two-phase commit

Two-phase commit is an algorithm that can be used in transactions.

- Commit request phase
- Commit phase

## Cursor

[Wikipedia](https://en.wikipedia.org/wiki/Cursor_(databases))
[Cursors on MS Docs](https://docs.microsoft.com/en-us/sql/t-sql/language-elements/cursors-transact-sql)

- A control structure that enables traversal over the records in a database.
- Similar to an iterator in programming languages.
- A pointer to one row in a set of rows.

```sql
DECLARE @Name VARCHAR(40)

DECLARE cursor_test CURSOR FOR
	SELECT TOP 10 Name FROM accounts

OPEN cursor_test

FETCH NEXT FROM cursor_test INTO @Name

WHILE @@FETCH_STATUS = 0  
BEGIN   
   PRINT @Name

   FETCH NEXT FROM cursor_test INTO @Name
END  


CLOSE cursor_test
DEALLOCATE cursor_test
```

## Trigger

Triggers are special stored procedures that are connected to tables. Triggers can be set to fire when INSERT,  
UPDATE, DELETE and similar statements are used on a table. Triggers are often used to maintain the integrity
of the table.

Triggers use virtual tables that are called *inserted* and *deleted*. The rows that are supposed to be deleted  
or inserted are put in these tables first. The trigger will then act on these tables to check whether the rows  
should be inserted/deleted or not.

- Triggers should not be used for ordinary integrity checks. Native constraints (check contraints, uniqueness,  
etc.) should be used instead. This is because triggers have a performance overhead.

```sql
CREATE TRIGGER dbo.accounts_trgi ON dbo.accounts  AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON
	
	IF EXISTS(SELECT 1 FROM inserted 
				WHERE firstName = '' OR lastName = '')
		BEGIN
		  RAISERROR('accounts_trgi: The first name or last name cannot be blank.', 16, 1)
		  ROLLBACK TRAN
		  RETURN
		END
		
	IF EXISTS(SELECT 1 FROM inserted i
                INNER JOIN accounts a ON a.SSN = i.SSN)
		BEGIN
		  RAISERROR('accounts_trgi: Person already exists with that SSN.', 16, 1)
		  ROLLBACK TRAN
		  RETURN
		END
END

GO

ALTER TABLE dbo.accounts ENABLE TRIGGER accounts_trgi
GO
```

## Connect to LocalDB

LocalDB is a local database running on the computer if SQL Server is installed.  
It can be used for development etc.

As server: (LocalDb)\MSSQLLocalDB

## Call stored procedure in .NET

Stored procedure with two output parameters:

```cs
SqlCommand cmd = new SqlCommand("spProcedureName", Connection);

cmd.CommandType = CommandType.StoredProcedure;
cmd.Parameters.Add(new SqlParameter { ParameterName = SqlParameter1, DbType = DbType.Int32, Direction = ParameterDirection.Output });
cmd.Parameters.Add(new SqlParameter { ParameterName = SqlParameter2, DbType = DbType.Int32, Direction = ParameterDirection.Output });

SqlDataReader sdr = cmd.ExecuteReader();
```