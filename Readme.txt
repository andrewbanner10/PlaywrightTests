Hello!

Firstly

All the tests except for the UserAddsProductAndCanViewProductInCart work, this test is showcasing a bug.

There is also a cloudflare issue within the sauce demo website which periodically fails tests as it cannot bypass 
the are you human check. There is nothing I can do about that (i discovered this when the assessment was pretty much completed)
this probably would not be a real issue on a development environment as its unlikey cloudflare would be present or configured

AI declaration.

Used to assist with the playwright.yml file and gave a step by step guide to the use of allure within the project
as it was not something i have used before so hence was using Ai to guide the process



CI/CD - 
https://github.com/andrewbanner10/PlaywrightTests

The github pipeline action(s) has been setup so that on code commit (on certain branches) or pull request
It will run the playwright tests and create the JSON and screenshot allure which the user can down and use the allure serve to view
I was looking at a way to have git/github create this report within a better output but it required git permissions and branching
which i tought for this exercise goes beyond what is required.

API test - there are no API tests for this solution at the moment. If i was creating API tests i would seperate the tests into
an API tests folder  and within there create the API tests using RestSharp (easy to construct the API request), i would then 
have JSON data files for the required API tests either Put/Post/Patch requests (if the request requires alot of data)
if the test was sending over 1 field i would have that as a parameter within the test that gets passed in. Likewise for any Get 
requests if i was checking a few fields i would pass into the test those vlaues else i would store the espected JSON in a file
and compare that to the JSON response from the test.

I have been using Visual studio for the running of the tests so in test explorer using run all (if in the Ci Cd pipeline it runs
on commit or pr or rerun select job from within github actions)



Running the tests

Ensure git is installed
Ensure .net9.0 is installed
Ensure powershell is installed

open visual studio - clone the repository - https://github.com/andrewbanner10/PlaywrightTests.git
build - rebuild solution
run the test in test explorer

View results 

in the terminal cd to your repo for the solution (if not already there)
then into the bin
then to Debug
then to net9.0

then run
allure serve allure-results

if you are not using visual studio then in your ide of choice run the following commands in a terminal

dotnet restore
dotnet build
pwsh bin/Debug/net9.0/playwright.ps1 install

Run the tests

dotnet test

View results 

in the terminal cd to your repo for the solution (if not already there)
then into the bin
then to Debug
then to net9.0

then run
allure serve allure-results

or open the repo in file explorer, navigate to the bin, debug,net9.0 file and open powershell from within that 
window (shift right click)
run the command  allure serve allure-results