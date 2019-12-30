using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyBird : MonoBehaviour
{

    public static int love= 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    //parameter로 음식의 애정도를 넣습니다.
    public static void eat_food(int foodAffect)
    {
        love += foodAffect;
    }

}

