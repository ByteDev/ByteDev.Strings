# Release Notes

## 6.0.0 - ??

Breaking changes:
- Fixed `CaseType` namespace

New features:
- Added `StringEndLineCharsExtensions.GetEndLineChars`
- Added `StringEndLineCharsExtensions.RemoveEndLineChars`

Bug fixes / internal changes:
- (None)

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
