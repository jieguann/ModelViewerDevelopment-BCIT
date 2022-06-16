using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    [SerializeField] GameObject treeView;
    private bool toggleBool;
    private void Awake()
    {
        
    }

    private void Start()
    {
        
        toggleBool = false;
        treeView.SetActive(toggleBool);
    }
    public void displayTreeView()
    {
        toggleBool = !toggleBool;
        treeView.SetActive(toggleBool);
    }
}
