Feature: ExampleWebFeature
	In order to create a basic example of automating a web applications
	As a tester
	I want to be able to perform some automated tasks

@web
Scenario: Successful login
	Given I have entered 'tomsmith' and 'SuperSecretPassword!' into the application
	When I login
	Then I should be informed that login was successful

@web
Scenario Outline: Unsuccessful login
	Given I have entered <username> and <password> into the application
	When I login
	Then I should be informed that login was unsuccessful

	Examples: 
	| testing                          | username | password             |
	| invalid combination 1            | test     | test                 |
	| special characters               | $$$      | SuperSecretPassword! |
	| this should fail - valid details | tomsmith | SuperSecretPassword! |