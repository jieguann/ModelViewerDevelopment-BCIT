# ModelViewerDevelopment-BCIT

Online Player: https://play.unity.com/mg/other/unitywebgl-24



https://user-images.githubusercontent.com/60665347/174645468-d96cdb78-4d71-49fe-aac3-00d458222841.mp4



## Test Description

### 3D Interaction
1. A MeshCollider is added to each of them for the single model part interaction to enable mouse interaction. Use OnMouseOver() to change the colour of a single part when the mouse icon hovers on it.
2. Get the mouse position and detect the click of the middle or right button of the mouse to move or rotate the model.
3. A pivot object is created, and its position is set to the center of the single model. Set the pivot of the parent of the single model part for the drag interaction since the original position of the single model is not match the ideal pivot position, which will affect the mouse drag interaction.


### UI
1. A TreeView interaction is created for the list UI panel to show the parts' names. The Vertical Layout Group and Scroll View in the UI are used to create the layout of the TreeView window.
2. A TextMeshPro object is instanced when the mouse clicks on a part and assigns the name to it, and destroys this object when the mouse is up.

### UI Buttons
1. Store all the position, rotation, and other states (such as colour, shader, etc.) of the model, parts, UI at the beginning of the game, and use the reset button to restore them.
2. Part list button is to set active with true and false of the TreeView.
3. The X-Ray button is to access the render material and set the alpha parameter of colour to 0.
4. The approach of transparent is changing to a custom shader with ZWrite OFF.
