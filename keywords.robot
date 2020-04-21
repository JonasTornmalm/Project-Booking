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
    [Arguments]                            ${name}  ${lastName}  ${phoneNumber}
    Enter Name WEB8-65                      ${name}
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
    Click Element               xpath://html/body/div/main/div[2]/div[1]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Euroway Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Gothia Towers Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[2]/div[2]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Gothia Towers Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Dorsia Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[2]/div[3]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Dorsia Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Hilton Prague Old Town Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[2]/div[4]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Hilton Prague Old Town
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Hotel Residence Agnes Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[2]/div[5]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Hotel Residence Agnes
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify One Room Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[2]/div[6]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      One Room Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify The Touch Puerto Banus Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[2]/div[7]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      The Touch Puerto Banús
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Amare Beach Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[2]/div[8]/div/div[1]/h4/a
    ${link_text} =    Get Text          xpath://html/body/div/main/div[1]/h1
    Should Be Equal   ${link_text}      Amàre Beach Hotel
    Click Element               xpath://html/body/header/nav/div/a
    Verify Page Loaded

Verify Marbella Club Hotel Page Loaded WEB8-45
    Click Element               xpath://html/body/div/main/div[2]/div[9]/div/div[1]/h4/a
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
