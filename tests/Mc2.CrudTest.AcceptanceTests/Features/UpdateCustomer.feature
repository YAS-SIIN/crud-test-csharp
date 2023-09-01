Feature: UpdateCustomer

A short summary of the feature

@UpdateSuccesfully
Scenario: Update customer successfully when data is valid
	Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
	When Update validation is true
	Then Update result should be succeeded
	
	Examples:
		| Id |  FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 2  |  Mahdi     | Asadnezhad      | 1991-02-02  | +989306030638 | mahdi@ggmail.com     | 6280231377560890  |


Scenario: Update customer when first name is small
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update validation should be false
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 2  | Ma        | Asadnezhad      | 1991-02-02  | +989306030638 | mahdi@ggmail.com     | 6280231377560890  |
  

Scenario: Update customer when last name is small
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update validation should be false
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 2  | Mahdi     | As              | 1991-02-02  | +989306030638 | mahdi@ggmail.com     | 6280231377560890  |
  

Scenario: Update customer when email is invalid
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update validation should be false
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 2  | Mahdi     | Asadnezhad      | 1991-02-02  | +989306030638 | mahdi                | 6280231377560890  |
  
Scenario: Update customer with invalid phone number
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update validation should be false
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 2  | Mahdi     | Asadnezhad      | 1991-02-02  | +98930        | mahdi@ggmail.com     | 6280231377560890  |
  

Scenario: Update customer with invalid bank account number
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Update validation should be false
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 2  | Mahdi     | Asadnezhad      | 1991-02-02  | +989306030638 | mahdi@ggmail.com     | 6280              |
 
		
Scenario: Update customer when email is repeated 
		Given Update customer information (<Id>,<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		When Update validation is true
		Then Update result should be failed
		
	Examples:
		| Id | FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 2  | Mahdi     | Asadnezhad      | 1991-02-02  | +989306030638 | y@y.com              | 6280231377560890  |
     