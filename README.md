# CleanHTML 
![image](https://img.shields.io/nuget/v/HtmlSanitizer?color=1) ![image](https://img.shields.io/github/license/mganss/HtmlSanitizer) <br>
An application used to clean dirty html code based on docx to html, built with <b>HtmlSanitizer</b>, C# winForm.

## OpenSource
https://github.com/mganss/HtmlSanitizer

## ScreenShot
![image](https://user-images.githubusercontent.com/47452491/147042414-c2aeeee9-8400-47e1-8845-625f9572a963.png)

# Usage
Install the HtmlSanitizer NuGet package. Then:

```C#
var sanitizer = new HtmlSanitizer();
var html = @"<script>alert('xss')</script><div onload=""alert('xss')"""
    + @"style=""background-color: test"">Test<img src=""test.gif"""
    + @"style=""background-image: url(javascript:alert('xss')); margin: 10px""></div>";
var sanitized = sanitizer.Sanitize(html, "http://www.example.com");
Assert.That(sanitized, Is.EqualTo(@"<div style=""background-color: test"">"
    + @"Test<img style=""margin: 10px"" src=""http://www.example.com/test.gif""></div>"));
```
There's an [online demo](http://xss.ganss.org/), plus there's also a [.NET Fiddle](https://dotnetfiddle.net/892nOk) you can play with.

More example code and a description of possible options can be found in the [Wiki](https://github.com/mganss/HtmlSanitizer/wiki).

### CSS properties allowed by default
`background, background-attachment, background-clip, background-color, background-image, background-origin, background-position, background-repeat, background-repeat-x, background-repeat-y, background-size, border, border-bottom, border-bottom-color, border-bottom-left-radius, border-bottom-right-radius, border-bottom-style, border-bottom-width, border-collapse, border-color, border-image, border-image-outset, border-image-repeat, border-image-slice, border-image-source, border-image-width, border-left, border-left-color, border-left-style, border-left-width, border-radius, border-right, border-right-color, border-right-style, border-right-width, border-spacing, border-style, border-top, border-top-color, border-top-left-radius, border-top-right-radius, border-top-style, border-top-width, border-width, bottom, caption-side, clear, clip, color, content, counter-increment, counter-reset, cursor, direction, display, empty-cells, float, font, font-family, font-feature-settings, font-kerning, font-language-override, font-size, font-size-adjust, font-stretch, font-style, font-synthesis, font-variant, font-variant-alternates, font-variant-caps, font-variant-east-asian, font-variant-ligatures, font-variant-numeric, font-variant-position, font-weight, height, left, letter-spacing, line-height, list-style, list-style-image, list-style-position, list-style-type, margin, margin-bottom, margin-left, margin-right, margin-top, max-height, max-width, min-height, min-width, opacity, orphans, outline, outline-color, outline-offset, outline-style, outline-width, overflow, overflow-wrap, overflow-x, overflow-y, padding, padding-bottom, padding-left, padding-right, padding-top, page-break-after, page-break-before, page-break-inside, quotes, right, table-layout, text-align, text-decoration, text-decoration-color, text-decoration-line, text-decoration-skip, text-decoration-style, text-indent, text-transform, top, unicode-bidi, vertical-align, visibility, white-space, widows, width, word-spacing, z-index`

#### This is important thing in this repo. You can change what CSS code you need in your case.
#### 這邊是本專案的重點，您可以設定自己所需的css tag。

License
-------

[MIT X11](http://en.wikipedia.org/wiki/MIT_License)