using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class partController : MonoBehaviour
{
    //When the mouse hovers over the GameObject, it turns to this color (red)
    Color hightLightColor = Color.red;

    //Store the original color
    Color originalColor;

    //Define the material mesh color for changing it
    MeshRenderer materialColor;

    //move object
    private Vector3 offsetPosition;
    private float objectZPosition;
    private Transform pivot;


    //name text object
    private GameObject nameText;
    [SerializeField] float nameTextXPosition;
    //reset the pivot of the mesh
    //private Vector3 pivotPosition; // the spawn position of the pivot point
    

    private void Awake()
    {
        pivot = new GameObject().transform;
        pivot.name = "pivot";
        
    }
    void Start()
    {
        pivot.position = transform.GetComponent<Renderer>().bounds.center; //put it to the centre of mesh
        pivot.SetParent(transform.parent);
        transform.SetParent(pivot);

        //add pivot to the list
        gameManager.Instance.pivot.Add(pivot);
        gameManager.Instance.pivotOriginalPosition.Add(pivot.localPosition);
        //Fetch the mesh renderer component from the GameObject
        materialColor = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        originalColor = materialColor.material.color;

        //set the pivot with parent
        

        //set up material for x-Ray
        materialColor.material = gameManager.Instance.partMaterial;
        

    }

    

    void OnMouseOver()
    {
        
        materialColor.material.color = hightLightColor;
        
    }

    
        void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        materialColor.material.color = originalColor;
    }


    void OnMouseDown()

    {
        
        Vector3 textPosition = new Vector3(pivot.position.x + 2f, pivot.position.y, pivot.position.z);
        nameText = Instantiate(gameManager.Instance.nameTextPrefeb, gameManager.Instance.canvasParent.transform);
        nameText.GetComponent<TextMeshPro>().text = gameObject.name;
        nameText.GetComponent<RectTransform>().position = textPosition;

        objectZPosition = Camera.main.WorldToScreenPoint(

            pivot.position).z;
        // Store offset = gameobject world pos - mouse world pos
        offsetPosition = pivot.position - GetMouseAsWorldPoint();

    }

    void OnMouseDrag()

    {
        
        Vector3 textPosition = new Vector3(pivot.position.x + 2f, pivot.position.y, pivot.position.z);
        nameText.GetComponent<RectTransform>().position = textPosition;
        //Debug.Log(centrePoint);
        //Debug.Log(transform.position);

        pivot.position = GetMouseAsWorldPoint() + offsetPosition;
    }

    private Vector3 GetMouseAsWorldPoint()

    {

        // the pixel position of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = objectZPosition;

        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseUp()
    {
        Destroy(nameText);
    }



}
