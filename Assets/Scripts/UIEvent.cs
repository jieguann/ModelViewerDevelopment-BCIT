using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    [SerializeField] GameObject treeView;
    private bool partListToggleBool;
   

    private void Start()
    {
        
        partListToggleBool = false;
        treeView.SetActive(partListToggleBool);
    }
    public void displayTreeView()
    {
        partListToggleBool = !partListToggleBool;
        treeView.SetActive(partListToggleBool);
    }
}
