using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partController : MonoBehaviour
{
    //When the mouse hovers over the GameObject, it turns to this color (red)
    Color m_MouseOverColor = Color.red;

    Color m_MouseEnterColor = Color.green;


    //This stores the GameObject’s original color
    Color m_OriginalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;

    bool mouseFlag = false;
    

    //camera
    Camera cam;
    private Vector3 originalWTSP;

    void Start()
    {
        //camera
        cam = Camera.main;
        originalWTSP = cam.WorldToScreenPoint(transform.position);

        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
    }

    
    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = m_MouseOverColor;
        if (Input.GetMouseButtonDown(0)){
            //select and change color
            for(int i=0; i< gameManager.Instance.children.Count; i++)
            {
                gameManager.Instance.children[i].gameObject.GetComponent<MeshRenderer>().material.color = m_OriginalColor;
            }
            

            m_Renderer.material.color = m_MouseEnterColor;
            mouseFlag = true;

            
            
        }
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
        if(mouseFlag == true)
        {
            return;
        }
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = m_OriginalColor;
        mouseFlag = false;
    }
}
