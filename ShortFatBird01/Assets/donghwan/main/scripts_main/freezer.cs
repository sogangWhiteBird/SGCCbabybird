using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezer : MonoBehaviour
{
    public GameObject foodSelectScene;
    const float tempScala = 5f / 3f;
    float timeSpan = 0;

    // Start is called before the first frame update
    void Start()
    {
        foodSelectScene = GameObject.Find("ButtonsOfFreezer");
        foodSelectScene.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            foodSelectScene.SetActive(true);
        
                        if (timeSpan < 3.0f)
                            timeSpan += Time.deltaTime;
                        else
                            timeSpan = 3.0f;

                        if(1.0f <= timeSpan* tempScala)
                            foodSelectScene.transform.localScale = new Vector3(timeSpan * tempScala, timeSpan * tempScala, 0);
          
        }
    */
        
    }
    private void OnMouseDown()
    {
        foodSelectScene.SetActive(true);
    }
}
