# Leveler_Leap
Valeria Ugarte: 
Added physics based seesaw and moveable block to implement puzzle element. Seesaw consists of 3D objects like the base of the seesaw and the board which uses a Hingejoint and Rigidbody to react to weight and player movement. Moveable block allows for player interaction with puzzle. Script is added to allow player to jump on platform and move block onto seesaw.

Added ambient noise to Main Game scene
Found at - https://assetstore.unity.com/packages/audio/ambient/sci-fi/sci-industrial-ambience-19010#publisher


Christopher Garcia-Arvizu:
Added jump capability and jump animation to character. Character was imported from project 1. 
Added anti gravity pad that multiplies the jump factor by 2 when jumping from on top of the pad.
Added 3D audio source to the pad, a hum can be heard louder the closer you get. 

Imports: 
Asset Name: Force Field - Sci-Fi Collection
By: Alpine Audio
Link: https://assetstore.unity.com/packages/audio/sound-fx/force-field-sci-fi-collection-113256

Main Menu & Room/Floor Textures - Amanda Bragg:
- Found wall texture at https://www.sharetextures.com/textures/wall/stone-wall-25 
- Applied texture to rooms and adjusted albedo, normal, metallic (made much higher), etc. accordingly.
- Created hand drawn 2D menu art background on Procreate for iPad, then imported to Unity.
- Created a UI canvas with 2 panels: first is the main menu which shows the game title, and “Play”, “Credits”, and “Exit” buttons; second is the credits panel which displays the names of all group members and includes a back button to the main menu.
- Main menu/credits uses fonts from: https://www.fontspace.com/cyber-horizon-font-f143392 and https://www.fontspace.com/nitro-eagle-font-f145939 
- The UI uses music from https://pixabay.com/sound-effects/musical-sc-fi-beat-effect-253284/ to play when the player is in the menu or credits panels. 
- Finally, I created a script for the UI (MainMenuManager) that responded to when the buttons were clicked and allowed the gameplay scene to be loaded. It uses two panels and has setActive() show/hide them, while SceneManager.LoadScene() transitions to the main game scene. Everything was adjusted in the hierarchy and the script was applied where needed for transitions. 

Raymond Groesbeck:
-----------------------------
- Initial Level design
- Timer
- integration of teams tickets
- Delt with merge conflicts
- Came up with designs
- Had implementation issues with our cutscenes and particle physics
- Implemented mouse look around and easy movements
- Created our inital test enviroment for our game mechanics
- Added in UI to let user know they have won the game or failed it. 
- Implemented some game sounds
- Dragged in our original game design from project 1 as a reward for winning the game.  

* https://cloud.unity.com/home/organizations/2475985092540/assets/my-asset-store-assets/asset-store?assetId=54622:1
* https://cloud.unity.com/home/organizations/2475985092540/assets/my-asset-store-assets/asset-store?assetId=54724:1
* Grass Material: from manytextures.com https://www.manytextures.com/texture/1/green-grass/
* Dirt/Dry grass Material: from manytextures.com https://www.manytextures.com/texture/53/dry-grass-ground/
* Stone Material: from manytextures.com https://www.manytextures.com/texture/130/mountain-rock/
* Water Texture and Normal map: water0339 from CADhatch.com https://www.cadhatch.com/seamless-water-textures
* Wood Texture: from TextureLabs.org https://texturelabs.org/textures/wood\_259/
* Boat Model: by garleth93 on Free3D.com https://free3d.com/3d-model/boat-model-436261.html'

Video Link:
-----------------------------
https://youtu.be/UCope_-Lq38