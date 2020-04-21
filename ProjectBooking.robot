*** Settings ***
Documentation  This is some basic info about the whole test suite
Resource        ../Resources/keywords.robot
Library  SeleniumLibrary
Test Setup      Begin Web Test
Test Teardown   End Web Test

*** Variables ***
${BROWSER} =  chrome
${URL} =   https://localhost:44321/
${email} =  goodwhether@123.com
${password} =  Helloworld123:)
${newpassword} =  Noworld123:(

*** Test Cases ***
User can access Project Booking website
    [Documentation]             This is some basic info about the test
    [Tags]                      Test 1
    Go to Web Page

User can not register an account WEB8-40
    [Documentation]             Create user account
    [Tags]                      Test 2
    Given Go to Web Page
    when Create a new account WEB8-40
    Then Verify user register fail WEB8-40

User can log in
    [Documentation]             Log in success
    [Tags]                      Test 3
    Given Go to Web Page
    When Input email and password
    Then log in success

User can change profile-1 WEB8-65
    [Documentation]             upload picture
    [Tags]                      Test 4
    Given User is in Profile Page
    When Upload File from local computer WEB8-65     C:\\ProfilePic.jpg
    Then Verify the information is uploaded WEB8-65   Your profile picture has been updated

User can change profile-2 WEB8-65
    [Documentation]             Change profile
    [Tags]                      Test 5
    Given User is in Profile Page
    When Input user information and click save WEB8-65        hello   world   12345678
    Then Verify the information is uploaded WEB8-65     Your profile has been updated

User can change profile-3 WEB8-65
    [Documentation]             upload the same picture twice
    [Tags]                      Test 6
    User is in Profile Page
    Upload File from local computer WEB8-65     C:\\ProfilePic.jpg
    Verify the information is uploaded WEB8-65   Your profile picture has been updated
    Upload File from local computer WEB8-65     C:\\ProfilePic.jpg
    Verify the information is uploaded WEB8-65   Your profile picture has been updated

User can change their password WEB8-66
    [Documentation]             Change password and reset the passward after test run
    [Tags]                      Test 7
    Given User log in to Webpage
    When Changing User Password WEB8-66
    Then Verify That Changes Was Made WEB8-66

User can delete user profile WEB8-66
    [Documentation]             Delete profile and recreate the user profile after test run
    [Tags]                      Test 8
    Given User log in to Webpage
    When User Can Delete Personal Data WEB8-66
    Then Verify That Delete Personal Data Was Made WEB8-66

User can see hotels on the page and find infomration on them WEB8-45
    [Documentation]             Hotels and the information about them
    [Tags]                      Test 9
    User log in to Webpage
    User Can Click On Different Hotels To Get Information About Them WEB8-45



