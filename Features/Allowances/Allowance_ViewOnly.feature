﻿@Regression @Allowance_ViewOnly
Feature: Verify Allowance_ViewOnly Module

	@Setup
	Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
		Given User launched "$browser"
		When User go to application "$url"
		Then User enter email: "$username_4" and password: "$password_4"
		And User navigates to the Allowance tab
		And User add allowance using below input if not exist
		| Key                                          | Value                             |
		| Name                                         | Allowances created via automation |
		| Paid Time (Minutes)                          | 300                               |
		| Excluded Paid Breaks (Minutes)               | 10                                |
		| Relief Time (Minutes)                        | 1                                 |
		| Included Paid Breaks (Minutes)               | 20                                |
		| Rest Calculation                             | Rest                              |
		| Minor Unavoidable Delay (Percent)            | 10                                |
		| Additional Delay (Percent)                   | 20                                |
		| Incentive Opportunity Allowance (Percent)    | 80                                |
		And User click on previous link
		Then User logout from the application

	Scenario: 02. Verify_add_button_is_not_available
		Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
		When User navigates to the Allowance tab
		Then User verify add button is not available on allowance page

	Scenario: 03. Verify_user_is_able_to_download_allowance_report
		When User navigates to the Allowance tab
		Then User verify download allowance details report for allowance: "Allowances created via automation"

	Scenario: 04. Verify_copy_option_is_not_available
		When User navigates to the Allowance tab 
		Then User verify copy option is not available on allowance page

	@Cleanup 
	Scenario: 05. Logout and Close Browser
		Given User logout from the application
		When User enter email: "$username_4" and password: "$password_4"
		Then User navigates to the Allowance tab
		And User delete allowance "Allowances created via automation" if exist
		And User logout from the application
		Then User close browser

  
