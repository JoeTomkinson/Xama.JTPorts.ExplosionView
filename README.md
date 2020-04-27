# Xama.JTPorts.ExplosionView
[![platform](https://img.shields.io/badge/platform-Xamarin.Android-brightgreen.svg)](https://www.xamarin.com/)
[![API](https://img.shields.io/badge/API-10%2B-orange.svg?style=flat)](https://android-arsenal.com/api?level=10s)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)


### Namespace: Xama.JTPorts.ExplosionView

Xamarin.Android UI Library port that provides an explosive dust effect for android views.

This is a ported build, converted from Java to C# for use with the Xamarin MonoFramework. Quite a bit needed to be reworked on this one to get it to work correctly in Xamarin.Android and there's some things that still need to be implemented to allow this library to function with quality of life functionality.

<br>

![!gif](https://github.com/DigitalSa1nt/Xama.JTPorts.ExplosionView/blob/master/images/20190220_122849.gif?raw=true)

# How to Install

![NuGetIcon](https://raw.githubusercontent.com/DigitalSa1nt/Xama.JTPorts.ExplosionView/master/images/nugetIcon.png)

Simply add the [NuGet package](https://www.nuget.org/packages/Xama.JTPorts.ExplosionView/) directly to your Xamarin.Android solution, or use one of the following:

Package Manager:
> Install-Package Xama.JTPorts.ExplosionView -Version 1.0.0

.NET CLI:
> dotnet add package Xama.JTPorts.ExplosionView --version 1.0.0

# Basic Usage

Create whatever controls you want to explode inside of your AXML layout as you would do any other view. In the backing class add the following code

```cs
Using Xama.JTPorts.ExplosionField;

// This creates the explosion view used to display the particals at the root of the content display.
// This is expecting an activity ideally, so this would be a little different if used inside of a fragment, so bear that in mind.
ExplosionField explosionField = new ExplosionField(this);

// Tells the view to start animating the explosion animation
explosionField.explode(view);

// Could be hooked up to an on click event of your control if you wish.
view.Click += (s,e) =>
{
    explosionField.Explode(view);
}
```

# Support 💎

If you want to support the work that I do and you find any of these libraries useful? Consider supporting it by joining [**stargazers**](https://github.com/DigitalSa1nt/Xama.JTPorts.ExplosionView/stargazers) for this repository. :telescope: :stars:

<br/>

or alternatively if you want to you can also buy me a coffee.

<a href="https://www.buymeacoffee.com/JTT" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-red.png" alt="Buy Me A Coffee" tyle="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>
-----
_You know, only if you want to._
