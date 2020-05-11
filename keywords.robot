*** Keywords ***
Begin Web Test
    Open Browser            about:blank  ${BROWSER}
    Maximize Browser Window
    Set Selenium Speed      0.2

Go to Web Page
    Load Page
    Verify Page Loaded

Load Page
    Go to                   ${URL}

Verify Page Loaded
    ${link_text} =    Get Text   xpath:/html/body/div/main/div[1]/h2
    Should Be Equal   ${link_text}   Welcome to Project Booking

End Web Test
    Close Browser

User log in to Webpage
    Go to Web Page
    Input email and password
    log in success

' User can not register an account WEB8-40 '
Create a new account WEB8-40
    Click Element                                  xpath://*[@id="register"]
    Verfy Create User Loaded WEB8-40
    Enter Email WEB8-40                            ${email}
    Enter Password WEB8-40                         ${password}
    Confirm Password WEB8-40                       ${password}
    Click Button                                   xpath:/html/body/div/main/div/div/form/button

Enter Email WEB8-40
    [Arguments]         ${search_term}
    Input Text          id:Input_Email       ${search_term}

Enter Password WEB8-40
    [Arguments]         ${search_term}
    Input Text          id:Input_Password       ${search_term}

Confirm Password WEB8-40
    [Arguments]         ${search_term}
    Input Text          id:Input_ConfirmPassword       ${search_term}

Verfy Create User Loaded WEB8-40
    ${link_text} =    Get Text   xpath:/html/body/div/main/div/div/form/h4
    Should Be Equal   ${link_text}   Create a new account.

Verify user register success WEB8-40
    Page Should Contain Button  xpath://*[@id="logout"]

Verify user register fail WEB8-40
    ${link_text} =    Get Text   xpath:/html/body/div/main/div/div/form/div[1]/ul/li
    Should Be Equal   ${link_text}   User name '${email}' is already taken.

' User can log in '
Input email and password
    Click Element                          xpath://*[@id="login"]
    Verfy login page Loaded
    Enter Email_login                        ${email}
    Enter Password_login                     ${password}
    Click Button                          xpath://*[@id="account"]/div[5]/button

Verfy login page Loaded
    ${link_text} =    Get Text   xpath:/html/body/div/main/h1
    Should Be Equal   ${link_text}   Log In

Enter Email_login
    [Arguments]         ${search_term}
    Input Text          id:Input_Email       ${search_term}

Enter Password_login
    [Arguments]         ${search_term}
    Input Text          id:Input_Password       ${search_term}

Log in success
    Page Should Contain Button  xpath://*[@id="logout"]

' User can change profile-1 WEB8-65 '
User is in Profile Page
    Go to Web Page
    User log in to Webpage
    Go to Profile Page

Go to Profile Page
    Click Element                          xpath://*[@id="manage"]
    Click Element                          xpath:/html/body/div/main/h1
    Click Element                          xpath://*[@id="profile"]
    Verfy profile page Loaded

Verfy profile page Loaded
    ${link_text} =    Get Text   xpath:/html/body/div/main/div/div/div[2]/h4
    Should Be Equal   ${link_text}   Profile Details

Upload File from local computer WEB8-65
    [Arguments]                            ${file_name}
    Choose File                           xpath://*[@name="photo"]      ${file_name}
    Click Element                         xpath://*[@value="Upload"]

Verify the information is uploaded WEB8-65
    [Arguments]                           ${message}
    Wait Until Page Contains                   ${message}

' User can change profile-2 WEB8-65 '
Input user information and click save WEB8-65
    [Arguments]                            ${firstName}   ${lastName}  ${phoneNumber}
    Enter Name WEB8-65                      ${firstName}
    Enter LastName WEB8-65                  ${lastName}
    Enter PhoneNumber WEB8-65               ${phoneNumber}
    Click Button                            xpath://*[@id="update-profile-button"]

Enter Name WEB8-65
    [Arguments]         ${name}
    Input Text          id:CurrentUser_Name       ${name}

