# Release Notes

## 4.1.0 - 17 July 2020

Breaking changes:
- (None)

New features:
- Add StringToExtensions.ToInt
- Add StringToExtensions.ToLong
- Add StringToExtensions.ToDateTime
- Add StringToExtensions.ToCsv
- Add StringToExtensions.ToUri
- Add StringToExtensions.ToBool
- Add StringToExtensions.ToBoolOrDefault
- Add StringToExtensions.ToGuid

Bug fixes / internal changes:
- (None)

## 4.0.0 - 01 July 2020

Breaking changes:
- Replaced ToStringHelper class with ToStringBuilder class

New features:
- Added StringCaseExtensions: IsCamelCase, IsKebabCase, IsPascalCase, IsSnakeCase, IsSnakeUpperCase
- Added StringCommands

Bug fixes / internal changes:
- (None)

## 3.0.0 - 16 June 2020

Breaking changes:
- Deleted StringIsExtensions.IsHex(); see ByteDev.Encoding package

New features:
- Added CaseConverter & CaseType

Bug fixes / internal changes:
- Fixed bug in ToTitleCase

## 2.1.0 - 29 May 2020

Breaking changes:
- (None)

New features:
- Added IsTrue
- Added IsFalse
- Added IsLengthBetween
- Added IsLowerCase
- Added IsUpperCase
- Added IsTime

Bug fixes / internal changes:
- (None)

## 2.0.1 - 29 May 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Fixes in IsHttpUrl method

## 2.0.0 - 28 May 2020

Breaking changes:
- Added IsNumeric extension method
- IsUrl is now IsHttpUrl
- CountOccurrences method name spelling mistake

New features:
- Added CountOccurrences overload for char value

Bug fixes / internal changes:
- Simplified IsEmailAddress implementation

## 1.0.0 - 30 April 2020

Initial version.
