# Zone Challenge
My approach for this challenge was to demonstrate how I would create a scalable and maintainable test automation framework using best practices. I chose the complex happy path route and the test has been designed to complete the path successfully on desktop and mobile devices. Considering the scope of this challenge and for simplicity, I chose to only run the tests in Chrome Driver. For a full test framework I would add the ability to switch to use other browsers as running on a cloud-based service such as Browserstack.

## Prerequisites
- Visual Studio 2017 (Windows)
- Visual Studio 2017 'ASP.NET and web development' workload

The following NuGet Packages are used in this framework which should be installed when restoring NuGet packages:
- log4net
- MSTest.TestAdapter
- MSTest.TestFramework
- Selenium.Chrome.WebDriver
- Selenium.Support
- Selenium.WebDriver

## How to use
1. Clone repository
2. Open ZoneChallenge.sln in Visual Studio 2017
3. Restore NuGet packages
4. Build solution
5. Run tests

## Tests
The following tests are contained in this solution:
1. **HappyPathTestComplex** - this test should pass
2. **HappyPathTestComplexFail** - this test will fail in order to demonstrate the information made available for debugging when a test fails

By default, both tests will run headless on a desktop size instance of Chrome. To demonstrate the tests being run on mobile you can comment and uncomment lines 32 and 35 respectively of BaseClasses/Base.cs. Additionally, line 37 can be commented out to disable headless mode.

![Test configuration](img/testConfig.png?raw=true "Test configuration")

## Features and notes
- Page Object Model pattern used
- Inheritance of classes Base.cs and Page.cs demonstrated
- Encapsulation used
- Logging added to all helper class methods and wherever appropriate
- Screenshots taken on test fail
- A different path is taken based on viewport width to enable Quick View to be opened on both mobile and desktop

## Technical debt
- Ability to run on browsers and devices other than Chrome not implemented
- Further logging could be added for additional information such as JavaScript errors
- Waits not used because they were unecessary for this happy path on Chrome - these may be required to ensure tests run reliably on other browsers and devices