Enter LastName WEB8-65
    [Arguments]         ${lastName}
    Input Text          id:CurrentUser_LastName       ${lastName}

Enter PhoneNumber WEB8-65
    [Arguments]         ${phoneNumber}
    Input Text          id:CurrentUser_PhoneNumber       ${phoneNumber}

' User can change their password WEB8-66 '
Changing User Password WEB8-66
    Click Element                          xpath://*[@id="manage"]
    Click Element               xpath://*[@id="change-password"]

    Input Text                  id=Input_OldPassword              ${password}
    Input Text                  id=Input_NewPassword              ${newpassword}
    Input Text                  id=Input_ConfirmPassword          ${newpassword}
    Click Element               xpath://html/body/div/main/div/div/div[2]/div/div/form/button
    Wait Until Element Is Visible  xpath:/html/body/div/main/div/div/div[2]/div[1]/button

Verify That Changes Was Made WEB8-66
    Click Element               xpath://*[@id="logout"]
    Verify Page Loaded
    Click Element               xpath://*[@id="login"]
    Verfy login page Loaded
    Enter Email_login                                               ${email}
    Enter Password_login                                            ${newpassword}
    Click Button                          xpath://*[@id="account"]/div[5]/button
    Log in success
    #Reset part
    Click Element                          xpath://*[@id="manage"]
    Click Element               xpath://*[@id="change-password"]
    Input Text                  id=Input_OldPassword              ${newpassword}
    Input Text                  id=Input_NewPassword              ${password}
    Input Text                  id=Input_ConfirmPassword          ${password}
    Click Element               xpath://html/body/div/main/div/div/div[2]/div/div/form/button
    Wait Until Element Is Visible  xpath:/html/body/div/main/div/div/div[2]/div[1]/button
    Click Element               xpath://*[@id="logout"]
    Verify Page Loaded

' User can delete user profile WEB8-66 '
Verify Delete Page Loaded WEB8-66
    ${link_text} =    Get Text          xpath://html/body/div/main/div/div/div[2]/div/div/p[3]/a
    Should Be Equal   ${link_text}      Delete

Verify Delete Personal Data Page Loaded WEB8-66
    ${link_text} =    Get Text          xpath://html/body/div/main/div/div/div[2]/div[2]/form/button
    Should Be Equal   ${link_text}      Delete data and close my account

Verify Login Fail WEB8-66
    ${link_text} =    Get Text          xpath://html/body/div/main/div/div/section/form/div[1]/ul/li
    Should Be Equal   ${link_text}      Invalid login attempt.

User Can Delete Personal Data WEB8-66
    Click Element               xpath://*[@id="manage"]
    Click Element               xpath://html/body/div/main/div/div/div[1]/ul/li[4]/a
    Verify Delete Page Loaded WEB8-66
    Click Element               xpath://html/body/div/main/div/div/div[2]/div/div/p[3]/a
    Verify Delete Personal Data Page Loaded WEB8-66

Verify That Delete Personal Data Was Made WEB8-66
    Input Text                  id=Input_Password          ${password}
    Click Element               xpath://html/body/div/main/div/div/div[2]/div[2]/form/button
    Verify Page Loaded
    Input email and password
    Verify Login Fail WEB8-66
    Create a new account WEB8-40
    Log in success

' User can see hotels on the page and find infomration on them WEB8-45 '
Verify Euroway Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[1]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Euroway Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Gothia Towers Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[2]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Gothia Towers Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Dorsia Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[3]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Dorsia Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Hilton Prague Old Town Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[4]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Hilton Prague Old Town
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Hotel Residence Agnes Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[5]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Hotel Residence Agnes
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify One Room Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[6]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      One Room Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify The Touch Puerto Banus Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[7]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      The Touch Puerto Banús
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Amare Beach Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[8]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Amàre Beach Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Marbella Club Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[3]/div[9]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Marbella Club Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

