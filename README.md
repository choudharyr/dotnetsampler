# DotNetSampler

## Overview

`DotNetSampler` is a .NET library containing utility functions for string comparison, path manipulation, and calculating the speed of a vehicle traveling along a path of points with timestamps. The project also includes a test suite to verify the functionality of these utilities.

## Features

1. **RelativeToCommonBase**: 
   - Computes the portion of the first path that is not common with the second path.

2. **ClosestWord**:
   - Finds the most liked string from a list of strings to a given input string using the Levenshtein distance algorithm.

3. **SpeedAtTime**:
   - Calculates the instantaneous speed of a vehicle at a given time based on a list of points and timestamps.

## Testing

1. Open the solution in Visual Studio 2022.
2. Ensure the test project `DotNetSampler.Tests` is set up correctly with a reference to `DotNetSampler`.
3. Run the tests using the Test Explorer.

### Test Cases

- **RelativeToCommonBase_ShouldReturnEmptyString_WhenPathsAreIdentical**
- **RelativeToCommonBase_ShouldReturnUncommonPathSegment**
- **ClosestWord_ShouldReturnMostSimilarWord**
- **SpeedAtTime_ShouldReturnCorrectSpeed**
- **SpeedAtTime_ShouldThrowException_WhenPathHasLessThanTwoPoints**
- **ClosestWord_ShouldThrowException_WhenInputIsNullOrEmpty**
