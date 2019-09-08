Feature: SignUp

Scenario: Sign up successful
	Given Joey is a new user
	And Joey is in the index page
	When Joey sign up with email "joeychen@odd-e.com"
	And account information is
		| Email              | FirstName | LastName | Password |
		| joeychen@odd-e.com | Joey      | Chen     | 54321    |
	And receiver information is
		| FirstName | LastName | Address1     | Address2 | City   | State | Country       | ZipCode | MobilePhone |
		| Mei       | Lin      | test address |          | Taipei | Ohio  | United States | 12345   | 0991911911  |
	Then bring Joey to my account page