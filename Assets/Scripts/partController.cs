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
    private Vector3 centrePoint;

    //name text object
    private GameObject nameText;

    void Start()
    {
       
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        originalColor = m_Renderer.material.color;

        
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
        centrePoint = transform.GetComponent<Renderer>().bounds.center;
        Vector3 textPosition = new Vector3(centrePoint.x + 2f, centrePoint.y, centrePoint.z);
        nameText = Instantiate(gameManager.Instance.nameTextPrefeb);
        nameText.GetComponent<TextMeshPro>().text = gameObject.name;
        nameText.GetComponent<RectTransform>().position = textPosition;

        mZCoord = Camera.main.WorldToScreenPoint(

            transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = transform.position - GetMouseAsWorldPoint();

    }

    void OnMouseDrag()

    {
        centrePoint = transform.GetComponent<Renderer>().bounds.center;
        Vector3 textPosition = new Vector3(centrePoint.x + 2f, centrePoint.y, centrePoint.z);
        nameText.GetComponent<RectTransform>().position = textPosition;
        //Debug.Log(centrePoint);
        //Debug.Log(transform.position);

        transform.position = GetMouseAsWorldPoint() + mOffset;
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
