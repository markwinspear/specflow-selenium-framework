@web
Feature: ExampleWebFeature
	In order to create a basic example of automating a web applications
	As a tester
	I want to be able to perform some automated tasks

Scenario Outline: Login
	Given I have entered username '<username>' and password '<password>'
	When I login
	Then I should be informed that login '<result>'

	Examples: 
	| testing               | username | password             | result |
	| valid combination     | tomsmith | SuperSecretPassword! | passed   |
	| invalid combination 1 | test     | test                 | failed   |
	| special characters    | $$$      | SuperSecretPassword! | failed   |