using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeViewManager : MonoBehaviour
{
    [SerializeField] private GameObject treeViewItem;
    [SerializeField] private GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        var itemRoot = Instantiate(treeViewItem, transform);
        itemRoot.transform.Find("Lable").GetChild(0).GetComponent<Text>().text = gameManager.Instance.testModel.transform.name;
        //Debug.Log(gameManager.Instance.testModel.transform.name);
        var parentRoot = Instantiate(parentObject, transform);


        itemRoot.transform.Find("Arrow").GetComponent<Toggle>().onValueChanged.AddListener(
           delegate { toggleArrow(itemRoot, parentRoot); }
            );

        foreach (Transform rootObject in gameManager.Instance.testModel.transform)
        {
            var itemOne = Instantiate(treeViewItem, parentRoot.transform);
            itemOne.transform.Find("Lable").GetChild(0).GetComponent<Text>().text = rootObject.transform.name;
            var parentOne = Instantiate(parentObject, parentRoot.transform);

            itemOne.transform.Find("Arrow").GetComponent<Toggle>().onValueChanged.AddListener(
           delegate { toggleArrow(itemOne, parentOne); }
            );
            foreach (Transform child in rootObject)
            {
                var item = Instantiate(treeViewItem, parentOne.transform);
                item.transform.Find("Lable").GetChild(0).GetComponent<Text>().text = child.transform.name;
                item.transform.Find("Arrow").gameObject.SetActive(false);
            }
        }
    }

    private void toggleArrow(GameObject item, GameObject parent)
    {
        if (item.transform.Find("Arrow").GetComponent<Toggle>().isOn) {
            parent.SetActive(true);
            item.transform.Find("Arrow").GetChild(0).eulerAngles = new Vector3(0,0,0);
        }
        else
        {
            parent.SetActive(false);
            item.transform.Find("Arrow").GetChild(0).eulerAngles = new Vector3(0, 0, 90);

        }
    }
}
