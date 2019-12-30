using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    [SerializeField]
    GameObject food1;
    [SerializeField]
    GameObject food2;
    [SerializeField]
    GameObject food3;
    [SerializeField]
    GameObject stone;



    GameObject[] pool1 = new GameObject[5];
    int food1number=0;
    GameObject[] pool2 = new GameObject[5];
    int food2number = 0;
    GameObject[] pool3 = new GameObject[5];
    int food3number = 0;
    GameObject[] pool4 = new GameObject[5];
    int stonenumber = 0;

    public Button goBack;
    public void goingBack()
    {
        StartCoroutine(fadeout());
    }

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadein());

        for (int i=0; i<5; i++)
        {
            pool1[i] = (GameObject)Instantiate(food1, new Vector3(-4, Random.Range((float)-3, (float)6.4), -2), Quaternion.identity);
            pool1[i].SetActive(false);
            pool2[i] = (GameObject)Instantiate(food2, new Vector3(-4, Random.Range((float)-3, (float)6.4), -2), Quaternion.identity);
            pool2[i].SetActive(false);
            pool3[i] = (GameObject)Instantiate(food3, new Vector3(-4, Random.Range((float)-3, (float)6.4), -2), Quaternion.identity);
            pool3[i].SetActive(false);
            pool4[i] = (GameObject)Instantiate(stone, new Vector3(-4, Random.Range((float)-3, (float)6.4), -2), Quaternion.identity);
            pool4[i].SetActive(false);

        }

        StartCoroutine(foodPop());
    }
  
    int jump_cnt = 3;
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)&(jump_cnt>0))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            jump_cnt--;
        }
    }

    //coroutine for food popping
    public IEnumerator foodPop()
    {
        while (true)
        {
            yield return new WaitForSeconds(3); //after 3 seconds
            pool1[food1number] = (GameObject)Instantiate(food1, new Vector3(-4, Random.Range((float)-3, (float)4.5), -2), Quaternion.identity);
            pool1[food1number].SetActive(true); //hamburger
            food1number = (food1number + 1) % 5;
            yield return new WaitForSeconds(3); //after 3 seconds
            pool2[food2number] = (GameObject)Instantiate(food2, new Vector3(-4, Random.Range((float)-3, (float)4.5), -2), Quaternion.identity);
            pool2[food2number].SetActive(true); //cupcake
            food2number = (food2number + 1) % 5;
            yield return new WaitForSeconds(3); //after 3 seconds
            pool3[food3number] = (GameObject)Instantiate(food3, new Vector3(-4, Random.Range((float)-3, (float)4.5), -2), Quaternion.identity);
            pool3[food3number].SetActive(true);
            food3number = (food3number + 1) % 5; //chicken
            yield return new WaitForSeconds(3); //after 3 seconds
            pool3[food3number] = (GameObject)Instantiate(stone, new Vector3(-4, Random.Range((float)-3, (float)4.5), -2), Quaternion.identity);
            pool3[food3number].SetActive(true);
            stonenumber = (stonenumber + 1) % 5; //stone

        }

    }

    //initialize jump count
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            jump_cnt = 3;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "food1(Clone)")
        {
          
            useButton.food_cnt1++;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "food2(Clone)")
        {

            useButton.food_cnt2++;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "food3(Clone)")
        {

            useButton.food_cnt3++;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "stone(Clone)")
        {

            collision.gameObject.SetActive(false);
            StartCoroutine(fadeout());
        }

    }

    [SerializeField]
    CanvasGroup A;

    IEnumerator fadein()
    {
        while (A.alpha > 0)
        {
            A.alpha -= Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator fadeout()
    {
        while (A.alpha < 1)
        {
            A.alpha += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(0);

    }


}
