Feature: CreateCustomer

A short summary of the feature

@CreateSuccesfully
Scenario: Create customer successfully when data is valid
	Given Create customer information (<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
	Then Create result should be succeeded
	
	Examples:
		| FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| Yasin     | Asadnezhad      | 1991-02-02  | +989306030638 | yasin@ggmail.com     | 6280231377560890  |


Scenario: Create customer when first name is small
		Given Create customer information (<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Create result should be failed
		
	Examples:
		| FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| Ya     | Asadnezhad      | 1991-02-02  | +989306030638 | yasin@ggmail.com     | 6280231377560890  |
  

Scenario: Create customer when last name is small
		Given Create customer information (<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Create result should be failed
		
	Examples:
		| FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| Yasin     | As              | 1991-02-02  | +989306030638 | yasin@ggmail.com     | 6280231377560890  |
  

Scenario: Create customer when email is invalid
		Given Create customer information (<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Create result should be failed
		
	Examples:
		| FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| Yasin     | Asadnezhad      | 1991-02-02  | +989306030638 | yasin                | 6280231377560890  |
  
Scenario: Create customer with invalid phone number
		Given Create customer information (<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Create result should be failed
		
	Examples:
		| FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| Yasin     | Asadnezhad      | 1991-02-02  | +98930        | yasin@ggmail.com     | 6280231377560890  |
  

Scenario: Create customer with invalid bank account number
		Given Create customer information (<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Create result should be failed
		
	Examples:
		| FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| Yasin     | Asadnezhad      | 1991-02-02  | +989306030638 | yasin@ggmail.com     | 6280              |
 
		
Scenario: Create customer when email is repeated 
		Given Create customer information (<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then Create result should be failed
		
	Examples:
		| FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| Mahdi     | Asadnezhad      | 1991-02-02  | +989306030638 | y@y.com              | 6280231377560890  |
     