using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class partController : MonoBehaviour
{
    //When the mouse hovers over the GameObject, it turns to this color (red)
    Color hightLightColor = Color.red;

    //This stores the GameObject’s original color
    Color originalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;

    
    

    //move object
    private Vector3 mOffset;
    private float mZCoord;
    

    //name text object
    private GameObject nameText;

    //reset the pivot of the mesh
    //private Vector3 pivotPosition; // the spawn position of the pivot point
    private Transform pivot;

    void Start()
    {
       
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        originalColor = m_Renderer.material.color;

        //set the pivot with parent
        pivot = new GameObject().transform;
        pivot.position = transform.GetComponent<Renderer>().bounds.center; //put it to the centre of mesh
        pivot.SetParent(transform.parent);
        transform.SetParent(pivot);
        

    }

    
    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = hightLightColor;
        /*
        if (Input.GetMouseButton(0))
        {
            //move the part
            //Vector3 posScreen = cam.WorldToScreenPoint(transform.position);
            transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, originalWTSP.z));
        }
        */
    }

    
        void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = originalColor;
    }


    void OnMouseDown()

    {
        
        Vector3 textPosition = new Vector3(pivot.position.x + 2f, pivot.position.y, pivot.position.z);
        nameText = Instantiate(gameManager.Instance.nameTextPrefeb);
        nameText.GetComponent<TextMeshPro>().text = gameObject.name;
        nameText.GetComponent<RectTransform>().position = textPosition;

        mZCoord = Camera.main.WorldToScreenPoint(

            pivot.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = pivot.position - GetMouseAsWorldPoint();

    }

    void OnMouseDrag()

    {
        
        Vector3 textPosition = new Vector3(pivot.position.x + 2f, pivot.position.y, pivot.position.z);
        nameText.GetComponent<RectTransform>().position = textPosition;
        //Debug.Log(centrePoint);
        //Debug.Log(transform.position);

        pivot.position = GetMouseAsWorldPoint() + mOffset;
    }

    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseUp()
    {
        Destroy(nameText);
    }



}
