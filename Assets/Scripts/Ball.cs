using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Color[] colors;
    public float bounceForce = 2.0f;
    private SpriteRenderer ballRenderer;
    private Rigidbody2D ballRb;
    private int score = 0, highScore;
    public TextMeshProUGUI scoreText, highScoreText;
    [SerializeField] private string hexColor = "#FFA500";
    private bool firstColor = true;

    void Start()
    {
        ballRenderer = GetComponent<SpriteRenderer>();
        ballRb = GetComponent<Rigidbody2D>();

        /* GameObject floor = GameObject.Find("Square6");
         if (floor != null)
         {

         }
         SpriteRenderer floorRenderer = GameObject.Find("Square6").GetComponent<SpriteRenderer>();

         ballRenderer.color = floor.color;*/


        ColorChanger();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        else
        {
            highScore = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            ballRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }


        if (collision.gameObject.CompareTag("Square"))
        {
            ballRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

            bool ColorsAreSimilar(Color c1, Color c2)
            {
                float tolerance = 0.2f;
                float distance = Mathf.Sqrt(
                    Mathf.Pow(c1.r - c2.r, 2) +
                    Mathf.Pow(c1.g - c2.g, 2) +
                    Mathf.Pow(c1.b - c2.b, 2)
                );
                return distance < tolerance;
            }

            if (ColorsAreSimilar(ballRenderer.color, collision.gameObject.GetComponent<SpriteRenderer>().color))
            {
                GetComponent<AudioSource>().Play();
                score++;
                scoreText.text = "Score: " + score.ToString();

                if (score > highScore)
                {
                    highScore = score;
                    highScoreText.text = "High Score: " + highScore.ToString();
                    PlayerPrefs.SetInt("HighScore", highScore);
                    PlayerPrefs.Save();
                }
            }
            else if (!ColorsAreSimilar(ballRenderer.color, collision.gameObject.GetComponent<SpriteRenderer>().color))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Oyun Bitti! Skor: " + score + " | En Yüksek Skor: " + highScore);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            ColorChanger();
        }
    }

    private void ColorChanger()
    {
        if (firstColor)
        {
            ballRenderer.color = colors[2];
            firstColor = false;
        }
        else
        {
            int random = Random.Range(0, colors.Length);
            ballRenderer.color = colors[random];
        }

        /*switch (random)
        {
            case 0:
                ballRenderer.color = colors[0];
                break;
            case 1:
                ballRenderer.color = colors[1];
                break;
            case 2:
                ballRenderer.color = colors[2];
                break;
            case 3:
                ballRenderer.color = colors[3];
                break;
            case 4:
                ballRenderer.color = colors[4];
                break;
            case 5:
                ballRenderer.color = colors[5];
                break;
            default:
                //ballRenderer.color = colors[random];
                break;
        }*/
    }
}