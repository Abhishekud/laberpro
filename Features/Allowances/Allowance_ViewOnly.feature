@Regression @Allowance_ViewOnly
Feature: Verify Allowance_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	And User navigates to the Allowance tab
	And User add allowance using below input if not exist
		| Key                                       | Value           |
		| Name                                      | ATM_ALLOW - TEA |
		| Paid Time (Minutes)                       | 300             |
		| Excluded Paid Breaks (Minutes)            | 10              |
		| Relief Time (Minutes)                     | 1               |
		| Included Paid Breaks (Minutes)            | 20              |
		| Rest Calculation                          | Rest            |
		| Minor Unavoidable Delay (Percent)         | 10              |
		| Additional Delay (Percent)                | 20              |
		| Incentive Opportunity Allowance (Percent) | 80              |
	Then User click on previous link
	And User logout from the application

Scenario: 02. Verify_add_button_is_not_available
	Given User "viewonly" is authenticated with application
	When User navigates to the Allowance tab
	Then User verify add button is not available on allowance page

Scenario: 03. Verify_user_is_able_to_download_allowance_report
	When User navigates to the Allowance tab
	Then User verify download allowance details report for allowance: "ATM_ALLOW - TEA"

Scenario: 04. Verify_copy_option_is_not_available
	When User navigates to the Allowance tab
	Then User verify copy option is not available on allowance page

@Cleanup
Scenario: 05. Logout and Close Browser
	Given User logout from the application
	When User "superadmin" is authenticated with application
	Then User navigates to the Allowance tab
	And User delete allowance "ATM_ALLOW - TEA" if exist
	And User logout from the application
	Then User close browser

  
