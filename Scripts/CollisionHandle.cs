using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CollisionHandle : MonoBehaviour
{
   //For Character Controller
    [Header("MATERIAL INFO:")]
    int matIndex;
    //public Renderer rend;
    public Material mat;
    public TrailRenderer trail;
    string currentColor;
    public Texture2D[] playerSkin;

    [Header("PLAYER MOVEMENT")]
    private PlayerMovementController player_ctrl;
    public ObstacleSpawner obstacleSpawner;
    public UIManager ui_manager;

    [Header("UI ACTIVITY")]
    private int score;
    private int coin;
    private bool game_over;

    private List<GameObject> active_playGround = new List<GameObject>();

    private void Awake()
    {
        game_over = false;
        score = 0;
        coin = 0;
        //For setting the initial random color of the player
        StartCoroutine(ChangeColor());
    }

    private void Start()
    {
        //obstacleSpawner = GetComponent<ObstacleSpawner>();
        player_ctrl = GetComponent<PlayerMovementController>();
        //ui_manager = GetComponent<UIManager>();
        mat.SetTexture("skin", playerSkin[PlayerPrefs.GetInt("SKIN", 0)]);
    }

    public void OnTriggerEnter(Collider hit)
    {
        if ((hit.transform.tag != currentColor && hit.transform.tag != "color_changer"))
        {
            if(hit.transform.tag == "finish_line")
            {
                ui_manager.setComment("WELL DONE");
                if(SceneManager.GetActiveScene().buildIndex <= 1)
                {
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
            {
                ui_manager.setComment("GAME OVER");
            }
            ui_manager.restartStatus(true);
            game_over = true;
            player_ctrl.enabled = !game_over;
        }
        if (hit.transform.tag == currentColor)
        {
            score++;
            ui_manager.setScore(score);
        }
        if (hit.transform.tag == "color_changer")
        {
            StartCoroutine(ChangeColor());
        }
    }
    public void OnCollisionEnter(Collision info)
    {
        if (info.transform.tag == "coin")
        {
            coin++;
            ui_manager.setCoin(coin);
            Destroy(info.gameObject);
            Debug.Log("COIN");
        }
        if (info.transform.tag == "play_ground")
        {
            //obstacleSpawner.GeneratePlayGround();
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "play_ground")
        {
            //obstacleSpawner.DeletePlayGround();
        }
    }

    IEnumerator ChangeColor()
    {
        matIndex = Random.Range(0, 3);
        yield return new WaitForSeconds(Random.Range(0, 1));

        if(matIndex == 0)
        {
            mat.SetColor("BaseColorValue", Color.red);
            currentColor = "red_obstacle";
        }
        if (matIndex == 1)
        {
            mat.SetColor("BaseColorValue", Color.blue);
            currentColor = "blue_obstacle";
        }
        if (matIndex == 2)
        {
            mat.SetColor("BaseColorValue", Color.green);
            currentColor = "green_obstacle"; 
        }
    }
    /*IEnumerator DestroyPlayGround(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        Destroy(obj);
    }*/
}

