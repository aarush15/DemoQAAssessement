Feature: demoQA

A short summary of the feature
@DemoQA
Scenario: verfiy details post submissions    
	Given I click on the text-box Link
	When I fill in the following fields with example values:
        | Field          | Value                        |
        | FullName       | Vinayak                      |
        | Email          | umadi@gmail.com              |
        | CurrentAddress | Bangalore, City              |
        | PermanentAddress | Banaglore, City            |
    When I submit the registration form
    Then I should see the details displayed correctly on the confirmation page
	Then I verfiy details post submissions


Scenario: Verify selected items in the checkbox      
    Given I click on the checkbox link
    When I select the item     
    Then I should see the selected items displayed correctly

Scenario: Edit a record in the web table
    Given  I click on the web link table link
    When I click on the edit button for record 1
    And I enter "Vinayak Umadi" in the edit field
    And I click on the save button   

Scenario: Verify button click messages
    Given Given I click on the button link
    When I perform a click on the button with the following details
        | clickType     | expectedMessage                   |
        | doubleClick  | You have done a double click      |
        | rightClick   | You have done a right click       |
        | dynamicClick | You have done a dynamic click     |
    Then the corresponding messages should be displayed


 Scenario: Download and Upload a File
    Given Given I click on the upoload and download link
    When I download a file 
    And I upload the downloaded file
    Then the file should be uploaded successfully

