﻿Feature: DeleteCustomer

A short summary of the feature

@DeleteSuccesfully
Scenario: Delete customer successfully when data is valid
	Given Delete customer information (<Id>)
	Then Delete result should be succeeded
	
	Examples:
		| Id |
		| 4  |


Scenario: Delete customer when id not found
		Given Delete customer information (<Id>)
		Then Delete result should be failed
			
	Examples:
		| Id |
		| 999  |

