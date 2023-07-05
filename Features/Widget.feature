Feature: Widget

A short summary of the feature

@Widget
  Scenario: Select Date and Date and Time
    Given I am on the date and time page
    When I select the date     
    Then check date populated in date field
    When I select the date and time 
    Then check date populated in datetime field

  Scenario: Verify Tooltip Content
    Given I am on the toool tips page
    When I hover over the highlighted items
    Then the tooltip content should be displayed correctly
