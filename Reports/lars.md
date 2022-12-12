# Individual report - Lars Blütecher Holter

## Score weighting
|Description | Weight |
|----|----|
|Gameplay video | 10 |
|Code video | 10 |
|Good Code  | 20 |
|Bad Code | 10 |
|Development process | 25 |
|Reflection | 20 |

## Good code
Throughout the project I have grown quite proud of a bunch of the code that I wrote. The parts that I would say are the best are probably the way I coded the ranged attacks. 

Function from CharacterController2D.cs script.

When the player has picked up the attack orbs and tries to attack an enemy nearby, the SelectTarget() function is called. What happens here is that it gets a list of every gameobject tagged as “Enemy” and then looks through them to see which one is closest by calculating the distance. If an enemy is found, it sets the target and it’s now ready to attack the target. If you try to attack once more, it goes through this process again and if the selected unit is out of sight or too far away, it unselects the target. 

To increase the calculation time, efficiency and to make sure that the player only is able to attack enemies that weren't hiding or behind any other object in the game, I created the GameObjectIsInLineOfSight() function. 


Function from the CharacterController2D.cs script.

What this function does is that it utilizes Raycasts to check whether or not the first ray hit in a straight line between the player and the enemy is in fact the enemy. Here it also takes into consideration the attack range we have given the player. Considering there are other gameobjects sometimes in the way, I added a check to see if it was a “approved” gameobject to pass through like the water or player character or not.


Function from the CharacterController2D.cs script.

If the attack ability passes through the previous functions, it gets sent to the RangedAttack() function. Here we spawn the projectile and animates how it looks. In here we randomize the way the attacks look and feel to make it the orbs feel more special while playing. These randomizations change the direction the orb spawns in, the curving while shooting and velocity to name a few.


Function from the RangedAttack.cs script.

Once the attack has been created, we administer the projectile in the FixedUpdate() function for the RangedAttack.cs script. Here we check whether or not the player has let go of the attack button. This is because the second attack ability is the same as the first one, but you are able to charge the attack to spawn in several projectiles. For this we make sure that the orb's position moves with the character while at the same time orbiting and accelerating around the player. It’s first when the player let go of the mouse left click the orbs are launched at the enemy target.

Function from the RangedAttack.cs script.

After the projectile had been launched towards the enemy, I added a new check to see if the target had been destroyed already or not. This is because the charge attack can charge up more projectiles than needed to destroy something and if that happens, the projectile will evaporate in game/ destroy itself. 

Considering the projectiles are orbiting the player I then make sure to set the new direction of the orbs to curve towards the target’s position to make sure they hit it while maintaining a pleasant look and feel to the attack move.
 
Once the projectile is within a close enough range of the target to “touch” it, I call the HitTarget() function. This function gets the health of the object, plays a sound on impact, shakes the camera to visualize the impact, deal damage and then destroy the projectile.


## Bad code
Even though i'm quite proud of the code written, there are some code snippets that I don't consider to be of the same high quality. An example of this is how I created the health pictures and updated them. 

Functions from the DisplayPlayerHealth.cs script.

My plan with this code was to automatically create the health images on a canvas based on how much health we allow the player to have if we later on decide to give the player power ups to increase its health beyond the starting amount. I then made it so that the position of these objects were spawned on the first image and then adjusted the size and position of it to be the same size and more to the right so it doesn't overlap. The way i did this however was by hard coding in the values of the sizeDelta and the value i added onto the previous position.

By coding the health visualization this way, it made it such that the health felt out of place where it was located on the screen and it also makes the customization of how it looks much less adjustable in the future if we wanted to change it. It also doesn’t consider any other GUI elements on screen which could be an issue if we added more health or more abilities. If we were to do this, we would soon run into the problem of overlapping GUI elements and an increased feeling of elements being out of place.

If we were to continue development of the game or had more time, this would most likely be one of the priorities to fix. A potential fix for this could be to get the position of all other GUI elements and have a check on where they were and while placing these elements we sort them into different parts of the screen. We should also remove hard coded values and try to make it more readable with more commenting.

## Reflection
Throughout this course I’ve only gained more and more interests in game development. I came from a background with little to no experience with game development, but the way the course has been set up and what we have created I find myself going back to developing the project whenever I get free time. This has made it such that I’ve gotten a good learning outcome of how gamedev works as well as remote work, teamwork, Unity, programming and much more.

At the start of this course I had barely downloaded and launched Unity previously and was in no state to create a game. Throughout the months of this course I went through the process of learning how to create simple cubes, to intermediate things like how to add movement and GUI elements to the game, to more advanced things like how to calculate and add the behavior of flying projectiles with special animations and targets to hit with a full damage and health system. When we started the development process, we had a rather large scope in mind. We imagined we would be able to create a game with similar scope and depth as some other major games released. We soon got a reality check after learning more about game development that creating a game is so much more than what we initially thought, which in turn made us end up with reducing the scope. This meant we reduced the game from having five or more “maps” to having only three. By reducing some of the scope, it allowed us to increase the quality of our other tasks significantly. The way we were able acquire competence were primarily through watching youtube tutorials, reading forums, as well as reading the documentation. 

Another great lesson I was able to learn throughout this course was how to efficiently and smoothly use GIT. Previously I have used GIT at a very primal level which only included cloning, pushing, pulling and creating issues on GIT. Quite early in the course we were taught how to utilize tools such as SourceTree to simplify the teamwork on GIT as well make the learning of how to properly use GIT easier. Once we obtained this skill, most of our group problems were solved, as they were regarding how to efficiently work on the same software with multiple developers. Having learned this, our method of using SCUM as a development tool increased ten folds. Now we were finally able to work on different branches without having to worry about merge problems and a lot of other problems that come with using GIT with several other people.

If I ever start developing another game, I will however make a few changes to how I would like to develop the game from start to finish. These changes are nothing big in particular but rather small things that make a huge difference in the long run. From the start of the development life cycle I would have sat down with my team and really filled out a plan for most aspects of how things should work, look and feel. By doing this, the time needed in later meetings for figuring out how mechanics would work is decreased. I would also from the start of the development create smaller GIT issues to make it easier to see what aspects of which task is done and which needs more work done. These are just smaller adjustments as previously stated though. 

With the new set of skills this course has given me, I feel much more confident going forward with any potential game development I attempt in the future, after gaining such a strong foundation. 

 