User Can Click On Different Hotels To Get Information About Them WEB8-45
    Verify Euroway Hotel Page Loaded WEB8-45
    Verify Gothia Towers Hotel Page Loaded WEB8-45
    Verify Dorsia Hotel Page Loaded WEB8-45
    Verify Hilton Prague Old Town Page Loaded WEB8-45
    Verify Hotel Residence Agnes Page Loaded WEB8-45
    Verify One Room Hotel Page Loaded WEB8-45
    Verify The Touch Puerto Banus Hotel Page Loaded WEB8-45
    Verify Amare Beach Hotel Page Loaded WEB8-45
    Verify Marbella Club Hotel Page Loaded WEB8-45

' User can book hotel room WEB8-21 '
User can book A Room In Different Hotels WEB8-21
    User log in to Webpage
    User Go Into A Hotel WEB8-21             ${hotelName}
    User Make A Booking At Hotel WEB8-21        ${firstName}   ${lastName}    ${checkinDate}    ${checkoutDate}   ${numOfRooms}   Euroway Hotel
    Verify The Booking Success WEB8-21

User Go Into A Hotel WEB8-21
    [Arguments]                                 ${hotelName}
    Click Element                               xpath:/html/body/div/main/div[3]/div[1]/div/div[1]/h4/a
    Verify Hotel Page Loaded WEB8-21            ${hotelName}

Verify Hotel Page Loaded WEB8-21
    [Arguments]                                 ${hotelName}
    ${link_text} =    Get Text          xpath:/html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      ${hotelName}

User Make A Booking At Hotel WEB8-21
    #[Arguments]                 ${name}  ${LastName}   ${checkinDate}  ${checkoutDate}  ${numberOfRoom}  ${hotelName}
    [Arguments]                 ${name}  ${LastName}    ${numberOfRoom}  ${hotelName}
    Click Element               xpath:/html/body/div/main/div[7]/a
    Verify Booking Page Loaded WEB8-21                                  ${hotelName}
    Input Text                  id=CurrentBooking_Name                  ${name}
    Input Text                  id=CurrentBooking_LastName              ${lastName}
    ${CurrentDate} =            Get Current Date    result_format=%m/%d/%Y
    ${CurrentDate1} =           Get Current Date
    ${checkinDate} =	        Add Time To Date     ${CurrentDate1}   2 days   result_format=%m/%d/%Y
    ${checkoutDate} =	        Add Time To Date     ${CurrentDate1}   4 days   result_format=%m/%d/%Y
    Input Text                  id=checkin                              ${checkinDate}
    Input Text                  id=checkout                             ${checkoutDate}
    Verfy Total Days WEB8-21
    Verfy Unit Price WEB8-21
    Input Text                  id=numroom                              ${numberOfRoom}
    Click Element               xpath:/html/body/div/main/div[4]/div/form/div[10]/label
    Verfy Total Price WEB8-21
    Click Button               xpath://*[@id="submitButton"]

Verfy Total Days WEB8-21
    ${link_text} =    Get Text          xpath://*[@id="days"]
    Should Be Equal   ${link_text}      2

Verfy Unit Price WEB8-21
    ${link_text} =    Get Text          xpath://*[@id="price"]
    Should Be Equal   ${link_text}      506.99

Verfy Total Price WEB8-21
    ${totalPrice}    Execute Javascript    return document.getElementById("totalPrice").value
    Should Be Equal    ${totalPrice}      2024

Verify Booking Page Loaded WEB8-21
    [Arguments]                         ${hotelName}
    ${link_text} =    Get Text          xpath:/html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      ${hotelName}
    #${link_text} =    Get Text          xpath:/html/body/div/main/h1
    #Should Be Equal   ${link_text}      Booking

Verify The Booking Success WEB8-21
    [Arguments]                                  ${message}
    Verify My Bookings Page Loaded WEB8-21
    Verify Booking Success Message WEB8-21       ${message}

Verify Booking Success Message WEB8-21
    [Arguments]                                ${message}
    Wait Until Page Contains                   ${message}

