[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Strings?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Strings/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Strings.svg)](https://www.nuget.org/packages/ByteDev.Strings)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/66d95274cd9e47729814395291051437)](https://www.codacy.com/manual/ByteDev/ByteDev.Strings?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=ByteDev/ByteDev.Strings&amp;utm_campaign=Badge_Grade)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Strings/blob/master/LICENSE)

# ByteDev.Strings

Set of string related extension methods and classes.

## Installation

ByteDev.Strings has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Strings is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Strings`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Strings/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Strings/blob/master/docs/RELEASE-NOTES.md).

## Usage

### String Extensions

To use any extension methods simply reference the `ByteDev.Strings` namespace.

Assembly contains string extension methods:
- AddPrefix
- AddSuffix
- ContainsIgnoreCase
- CountOccurrences
- FormatWith
- IsDigit
- IsDigits
- IsEmpty
- IsEmailAddress
- IsFalse
- IsGuid
- IsHttpUrl
- IsIpAddress
- IsLengthBetween
- IsLetters
- IsLowerCase
- IsNullOrEmpty
- IsNullOrWhitespace
- IsNotNullOrEmpty
- IsNumeric
- IsUpperCase
- IsTime
- IsTrue
- IsXml
- Left
- LeftWithEllipsis
- LeftWithInnerEllipsis
- Mask
- Pluralize
- Remove
- RemoveStartsWith
- RemoveEndsWith
- RemoveBracketedText
- RemoveWhiteSpace
- Repeat
- ReplaceFirst
- ReplaceLast
- ReplaceToken
- Reverse
- Right
- SafeLength
- SafeSubstring
- ToTitleCase
- ToLines
- ToByteArray
- ToIntOrDefault
- ToLongOrDefault
- ToDateTimeOrDefault
- ToEnum

### CaseConverter

To use `CaseConverter` reference the `ByteDev.Strings.Case` namespace.

`CaseConverter` has the following methods:
- ToCamelCase
- ToKebabCase
- ToPascalCase
- ToSnakeCase
- ToSnakeUpperCase

```csharp
string s1 = CaseConverter.ToCamelCase("snake_case", CaseType.SnakeCase);   // "snakeCase"

string s2 = CaseConverter.ToPascalCase("kebab-case", CaseType.KebabCase);  // "KebabCase"

bool isPascalCase = s2.IsPascalCase();   // true
```

There are also a number of case related string extension methods:

- IsCamelCase
- IsKebabCase
- IsPascalCase
- IsSnakeCase
- IsSnakeUpperCase
- IsCaseType

### StringCommands

To use the various string commands reference the `ByteDev.Strings.StringCommands` namespace.

```csharp
var c1 = new CaseToLowerCommand().SetValue("John Smith");
var c2 = new CopyPasteCommand(0, 4, 0).SetValue("John Smith");

IStringCommandInvoker invoker = new StringCommandInvoker();

invoker.SetCommands(c1, c2);
invoker.Invoke();

// c1.Result == "john smith" 
// c2.Result == "JohnJohn Smith"
```

Commands can also be chained together using the `StringChainedCommand`:

```csharp
// Note: we don't have to call SetValue on each command just on StringChainedCommand
// as this will provide the initial value.

var commands = new List<StringCommand>
{
    new CaseToLowerCommand(),
    new InsertCommand(100, " lives in England."),
    new CutPasteCommand(5, 5, 0)
};

var c1 = new StringChainedCommand(commands).SetValue("John Smith");

IStringCommandInvoker invoker = new StringCommandInvoker();

invoker.SetCommands(c1);
invoker.Invoke();

// command.Result == "smithjohn  lives in England."
```


### ToStringBuilder

The assembly also contains the type `ToStringBuilder` to help return string representations of an object when overriding it's `ToString` method.

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
        return new ToStringBuilder()
            .WithNullValue("<null>")
            .WithStringQuoteChar('\'')
            .With(nameof(Name), Name)
            .With(nameof(Age), Age)
            .With(nameof(Address), Address)
            .Build();
    }
}

// ...
string s = new MyClass().ToString();

// s == "Name: 'John', Age: <null>, Address: { '123 Highstreet', 'London', 'UK' }"
```
