using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Construction : MonoBehaviour
{
    public Transform material;

    public GameObject brickPref_4;
    public GameObject brickPref_2;
    public GameObject steelPref_4;
    public GameObject steelPref_2;
    public GameObject treesPref;
    public GameObject water1Pref;
    public GameObject map;

    GameObject instantiatedObject;
    GameObject placedMat;
    GameObject clonedMap;

    int selectedMat;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        //instantiatedObject = Instantiate(brickPref_4, material);
        //instantiatedObject.GetComponent<Renderer>().sortingOrder = 1;
        clonedMap = Instantiate(map);
        transform.SetParent(clonedMap.transform);
        selectedMat = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Ấn Z để đổi vật liệu
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchMaterial();
        }

        //Enter/Space để instantiate vật liệu đang chọn tại chỗ
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
        {
            placedMat = Instantiate(instantiatedObject, material);
            placedMat.GetComponent<Renderer>().sortingOrder = 0;
            placedMat.transform.parent = null;
            placedMat.transform.SetParent(map.transform);
        }

        //Ấn escape để trở lại màn hình chính
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("StartGame");
        }
    }

    void SwitchMaterial()
    {
        switch (selectedMat)
        {
            //Brick_4
            //-----------------------------------------------------------------------------
            case 1:
                //Destroy vật liệu đang chọn, khởi tạo vật liệu mới
                Destroy(instantiatedObject);
                instantiatedObject = Instantiate(brickPref_4, material);
                instantiatedObject.GetComponent<Renderer>().sortingOrder = 1;
                selectedMat++;
                break;

            //Brick_2
            //-----------------------------------------------------------------------------
            case 2:
                Destroy(instantiatedObject);
                instantiatedObject = Instantiate(brickPref_2, material);
                instantiatedObject.GetComponent<Renderer>().sortingOrder = 1;
                selectedMat++;
                break;
            case 3:
                instantiatedObject.transform.Rotate(0f, 0f, -90f);
                instantiatedObject.transform.position += new Vector3(0, 0.16f, 0);
                selectedMat++;
                break;
            case 4:
                instantiatedObject.transform.Rotate(0f, 0f, -90f);
                instantiatedObject.transform.position += new Vector3(0.16f, 0f, 0);
                selectedMat++;
                break;
            case 5:
                instantiatedObject.transform.Rotate(0f, 0f, -90f);
                instantiatedObject.transform.position += new Vector3(0f, -0.16f, 0);
                selectedMat++;
                break;

            //Steel_4
            //-----------------------------------------------------------------------------
            case 6:
                Destroy(instantiatedObject);
                instantiatedObject = Instantiate(steelPref_4, material);
                instantiatedObject.GetComponent<Renderer>().sortingOrder = 1;
                selectedMat++;
                break;

            //Steel_2
            //-----------------------------------------------------------------------------
            case 7:
                Destroy(instantiatedObject);
                instantiatedObject = Instantiate(steelPref_2, material);
                instantiatedObject.GetComponent<Renderer>().sortingOrder = 1;
                selectedMat++;
                break;
            case 8:
                instantiatedObject.transform.Rotate(0f, 0f, -90f);
                instantiatedObject.transform.position += new Vector3(0, 0.16f, 0);
                selectedMat++;
                break;
            case 9:
                instantiatedObject.transform.Rotate(0f, 0f, -90f);
                instantiatedObject.transform.position += new Vector3(0.16f, 0f, 0);
                selectedMat++;
                break;
            case 10:
                instantiatedObject.transform.Rotate(0f, 0f, -90f);
                instantiatedObject.transform.position += new Vector3(0f, -0.16f, 0);
                selectedMat++;
                break;

            //Trees
            //-----------------------------------------------------------------------------
            case 11:
                Destroy(instantiatedObject);
                instantiatedObject = Instantiate(treesPref, material);
                instantiatedObject.GetComponent<Renderer>().sortingOrder = 1;
                selectedMat++;
                break;

            //Water1
            //-----------------------------------------------------------------------------
            case 12:
                Destroy(instantiatedObject);
                instantiatedObject = GameObject.Instantiate(water1Pref, material);
                instantiatedObject.GetComponent<Renderer>().sortingOrder = 1;
                selectedMat = 1;
                break;
        }
    }
}
