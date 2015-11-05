Feature: ExampleWebFeature
	In order to create a basic example of automating a web applications
	As a tester
	I want to be able to perform some automated tasks

@web
Scenario: Successful login
	Given I have entered 'tomsmith' and 'SuperSecretPassword!' into the application
	When I login
	Then I should be informed that login was successful
