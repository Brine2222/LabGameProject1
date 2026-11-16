using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int health = 3;
    public static int lives = 0;
    public static int score = 0;
    public static bool hasHeart = false;
    public TextMeshProUGUI scoreUI;


    public Image healthBar;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer sr;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
                sr.enabled = true;
            }
        }

        scoreUI.text = " " + score;
    }

    void SpriteFlicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime = flickerTime + Time.deltaTime;
        }
        else if (flickerTime >= flickerDuration)
        {
            sr.enabled = !(sr.enabled);
            flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isImmune == false)
        {
            health = health - damage;

            healthBar.fillAmount = PlayerStats.health / 3f; //HEALTH IS STATIC, "THIS.OBJ" IS INVALID. (Also why not call onto int hp?)

            if (health < 0)
                health = 0;
            if (lives > 0 && health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health = 3;
                healthBar.fillAmount = PlayerStats.health / 3f; //HEALTH IS STATIC, "THIS.OBJ" IS INVALID. (Also why not call onto int hp?)
                lives--;
            }
            else if (lives == 0 && health == 0)
            {
                Debug.Log("Gameover");
                Destroy(this.gameObject);
                SceneManager.LoadScene(3);
            }

            Debug.Log("Player Health:" + health.ToString());
            Debug.Log("Player Lives:" + lives.ToString());
        }

        isImmune = true;
        immunityTime = 0f;
    }

}