Verify The Booking not Success WEB8-21
    #[Arguments]                                  ${message}
    Verify Error Page Loaded WEB8-21
    ${CurrentDate} =            Get Current Date    result_format=%m/%d/%Y
    ${CurrentDate1} =           Get Current Date
    ${FutureDate} =	            Add Time To Date     ${CurrentDate1}   184 days   result_format=%m/%d/%Y
    #Verify Confirmation Message Returned WEB8-21   The field Check In must be between ${CurrentDate} 12:00:00 AM and ${FutureDate} 12:00:00 AM.
    #Verify Confirmation Message Returned WEB8-21   The field Check In must be between 05/09/2020 12:00:00 AM and 11/09/2020 12:00:00 AM.
    Verify Confirmation Message Returned WEB8-21

Verify My Bookings Page Loaded WEB8-21
    ${link_text} =    Get Text          xpath:/html/body/div/main/div/div/div[2]/h4
    Should Be Equal   ${link_text}      My Bookings

Verify Error Page Loaded WEB8-21
    ${link_text} =    Get Text          xpath:/html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Euroway Hotel

Verify Confirmation Message Returned WEB8-21
    #[Arguments]                                ${message}
    #Wait Until Page Contains                   ${message}      10s
    Wait Until Page Contains Element           xpath:/html/body/div/main/div[2]

' User cannot book A Room earlier WEB8-21  '
User Make A Booking Earlier Then Today At Hotel WEB8-21
    [Arguments]                 ${name}  ${LastName}    ${numberOfRoom}  ${hotelName}
    Click Element               xpath:/html/body/div/main/div[7]/a
    Verify Booking Page Loaded WEB8-21                                  ${hotelName}
    Input Text                  id=CurrentBooking_Name                  ${name}
    Input Text                  id=CurrentBooking_LastName              ${lastName}
    ${CurrentDate1} =           Get Current Date
    ${checkinDate} =	        Add Time To Date     ${CurrentDate1}   -2 days   result_format=%m/%d/%Y
    ${checkoutDate} =	        Add Time To Date     ${CurrentDate1}   0 days   result_format=%m/%d/%Y
    Input Text                  id=checkin                              ${checkinDate}
    Input Text                  id=checkout                             ${checkoutDate}
    Verfy Total Days WEB8-21
    Verfy Unit Price WEB8-21
    Input Text                  id=numroom                              ${numberOfRoom}
    Click Element               xpath:/html/body/div/main/div[4]/div/form/div[10]/label
    Verfy Total Price WEB8-21
    Click Button               xpath://*[@id="submitButton"]

' Checkout date should be after checkin date WEB8-21 '
User Make A Wrong Booking At Hotel WEB8-21
    [Arguments]                 ${name}  ${LastName}    ${numberOfRoom}  ${hotelName}
    Click Element               xpath:/html/body/div/main/div[7]/a
    Verify Booking Page Loaded WEB8-21                                  ${hotelName}
    Input Text                  id=CurrentBooking_Name                  ${name}
    Input Text                  id=CurrentBooking_LastName              ${lastName}
    ${CurrentDate} =            Get Current Date    result_format=%m/%d/%Y
    ${CurrentDate1} =           Get Current Date
    ${checkinDate} =	        Add Time To Date     ${CurrentDate1}   4 days   result_format=%m/%d/%Y
    ${checkoutDate} =	        Add Time To Date     ${CurrentDate1}   2 days   result_format=%m/%d/%Y
    Input Text                  id=checkin                              ${checkinDate}
    Input Text                  id=checkout                             ${checkoutDate}
    Verify Error Message Return WEB8-21

Verify Error Message Return WEB8-21
    ${link_text} =    Get Text          xpath://*[@id="days"]
    Should Be Equal   ${link_text}      Pick a checkout date that is after the checkin date

