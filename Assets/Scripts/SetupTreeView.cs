/*
 * treeview example from unity https://docs.unity3d.com/Manual/TreeViewAPI.html
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
public class SetupTreeView : TreeView
{
    private int id = 0;
    public SetupTreeView(TreeViewState treeViewState)
        : base(treeViewState)
    {
        Reload();
    }

    private int GetId()
    {
        id++;
        return id;
    }

protected override TreeViewItem BuildRoot()
    {
        // BuildRoot is called every time Reload is called to ensure that TreeViewItems 
        // are created from data. Here we create a fixed set of items. In a real world example,
        // a data model should be passed into the TreeView and the items created from the model.

        // This section illustrates that IDs should be unique. The root item is required to 
        // have a depth of -1, and the rest of the items increment from that.
        var root = new TreeViewItem { id = 0, depth = -1, displayName = "Root" };
        var model = new TreeViewItem { id = GetId(), displayName = gameManager.Instance.testModel.transform.name };
        root.AddChild(model);


        foreach (Transform rootObject in gameManager.Instance.testModel.transform)
        {
            var temp = new TreeViewItem { id = GetId(), displayName = rootObject.name };
            model.AddChild(temp);
            foreach (Transform child in rootObject)
            {
                var childTemp = new TreeViewItem { id = GetId(), displayName = child.GetChild(0).name };
                temp.AddChild(childTemp);
            }

        }
        

        // Utility method that initializes the TreeViewItem.children and .parent for all items.
        //SetupParentsAndChildrenFromDepths(root, allItems);
        SetupDepthsFromParentsAndChildren(root);

        // Return root of the tree
        return root;
    }
}
