# EmbeddedBlazorContent

[![NuGet](https://img.shields.io/nuget/v/EmbeddedBlazorContent.svg)](https://www.nuget.org/packages/EmbeddedBlazorContent/)
[![Gitter](https://badges.gitter.im/MatBlazor/community.svg)](https://gitter.im/MatBlazor/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
[![GitHub Stars](https://img.shields.io/github/stars/SamProf/EmbeddedBlazorContent.svg)](https://github.com/SamProf/EmbeddedBlazorContent/stargazers)
[![GitHub Issues](https://img.shields.io/github/issues/SamProf/EmbeddedBlazorContent.svg)](https://github.com/SamProf/EmbeddedBlazorContent/issues)
[![MIT](https://img.shields.io/github/license/SamProf/EmbeddedBlazorContent.svg)](LICENSE)
[![Donate](https://www.paypalobjects.com/en_US/i/btn/btn_donate_SM.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=9XT68N2VKWTPE&source=url)

This library helps you with [server side Blazor projects](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-3.0#server-side) to enable content files from BlazorLib projects.
In my opinion, it is the most perfomant and convenient way for using embedded content files from Blazor Libraries at this moment.

## Usage

- Install the latest version from [nuget](https://www.nuget.org/packages/EmbeddedBlazorContent/): [![NuGet](https://img.shields.io/nuget/v/EmbeddedBlazorContent.svg)](https://www.nuget.org/packages/EmbeddedBlazorContent/)

- Enable host return static content from embedded resources.
```
# Startup.cs
app.UseEmbeddedBlazorContent(assembly);

// Or with custom request path

app.UseEmbeddedBlazorContent(assembly, "/staticContent");
```

- Include links to static contents in a page
```html
# _Host.cshtml
@Html.EmbeddedBlazorContent(assembly)

// Or with custom request path

@Html.EmbeddedBlazorContent(assembly, "/staticContent")

// Or all embedded content from all hosted asemblies

@Html.EmbeddedBlazorContent()
```

## Examples
- EmbeddedBlazorContent.ExampleApp
- EmbeddedBlazorContent.ExampleLib

## License
[MIT](LICENSE)


## News

### EmbeddedBlazorContent 1.10.0
- Updated to .NET Core 3.1 Preview 1

### EmbeddedBlazorContent 1.9.0
- Updated to .NET Core 3.0

### EmbeddedBlazorContent 1.8.0
- Updated to .NET Core 3.0 RC 1

### EmbeddedBlazorContent 1.7.0
- Updated to .NET Core 3.0 Preview 9

### EmbeddedBlazorContent 1.4.0
- .NET Core 3.0.0-preview8.19405.7

### EmbeddedBlazorContent 1.3.0
- .NET Core 3.0.0-preview7.19365.7

### EmbeddedBlazorContent 1.2.0
- .NET Core 3.0.100-preview6-012264
