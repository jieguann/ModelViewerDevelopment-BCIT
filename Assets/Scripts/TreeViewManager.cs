using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TreeViewManager : MonoBehaviour
{
    [SerializeField] private GameObject treeViewItem;
    [SerializeField] private GameObject parentObject;

    [SerializeField] private List<GameObject> itemList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        var itemRoot = Instantiate(treeViewItem, transform);
        itemList.Add(itemRoot);
        itemRoot.transform.Find("Button").GetChild(0).GetComponent<TMP_Text>().text = "Technical Test Asset";
            //gameManager.Instance.testModel.transform.name;
        //Debug.Log(gameManager.Instance.testModel.transform.name);
        var parentRoot = Instantiate(parentObject, transform);


        itemRoot.transform.Find("Arrow").GetComponent<Toggle>().onValueChanged.AddListener(
           delegate { toggleArrow(itemRoot, parentRoot); }
            );
        itemRoot.transform.Find("Button").GetComponent<Button>().onClick.AddListener(delegate { onTextColorChange(itemRoot); }
            );
        foreach (Transform rootObject in gameManager.Instance.testModel.transform)
        {
            var itemOne = Instantiate(treeViewItem, parentRoot.transform);
            itemList.Add(itemOne);
            itemOne.transform.Find("Button").GetChild(0).GetComponent<TMP_Text>().text = rootObject.transform.name;
            var parentOne = Instantiate(parentObject, parentRoot.transform);

            itemOne.transform.Find("Arrow").GetComponent<Toggle>().onValueChanged.AddListener(
           delegate { toggleArrow(itemOne, parentOne); }
            );
            itemOne.transform.Find("Button").GetComponent<Button>().onClick.AddListener(delegate { onTextColorChange(itemOne); }
                        );
            foreach (Transform child in rootObject)
            {
                var item = Instantiate(treeViewItem, parentOne.transform);
                itemList.Add(item);
                item.transform.Find("Button").GetChild(0).GetComponent<TMP_Text>().text = child.transform.name;
                item.transform.Find("Button").GetComponent<Button>().onClick.AddListener(delegate { onTextColorChange(item); }
                        );
                item.transform.Find("Arrow").gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i].transform.Find("Button").GetChild(0).GetComponent<TMP_Text>().color = Color.black;
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

    private void onTextColorChange(GameObject item)
    {
        for (int i = 0; i < itemList.Count; i++){
            itemList[i].transform.Find("Button").GetChild(0).GetComponent<TMP_Text>().color = Color.black;
        }
        item.transform.Find("Button").GetChild(0).GetComponent<TMP_Text>().color = Color.blue;
    }


}
