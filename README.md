# FloatingPointToDenary
A C# script to convert floating point binary numbers (of any sized mantissa and exponent) into denary.
## Features
 - Converts two's complement floating-point binary numbers to decimal.
 - Validates user inputs to ensure accuracy
 - Handles positive and negative mantissas and exponents.
 - Outputs the decimal representation of the given binary number.
## How It Works
1. The user inputs:
 - A binary number (including mantissa and exponent)
 - The length of the mantissa
 - The length of the exponent
2. The input is validated to avoid problems later
3. The binary input is split into the mantissa and the exponent
4. If the number is negative this fact is stored and a twos complement operation applied
5. The exponent determines the placement of the binary point in the mantissa.
6. The integer and fractional parts of the mantissa are converted to decimal using place value.
7. The final decimal value is displayed.
## Installation & Usage
### Prerequisites
Ensure that you have a version of the C# dotnet compiler
```console
dotnet --version
```
If you do not have it install it from [here](https://dotnet.microsoft.com/en-us/download)
### Running the Program
1. Clone this repository
```console
git clone https://github.com/SethAidan/FloatingPointToDenary.git FloatToDecimal
cd FloatToDecimal
```
2. Compile and run the program
```console
dotnet run
```
### Example Input/Output
```console
Enter a binary number : 1101010
Enter the length of the mantissa : 4
Enter the length of the exponent : 3
Decimal equivalent: -5.25
```