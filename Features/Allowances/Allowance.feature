@Regression @Allowance
Feature: Verify Allowances Module

@Setup
Scenario: 01. Launch Browser and Login to the Application
	Given User "superadmin" is authenticated with "url"

Scenario: 02. Verify name input required validation message
	When User add allowance without name
	Then User verify validation message: "Name is required" on allowance popup

Scenario: 03. Verify paid time required validation message
	When User add new allowance with name "CAFE ALLOWANCE" and without paid time
	Then User verify validation message: "Paid Time must be between 200 and 720" on allowance popup

Scenario: 04. Verify validation message paid time must be between 200 and 720
	When User add new allowance with name "CAFE ALLOWANCES" and paid time "150"
	Then User verify validation message: "Paid Time must be between 200 and 720" on allowance popup
	
Scenario: 05. Verify create new allowance by providing paid time in range and incentive opportunity allowance percent in range
	When User add new allowance with below input
	| Name              | PaidTime | ExcludePaidBreak | ReleifTime | IncludePaidBreak | RestCalculation | MinorDelay | AdditionalDelay | IncentiveOpportunityAllowance |
	| SEAFOOD ALLOWANCE | 300      |     10           |   1        |   20             |  Rest           |     10     |  20             |  125                             |
	Then User verify created allowance name "SEAFOOD ALLOWANCE"

Scenario: 06. Verify duplicate message name already exists
	When User add new allowance with duplicate name "SEAFOOD ALLOWANCE" and paid time "300"
	Then User verify validation message: "Name already exists" on allowance popup

Scenario: 07. Verify validation message calculate allowance percent must be less than hundred percent
	When User add new allowance with below input to verify alert message
	| Name               | PaidTime | ExcludePaidBreak | ReleifTime | IncludePaidBreak | RestCalculation | MinorDelay | AdditionalDelay | IncentiveOpportunityAllowance |
	| LONGLIFE ALLOWANCE | 300      |     10           |   1        |   20             |  Rest           |     200     |  20            |  125                          |
	Then User verify error alert message: "Calculated Allowance Percent must be less than 100%" on allowance page
	And User add new allowance with below input to verify alert message
	| Name           | PaidTime | ExcludePaidBreak | ReleifTime | IncludePaidBreak | RestCalculation | MinorDelay | AdditionalDelay | IncentiveOpportunityAllowance |
	| BAKERY ALLOWANCE | 300      |     10           |   1        |   20             |  Rest           |     20     |  200            |  125                          |
	Then User verify error alert message: "Calculated Allowance Percent must be less than 100%" on allowance page

@Cleanup
Scenario: 08. Logout and Close Browser
	Then User delete record of allowance "SEAFOOD ALLOWANCE"
	And User logout from the application
	And User close browser