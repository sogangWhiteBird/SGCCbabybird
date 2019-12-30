using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(1 * Time.deltaTime, 0, 0);
        if (transform.position.x > 3.6f)
            transform.Translate(-7.6f, 0, 0);

    }
}

