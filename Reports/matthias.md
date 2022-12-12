
###  Score weighting

|Description | my weight |
|----|----|
|Gameplay video | 10 |
|Code video | 10 |
|Good Code | 20 |
|Bad Code | 25 |
|Development process | 20 |
|Reflection | 15 |

###  Code video
https://youtu.be/LWKAhfy7I3w
###  Bad code

The collision detection / movement for our main character leaves a bad impression for me.
For detecting whether the player has landed or not, we used to have a singular point on our sprite that would cast an invisible circle, check if there were any colliders within it's radius, and set the "*isGrounded*" variable to true, letting the character jump. This point was labelled as "groundcheck" and was placed at the bottom of our sprite (pictured underneath, with the red dot indicating the location). 
![image](https://cdn.discordapp.com/attachments/440640969679962124/1051931332235771964/image.png)

The biggest issue with this was that the radius cast out from this point could not be big enough to capture the bottom of the entire sprite. If the radius covered the diameter of the sprite, the downward part of the circle would mean the player would be marked as grounded way before physically touching the floor. This implementation also had issues regarding steep hills, as the rigidbody would make contact with the ground and stopping, the ground would be out of reach from the groundCheck, not allowing the player to jump.

My fix around this issue could be improved on. Since the issue was discovered fairly deeply into the development, I implemented a quick fix by changing from a radial groundCheck, to an invisible box near the characters paws. The box (consisting of two points pictured below) is only a replacement for previous circle, but due to the box covering our character's feet completely, the problem was solved.

![image](https://cdn.discordapp.com/attachments/440640969679962124/1051934560688021514/image.png)

Instead of that quickfix, I'd like to implement a different way of registering groundCheck entirely, as the current method is as follows (*from CharacterController2D*).

![image](https://cdn.discordapp.com/attachments/440640969679962124/1051935260616687633/image.png)

This method is overly complex. Using Unity's OverlapAreaAll, we check for the definition of "ground" (defined by m_WhatIsGround), and if that ground is within our Groundcheck box. In the for loop we go through all the colliders registered and more intricately define what is ground and what isnt (checking for triggers and gameobjects).
If I had the time to rework this, I would go through with [CodeMonkey's example (number two specifically)](https://www.youtube.com/watch?v=c3iEl5AwUF8) for GroundChecking, which creates a hitbox automatically under the character, removing the manual implemented hitbox I quickly put together.

###  Good code
The implementation that I am most proud of, is the creation and storage of Orbs.
In the [OrbController.cs](https://git.gvk.idi.ntnu.no/course/imt3603/imt3603-2022-workspace/symbiosis/this-symbiotic-world-of-ours/-/blob/main/This_Symbiotic_World_Of_Ours/Assets/Scripts/OrbController.cs) script I set up two sets of enums, one for the orb Element, and the Powerup that orb contains.
When the build would run, start() sets the colours of the sprite and lighting to match that of the orbs Element: Water orbs would be blue, and earth orbs brown. 
If the player collides with the orb, they are given the powerup based on the powerup enum the orb contained. For most abilities this equals to setting that ability-Bool to true, but for the double jump it sets the extra jumps value to 1, which get's added on the players *jumpsLeft* integer whenever they land. 

![image](https://cdn.discordapp.com/attachments/440640969679962124/1051923839971495976/image.png)

*snippet from OrbController.cs*

This method of implementing the orbs allowed for extremely easy debugging around the abilities or orb features. We could now drag and drop the orbs onto our scene, change the values based on what we wanted to test, and easily expand the capabilities of the powerups without having to change the orbs themselves.

###  Reflection
Overall, this was a fun, engaging and good learning experience around game development, remote work and extended project work.

Using Unity for the first time meant that there was alot of learning to do, which resulted in alot of situations like "oh that method is so much better than the one I implemented 2 months ago". The learning curve was gradual, but still steep in the beginning, where we felt like we were making zero to no progress after designing the general "feel" for our game. I've learned alot about the potential connections you can make between the engine and your code, using my codebase as an "assistant" to the engine instead of doing everything via the code. I also got to experience (what feels like) the ultimate OOP test I've had so far, with managing multiple file types and their co-existence. 

Using Unity as our game engine was probably the best choice we could've made, as it has taught me the basics when it comes to developing video games. I have some regrets from not implementing the best methods that I found, and not taking the time to fully test / play around with the tasks I had to implement, leading to some code I'm not fully happy with / want to improve (e.g. the groundCheck).

 Our testing was mostly quickly booting up our game in the editor to check for changes, and user testing. When we had our user tests, we were always suprised to see the amount of hints we would need to drop for the players to understand their objectives, which was fun to watch. The results of these tests gave us alot of reflections on clear communication between player and game, and we probably need to add many more indicators to show all the game has to offer.
 
 Working together remotely isn't a new challenge to me, but this project gave us a better view of the bigger picture. Having clear communications and sticking to pre-determined schedules was an important part of it. Utilizing Scrum worked well for this, as the meetings gave us clear objectives for the workweek. In the start it was hard to get going, as the field was new to all of us. When we finally got our first "playable" version (a sprite that ran around and jumped), we "got the ball rolling" and were able to split the tasks the way we wanted. Working together remotely made the rest of the development alot easier, as we could share screen over discord and get direct inputs from eachother through chat, in and out of meetings.
 
 In conclusion, we struggled a bit in the start, but when we got past that first hurdle we were able to gradually increase the speed of development. I greatly enjoyed the experience this project gave us, and I learned enough to potentially make my own game in my spare time, which is alot of fun!

