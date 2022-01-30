@LaberPro @Login
Feature: Verify Locations Module Functionality

  @Setup @Regression @Smoke
  Scenario: 1. Launch Browser and go to application
    Given User launched "chrome"
    Then User go to application "https://laborpro.benchmarkit.solutions/log-in"
    When User enter email: "<username>" and password: "<password>"
    Then Verify Login message: "<message>"
    Examples:
      | username                         | password   | message |
      | ajaykhadke@benchmarkit.solutions | Ajay2021$$ | success |

  @Regression @Smoke
  Scenario Outline: 2. verify_add_location_when_enter_blank_details  
    
  Given  User Enters the HomePage
  Then User navigates to the Profiling  tab
  Then User navigates to the location tab
  Then User presses on Add location Button
  When user  enter  blank details  
  Then Verify Alert Message: "<message>"
  
   @Regression @Smoke
  Scenario Outline: 3. verify_add_location_when_enter_correc_details 
    
  Given User press cancel Button
  Then User opens the form again by pressing Add Location button
  Then User enters value in Name:"Labor" tag  and press submit button
  Then Verify validation Message: "<message>"
  

   @Regression @Smoke
  Scenario Outline: 4. verify_add_location_when_enter_existing_details
    
  Given User press cancel Buttons
  Then User opens the form again by pressing Add location buttons
  Then User enters value in Name:"Labor" tag the value entered is already present in database and press submit button
  Then Verify validation Message: "<message>"
 


  @Regression @Smoke
  Scenario Outline: 5. verify_edit_location_blank_Details
    Given User press cancel Butto 
    When user click on profile it opens a profile
   Then  User enters empty value in Name:"Labor" tag   and press submit button
     Then Verify validation Message: "<message>"


  @Regression @Smoke
  Scenario Outline: 6. verify_edit_location_existing_Details
    Given User press cancel Button after previous test case
    When user click on profile it open a profile
   Then  User enters existing value in Name:"Labor" tag   and press submit button
     Then Verify validation Message: "<message>"


  @Regression @Smoke
  Scenario Outline: 7. verify_edit_location_correct_Details
  Given User will press previous button 
  When user click on profile it open a profiles
   Then  User enters  value in Name:"Labor" tag and press submit 
     Then Verify validation Message: "<message>"

  @Regression @Smoke
  Scenario Outline: 8. verify_delete_location
  Given User will press cancel button 
  When select a location it selects location and on deletes it  
    
  @Cleanup @Regression @Smoke
  Scenario: 9. Logout and Close Browser
    When User logout from the application
    Then User close browser