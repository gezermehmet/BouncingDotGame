using UnityEngine;

public class BallColor : MonoBehaviour
{
    public Color[] colors;
    private SpriteRenderer spriteRenderer;
    public GameObject[] edges;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //colorChange();
        InvokeRepeating("ColorChange", 0f, Random.Range(1f, 5f));
    }

    void ColorChange()
    {
        spriteRenderer.color = colors[Random.Range(0, colors.Length)];
    }

    bool ColorsAreSimilar(Color c1, Color c2)
    {
        float tolerance = 0.2f;
        bool result = Mathf.Abs(c1.r - c2.r) < tolerance &&
                      Mathf.Abs(c1.g - c2.g) < tolerance &&
                      Mathf.Abs(c1.b - c2.b) < tolerance;
        return result;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            GameObject lowestEdge = GetLowestEdge();
            Color edgeColor = lowestEdge.GetComponent<SpriteRenderer>().color;

            Debug.Log("En Alt Kenar: " + lowestEdge.name);

            if (ColorsAreSimilar(edgeColor, spriteRenderer.color))
            {
                Debug.Log("Yess");
                
            }
            else
            {
                Debug.Log("Renkler Uyuşmuyor");
                //Destroy(gameObject);
            }
        }
    }

    GameObject GetLowestEdge()
    {
        GameObject lowestEdge = edges[0];
        float lowestY = lowestEdge.transform.position.y;

        foreach (GameObject edge in edges)
        {
            if (edge.transform.position.y < lowestY)
            {
                lowestEdge = edge;
                lowestY = edge.transform.position.y;
            }
        }

        return lowestEdge;
    }
}


// Update is called once per frame
/*void Update()
{
    /*if (Input.GetKeyDown(KeyCode.A))
    {
        colorChange();
    }
}*/


/* void OnCollisionEnter2D(Collision2D collision)
 {
     if (collision.gameObject.tag == "Square")
     {
         Color ballColor = spriteRenderer.color;

         foreach (GameObject edge in edges)
         {
             Color edgeColor = edge.GetComponent<SpriteRenderer>().color;
             if (ColorsAreSimilar(ballColor, edgeColor))
             {
                 Debug.Log("YEss");
                 return;
             }
         }
     }
 }*/