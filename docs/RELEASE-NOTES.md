# Release Notes

## 9.3.0 - ?

Breaking changes:
- (None)

New features:
- Added `StringIsExtensions.IsAscii`.

Bug fixes / internal changes:
- (None)

## 9.2.0 - 27 May 2021

Breaking changes:
- (None)

New features:
- Added `StringIsExtensions.IsUri`.
- Added `StringToExtensions.ToLinesList`.

Bug fixes / internal changes:
- (None)

## 9.1.0 - 29 March 2021

Breaking changes:
- (None)

New features:
- Added `StringToExtensions.ToKeyValuePair`.

Bug fixes / internal changes:
- (None)

## 9.0.0 - 15 March 2021

Breaking changes:
- Renamed `StringEndLineCharsExtensions.GetEndLineChars` to `StringNewLineExtensions.GetEndNewLine`.
- Renamed `StringEndLineCharsExtensions.RemoveEndLineChars` to `StringNewLineExtensions.RemoveEndNewLine`.

New features:
- Added `StringNewLineExtensions.DetectNewLineType`.
- Added `StringNewLineExtensions.NormalizeNewLinesToUnix`.
- Added `StringNewLineExtensions.NormalizeNewLinesToWindows`.
- Added `NewLineType`.
- Added `NewLineStrings`.

Bug fixes / internal changes:
- (None)

## 8.3.0 - 10 March 2021

Breaking changes:
- (None)

New features:
- Added `StringBuilderExtensions.AppendIfEmpty`.
- Added `StringBuilderExtensions.AppendIfNotEmpty`.

Bug fixes / internal changes:
- (None)

## 8.2.0 - 28 January 2021

Breaking changes:
- (None)

New features:
- Added `StringBuilder.IsEmpty`.
- Added `StringBuilder.AppendValues`.
- Added `StringBuilder.AppendLines`.
- Added `StringToExtensions.ToLines` optional param.
- Added `StringExtensions.Wrap`.

Bug fixes / internal changes:
- (None)

## 8.1.0 - 31 December 2020

Breaking changes:
- (None)

New features:
- Added overload for `StringSafeExtensions.SafeSubstring`

Bug fixes / internal changes:
- Changed `StringRemoveExtensions.RemoveWhiteSpace` implementation
- Fixed bug in `StringSafeExtensions.SafeSubstring`

## 8.0.0 - 10 November 2020

Breaking changes:
- Removed `StringIsExtensions.IsNotNullOrEmpty`

New features:
- Added `StringIsExtensions.IsPhoneNumber`

Bug fixes / internal changes:
- Fix `StringIsExtensions.IsNumeric` now allows hyphen prefix

## 7.0.0 - 05 November 2020

Breaking changes:
- Renamed `StringExtensions.AddPrefix` to `EnsureStartsWith`
- Renamed `StringExtensions.AddSuffix` to `EnsureEndsWith`

New features:
- `Masker.EmailAddress` now takes optional params
- Added `StringContainsExtensions.ContainsOnly`
- Added `StringContainsExtensions.ContainsAny`

Bug fixes / internal changes:
- (None)

## 6.0.0 - 30 September 2020

Breaking changes:
- Fixed `CaseType` namespace

New features:
- Added `StringEndLineCharsExtensions.GetEndLineChars`
- Added `StringEndLineCharsExtensions.RemoveEndLineChars`

Bug fixes / internal changes:
- Fixed `RemoveStartsWith` to now return same value on empty or null
- Fixed `RemoveEndsWith` to now return same value on empty or null

## 5.0.0 - 28 September 2020

Breaking changes:
- Removed `StringExtensions.Mask`

New features:
- Added `Masker` type

Bug fixes / internal changes:
- (None)

## 4.1.0 - 17 July 2020

Breaking changes:
- (None)

New features:
- Add `StringToExtensions.ToInt`
- Add `StringToExtensions.ToLong`
- Add `StringToExtensions.ToDateTime`
- Add `StringToExtensions.ToCsv`
- Add `StringToExtensions.ToUri`
- Add `StringToExtensions.ToBool`
- Add `StringToExtensions.ToBoolOrDefault`
- Add `StringToExtensions.ToGuid`

Bug fixes / internal changes:
- (None)

## 4.0.0 - 01 July 2020

Breaking changes:
- Deleted `ToStringHelper` class (use `ToStringBuilder`) 

New features:
- Added `ToStringBuilder` class
- Added `StringCaseExtensions`: `IsCamelCase`, `IsKebabCase`, `IsPascalCase`, `IsSnakeCase`, `IsSnakeUpperCase`
- Added `StringCommands`

Bug fixes / internal changes:
- (None)

## 3.0.0 - 16 June 2020

Breaking changes:
- Deleted `StringIsExtensions.IsHex()` (instead use `ByteDev.Encoding` package)

New features:
- Added `CaseConverter` type
- Added `CaseType` enum

Bug fixes / internal changes:
- Fixed bug in `ToTitleCase`

## 2.1.0 - 29 May 2020

Breaking changes:
- (None)

New features:
- Added `StringIsExtensions.IsTrue`
- Added `StringIsExtensions.IsFalse`
- Added `StringIsExtensions.IsLengthBetween`
- Added `StringIsExtensions.IsLowerCase`
- Added `StringIsExtensions.IsUpperCase`
- Added `StringIsExtensions.IsTime`

Bug fixes / internal changes:
- (None)

## 2.0.1 - 29 May 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Fixes in `IsHttpUrl` method

## 2.0.0 - 28 May 2020

Breaking changes:
- Added `StringIsExtensions.IsNumeric`
- Renamed `IsUrl` to `IsHttpUrl`
- Renamed `CountOccurrences` method name (spelling mistake)

New features:
- Added `CountOccurrences` overload for char value

Bug fixes / internal changes:
- Simplified `IsEmailAddress` implementation

## 1.0.0 - 30 April 2020

Initial version.