' User Make A Booking After 6 Months At Hotel WEB8-21 '
User Make A Booking After 6 Months At Hotel WEB8-21
    [Arguments]                 ${name}  ${LastName}    ${numberOfRoom}  ${hotelName}
    Click Element               xpath:/html/body/div/main/div[7]/a
    Verify Booking Page Loaded WEB8-21                                  ${hotelName}
    Input Text                  id=CurrentBooking_Name                  ${name}
    Input Text                  id=CurrentBooking_LastName              ${lastName}
    ${CurrentDate1} =           Get Current Date
    ${checkinDate} =	        Add Time To Date     ${CurrentDate1}   200 days   result_format=%m/%d/%Y
    ${checkoutDate} =	        Add Time To Date     ${CurrentDate1}   202 days   result_format=%m/%d/%Y
    Input Text                  id=checkin                              ${checkinDate}
    Input Text                  id=checkout                             ${checkoutDate}
    Verfy Total Days WEB8-21
    Verfy Unit Price WEB8-21
    Input Text                  id=numroom                              ${numberOfRoom}
    Click Element               xpath:/html/body/div/main/div[4]/div/form/div[10]/label
    Verfy Total Price WEB8-21
    Click Button               xpath://*[@id="submitButton"]

' WEB8-27 User can search for hotels regesterd on the page '
WEB8-27 Verfy Search Page Loaded
    ${link_text} =    Get Text   xpath://html/body/div/main/div/div/div[2]/label
    Should Be Equal   ${link_text}   Search:

WEB8-27 Search for Hotel
    [Arguments]                 ${search_term}      ${search_result}
    Enter Search Term           ${search_term}
    Verify Search Completed     ${search_term}      ${search_result}

Enter Search Term
    [Arguments]                 ${search_term}
    Input Text                  xpath://html/body/div/main/div/div/div[2]/label/input   ${search_term}

Verify Search Completed
    [Arguments]                 ${search_term}      ${search_result}
    ${result_text} =    Get Text          xpath://html/body/div/main/div/div/div[3]
    Should be Equal             ${result_text}      ${search_result}

WEB8-27 Search for a specific hotel
    [Arguments]                 ${search_term}      ${search_result}
    Enter Search Term           ${search_term}
    WEB8-27 Verify A Search For A Specific Hotel Completed     ${search_term}      ${search_result}

WEB8-27 Verify A Search For A Specific Hotel Completed
    [Arguments]                 ${search_term}      ${search_result}
    Element Should Contain     xpath://html/body/div/main/div/div/table/tbody/tr/td[2]  ${search_result}

' WEB8-27 user can empty the search feld after entering text '
WEB8-27 Empty the search feld after entering text
    [Arguments]                 ${search_term}      ${search_result}
    Go to Web Page
    Click Element                xpath://html/body/div/main/div[2]/a
    WEB8-27 Verfy Search Page Loaded
    WEB8-27 Search for Hotel         ${search_term}      ${search_result}
    Click Button                xpath://html/body/div/main/div/div/div[2]/label/input
    Element Should Contain      xpath://html/body/div/main/div/div/div[2]/label/input   \

User Can Go To The WebPage
    Go to Web Page

User Can Search For Hotels Regesterd On The Web Page
    Click Element                xpath://html/body/div/main/div[2]/a
    WEB8-27 Verfy Search Page Loaded

User Can Get Results For Hotels Regesterd On The Web Page By Town, Name Or Offerings By The Hotels
    WEB8-27 Search for Hotel    Gothenburg      Showing 1 to 3 of 3 entries (filtered from 9 total entries)
    WEB8-27 Search for Hotel    Prague          Showing 1 to 3 of 3 entries (filtered from 9 total entries)
    WEB8-27 Search for Hotel    Marbella        Showing 1 to 3 of 3 entries (filtered from 9 total entries)

    WEB8-27 Search for a specific hotel     Euroway Hotel       Euroway Hotel
    WEB8-27 Search for a specific hotel     Hotel Residence Agnes       Hotel Residence Agnes
    WEB8-27 Search for a specific hotel     Amàre Beach Hotel       Amàre Beach Hotel

    WEB8-27 Search for Hotel    tv bath wifi    Showing 1 to 2 of 2 entries (filtered from 9 total entries)

