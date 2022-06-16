using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    [SerializeField] GameObject treeView;
    private bool partListToggleBool;
    private bool xRayToggleBool;
    Color color;




    private void Start()
    {
        
        partListToggleBool = false;
        treeView.SetActive(partListToggleBool);
        //set up origial color
        color = gameManager.Instance.partMaterial.color;


    }
    public void displayTreeView()
    {
        partListToggleBool = !partListToggleBool;
        treeView.SetActive(partListToggleBool);
    }


    public void toggleXRay()
    {
        xRayToggleBool = !xRayToggleBool;
        if(xRayToggleBool == false)
        {
            color.a = 1f;
        }
        else
        {
            color.a = 0;
        }
        
        for (int i=0;i < gameManager.Instance.children.Count; i++)
        {
           
            gameManager.Instance.children[i].gameObject.GetComponent<Renderer>().material.color = color;
        }
        
    }
}
