# Description
Implementation of the [assignment](doc/assignment.pdf) for MM Guide company

# Tech Stack
* .NET 7 (latest **battle** tested version)
* xUnit (for convenience to execute solutions and unit tests)
* Moq (for unit tests)
* FluentAssertions (for unit tests)
* BenchmarkDotNet (for performance tests)

# Solution structure
* Each 'Question' form the assignment has its own isolated folder in the code base with appropriate number
* Each 'Question' might have several/alternative solutions
* Each 'Solution' has domain related files, **UnitTests** file and might have **PerformanceTests** file (Warning! Performance Tests might take up to 25 min to run)
