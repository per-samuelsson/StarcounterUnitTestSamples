# Projects

* AppLibrary is a DLL with some database classes, referencing Starcounter.
* App is an EXE with additional database classes, referencing AppLibrary and Starcounter
* App.Tests contain unit tests, based on xUnit (https://xunit.github.io/).

# References in App.Tests
These test references where added:

  * xunit - the actual test facade library
  * xunit.runner.console - development dependency to allow running tests in a CLI
  * xunit.runner.visualstudio - development dependency making tests discoverable by VS Test Explorer
  * Starcounter and Starcounter.Hosting to enable hosting of tests

# Testing Starcounter with xUnit
For tests based on xUnit, we enforce or recommend the following settings:

  * For VS Test Explorer,
	* Test | Test Settings | Default Processor Architecture: x64 (enforced)
	* Test | Test Settings | Keep Test Execution Engine Running: False (recommended)