' User Can Delete Booking WEB8-23 '
User go to My Bookings WEB8-23
    Click Element                xpath://*[@id="my-bookings"]
    Verify My Bookings Page Loaded WEB8-21

User can delele the page successfully WEB8-23
    [Arguments]                 ${message}
    Click Element               xpath:/html/body/div/main/div/div/div[2]/table/tbody/tr[2]/td[4]/a
    Verify Delete Bookings Page Loaded WEB8-23
    Click Element               xpath:/html/body/div/main/div/form/a
    Verify My Bookings Page Loaded WEB8-21
    Click Element               xpath:/html/body/div/main/div/div/div[2]/table/tbody/tr[1]/td[4]/a
    Verify Delete Bookings Page Loaded WEB8-23
    Click Element               xpath:/html/body/div/main/div/form/input[1]
    Verfy my booking is deleted WEB8-23    ${message}

Verify Delete Bookings Page Loaded WEB8-23
    ${link_text} =    Get Text         xpath:/html/body/div/main/h3
    Should Be Equal   ${link_text}     Are you sure you want to delete this?

Verfy my booking is deleted WEB8-23
    [Arguments]                                 ${message}
    #Wait Until Page Contains                   ${message}
    Element Should Contain     xpath:/html/body/div/main/div/div/div[2]/div    ${message}

' User Can View Booking WEB8-23 '
User can view a specified booking WEB8-23
    Click Element               xpath://*[@id="booking-list"]/td[2]/a
    Verify View Bookings Page Loaded WEB8-23
    Click Element                      xpath:/html/body/div/main/div[2]/a
    User go to My Bookings WEB8-23

Verify View Bookings Page Loaded WEB8-23
    ${link_text} =    Get Text         xpath:/html/body/div/main/div[1]/h4
    Should Be Equal   ${link_text}     Booking Details

User made a booking
    #[Arguments]                             ${firstName}   ${lastName}     ${numOfRooms}
    User log in to Webpage
    User Go Into A Hotel WEB8-21             Euroway Hotel
    ${CurrentDate} =            Get Current Date    result_format=%m/%d/%Y
    ${CurrentDate1} =           Get Current Date
    ${checkinDate} =	        Add Time To Date     ${CurrentDate1}   2 days   result_format=%m/%d/%Y
    ${checkoutDate} =	        Add Time To Date     ${CurrentDate1}   4 days   result_format=%m/%d/%Y
    User Make A Booking At Hotel WEB8-21        ${firstName}   ${lastName}    ${numOfRooms}  Euroway Hotel
    Verify The Booking Success WEB8-21          Booking has been added

' User Can Edit Booking WEB8-23 '
User can edit a specified booking WEB8-23
    Click Element               xpath://*[@id="booking-list"]/td[3]/a
    Verify Edit Bookings Page Loaded WEB8-23
    Click Element                           xpath:/html/body/div/main/div[2]/a
    Verfy Back To My Booking success WEB8-23
    Click Element                           xpath://*[@id="booking-list"]/td[3]/a
    Verify Edit Bookings Page Loaded WEB8-23
    Click Element                           xpath:/html/body/div/main/div[1]/div/form/div[10]/input
    Verfy Edit Booking Success WEB8-23      Booking has been edited

Verfy Back To My Booking success WEB8-23
    ${link_text} =    Get Text         xpath:/html/body/div/main/div/div/div[2]/h4
    Should Be Equal   ${link_text}     My Bookings

Verify Edit Bookings Page Loaded WEB8-23
    ${link_text} =    Get Text         xpath:/html/body/div/main/h4
    Should Be Equal   ${link_text}     Edit Booking

Verfy Edit Booking Success WEB8-23
    [Arguments]                                ${message}
    Wait Until Page Contains                   ${message}


