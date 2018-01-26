# Alexa Fact Skill .NET Template

Project Template for Visual Studio 2017 for creating an Alexa Fact Skill in .NET


# Introduction

Please download the [latest version](https://github.com/tsjdev-apps/AlexaFactSkillNetTemplate/raw/master/Releases/latest/AlexaFactSkill.zip) of the template and place the `zip` file into your `ProjectTemplates` folder.

Normally this folder should be located here: `%userprofile%\documents\Visual Studio 2017\Templates\ProjectTemplates`


# Latest Version

Latest Version can be downloaded [here](https://github.com/tsjdev-apps/AlexaFactSkillNetTemplate/raw/master/Releases/latest/AlexaFactSkill.zip)


# Features

## version 1
* AWS Lambda Project (.NET Core 2.0)
* Nuget package [Alexa.Net](https://www.nuget.org/packages/Alexa.NET/)
* Nuget package [Newtonsoft.JSON](https://www.nuget.org/packages/Newtonsoft.Json/)
* Preparation of `facts.json` file to store the facts
* Extensions Methods for `Enumerable` for picking a random item
* `MessagesService` to get randomly picked message
* `EmbeddedResourceService` to read an embedded `json` file
* `FactsService` to get a random fact or a fact by intent
* Preparations to handle required intents like `AMAZON.StopIntent`, `AMAZON.CancelIntent`, `AMAZON.HelpIntent` and `LaunchRequest`


# Source Code

The source code of the template is located in the `develop` branch of this repository. You can find it [here]{https://github.com/tsjdev-apps/AlexaFactSkillNetTemplate/tree/develop}
