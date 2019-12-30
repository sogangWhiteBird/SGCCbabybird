using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class useButton : MonoBehaviour
{
    public static int food_cnt1 = 0;
    public static int food_cnt2 = 0;
    public static int food_cnt3 = 0;

    public static int food_use1 = 0;
    public static int food_use2 = 0;
    public static int food_use3 = 0;

    int[] food_love = { 15, 10, 5 };


    static int exp_limit = 500;
    static int cur_level = 1;
    public static int exp = 0;

    public Text text_point;


    int food1_score = 50;
    int food2_score = 100;
    int food3_score = 150;

    string text;
    public static Button m_Bt1;
    public Text m_Text1;

    public static Button m_Bt2;
    public Text m_Text2;

    public static Button m_Bt3;
    public Text m_Text3;

    public static Button moveScene;

    // Start is called before the first frame update
    void Start()
    {
        cur_level = PlayerPrefs.GetInt("cur_level");
        exp = PlayerPrefs.GetInt("exp");
        exp_limit = PlayerPrefs.GetInt("exp_limit");

        text_point.GetComponent<Text>().text = "level: " + setLevel().ToString();


        moveScene = GameObject.Find("GoWalkButton").GetComponent<Button>();

        moveScene.onClick.AddListener(moveScene1);

        m_Text1.GetComponent<Text>().text = "x " + food_cnt1.ToString();

        m_Text2.GetComponent<Text>().text = "x " + food_cnt2.ToString();

        m_Text3.GetComponent<Text>().text = "x " + food_cnt3.ToString();

        StartCoroutine("fadein");
    }

    [SerializeField]
    CanvasGroup A;
    IEnumerator fadein()
    {
        while (A.alpha > 0 )
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
        //Debug.Log("move to walk scene");
        SceneManager.LoadScene(1);
    }

    public void moveScene1() {
        //StartCoroutine("fadein");
        StartCoroutine("fadeout");
    }

    public void eatFood1()
    {
        if (food_cnt1 > 0)
        {
            food_cnt1--;
            food_use1++;
            text = string.Concat("x", food_cnt1.ToString());
            m_Text1.GetComponent<Text>().text = text;
           // babyBird.eat_food(food_love[0]);

            exp = food_use1 * food1_score + food_use2 * food2_score + food_use3 * food3_score;
            text_point.GetComponent<Text>().text = "level: " + setLevel().ToString();

        }
    }

    public void eatFood2()
    {
        if (food_cnt2 > 0)
        {
            food_cnt2--;
            food_use2++;
            text = string.Concat("x", food_cnt2.ToString());
            m_Text2.GetComponent<Text>().text = text;
            //babyBird.eat_food(food_love[1]);

            exp = food_use1 * food1_score + food_use2 * food2_score + food_use3 * food3_score;
            text_point.GetComponent<Text>().text = "level: " + setLevel().ToString();

        }
    }

    public void eatFood3()
    {
        if (food_cnt3 > 0)
        {
            food_cnt3--;
            food_use3++;
            text = string.Concat("x", food_cnt3.ToString());
            m_Text3.GetComponent<Text>().text = text;
           // babyBird.eat_food(food_love[2]);

            exp = food_use1 * food1_score + food_use2 * food2_score + food_use3 * food3_score;
            text_point.GetComponent<Text>().text = "level: " + setLevel().ToString();


        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    int setLevel()
    {
        Debug.Log("cur_level: " +cur_level);
        Debug.Log("exp: " + exp);
        Debug.Log("exp_limit: " + exp_limit);

        if (exp > exp_limit)
        {
            exp_limit += 500;
            cur_level = cur_level+1;
        }
        PlayerPrefs.SetInt("cur_level", cur_level);
        PlayerPrefs.SetInt("exp", exp);
        PlayerPrefs.SetInt("exp_limit", exp_limit);

        return cur_level;
    }
}
