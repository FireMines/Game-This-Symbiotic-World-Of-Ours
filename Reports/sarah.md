# Individual Report - Sarah Seifert


# Rubric


<table>
  <tr>
   <td>Description
   </td>
   <td>def
   </td>
  </tr>
  <tr>
   <td>Gameplay video
   </td>
   <td>10
   </td>
  </tr>
  <tr>
   <td>Code video
   </td>
   <td>0
   </td>
  </tr>
  <tr>
   <td>Good code
   </td>
   <td>20
   </td>
  </tr>
  <tr>
   <td>Bad code
   </td>
   <td>20
   </td>
  </tr>
  <tr>
   <td>Development process
   </td>
   <td>20
   </td>
  </tr>
  <tr>
   <td>Reflection
   </td>
   <td>30
   </td>
  </tr>
</table>





# Good code

Generally, out of all the code I have written for this project, the [Enemy.cs](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/Enemy.cs) Script is the best when looking at the structure and cohesiveness of it. It is very well structured and I find it to be easily understandable.

An example of good code is the EnemyMovement function in the [Enemy.cs](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/Enemy.cs) file:


![enemy file](/Images/enemies_sarah.png)
 

_Lines 56 to 81 in _[Enemy.cs](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/Enemy.cs)

 

Lines 56 to 81 in this file implement the movement of an enemy as long as the player is not within the target range. I decided on moving the enemy instead of having it idle as I thought this would look better if an enemy is on screen but the player is not yet in their target range. For this, the distance sets how many “steps” the enemy is supposed to walk. These steps are counted in the movement index and the counterUp variable defines whether the enemy moves left or right. The switch case function in line 56 makes the enemy move into the corresponding direction depending on this variable.

The switch case function at line 70 keeps track of how far the enemy has walked and will then flip the sprite and change the counterUp variable to change the enemy’s walking direction. All of this enables the enemy to move smoothly from left to right while it is not attacking the player.


# Bad Code

A lot of my code could be better as I have not worked much with unity or with C# before this project, so I didn’t always know the best way to implement certain features. However, all of the code I have written works well and I am happy with the way it works, there are just parts of it that have a bad implementation.

Examples of bad code I have written can be mainly found in the implementation of the swimming. It is sometimes poorly handled as it uses a lot of if-statements. This is because the controlling of the swimming often collides with the controlling of the abilities or the simple movement, so it has to be constantly checked if the player is swimming.

 

Particularly bad here is the handling of the isSwimming variables. In line 144 of the [PlayerMovement.cs ](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/PlayerMovement.cs)file, the isSwimming variable is given to the move function of the  [CharacterController2D.cs](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/CharacterController2D.cs) file. The character controller then uses this variable in the move function to check whether the player is swimming, instead of using its own isSwimming variable that is set earlier in the OnTriggerEnter2D and OnTriggerExit2D functions. This was handled this way as it was the only way the swimming worked without influencing the other abilities. For example, when I changed the isSwimming variable at another place in the script, the gliding ability no longer worked at all.



![enemy file](/Images/ontrigger_sarah.png)


_OnTriggerEnter2D and OnTriggerExit2D functions in [CharacterController2D.cs](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/CharacterController2D.cs)_



![enemy file](/Images/playermovement_sarah.png)


_FixedUpdate function in [PlayerMovement.cs](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/PlayerMovement.cs)_



![enemy file](/Images/move_sarah.png)


_Lines 276 to 284 of the [CharacterController2D.cs](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/CharacterController2D.cs) _


# Reflection

Overall, I learned a lot in this project and I had a lot of fun as well. The group worked together well and we managed to mostly meet at least once a week, sometimes even twice a week. We constantly communicated our problems, so we helped each other a lot and big problems, such as merge errors, were fixed right away. Another good thing about our group work, which I will keep in mind for future projects, is that we labeled our issues “Ready for Review” when they were done and then we reviewed them together during our next meeting. This way we could make sure everyone is satisfied with all changes we made to the game.

At the start of this semester, we had a bigger game in mind. We planned more levels and more scenes in it, such as a big opening scene and a more exciting ending scene. This was because none of us had ever made a whole game in unity, so we did not realize how much work that would be. So once we realized that we could not make a game this big within our short time span, we ended up focusing on making it a playable game with only two levels.

One thing I learned in this project is how much work goes into designing a game and its levels. A big point here for me was that we had to keep on playtesting our game again and again whenever we made any changes to the layout, even if they were small changes, to ensure that the player character does not get stuck on the map and all layout changes are playable in the way we wanted them to. 

I really enjoyed learning how to use unity for this game and I was impressed with how easy it is to make a simple game in Unity when you know how to use basic C#. The documentation for Unity is very detailed and Unity has many tutorials, so it was quite easy to learn how to use the basics before we got started with our game.

Overall, I’m very happy with our game. I think it looks really good and it’s fun to play. I also got feedback from playtesters that they really liked the game and enjoyed playing it.

