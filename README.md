[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Strings?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Strings/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Strings.svg)](https://www.nuget.org/packages/ByteDev.Strings)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/66d95274cd9e47729814395291051437)](https://www.codacy.com/manual/ByteDev/ByteDev.Strings?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=ByteDev/ByteDev.Strings&amp;utm_campaign=Badge_Grade)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Strings/blob/master/LICENSE)

# ByteDev.Strings

Set of string extension methods.

## Installation

ByteDev.Strings has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Strings is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Strings`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Strings/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Strings/blob/master/docs/RELEASE-NOTES.md).

## Code

The repo can be cloned from git bash:

`git clone https://github.com/ByteDev/ByteDev.Strings`

## Usage

### String Extensions

To use any extension methods simply reference the `ByteDev.Strings` namespace.

Assembly contains string extension methods:
- FormatWith
- SafeLength
- SafeSubstring
- Repeat
- Left
- LeftWithEllipsis
- LeftWithInnerEllipsis
- Right
- Pluralize
- CountOccurences
- Mask
- Reverse
- ContainsIgnoreCase
- AddPrefix
- AddSuffix
- Remove
- RemoveStartsWith
- RemoveEndsWith
- RemoveBracketedText
- RemoveWhiteSpace
- ReplaceFirst
- ReplaceLast
- ReplaceToken
- IsEmpty
- IsNullOrEmpty
- IsNullOrWhitespace
- IsNotNullOrEmpty
- IsEmailAddress
- IsUrl
- IsIpAddress
- IsGuid
- IsXml
- IsHex
- IsDigit
- IsDigits
- IsLetters
- ToTitleCase
- ToLines
- ToByteArray
- ToIntOrDefault
- ToLongOrDefault
- ToDateTimeOrDefault
- ToEnum

### ToStringHelper

The assembly also contains the type `ToStringHelper` to help return string representations of an object when overriding it's ToString method.

```csharp
public class MyClass
{
    public string Name => "John";

    public string Age => null;

    public IEnumerable<string> Address => new List<string>
    {
        "123 Highstreet",
        "London",
        "UK"
    };

    public override string ToString()
    {
        var helper = new ToStringHelper("<null>");

        return helper.ToString(nameof(Name), Name) + ", " +
                helper.ToString(nameof(Age), Age) + ", " +
                helper.ToString(nameof(Address), Address);
    }
}

// ...
string s = new MyClass().ToString();

// s == "Name: John, Age: <null>, Address: { 123 Highstreet, London, UK }"
```