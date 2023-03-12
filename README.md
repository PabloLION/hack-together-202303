---
tags:
  - hack-together
  - microsoft-graph-sdk
  - microsoft-bot-framework
---

[![Hack Together: Microsoft Graph and .NET](https://img.shields.io/badge/Microsoft%20-Hack--Together-orange?style=for-the-badge&logo=microsoft)](https://github.com/microsoft/hack-together)

## What

This is a bot that uses the Microsoft Graph SDK to access the Microsoft Graph API for [Hack Together: Microsoft Graph and .NET](https://github.com/microsoft/hack-together). The bot is built using the Microsoft Bot Framework and is written in C#.

## References

[Create a bot with the Bot Framework SDK](https://learn.microsoft.com/en-us/azure/bot-service/bot-service-quickstart-create-bot?view=azure-bot-service-4.0&tabs=csharp%2Cvscode)

## Ideas

- meeting transcript (for both points below)
- realtime captions (with translate, assuming there's no API)
- summary of meeting with AI

## Notes

### Publish a bot

The team calling bot is created following these two tutorials:

- [Update and create Teams app package](https://learn.microsoft.com/en-us/microsoftteams/platform/sbs-calling-and-meeting)
- [Calling and Meeting Bot Sample V4](https://learn.microsoft.com/en-us/samples/officedev/microsoft-teams-samples/officedev-microsoft-teams-samples-bot-calling-meeting-csharp/)
- Add Permissions to commit your changes (via powershell, it's on homebrew, also, [install module](https://learn.microsoft.com/en-us/microsoftteams/teams-powershell-install)): `New-CsApplicationAccessPolicy -Identity “Teams-chat-bot-tutorial-policy” -AppIds "dfddac9c-4190-4449-a92a-f2c01610b9f4" -Description "policy to create meeting via bot"`, `Grant-CsApplicationAccessPolicy -PolicyName "Teams-chat-bot-tutorial-policy" -Identity "63e19d32-67a4-4348-9a72-3b60c1460d6f"`, `Get-CsApplicationAccessPolicy -PolicyName Teams-chat-bot-tutorial-policy -Identity dfddac9c-4190-4449-a92a-f2c01610b9f4`(tutorial did this is wrong), `Get-CsApplicationAccessPolicy -Identity Teams-chat-bot-tutorial-policy`

### Failed Publish a bot

- From [Publish a bot](https://learn.microsoft.com/en-us/azure/bot-service/provision-and-publish-a-bot?view=azure-bot-service-4.0&tabs=multitenant%2Ccsharp#create-an-identity-resource)
- create an Azure Active Directory app: `az ad app create --display-name "tutorial-team-chat-bot-1" --sign-in-audience "AzureADandPersonalMicrosoftAccount"`
- generate a new password for your app registration: `az ad app credential reset --id "dfddac9c-4190-4449-a92a-f2c01610b9f4"`
- Create Azure Bot resource `az deployment group create --resource-group tutorial1 --template-file <template-file-path> --parameters "@<parameters-file-path>"`
