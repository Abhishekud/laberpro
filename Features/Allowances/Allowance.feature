@Regression @Allowance
Feature: Verify Allowances Module

@Setup @Smoke
Scenario: 01. Launch Browser and Login to the Application
	Given User "superadmin" is authenticated with application
   
@Smoke
Scenario: 02. verify_add_allowance_name_empty_tag
	Given User navigates to the Allowance tab
	When User add allowance using below input
		| Key  | Value |
		| Name |       |
 	Then Verify validation Message: "Name is required"
	And User click on cancel Button
    

Scenario: 03. verify_add_allowance_name_already_exist
	Given User navigates to the Allowance tab
	Then User delete allowance "ATM_ALLOW - PRODUCE" if exist
	When User add allowance using below input
		| Key                                       | Value               |
		| Name                                      | ATM_ALLOW - PRODUCE |
		| Paid Time (Minutes)                       | 300                 |
		| Excluded Paid Breaks (Minutes)            | 10                  |
		| Relief Time (Minutes)                     | 1                   |
		| Included Paid Breaks (Minutes)            | 20                  |
		| Rest Calculation                          | Rest                |
		| Minor Unavoidable Delay (Percent)         | 10                  |
		| Additional Delay (Percent)                | 20                  |
		| Incentive Opportunity Allowance (Percent) | 80                  |
	Then User verify created allowance name "ATM_ALLOW - PRODUCE"
	And User click on previous link
	When User add allowance using below input
		| Key                                       | Value               |
		| Name                                      | ATM_ALLOW - PRODUCE |
		| Paid Time (Minutes)                       | 300                 |
		| Excluded Paid Breaks (Minutes)            | 10                  |
		| Relief Time (Minutes)                     | 1                   |
		| Included Paid Breaks (Minutes)            | 20                  |
		| Rest Calculation                          | Rest                |
		| Minor Unavoidable Delay (Percent)         | 10                  |
		| Additional Delay (Percent)                | 20                  |
		| Incentive Opportunity Allowance (Percent) | 80                  |
  
	Then Verify validation Message: "Name already exists"
	And User click on cancel Button
	And User delete created allowance: "ATM_ALLOW - PRODUCE"

  
@Smoke
Scenario: 04. verify_add_allowance_by_adding_correct_record_of_name
	Given User navigates to the Allowance tab
	Then User delete allowance "ATM_ALLOW - TRADE" if exist
	When User add allowance using below input
		| Key                                       | Value             |
		| Name                                      | ATM_ALLOW - TRADE |
		| Paid Time (Minutes)                       | 300               |
		| Excluded Paid Breaks (Minutes)            | 10                |
		| Relief Time (Minutes)                     | 1                 |
		| Included Paid Breaks (Minutes)            | 20                |
		| Rest Calculation                          | Rest              |
		| Minor Unavoidable Delay (Percent)         | 10                |
		| Additional Delay (Percent)                | 20                |
		| Incentive Opportunity Allowance (Percent) | 80                |
	Then User verify created allowance name "ATM_ALLOW - TRADE"
	And User delete allowance record

Scenario: 05. verify_add_allowance_paid_time_empty
	Given User navigates to the Allowance tab
	When User add allowance using below input
		| Key                 | Value                |
		| Name                | ATM_ALLOW - NONTRADE |
		| Paid Time (Minutes) |                      |
	Then Verify validation Message: "Paid Time must be between 200 and 720"
	And User click on cancel Button

@Smoke
Scenario: 06. verify_add_allowance_paid_time_range_200_and_720
	Given User navigates to the Allowance tab
	When User add allowance using below input
		| Key                                       | Value                |
		| Name                                      | ATM_ALLOW - NONTRADE |
		| Paid Time (Minutes)                       | 150                  |
		| Excluded Paid Breaks (Minutes)            | 10                   |
		| Relief Time (Minutes)                     | 1                    |
		| Included Paid Breaks (Minutes)            | 20                   |
		| Rest Calculation                          | Rest                 |
		| Minor Unavoidable Delay (Percent)         | 10                   |
		| Additional Delay (Percent)                | 20                   |
		| Incentive Opportunity Allowance (Percent) | 80                   |
	Then Verify validation Message: "Paid Time must be between 200 and 720"
	And User click on cancel Button

