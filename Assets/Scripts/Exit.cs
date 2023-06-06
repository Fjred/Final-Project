using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class Exit : MonoBehaviour
{
    public ItemUnlocker padlock;
    public ItemUnlocker plank;
    public ItemUnlocker cables;

    public ChickenEater chicken;

    public GameObject doll;

    public bool obstaclesRemoved = false;
    public bool chickenEaten = false;
    public bool dollShot = false;

    [SerializeField] private Animator exit = null;

    public bool animationDone = false;

    public TMP_Text chickenText;
    public TMP_Text obstaclesText;

    public Image obstacleImg;
    public Image chickenImg;
    public Image dollImg;

    public Sprite checkSprite;

    public float chickenEatenNumber;

    public float obstaclesRemovedNumber;

    void Update()
    {
        GameEndCheck();

        ObstaclesRemovedCounter();

        chickenText.text = $"Chicken Eaten {chickenEatenNumber}/2";
        obstaclesText.text = $"Obstacles removed {obstaclesRemovedNumber}/3";

    }
    public void GameEndCheck()
    {
        if (padlock.unlocked && plank.unlocked && cables.unlocked)
        {
            obstaclesRemoved = true;

            obstacleImg.sprite = checkSprite;
        }

        if (chicken.chickenCounter == 0)
        {
            chickenEaten = true;
            chickenImg.sprite = checkSprite;
        }
        if (!doll.activeSelf)
        {
            dollShot = true;
            dollImg.sprite = checkSprite;
        }
    }

    public void ObstaclesRemovedCounter()
    {
        var cab = 0;
        var pad = 0;
        var pla = 0;
        if (cables.unlocked)
        {
            cab = 1;
        }

        if (padlock.unlocked)
        {
            pad = 1;
        }        
        if (plank.unlocked)
        {
            pla = 1;
        }

        obstaclesRemovedNumber = cab + pad + pla;

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (obstaclesRemoved && chickenEaten && dollShot && animationDone == false)
            {
                exit.Play("ExitDoor", 0, 0.0f);

                animationDone = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
