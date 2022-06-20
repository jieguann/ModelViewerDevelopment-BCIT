using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    [SerializeField] GameObject treeView;
    private bool partListToggleBool;
    private bool xRayToggleBool;
    private bool transparentToggleBool;
    private Color color;




    private void Start()
    {
        
        
        transparentToggleBool = false;
        //partListToggleBool = false;
        treeView.SetActive(partListToggleBool);
        //set up origial color
        color = gameManager.Instance.originalColor;


    }

    //Toggle Tree View
    public void displayTreeView()
    {
        partListToggleBool = !partListToggleBool;
        treeView.SetActive(partListToggleBool);
    }

    //For change X-Rayh
    public void toggleXRay()
    {
        xRayToggleBool = !xRayToggleBool;
        if(xRayToggleBool == false)
        {
            color = gameManager.Instance.originalColor;
        }
        else
        {
            color.a = 0;
        }
        
        for (int i=0;i < gameManager.Instance.children.Count; i++)
        {
            gameManager.Instance.children[i].GetComponent<Renderer>().material.shader = gameManager.Instance.originalShader;
            gameManager.Instance.children[i].gameObject.GetComponent<Renderer>().material.color = color;
        }
        
    }

    //Togle Transparent
    public void toggleTransparent()
    {
        transparentToggleBool = !transparentToggleBool;
        color = gameManager.Instance.originalColor;
        for (int i = 0; i < gameManager.Instance.children.Count; i++)
        {
            gameManager.Instance.children[i].gameObject.GetComponent<Renderer>().material.color = color;
            if (transparentToggleBool == false)
            {
                gameManager.Instance.children[i].GetComponent<Renderer>().material.shader = gameManager.Instance.originalShader;
            }
            else
            {
                gameManager.Instance.children[i].GetComponent<Renderer>().material.shader = Shader.Find("Custom/Transparent");
            }
            
        }
    }

    public void resetScene()
    {
        gameManager.Instance.testModel.transform.position = gameManager.Instance.spawnPoint.transform.position;
        gameManager.Instance.testModel.transform.rotation = gameManager.Instance.spawnPoint.transform.rotation;
        //reset x ray
        
        for (int i = 0; i < gameManager.Instance.children.Count; i++)
        {
            gameManager.Instance.children[i].gameObject.GetComponent<Renderer>().material.color = gameManager.Instance.originalColor;
            //gameManager.Instance.children[i].parent.position = gameManager.Instance.childrenPosition[i];
            gameManager.Instance.pivot[i].localPosition = gameManager.Instance.pivotOriginalPosition[i];
            gameManager.Instance.children[i].GetComponent<Renderer>().material.shader = gameManager.Instance.originalShader;
        }
    }
}
