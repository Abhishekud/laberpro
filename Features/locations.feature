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
  Scenario Outline: 2. verify_add_location
 
  When user enter  blank details  
  When user enter existing details it show error
  When user enter correct details it shows error


  @Regression @Smoke
  Scenario Outline: 3. verify_edit_location
    When user enter edit  blank details 
  When user enter edit existing details it show error
  When user enter edit correct details it shows error

  @Regression @Smoke
  Scenario Outline: 4. verify_delete_location
  When seect a location it selects location and on delete it  
    
  @Cleanup @Regression @Smoke
  Scenario: 5. Logout and Close Browser
    When User logout from the application
    Then User close browser