Scenario: 07. verify_add_allowance_paid_time_value_getting_added_when_value_is_supplied_in_range
	Given User navigates to the Allowance tab
	Then User delete allowance "ATM_ALLOW - NONTRADE" if exist
	When User add allowance using below input
		| Key                                       | Value                |
		| Name                                      | ATM_ALLOW - NONTRADE |
		| Paid Time (Minutes)                       | 300                  |
		| Excluded Paid Breaks (Minutes)            | 10                   |
		| Relief Time (Minutes)                     | 1                    |
		| Included Paid Breaks (Minutes)            | 20                   |
		| Rest Calculation                          | Rest                 |
		| Minor Unavoidable Delay (Percent)         | 10                   |
		| Additional Delay (Percent)                | 20                   |
		| Incentive Opportunity Allowance (Percent) | 80                   |
	Then User verify created allowance name "ATM_ALLOW - NONTRADE"
	And User delete allowance record

Scenario: 08. verify_add_allowance_Incentive_Opportunity_Allowance_Percent
	Given User navigates to the Allowance tab
	Then User delete allowance "ATM_ALLOW - LONGLIFE" if exist
	When User add allowance using below input
		| Key                                       | Value                |
		| Name                                      | ATM_ALLOW - LONGLIFE |
		| Paid Time (Minutes)                       | 300                  |
		| Excluded Paid Breaks (Minutes)            | 10                   |
		| Relief Time (Minutes)                     | 1                    |
		| Included Paid Breaks (Minutes)            | 20                   |
		| Rest Calculation                          | Rest                 |
		| Minor Unavoidable Delay (Percent)         | 10                   |
		| Additional Delay (Percent)                | 20                   |
		| Incentive Opportunity Allowance (Percent) | 125                  |
	Then User verify created allowance name "ATM_ALLOW - LONGLIFE"
	And User delete allowance record

Scenario: 09. verify_Add_allowance_Minor_Unavoidable_delay_percent_and_Additional_Percent_range_value_less_than_100
	Given User navigates to the Allowance tab
	When User add allowance using below input to verify validation message
		| Key                                       | Value                               |
		| Name                                      | Verify Calculated Allowance Percent |
		| Paid Time (Minutes)                       | 300                                 |
		| Excluded Paid Breaks (Minutes)            | 10                                  |
		| Relief Time (Minutes)                     | 1                                   |
		| Included Paid Breaks (Minutes)            | 20                                  |
		| Rest Calculation                          | Rest                                |
		| Minor Unavoidable Delay (Percent)         | 200                                 |
		| Additional Delay (Percent)                | 20                                  |
		| Incentive Opportunity Allowance (Percent) | 125                                 |
	Then User verify error alert message: "Calculated Allowance Percent must be less than 100%"
	And User click on cancel Button
	When User add allowance using below input to verify validation message
		| Key                                       | Value |
		| Name                                      | Dummy |
		| Paid Time (Minutes)                       | 300   |
		| Excluded Paid Breaks (Minutes)            | 10    |
		| Relief Time (Minutes)                     | 1     |
		| Included Paid Breaks (Minutes)            | 20    |
		| Rest Calculation                          | Rest  |
		| Minor Unavoidable Delay (Percent)         | 20    |
		| Additional Delay (Percent)                | 200   |
		| Incentive Opportunity Allowance (Percent) | 125   |
	Then User verify error alert message: "Calculated Allowance Percent must be less than 100%"
	And User click on cancel Button

@Cleanup @Smoke
Scenario: 10. Logout and Close Browser
	Given User navigates to the Allowance tab
	When User logout from the application
	Then User close browser
