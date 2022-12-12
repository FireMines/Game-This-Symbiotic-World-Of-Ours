# **Welcome to This Symbiotic World of Ours**


[TOC]


**Students**

Lars Blütecher Holter (Bear) _- Link to individual report_

Lillian Alice Wangerud (Owl) _- Link to individual report_

Sarah Seifert (Cat) _- [Link to individual report](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/Reports/sarah.md)_

Matthias David Greeven (Wolf) _- Link to individual report_


## **Video of our game**

## **Game Design file**

[Link to the gamedesign.md file](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/gamedesign.md9

This file was used for our initial game planning. We didn't continously use it but it shows some of the thoughts we had during our early development stages.

## **Work distribution**


<table>
  <tr>
   <td>
   </td>
   <td>Lars
   </td>
   <td>Mats
   </td>
   <td>Sarah
   </td>
   <td>Lillian
   </td>
  </tr>
  <tr>
   <td>Player movement
   </td>
   <td>Some
   </td>
   <td>Some
   </td>
   <td>Some
   </td>
   <td>Some
   </td>
  </tr>
  <tr>
   <td>Player attacks
   </td>
   <td>All
   </td>
   <td>Touched
   </td>
   <td>
   </td>
   <td>Touched
   </td>
  </tr>
  <tr>
   <td>Orbs
   </td>
   <td>Some
   </td>
   <td>Most
   </td>
   <td>Touched
   </td>
   <td>Touched
   </td>
  </tr>
  <tr>
   <td>Abilities
   </td>
   <td>Touched
   </td>
   <td>All
   </td>
   <td>Touched
   </td>
   <td>Touched
   </td>
  </tr>
  <tr>
   <td>Maps
   </td>
   <td>Half
   </td>
   <td>Touched
   </td>
   <td>Touched
   </td>
   <td>Half
   </td>
  </tr>
  <tr>
   <td>Environment Mechanics
   </td>
   <td>Some
   </td>
   <td>
   </td>
   <td>Some
   </td>
   <td>Some
   </td>
  </tr>
  <tr>
   <td>Lighting
   </td>
   <td>
   </td>
   <td>
   </td>
   <td>
   </td>
   <td>All
   </td>
  </tr>
  <tr>
   <td>Enemies
   </td>
   <td>Touched
   </td>
   <td>
   </td>
   <td>All
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td>Health and damage
   </td>
   <td>Half
   </td>
   <td>
   </td>
   <td>Half
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td>Friendly NPC
   </td>
   <td>All
   </td>
   <td>
   </td>
   <td>Touched
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td>Dialogue
   </td>
   <td>All
   </td>
   <td>
   </td>
   <td>Touched
   </td>
   <td>Touched
   </td>
  </tr>
  <tr>
   <td>UI (GUI, main and pause menu)
   </td>
   <td>Most
   </td>
   <td>Some
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td>Audio
   </td>
   <td>All
   </td>
   <td>
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td>Sprites
   </td>
   <td>Touched
   </td>
   <td>
   </td>
   <td>
   </td>
   <td>All
   </td>
  </tr>
  <tr>
   <td>Camera
   </td>
   <td>All
   </td>
   <td>
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
</table>



## **Group discussion on the Development Process**


### Game Engine

We chose to develop in Unity due to the accessibility support and resources it offers. There is a massive community behind this engine with free tutorials and assets that we used in the life cycle of this project.

The engine has good support for the type of game we wanted to create (2D metroidVania), and a built-in physics engine free for use. The unity launcher has built in deployables and provides a “game window” in the editor to allow for quick previews while developing, instead of generating a new build for every change. Unity has built in colliders, game physics and UI features (positional anchoring, simple animations) which makes development easy, especially for newcomers to the field.

A major flaw with the Unity game engine came with the consistent merge errors we would receive. This only applied to the scene files (_scene.unity_), where git could not understand / merge these files effectively. The way we had to resolve these conflicts is by choosing the most optimal version, and manually insert every element from the “throwaway” file. This method of fixing was extremely annoying, and led to unintended bugs along the way, as the developers needed to remember exactly what to insert, and how to do it.


### Version control

At the start we decided on using git for version control and used the NTNU Gitlab to create a repository. After some initial merge conflicts and errors, we decided on using SourceTree as a way to keep track of all changes and to help with merging everything. We used the [issues](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/boards) on Gitlab as a way to assign tasks to ourselves. In our commits, we referenced which issue a commit addresses by adding the issue number in square brackets. This links the commit directly to the issue. This way it is easier to see which code belongs to which issue. This way errors can be fixed easier.

To have an overview of our progress, we labeled issues depending on whether they are in the backlog, in progress, ready for review, stuck, closed or open. Issues that we did not find important for now were usually labeled “Open”, while issues that we found had to be worked on as soon as possible were labeled “Sprint Backlog”. 

During our meetings, which were usually twice a week, we went over the issues that were ready for review and decided whether they were closed or not. We each worked on our own branch in the repository and merged our changes into main whenever we put an issue into the “Ready for review” category, or whenever we made changes that were important for the games functionality.


### Teamwork

At the start of the project, we met up in person once to discuss our main idea for the game. After that, we met at least once a week and mostly kept our meetings online, so that we could work together, each on our own PCs. 

Every meeting started off with a scrum meeting where we discussed the issue board and looked at issues that were marked as “Ready for Review” and then we decided together whether these issues are closed or not. After the Scrum meeting we would then usually all work on the project individually, while still being in the meeting. This way we could ask the other group members when we had problems, or needed help. As we usually had those meetings over Discord, we could also share our screens if that was needed.

At the start of the project, we assigned ourselves roles during the lecture. These were not used by us that much, as we didn’t need them a lot during our group work. The only role that was often mentioned and used by us was the role of the bear as he was also the person who came up with the idea for the game, so he acted as our scrum master during the meetings.

