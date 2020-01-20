using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement_con : MonoBehaviour
{
    public float speed = 0f;
    /*enum ModeSwitching { Start, Impulse};
    ModeSwitching ModeSwitch;
    ForceMode2D ForceMode;
    Vector2 StartPos;
    Vector2 NewForce;*/
    Rigidbody2D Rb;
    public float jumpH = 0f;
    public float score;
    public GameObject timeCanvas;
    public GameObject scoreCanvas;
    private Text timeing;
    private Text scoreCount;
    public float timer;
    public float CT;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Rb = GetComponent<Rigidbody2D>();
        GameObject.FindGameObjectsWithTag("speed_up");
        GameObject.FindGameObjectsWithTag("hurdle");
        GameObject.FindGameObjectWithTag("point");
        /*setScoreText();
        setTime();*/
        /*ModeSwitch = ModeSwitching.Start;
          NewForce = new Vector2 (0.0f, 1.0f);
          StartPos = Rb.transform.positon*/
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //setTime();
       Rb.velocity = transform.right * speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {

                Rb.AddForce(transform.up * jumpH, ForceMode2D.Impulse);
            }
        
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("speed_up"))
        {
            speed = speed + 100;
        }
        if (other.gameObject.CompareTag("hurdle"))
        {
            if (speed > 50)
            {
                speed = speed - 50;
            } if (speed == 50)
            {
                speed = 50;
            }
            if (score > 0)
            {
                score = score -1;
            }
        }
        if (other.gameObject.CompareTag("point"))
        {
            score = score + 1;
        }
    }

   /* void setTime()
    {
        CT = timer;
        timeing.text = CT.ToString();
    }
    void setScoreText()
    {
        scoreCount.text = "score: " + score.ToString();
    }*/

}
