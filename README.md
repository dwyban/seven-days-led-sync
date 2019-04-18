# Seven Days to Die Light Sync

## Introduction
Seven Days to Die Light Sync is an application that is intended for use at LAN parties to keep RGB LED lighting in the room in sync with the time of day in game.  For example, when it is night time in game the lighting will be dark blue while during the day the lighting will be light yellow making the color of the light in the room match the color of the light in the game.  This application also recognizes when the Blood Moon is out and will adjust the lighting accordingly, making the lighting a dark orange red to match the lighting in game.

## Project Description
The project consists of a Visual Studio Solution to build a .NET Windows Forms application written in C#.  This application is responsible for keeping track of the in game time and sending updates to the RGB LED Controller to update the lighting in the room accordingly.  The application keeps in sync with the server by conecting to the game server's built in TelNet interface.  However, the application can be configured manually to keep track of time when TelNet access to the server is not available.

As the light color changes with the in game time of day, the application sends lighting color updates to an RGB LED Strip Controller via Serial Port.  The controller intended for use with this application is a Simple RGB Strip Controller built on the Arduino platform.  The Arduino sketch for this controller can be found in my [arduino-simple-rgb-strip-controller](https://github.com/dwyban/arduino-simple-rgb-strip-controller) project.
