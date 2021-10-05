# SAPI voices manager

The SAPI voice manager is a meant to copy voices from different registry to a target one, allowing to use all SAPI compatible voices installed on your system through the main SAPI library.

The principle is simple :
The tool retrieve all the voice installed within your 32bits and 64bits SAPI and onecore registries, and allows you to install one or more voices found to the main SAPI registry (the 32bits registry if you use the 32bits voices manager, or the 64bits registry if you use the 64bits voices manager).

**Beware that this tool is modifying your windows registry, It should not damage it but just in case MAKE A REGISTRY BACKUP BEFORE and USE AT YOUR OWN RISKS.**

## Requirements

This project was developped using visual studio (2019 community edition) and use the following nuget packages :
- CommandLine
- Newtonsoft.Json

## TODO list

- The Restore registry button is not working yet, but it will allow to restore previous version of the SAPI registry.

## How to use it

__Please do not unzip both VoiceManager in the same folder, as the different libraries are using the same names while being build for different architecture.__

Just unzip the VoiceManager zip file you need in an empty folder and launch the VoiceManager.exe.

In the form, select the voices you want to install and click on the "Install selected voices" to install them.
You can also install all the available voices by clicking on the "Install all available voices"button.

When finish, you can open the corresponding SAPI settings panel and select the newly installed voices : 
- For VoiceManager_64Bits, the 64bits SAPI windows setting panel can be found at `C:\Windows\System32\Speech\SpeechUX\sapi.cpl`
- For VoiceManager_32Bits, the 32bits SAPI windows settings panel can be found at  `C:\Windows\SysWOW64\Speech\SpeechUX\sapi.cpl`

(Be aware that the default voice selected is not stored in the globals sapi registries but in a single entry in the user registry, and it is shared betwwen SAPI 32bits and SAPI 64bits settings panel and possibly in other applications, so selecting a voice in either version of the sapi settings panel will change the default voice for the user)

## Why using this tool ?

With latest update of SAPI, including the new OneCore, new voices are made available but not put in the default SAPI registries.
It can also happen that you installed a 32bit voice from a third party voice provider, and you are using 64bit tool that can only access the 64bits main SAPI registry.

On windows 64bits, that translates by the voices
- not being selectable in the 64bits SAPI windows setting panel, and not being usable in 64bits application
- while being selectable in the 32bits SAPI windows settings panel, and usable in 32bits application

As it happens, advanced users accross the internet have reported that SAPI voices could be copied from one registry to another, especially [SAPI OneCore voices to SAPI registry](https://www.ghacks.net/2018/08/11/unlock-all-windows-10-tts-voices-system-wide-to-get-more-of-them/)

This voice management tool is meant to simplify this management using a front end instead of manually mopdify the registry.