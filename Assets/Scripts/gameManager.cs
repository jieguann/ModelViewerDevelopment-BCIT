using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private GameObject prefebModel;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    private GameObject testModel;
    private  List<Transform> children = new List<Transform>();

    public GameObject nameTextPrefeb;
    


    
    private static gameManager _instance;
    public static gameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Game Manager");
                go.AddComponent<gameManager>();
            }
            return _instance;

        }
    }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        testModel = Instantiate(prefebModel);

        //Add list of child
        

        foreach (Transform rootObject in testModel.transform)
        {
            //Debug.Log(child.name);
            //Debug.Log(child.GetType());
            //children.Add(child);
            foreach(Transform child in rootObject)
            {
                Debug.Log(child.name);
                MeshCollider childCollider = child.gameObject.AddComponent<MeshCollider>();
                childCollider.convex = true;
                childCollider.isTrigger = true;

                child.gameObject.AddComponent<partController>();

                children.Add(child);
            }
        }

        //Debug.Log("Count: " + children.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Mouse X"));
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        //Press right button to rotate
        if (Input.GetMouseButton(1)) { 
        
            testModel.transform.Rotate(mouseY * rotationSpeed * Time.deltaTime,
            -mouseX * rotationSpeed * Time.deltaTime,
            0, Space.World);
        }



        //Press middle button to move
        if (Input.GetMouseButton(2))
        {
            testModel.transform.Translate(mouseX * moveSpeed * Time.deltaTime,
            mouseY * moveSpeed * Time.deltaTime,
            0, Space.World);
        }


    }
}
