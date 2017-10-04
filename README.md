# About
Unit testing samples, showing recommended practices writing unit tests targeting Starcounter.

# Structure of samples
* AppLibrary.dll - library with database classes
* App.exe - Application consuming database classes from AppLibrary, and define classes itself.
* App.Tests - tests testing classes in above assemblies, using a specific framework (e.g. xUnit or NUnit)
* UnitTestSamples.[TestFramework].sln
* ReadMe.txt - specifics for this particular framework
