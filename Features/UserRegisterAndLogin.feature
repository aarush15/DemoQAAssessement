Feature: UserRegisterAndLogin

A short summary of the feature

@UserRegisterAndLogin
Scenario: Register a new user
    Given I am on the login page
    When I click on the new user button
    When I enter the following details:
        | Field        | Value     |
        | First Name   | Vin      |
        | Last Name    | umadi       |
        | Username     | vin   |
        | Password     | Welcome@8 |
    And I click the Register button
    Then I should see a success message
