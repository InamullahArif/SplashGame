using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{
    private bool add_force;
    public GameObject splash_Prefab;
    public float force;
    public Rigidbody rb;
    private int Score;
    public Text score_txt;
    public Text HighScore_txt;
    public GameObject GameOverMenu;
    public GameObject finish;
    void Start()
    {
        add_force = true;
        HighScore_txt.text = "Best: " + PlayerPrefs.GetInt ("ScoreHigh");
    }
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "helix_piece" && add_force)
        {
            add_force = false;
            Invoke("fix",0.5f);
            gameObject.GetComponent<AudioSource>().Play();
        rb.AddForce(new Vector3 (0f,1f,0f)*Time.deltaTime * force);
        GameObject splash = Instantiate(splash_Prefab);
        Vector3 pos = transform.position;
        pos.y = pos.y - 0.2f;
        splash.transform.position = pos;
        splash.transform.SetParent(GameObject.Find("helix").transform);
        }
        else if (collision.gameObject.tag == "gameOver")
        {
            GameOverMenu.SetActive(true);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "complete")
        {
            finish.SetActive(true);
        }
    }
    private void fix()
    {
        add_force = true;
    }
    
    private void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Score")
        {
             Score = Score + 5;
             int ScoreHigh = PlayerPrefs.GetInt ("ScoreHigh");
            if (Score>ScoreHigh)
            {
               PlayerPrefs.SetInt ("ScoreHigh", Score);
               HighScore_txt.text = "Best: " + PlayerPrefs.GetInt ("ScoreHigh");
            }
            
            score_txt.text = Score + " ";
        }
    }
    private void Update()
    {
        if ((transform.position.y + 2.1f) < Camera.main.transform.position.y)
        {
            Vector3 pos = Camera.main.transform.position;
            pos.y = transform.position.y + 2.1f;
            Camera.main.transform.position = pos;
        }
    }
}
