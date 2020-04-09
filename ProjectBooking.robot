*** Settings ***
Documentation  This is some basic info about the whole test suite
Resource        ../Resources/keywords.robot
Library  SeleniumLibrary
Test Setup      Begin Web Test
Test Teardown   End Web Test

*** Variables ***
${BROWSER} =  chrome
${URL} =   https://localhost:44321/


*** Test Cases ***
User can access Project Booking website
    [Documentation]             This is some basic info about the test
    [Tags]                      Test 1
    Go to Web Page



