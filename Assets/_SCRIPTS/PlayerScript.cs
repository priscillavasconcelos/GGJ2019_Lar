using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour 
{
    bool pressed;
    public List<Sprite> hearts;
    public float velocidade;
    public int posAtual = 0;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public bool over;
    public CanvasGroup gameOver, happyEnding;
	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        //InvokeRepeating("ChangeHeart", 30f, 30f);
    }

    public void ChangeHeart()
    {
        posAtual++;
        if (posAtual <= 3)
        {
            if (sr)
            {
                sr.sprite = hearts[posAtual];
            }

        }
    }
	
	// Update is called once per frame
	void Update () 
    {

        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(dirX * velocidade, dirY * velocidade, 0);
        //transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bad")
        {
            Destroy(collision.gameObject);
            sr.color = new Color(1, 1, 1, sr.color.a - 0.2f); 
            velocidade -= 0.2f;
            if (sr.color.a <= 0.2f)
            {
                GameOver();
                Destroy(gameObject);
            }
        }
        else if (collision.transform.tag == "good")
        {
            Destroy(collision.gameObject);
            if (sr.color.a < 1)
            {
                sr.color = new Color(1, 1, 1, sr.color.a + 0.2f);
                velocidade += 0.2f;
            }
            if (posAtual >= 4)
            {
                transform.localScale += new Vector3(0.05f, 0.05f, 0);
            }
        }
        else if (collision.transform.tag == "Finish")
        {
            sr.sprite = hearts[4];
        }


    }

    void GameOver()
    {
        gameOver.alpha = 1f;
        gameOver.interactable = true;
        gameOver.blocksRaycasts = true;
        over = true;
    }

    public void HappyEnd()
    {
        if (!over)
        {
            happyEnding.alpha = 1f;
            happyEnding.interactable = true;
            happyEnding.blocksRaycasts = true;
        }

    }
}
