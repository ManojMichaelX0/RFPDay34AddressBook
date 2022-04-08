CREATE Procedure [dbo].[SPAddressBook]
(
@FirstName varchar(50),
@LastName varchar(50),
@_address varchar(50),
@City varchar(50),
@_State varchar(50),
@Zip int ,
@PhoneNumber varchar(12),
@email varchar(50),
@RElationType varchar(20),
@StartDate datetime
)
As
Begin
Insert into Address_Book_Table values(@FirstName,@LastName,@_address,@City,@_State,@Zip,@PhoneNumber,@email,@RElationType,@StartDate)
SET NOCOUNT ON
End
