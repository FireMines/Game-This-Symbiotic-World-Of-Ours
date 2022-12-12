### Score Weighting


<table>
  <tr>
   <td>Description
   </td>
   <td>Weight
   </td>
  </tr>
  <tr>
   <td>Gameplay video
   </td>
   <td>5
   </td>
  </tr>
  <tr>
   <td>Code video
   </td>
   <td>10
   </td>
  </tr>
  <tr>
   <td>Good code
   </td>
   <td>15
   </td>
  </tr>
  <tr>
   <td>Bad code
   </td>
   <td>10
   </td>
  </tr>
  <tr>
   <td>Development process
   </td>
   <td>30
   </td>
  </tr>
  <tr>
   <td>Reflection
   </td>
   <td>30
   </td>
  </tr>
</table>



## Code

Throughout this project I did not write a lot of code for the game. This is due to most of the work I did for the game ment working with tools built in from Unity or packages that were provided. I however spent a fair share of time debugging and helping other group members.   


### Bad code

Some of the code that I wrote that I consider bad, was used to help an issue that another developer on the team had on a part of the code that I wasn’t that familiar with. These areas were left in the code due to the struggle to find more modular/optimal solutions within the timeframe of the project.

One of these problem areas was within the ObstaclePush.cs. The original issue was that we wanted to be able to rotate a tree such that it fell over and created a bridge, however when the tree was rotated it did not detect the collision with the ground on the other side and just continued rotating into the ground. 

At the time the solution I came up with was a check for if the tree rotated past a certain point and to then turn the tree not pushable past that point. This point is hardcoded, which is considered bad coding practice and should rather have been a check for object collision. 

![image](./Images/ObstaclePush_rotation.png)



### Good code

For me it was a bit difficult rating what I considered good code that I have written. However I would like to think that most of the WaterMovement.cs script would be considered good code.

I would consider this good code as the entire script is pretty easy to read and understand even for someone who hasn't worked with the script. The script is used to move the water object if the player manages to remove an obstacle, either by pushing/pulling it away or by destroying it.

![image](./Images/WaterMovement_script.png)

I have also made sure that the code is modular and easy to reuse on different gameObjects that might need to move. The code also makes sure that obstacle gameObject is null and is not called or used in the case of the obstacle being destroyed or not applied to the script. This is to avoid any errors that may occur if the code tries to access a non-existent gameObject. 


## Reflection

Overall, this class has taught me a fair share about the development of games within the Unity game engine. Such as important aspects when designing a game, working with Unity, how to work with a team in game development and how to deal with issues and bugs that come up during the development and while building a game. 

As earlier explained I do not have much code to show for my work within this project. I do believe this is because my team decided to divide up our tasks pretty early on, and I was supposed to work with the visual works; such as map layout, puzzles, lighting and such. These aspects do not have much coding needed to be developed and I ended up leaning too heavily into those aspects of developing the game as I was too uncertain to be assertive to take work away from my teammates. I would therefore like to say that I have learned that I probably should be more assertive when taking on work during projects.

I have definitely learned a lot about the game development process and how much work that goes into it. Before this project I did not know how much psychology was behind a player’s decision making and perception on game mechanics and how much game developers have to consider when planning and developing a game. I have also learned how to use Unity. The Unity learning curve was pretty steep for me when I had never worked with it before, however I am glad that I have been able to use this project as an opportunity to learn how to use it. 
