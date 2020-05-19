*** Settings ***
Documentation  This is some basic info about the whole test suite
Resource        ../Resources/keywords.robot
Library     SeleniumLibrary
Library           DateTime
Test Setup      Begin Web Test
Test Teardown   End Web Test

*** Variables ***
${BROWSER} =  chrome
${URL} =   https://localhost:44321/
${email} =  goodwhether@123.com
${password} =  Helloworld123:)
${newpassword} =  Noworld123:(
${numOfRooms} =  2
${firstName} =  Hello
${lastName} =  World
${uploadProfile1} =  C:\\ProfilePic.jpg
${adminemail} =  Admin@hotmail.com
${adminpassword} =  Admin123!

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
    When Upload File from local computer WEB8-65     ${uploadProfile1}
    Then Verify the information is uploaded WEB8-65   Your profile picture has been updated

User can change profile-2 WEB8-65
    [Documentation]             Change profile
    [Tags]                      Test 5
    Given User is in Profile Page
    When Input user information and click save WEB8-65        ${firstName}   ${lastName}   12345678
    Then Verify the information is uploaded WEB8-65     Your profile has been updated

User can change profile-3 WEB8-65
    [Documentation]             upload the same picture twice
    [Tags]                      Test 6
    User is in Profile Page
    Upload File from local computer WEB8-65     ${uploadProfile1}
    Verify the information is uploaded WEB8-65   Your profile picture has been updated
    Upload File from local computer WEB8-65     ${uploadProfile1}
    Verify the information is uploaded WEB8-65   The uploaded filename has to be different from the existing file

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

User can book A Room WEB8-21
   [Documentation]             user can book hotel room from a specific hotel
   [Tags]                      Test 10
    Given User log in to Webpage
        and User Go Into A Hotel WEB8-21             Euroway Hotel
    When User Make A Booking At Hotel WEB8-21        ${firstName}   ${lastName}      ${numOfRooms}   Euroway Hotel
    then Verify The Booking Success WEB8-21          Booking has been added

User cannot book A Room earlier WEB8-21
   [Documentation]             user can book hotel room from a specific hotel
   [Tags]                      Test 11
    Given User log in to Webpage
        and User Go Into A Hotel WEB8-21             Euroway Hotel
    When User Make A Booking Earlier Then Today At Hotel WEB8-21        ${firstName}   ${lastName}    ${numOfRooms}   Euroway Hotel
    then Verify The Booking not Success WEB8-21

User cannot book A Room after 6 months WEB8-21
   [Documentation]             user can book hotel room from a specific hotel
   [Tags]                      Test 12
    Given User log in to Webpage
        and User Go Into A Hotel WEB8-21             Euroway Hotel
    When User Make A Booking After 6 Months At Hotel WEB8-21        ${firstName}   ${lastName}       ${numOfRooms}   Euroway Hotel
    then Verify The Booking not Success WEB8-21

Checkout date should be after checkin date WEB8-21
   [Documentation]             user can book hotel room from a specific hotel
   [Tags]                      Test 13
    Given User log in to Webpage
        and User Go Into A Hotel WEB8-21             Euroway Hotel
    When User Make A Wrong Booking At Hotel WEB8-21        ${firstName}   ${lastName}      ${numOfRooms}   Euroway Hotel
    then Verify Error Message Return WEB8-21

WEB8-27 User can search for hotels regesterd on the page
    [Documentation]             Search for hotels on the page
    [Tags]                      Test 14
    Given User Can Go To The WebPage
    When User Can Search For Hotels Regesterd On The Web Page
    Then User Can Get Results For Hotels Regesterd On The Web Page By Town, Name Or Offerings By The Hotels

WEB8-27 user can empty the search feld after entering text
    [Documentation]             Verify an empty search feld after entering text
    [Tags]                      Test 15
    WEB8-27 Empty the search feld after entering text   Gothenburg      Showing 1 to 3 of 3 entries (filtered from 9 total entries)

User Can Delete Booking WEB8-23
    [Documentation]             Testing delete button and backtolist button in delete bookings
    [Tags]                      Test 16
    Given User made a booking
    When User go to My Bookings WEB8-23
    Then User can delele the page successfully WEB8-23          Booking has been deleted

User Can View Booking WEB8-23
    [Documentation]             This is actually testing the backtolist button
    [Tags]                      Test 17
    Given User made a booking
    When User go to My Bookings WEB8-23
    Then User can view a specified booking WEB8-23

User Can Edit Booking WEB8-23
    [Documentation]             This is actually testing the backtolist button
    [Tags]                      Test 18
    Given User made a booking
    When User go to My Bookings WEB8-23
    Then User can edit a specified booking WEB8-23

User Can Contact Support By Messages WEB8-29
    [Documentation]             Testing massages for support and after the message is deleted
    [Tags]                      Test 19
    Given User log in to Webpage
    When User Can Send Messeges To Support
        and Support Can Read The Message And Reply
    Then User Can Read The Reply





