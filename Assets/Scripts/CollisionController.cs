using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CollisionController : MonoBehaviour
{

    //References
    private PlayerController playerController;
    public GameObject snakeHead;

    public bool isfinished = false;
    public bool isAlive = true;
    public bool hasFever = false;

    //For collision check
    private int counter = 0;
    private int counterForFever = 0;

    //Audio
    public AudioSource audioSource;
    public AudioSource gameTheme;
    public AudioClip gameOverAudio;
    public AudioClip eatFood;
    public AudioClip eatCoin;
    public AudioClip newBody;

    //Particle
    public ParticleSystem particleFever;
    public ParticleSystem particleEnviromemt;

    //UI
    public Text coinCounter;
    private int numberOfCoins;

    public Text foodCounter;
    private int numberOfFood;
    private void Start()
    {
        playerController = snakeHead.GetComponent<PlayerController>();
    }
    private void Update()
    {
        coinCounter.text = numberOfCoins.ToString();
        foodCounter.text = numberOfFood.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collision with basic food
        if (other.gameObject.CompareTag("Food") & counter >=9)
        {
            audioSource.PlayOneShot(eatFood);
            playerController.AddBodyPart();
            audioSource.PlayOneShot(newBody);
            Destroy(other.gameObject);
            counter = 0;
            counterForFever = 0;
            numberOfFood++;
            Debug.Log(other.gameObject.name);
        }
        //Collision with basic food + check body part
        else if (other.gameObject.CompareTag("Food") & counter < 10)
        {
            audioSource.PlayOneShot(eatFood);
            counter++;
            Destroy(other.gameObject);
            counterForFever = 0;
            numberOfFood++;
            Debug.Log(other.gameObject.name);
        }
        //Collision with coin + check fever
        else if (other.gameObject.CompareTag("Coin") & counterForFever >=2)
        {
            audioSource.PlayOneShot(eatCoin);
            Destroy(other.gameObject);
            counterForFever = 0;
            numberOfCoins++;
            FeverOn();
            Debug.Log(other.gameObject.name);
            print("FEVER!!!!!!!!!!!!!!!");
        }
        //Collision with coin
        else if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(eatCoin);
            Destroy(other.gameObject);
            counterForFever++;
            numberOfCoins++;
            Debug.Log(counterForFever);
            Debug.Log(other.gameObject.name);
        }
        //Collision with food, which another color, GameOver
        if (other.gameObject.CompareTag("Food") & other.gameObject.GetComponent<MeshRenderer>().material.color != GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().material.color 
            & hasFever == false || other.gameObject.CompareTag("Obstacle") & hasFever == false)
        {
            isAlive = false;
            counterForFever = 0;
            audioSource.PlayOneShot(gameOverAudio);
            Invoke("Restart", 1f);
            Debug.Log(other.gameObject.name);
        }
        else if(other.gameObject.CompareTag("Food") & other.gameObject.GetComponent<MeshRenderer>().material.color != GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().material.color
            & hasFever == false || other.gameObject.CompareTag("Obstacle") & hasFever == true)
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            FinishLevel();
        }
    }

    public void FeverOn()
    {
        gameTheme.pitch = 1.2f;
        hasFever = true;
        particleFever.Play();
        particleEnviromemt.Play();
        Invoke("FeverOff", 5f);
        playerController.CheckFever();
    }
    public void FeverOff()
    {
        gameTheme.pitch = 1f;
        hasFever = false;
        particleFever.Stop();
        particleEnviromemt.Stop();
        playerController.CheckFever();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    void FinishLevel()
    {
        isfinished = true;
        Debug.Log(isfinished);
    }



}
