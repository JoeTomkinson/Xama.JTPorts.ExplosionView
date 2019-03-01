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

At the moment, until I create the nuget package you would need to download the src code, compile and build it, then simply reference the DLL in your Xamarin.Android Project. Or alternatively you could add the project as a project within your solution if you plan on adjusting any of the code for your own uses.

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

# Useful?
<a href="https://www.buymeacoffee.com/digitalsa1nt" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/purple_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>
