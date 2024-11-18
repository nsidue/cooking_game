for the wrld unity player fix the collectibles text and the timertext bc it is not showing up on the imported file(create new textmeshpros and use the existing format that i already have there)
for the player survival package, the collision with the collectibles are identified through the tag "Collectible", so for the collectibles that you've created, make sure they are under the tag "Collectible". This will allow for the program to identify when the player has collided with a collectible. 
Also, I set a default number of 15 total collectibles in 3 minutes for them to go to the next level. feel free to adjust this number based on the different levels of terrains you are doing when you attach them.

Steps to Make The code Work in Unity with your collectibles
make sure you:

Create a collectible prefab (e.g., a coin, object, or model).
Add a Collider to the collectible (e.g., a Box Collider or Sphere Collider).
Check the Is Trigger box in the Collider component.
Add a Tag to the collectible:
Select the collectible in the Inspector.
Click the Tag dropdown > Add Tag....
Add a new tag called Collectible.
Assign this tag to your collectible GameObject.
Ensure Player Has a Collider:

Make sure the player GameObject has a Collider (e.g., Capsule Collider) and a Rigidbody component.
Set the Rigidbody's Is Kinematic property to true if the player isn’t affected by physics.
Place Collectibles in the Scene:

Drag the collectible prefab into your scene.
Place multiple collectibles throughout your level.
