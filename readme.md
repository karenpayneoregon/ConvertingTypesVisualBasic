# VB.NET Data conversions


## Overview
Developers work with various types of data ranging from displaying information collected from user inputting which is then stored in a container, reading information from various sources such as web services, native files to databases. One thing is common, at one point the data is represented as an object and usually a string. In this article developers will learn how to work with raw data to convert to a type suitable for tasks in Visual Studio solutions using defensive programming which means in most task data read or written may not be in the expected format to be stored in designated containers like databases, json, xml or another format.

Information and code samples are geared towards both novice and intermediate skill level which are demonstrated in unit test, Windows Forms and WPF projects. In some cases, there will be class projects which can be used in a Visual Studio solution by copying one of the class projects into an existing Visual Studio solution followed by (if needed) changing the .NET Framework version in the class project to match the .NET Framework used in an existing Visual Studio solution. The base .NET Framework used in code in this article is 4.7.2. If a Framework below 3.5 is used code presented may not work, for example String. IsNullOrWhiteSpace was first introduced in Framework 3.5.

Language extension methods are utilizing in many operations which in some cases utilize LINQ or Lambda, when reviewing these methods do not to hung up on the complexity, instead if the method(s) work simply use them. 

> The code presented should not be considered that they belong to one platform when presented in  [ASP.NET](https://dotnet.microsoft.com/apps/aspnet), [WPF](https://docs.microsoft.com/en-us/dotnet/framework/wpf/) or [Windows Forms](https://docs.microsoft.com/en-us/dotnet/framework/winforms/). For example, exploring code in a WPF project may reveal a useful regular expression pattern or a unit test may lead to a method useful in a Windows Form project

See [Microsoft TechNet article](https://social.technet.microsoft.com/wiki/contents/articles/52768.vb-net-type-conversions-part-1.aspx)