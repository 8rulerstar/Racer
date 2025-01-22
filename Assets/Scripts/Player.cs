using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float PlayerGas = 100f;
    private float gasDecreaseTime = 1f;
    private float screenCenterX = 0f;
    private bool isGameStarted = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        ResetPlayer();
    }

    void Update()
    {
        if (!BackgroundScroll.isGameStarted) return;  

        if (!isGameStarted)
        {
            isGameStarted = true;
            StartCoroutine(DecreaseGas());  
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < screenCenterX)
            {
                if (transform.position.x > -1.99f)
                {
                    transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                }
            }
            else if (mousePos.x > screenCenterX)
            {
                if (transform.position.x < 2.01f)
                {
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                }
            }
        }
    }

    IEnumerator DecreaseGas()
    {
        while (PlayerGas > 0)
        {
            yield return new WaitForSeconds(gasDecreaseTime);
            PlayerGas -= 10f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            Destroy(other.gameObject);
            PlayerGas += 30f;
        }
    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        PlayerGas = 100f;
        isGameStarted = false;
        StopAllCoroutines();
    }
}