# EmbeddedBlazorContent

[![NuGet](https://img.shields.io/nuget/v/EmbeddedBlazorContent.svg)](https://www.nuget.org/packages/EmbeddedBlazorContent/)
[![Gitter](https://badges.gitter.im/MatBlazor/community.svg)](https://gitter.im/MatBlazor/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
[![GitHub Stars](https://img.shields.io/github/stars/SamProf/EmbeddedBlazorContent.svg)](https://github.com/SamProf/EmbeddedBlazorContent/stargazers)
[![GitHub Issues](https://img.shields.io/github/issues/SamProf/EmbeddedBlazorContent.svg)](https://github.com/SamProf/EmbeddedBlazorContent/issues)
[![MIT](https://img.shields.io/github/license/SamProf/EmbeddedBlazorContent.svg)](LICENSE)
[![Donate](https://www.paypalobjects.com/en_US/i/btn/btn_donate_SM.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=9XT68N2VKWTPE&source=url)

This library helps you in server Blazor mode to enable content files from BlazorLib projects.
In my opinion at this moment it is the perfomance and convenient way use embedded content files from Blazor Libraries.

## Usage

- Install latest version from [nuget](https://www.nuget.org/packages/EmbeddedBlazorContent/): [![NuGet](https://img.shields.io/nuget/v/EmbeddedBlazorContent.svg)](https://www.nuget.org/packages/EmbeddedBlazorContent/)

- Enable Host return static content from embedded resources.
```
# Startup.cs
app.UseEmbeddedBlazorContent(assembly);

// or with custom requestPath

app.UseEmbeddedBlazorContent(assembly, "/staticContent");
```

- Include links to static content in page
```html
# _Host.cshtml
@Html.EmbeddedBlazorContent(assembly)

// or with custom requestPath

@Html.EmbeddedBlazorContent(assembly, "/staticContent")

// or all embedded content from all hosted asemblies

@Html.EmbeddedBlazorContent()
```

## Examples
- EmbeddedBlazorContent.ExampleApp
- EmbeddedBlazorContent.ExampleLib

## License
[MIT](LICENSE)
