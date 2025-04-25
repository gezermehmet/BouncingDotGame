using System.Collections;
using UnityEngine;

public class RotationOfSquare : MonoBehaviour
{
    private float waitForSeconds = 0.05f;
    public GameObject ball;
    private SpriteRenderer sr;


    void Update()
    {
        StartCoroutine(turnHexagonWithMouse());
        StartCoroutine(turnHexagonWithKeyboard());
    }

    IEnumerator turnHexagonWithKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, -30f);
            yield return new WaitForSeconds(waitForSeconds);
            transform.Rotate(0f, 0f, -30f);
            //transform.Rotate(new Vector3(0f, 0f, -60f), Space.World);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, 30f);
            yield return new WaitForSeconds(waitForSeconds);
            transform.Rotate(0f, 0f, 30f);
            //transform.Rotate(new Vector3(0f, 0f, 60f), Space.World);
        }
    }

    IEnumerator turnHexagonWithMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0));

        if (Input.GetMouseButtonDown(0) && mousePos.x > 0f)
        {
            transform.Rotate(0f, 0f, -30f);
            yield return new WaitForSeconds(waitForSeconds);
            transform.Rotate(0f, 0f, -30f);
        }
        else if (Input.GetMouseButtonDown(0) && mousePos.x < 0f)
        {
            transform.Rotate(0f, 0f, 30f);
            yield return new WaitForSeconds(waitForSeconds);
            transform.Rotate(0f, 0f, 30f);
        }
    }
}