Feature: Alerts_Frame_Windows

A short summary of the feature

@Alerts_Frame_Windows
Scenario: Prompt box should appear on button click
    Given I click on the Alert link
    When I click on the button
    Then the alert box should appear 
    Then click the button in alert box

    When I click on the after 5sec button
    Then the alert box should appear 
    Then click the button in alert box

   
    When I click on the confirm box button
    Then the alert box should appear 
    Then click the button in alert box
    
    When I click on the prompt box button
    Then the alert box should appear 
    Then click the button in alert box


 Scenario: Handling New Tabs, New Windows, and New Window Message
    Given I click on the Window link
    When I click on the New tab button
    Then a new tab should be opened
    Then I go back to the home page

    When I click on the New Window button
    Then a new window should be opened
    Then I go back to the home page

    When I click on the New Window 2 button
    Then a new window should be opened
    Then I go back to the home page
    
