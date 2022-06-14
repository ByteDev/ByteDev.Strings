[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Strings?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Strings/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Strings.svg)](https://www.nuget.org/packages/ByteDev.Strings)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Strings/blob/master/LICENSE)

# ByteDev.Strings

Library of extended string related functionality.

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

To use any of the extension method reference the `ByteDev.Strings` namespace.

String extension methods:

- ContainsAll
- ContainsAny
- ContainsOnly
- ContainsIgnoreCase
- CountOccurrences
- DetectNewLineType
- EnsureStartsWith
- EnsureEndsWith
- FormatWith
- GetEndNewLine
- InsertBeforeUpperCase
- IsAscii
- IsDateTime
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
- IsNumeric
- IsPhoneNumber
- IsUpperCase
- IsUri
- IsTime
- IsTrue
- IsXml
- Left
- LeftWithEllipsis
- LeftWithInnerEllipsis
- NormalizeNewLinesToUnix
- NormalizeNewLinesToWindows
- Pluralize
- Remove
- RemoveBracketedText
- RemoveEndNewLine
- RemoveEndsWith
- RemoveLeadingZeros
- RemoveNonDigits
- RemoveStartsWith
- RemoveWhiteSpace
- Repeat
- ReplaceFirst
- ReplaceLast
- ReplaceToken
- Reverse
- Right
- SafeGetChar
- SafeLength
- SafeSubstring
- ToBool
- ToBoolOrDefault
- ToByteArray
- ToSequence
- ToEnum
- ToGuid
- ToInt
- ToIntOrDefault
- ToKeyValuePair
- ToLines
- ToLinesList
- ToLong
- ToLongOrDefault
- ToMemoryStream
- ToUri
- ToTitleCase
- Wrap

StringBuilder extension methods:

- AppendIfEmpty
- AppendIfNotEmpty
- AppendLines
- AppendValues
- IsEmpty

---

### CaseConverter

`CaseConverter` can be used to change the case of different strings.

Reference namespace: `ByteDev.Strings.Case`.

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

---

### StringCommands

Various `StringCommands` are included that encapsulate different string operations.

Reference namespace: `ByteDev.Strings.StringCommands`.

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

---

### ToStringBuilder

The assembly also contains the type `ToStringBuilder` to help return string representations of an object when overriding it's `ToString` method.

Reference namespace: `ByteDev.Strings`.

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

---

### Masker

Use the `Masker` type to help mask different types of strings.

Reference namespace: `ByteDev.Strings.Masking`.

```csharp
// Initialize Masker type

var options = new MaskerOptions
{
    MaskChar = '#',
    MaskSpace = true
};

var masker = new Masker(options);
```

```csharp
// Mask a payment card number

string card = masker.PaymentCard("4111111111111111");

// card == "############1111"
```

```csharp
// Mask an email address

string email = masker.EmailAddress("john.smith@gmail.co.uk");

// email == "j#########@#####.co.uk"
```

```csharp
// Mask a custom string

string custom = masker.Custom("12345", 1, 2);

// custom == "1##45"
```

