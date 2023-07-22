Feature: CreateCustomer

A short summary of the feature

@CreateSuccesfully
Scenario: Create customer successfully when data is valid
	Given customer information (<FirstName>,<Lastname>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
	When validation is true
	Then result should be succeeded
	
	Examples:
		| FirstName | Lastname        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| Yasin     | Asadnezhad      | 1991-02-02  | +989306030638 | yasin@ggmail.com     | 6280231377560890  |
