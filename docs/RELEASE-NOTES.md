# Release Notes

## 9.5.0 - 30 November 2021

Breaking changes:
- (None)

New features:
- Added `RemoveLeadingZeros` method.
- Added `ToMemoryStream` method.
- Added `InsertBeforeUpperCase` method.

Bug fixes / internal changes:
- Minor bug fix in `EnsureStartsWith`.
- Minor bug fix in `EnsureEndsWith`.

## 9.4.0 - 16 August 2021

Breaking changes:
- (None)

New features:
- Added `StringSafeExtensions.SafeGetChar` method.

Bug fixes / internal changes:
- (None)

## 9.3.0 - 14 July 2021

Breaking changes:
- (None)

New features:
- Added `StringIsExtensions.IsAscii` method.
- Added `StringRemoveExtensions.RemoveNonDigits` method.

Bug fixes / internal changes:
- (None)

## 9.2.0 - 27 May 2021

Breaking changes:
- (None)

New features:
- Added `StringIsExtensions.IsUri` method.
- Added `StringToExtensions.ToLinesList` method.

Bug fixes / internal changes:
- (None)

## 9.1.0 - 29 March 2021

Breaking changes:
- (None)

New features:
- Added `StringToExtensions.ToKeyValuePair` method.

Bug fixes / internal changes:
- (None)

## 9.0.0 - 15 March 2021

Breaking changes:
- Renamed `StringEndLineCharsExtensions.GetEndLineChars` to `StringNewLineExtensions.GetEndNewLine`.
- Renamed `StringEndLineCharsExtensions.RemoveEndLineChars` to `StringNewLineExtensions.RemoveEndNewLine`.

New features:
- Added `StringNewLineExtensions.DetectNewLineType` method.
- Added `StringNewLineExtensions.NormalizeNewLinesToUnix` method.
- Added `StringNewLineExtensions.NormalizeNewLinesToWindows` method.
- Added `NewLineType` enum.
- Added `NewLineStrings` static class.

Bug fixes / internal changes:
- (None)

## 8.3.0 - 10 March 2021

Breaking changes:
- (None)

New features:
- Added `StringBuilderExtensions.AppendIfEmpty` method.
- Added `StringBuilderExtensions.AppendIfNotEmpty` method.

Bug fixes / internal changes:
- (None)

## 8.2.0 - 28 January 2021

Breaking changes:
- (None)

New features:
- Added `StringBuilder.IsEmpty` method.
- Added `StringBuilder.AppendValues` method.
- Added `StringBuilder.AppendLines` method.
- Added `StringToExtensions.ToLines` optional param.
- Added `StringExtensions.Wrap`  method.

Bug fixes / internal changes:
- (None)

## 8.1.0 - 31 December 2020

Breaking changes:
- (None)

New features:
- Added overload for `StringSafeExtensions.SafeSubstring`  method.

Bug fixes / internal changes:
- Changed `StringRemoveExtensions.RemoveWhiteSpace` implementation.
- Fixed bug in `StringSafeExtensions.SafeSubstring`.

## 8.0.0 - 10 November 2020

Breaking changes:
- Removed `StringIsExtensions.IsNotNullOrEmpty`  method.

New features:
- Added `StringIsExtensions.IsPhoneNumber`  method.

Bug fixes / internal changes:
- Fix `StringIsExtensions.IsNumeric` now allows hyphen prefix.

## 7.0.0 - 05 November 2020

Breaking changes:
- Renamed `StringExtensions.AddPrefix` to `EnsureStartsWith`.
- Renamed `StringExtensions.AddSuffix` to `EnsureEndsWith`.

New features:
- Method `Masker.EmailAddress` now takes optional params.
- Added `StringContainsExtensions.ContainsOnly` method.
- Added `StringContainsExtensions.ContainsAny` method.

Bug fixes / internal changes:
- (None)

## 6.0.0 - 30 September 2020

Breaking changes:
- Fixed `CaseType` namespace.

New features:
- Added `StringEndLineCharsExtensions.GetEndLineChars` method.
- Added `StringEndLineCharsExtensions.RemoveEndLineChars` method.

Bug fixes / internal changes:
- Fixed `RemoveStartsWith` to now return same value on empty or null.
- Fixed `RemoveEndsWith` to now return same value on empty or null.

## 5.0.0 - 28 September 2020

Breaking changes:
- Removed `StringExtensions.Mask` method.

New features:
- Added `Masker` type.

Bug fixes / internal changes:
- (None)

## 4.1.0 - 17 July 2020

Breaking changes:
- (None)

New features:
- Add `StringToExtensions.ToInt` method.
- Add `StringToExtensions.ToLong` method.
- Add `StringToExtensions.ToDateTime` method.
- Add `StringToExtensions.ToCsv` method.
- Add `StringToExtensions.ToUri` method.
- Add `StringToExtensions.ToBool` method.
- Add `StringToExtensions.ToBoolOrDefault` method.
- Add `StringToExtensions.ToGuid` method.

Bug fixes / internal changes:
- (None)

## 4.0.0 - 01 July 2020

Breaking changes:
- Deleted `ToStringHelper` class (use `ToStringBuilder`).

New features:
- Added `ToStringBuilder` class.
- Added `StringCaseExtensions.IsCamelCase` method.
- Added `StringCaseExtensions.IsKebabCase` method.
- Added `StringCaseExtensions.IsPascalCase` method.
- Added `StringCaseExtensions.IsSnakeCase` method.
- Added `StringCaseExtensions.IsSnakeUpperCase` method.
- Added `StringCommands`.

Bug fixes / internal changes:
- (None)

## 3.0.0 - 16 June 2020

Breaking changes:
- Deleted `StringIsExtensions.IsHex()` (instead use `ByteDev.Encoding` package).

New features:
- Added `CaseConverter` type.
- Added `CaseType` enum.

Bug fixes / internal changes:
- Fixed bug in `ToTitleCase`.

## 2.1.0 - 29 May 2020

Breaking changes:
- (None)

New features:
- Added `StringIsExtensions.IsTrue` method.
- Added `StringIsExtensions.IsFalse` method.
- Added `StringIsExtensions.IsLengthBetween` method.
- Added `StringIsExtensions.IsLowerCase` method.
- Added `StringIsExtensions.IsUpperCase` method.
- Added `StringIsExtensions.IsTime` method.

Bug fixes / internal changes:
- (None)

## 2.0.1 - 29 May 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Fixes in `IsHttpUrl` method.

## 2.0.0 - 28 May 2020

Breaking changes:
- Renamed method `IsUrl` to `IsHttpUrl`.
- Renamed `CountOccurrences` method name (spelling mistake).

New features:
- Added `StringIsExtensions.IsNumeric` method.
- Added `CountOccurrences` overload for char value.

Bug fixes / internal changes:
- Simplified `IsEmailAddress` implementation.

## 1.0.0 - 30 April 2020

Initial version.
