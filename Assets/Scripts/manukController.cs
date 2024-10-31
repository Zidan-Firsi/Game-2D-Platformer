using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class manukController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float mencelat;
    public GameObject panelSelesai;
    private int Score;
    public TMPro.TextMeshProUGUI skor;
    public TMPro.TextMeshProUGUI skorGameplay;
    public GameObject panelGameplay;

    // Start is called before the first frame update
    void Start()
    {
        panelSelesai.SetActive(false);
        panelGameplay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ManukMencelat();
    }

    void ManukMencelat()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * mencelat;
            AudioManager.singleton.PlaySound(0);
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.CompareTag("Obstacle"))
        {
            PlayerTamat();
        }
    }

    void PlayerTamat()
    {   
        panelGameplay.SetActive(false);
        panelSelesai.SetActive(true);
        Time.timeScale = 0;
        AudioManager.singleton.PlaySound(1);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D (Collider2D z)
    {
        if (z.CompareTag("Score"))
        {
            tambahScore();
        }
    }

    void tambahScore()
    {
        AudioManager.singleton.PlaySound(2);
        Score++;
        skor.text = Score.ToString();
        skorGameplay.text = Score.ToString();
    }
}
