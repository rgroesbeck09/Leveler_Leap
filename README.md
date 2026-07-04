# Leveler_Leap

Christopher Garcia-Arvizu:
Added jump capability and jump animation to character. Character was imported from project 1. 
Added anti gravity pad that multiplies the jump factor by 2 when jumping from on top of the pad.
Added 3D audio source to the pad, a hum can be heard louder the closer you get. 

Imports: 
Asset Name: Force Field - Sci-Fi Collection
By: Alpine Audio
Link: https://assetstore.unity.com/packages/audio/sound-fx/force-field-sci-fi-collection-113256

Main Menu & Room/Floor Textures - Amanda Bragg:
- Found wall texture at https://www.sharetextures.com/textures/roof/false_ceiling_2 
- Applied texture to rooms and adjusted albedo, normal, metallic, etc. accordingly.
- Created hand drawn 2D menu art background on Procreate for iPad, then imported to Unity.
- Created a UI canvas with 2 panels: first is the main menu which shows the game title, and “Play”, “Credits”, and “Exit” buttons; second is the credits panel which displays the names of all group members and includes a back button to the main menu.
- Main menu/credits uses fonts from: https://www.fontspace.com/cyber-horizon-font-f143392 and https://www.fontspace.com/nitro-eagle-font-f145939 
- The UI uses music from https://pixabay.com/sound-effects/musical-sc-fi-beat-effect-253284/ to play when the player is in the menu or credits panels. 
- Finally, I created a script for the UI (MainMenuManager) that responded to when the buttons were clicked and allowed the gameplay scene to be loaded. It uses two panels and has setActive() show/hide them, while SceneManager.LoadScene() transitions to the main game scene. Everything was adjusted in the hierarchy and the script was applied where needed for transitions. 

