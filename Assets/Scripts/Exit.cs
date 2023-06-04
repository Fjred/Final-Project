using UnityEngine;
using UnityEngine.SceneManagement;
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

    void Update()
    {
        GameEndCheck();

    }

    public void GameEndCheck()
    {
        if (padlock.unlocked && plank.unlocked && cables.unlocked)
        {
            obstaclesRemoved = true;
        }

        if (chicken.chickenCounter == 0)
        {
            chickenEaten = true;
        }
        if (!doll.activeSelf)
        {
            dollShot = true;
        }
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
        SceneManager.LoadScene(3);
    }
}
