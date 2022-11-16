using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private AudioManager audioManager;
    private BackGroundManager backgroundManager;
    public int contadorEstrellas;
    public Text estrellasText;

    public GameObject[] hearts;
    public GameObject gameOver;
    public GameObject win;

    void Start()
    {
        gameOver.SetActive(false);
        win.SetActive(false);
    }
    
    void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        backgroundManager = GameObject.Find("BackGroundManager").GetComponent<BackGroundManager>();



        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathCharacter(GameObject character)
    {
        audioManager.DeathSound();
        backgroundManager.StopBGM();
        gameOver.SetActive(true);
        Destroy(character, 0.3f);
    }

    public void VictoriaEstrellas(GameObject character)
    {
        audioManager.EstrellasVictoria();
        backgroundManager.StopBGM();
        win.SetActive(true);
        Destroy(character, 0.3f);

    }

    //Funcion para cuando tocamos una bomba
    public void BombaHit(GameObject bomba)
    {
        Animator bombaAnimator;
        BoxCollider2D bombaCollider;

        bombaAnimator = bomba.GetComponent<Animator>();
        bombaCollider = bomba.GetComponent<BoxCollider2D>();

        audioManager.TocasBomba();

        bombaAnimator.SetBool("BombExplosion", true);
        bombaCollider.enabled = false;

        StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(1f, 0.05f));

        Destroy(bomba, 0.3f);
    }

    public void ColeccionaEstrella(GameObject estrella, GameObject character)
    {
        Animator estrellaAnimator;
        BoxCollider2D estrellaCollider;

        estrellaAnimator = estrella.GetComponent<Animator>();
        estrellaCollider = estrella.GetComponent<BoxCollider2D>();

        estrellaAnimator.SetBool("RecogeEstrella", true);
        estrellaCollider.enabled = false;

        Destroy(estrella, 0.8f);

        contadorEstrellas = contadorEstrellas + 1;
        Debug.Log("Tienes un total de "+contadorEstrellas+" estrellas");

        estrellasText.text = contadorEstrellas.ToString();

        if(contadorEstrellas == 10)
        {
            VictoriaEstrellas(character);
        }

        audioManager.RecogerEstrella();
    }

    public void RestarVidas(GameObject character)
    {
        Global.vidas--;


        if(Global.vidas == 0)
        {
            DeathCharacter(character);
            hearts[0].SetActive(false);
        }
        else if(Global.vidas == 1)
        {
            hearts[1].SetActive(false);
        }
        else if(Global.vidas == 2)
        {
            hearts[2].SetActive(false);
        }
        
    }



}
