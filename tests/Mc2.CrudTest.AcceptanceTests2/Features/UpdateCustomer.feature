Feature: UpdateCustomer

A short summary of the feature

@UpdateSuccesfully
Scenario: Update customer successfully when data is valid
	Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
	Then Update result should be succeeded
	
	Examples:
		| Id |  FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 3  |  Amir      | Asadnezhad      | 1991-02-02  | +989306030639 | yassin@ggmail.com     | 6280231377560890  |


Scenario: Update customer when first name is small
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update result should be failed
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 3  | Am        | Asadnezhad      | 1991-02-02  | +989306030639 | yasin@ggmail.com     | 6280231377560890  |
  

Scenario: Update customer when last name is small
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update result should be failed
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 3  | Amir      | As              | 1991-02-02  | +989306030639 | yasin@ggmail.com     | 6280231377560890  |
  

Scenario: Update customer when email is invalid
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update result should be failed
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 3  | Amir      | Asadnezhad      | 1991-02-02  | +989306030639 | yasin                | 6280231377560890  |
  
Scenario: Update customer with invalid phone number
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update result should be failed
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 3  | Amir      | Asadnezhad      | 1991-02-02  | +98930        | yasin@ggmail.com     | 6280231377560890  |
  

Scenario: Update customer with invalid bank account number
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update result should be failed
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 3  | Amir      | Asadnezhad      | 1991-02-02  | +989306030639 | yasin@ggmail.com     | 6280              |
 
		
Scenario: Update customer when email is repeated 
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update result should be failed
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 3  | Amir      | Asadnezhad      | 1991-02-02  | +989306030639 | y@y.com              | 6280231377560890  |
     