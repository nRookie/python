*** Settings ***
Documentation     Simple example using SeleniumLibrary.
Library           SeleniumLibrary

*** Variables ***
${LOGIN URL}      http://localhost:5000
${BROWSER}        Chrome

*** Test Cases ***
Valid Login
    Open Browser To Login Page
    capture page screenshot  D:/good/test.png
    Input Username    admin
    Input Password    admin
    Submit Credentials
    Welcome Page Should Be Open
    [Teardown]    Close Browser

*** Keywords ***
Open Browser To Login Page
    Open Browser    ${LOGIN URL}    ${BROWSER}
    Title Should Be    Welcome to FlaskTaskr

Input Username
    [Arguments]    ${username}
    Input Text    username    ${username}

Input Password
    [Arguments]    ${password}
    Input Text    password    ${password}

Submit Credentials
    Click Button    Login

Welcome Page Should Be Open
    Title Should Be    Welcome to FlaskTaskr