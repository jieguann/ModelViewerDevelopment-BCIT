using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
public class TreeViewUI : MonoBehaviour
{
    [SerializeField] TreeViewState m_TreeViewState;
    [SerializeField] RectTransform anchor;

    SetupTreeView setupTreeView;
    private void Start()
    {
        if (m_TreeViewState == null)
            m_TreeViewState = new TreeViewState();

        setupTreeView = new SetupTreeView(m_TreeViewState);
        setupTreeView.Reload();

        Debug.Log(anchor.position);
    }
    void OnGUI()
    {
        setupTreeView.OnGUI(new Rect(30,50, 500, 500));
    }
    
}
