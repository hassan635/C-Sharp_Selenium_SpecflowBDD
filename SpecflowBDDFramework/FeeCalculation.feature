Feature: Unregistered Car Permit Fee Calculation
	In order to calculate permit fee for unregistered car
	As a unregistered car owner
	I want the calculated fee displayed

Scenario: Successful input of specific details
	Given I am on the unregistered car permit fee page
    And I have entered my vehical type
    And I have entered my sub type
    And I have entered my garage location
    And I have entered my desired permit duration
	When I choose to calculate
	Then the result should be displayed
    And I should be taken to permit type selection page