using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hexagon, ball, startText;
    public Transform ballSpawn;
    private bool start = false;

    void Start()
    {
        hexagon.GetComponent<RotationOfSquare>().enabled = false;
    }

    void Update()
    {
        if (Input.anyKeyDown && !start)
        {
            ball.transform.position = ballSpawn.position;
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            hexagon.GetComponent<RotationOfSquare>().enabled = true;
            startText.SetActive(false);
            start = true;
        }
    }
}