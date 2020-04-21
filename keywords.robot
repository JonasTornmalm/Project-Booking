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

#Verify Page Loaded
#   ${link_text} =    Get Text   xpath://html/body/header/nav/div/a
#    Should Be Equal   ${link_text}   Project_Booking

Verify Page Loaded
    ${link_text} =    Get Text   xpath://html/body/div/main/div/h1
    Should Be Equal   ${link_text}   Welcome

End Web Test
    Close Browser

