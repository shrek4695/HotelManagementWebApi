Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And User has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

Scenario Outline: User finds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel
	And User has added required details for hotel
	And User calls AddHotel api
	When User calls GetHotelById api
	Then Hotel with id '<id>' should be present in the database
Examples: 
| id | name   |
| 2  | hotel4 |
| 5  | hotel5 |
| 6  | hotel6 |

Scenario Outline: User get detail of all hotels
	Given User provided valid Id '<id>'  and '<name>'for hotel
	And User has added required details for hotel
	And User calls AddHotel api
	When User calls GetAllHotels api
	Then Hotels added should be present in the database
Examples: 
| id | name    |
| 7  | hotel7  |
| 8  | hotel8  |
| 9  | hotel9  |
| 10 | hotel10 |