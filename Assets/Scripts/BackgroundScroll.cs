using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public static float gameSpeed = 1f;
    public float baseScrollSpeed = 5f;
    private float speedIncreaseRate = 1f;
    public float speedIncreaseInterval = 5f;
    private float maxScrollSpeed = 80f;
    private float currentScrollSpeed;
    
    private GameObject bgCopy;
    private float totalHeight;
    private bool isInitialized = false;
    private float offset = 0.2f;
    private float timer = 0f;
    public static bool isGameStarted = false;

    void Start()
    {
        if (!isInitialized)
        {
            CalculateTotalHeight();
            CreateBackgroundCopy();
            currentScrollSpeed = baseScrollSpeed;
            gameSpeed = 1f;
        }
    }

    void CalculateTotalHeight()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        float minY = float.MaxValue;
        float maxY = float.MinValue;

        foreach (SpriteRenderer sprite in sprites)
        {
            float spriteTop = sprite.bounds.min.y;
            float spriteBottom = sprite.bounds.max.y;

            minY = Mathf.Min(minY, spriteTop);
            maxY = Mathf.Max(maxY, spriteBottom);
        }

        totalHeight = maxY - minY;
    }

    void CreateBackgroundCopy()
    {
        bgCopy = Instantiate(gameObject, transform.parent);
        bgCopy.GetComponent<BackgroundScroll>().isInitialized = true;
        
        bgCopy.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + totalHeight - offset,
            transform.position.z
        );

        bgCopy.GetComponent<BackgroundScroll>().enabled = false;
    }

    void Update()
    {
        if (!isGameStarted) 
            return;
        timer += Time.deltaTime;
        if (timer >= speedIncreaseInterval)
        {
            timer = 0f;
            currentScrollSpeed = Mathf.Min(currentScrollSpeed + speedIncreaseRate, maxScrollSpeed);
            gameSpeed = currentScrollSpeed / baseScrollSpeed;
        }

        transform.Translate(Vector2.down * (currentScrollSpeed * Time.deltaTime));
        if(bgCopy != null)
        {
            bgCopy.transform.Translate(Vector2.down * currentScrollSpeed * Time.deltaTime);
        }
        
        if (transform.position.y <= -totalHeight)
        {
            transform.position = new Vector3(
                transform.position.x,
                bgCopy.transform.position.y + totalHeight - offset,
                transform.position.z
            );
        }
        
        if (bgCopy != null && bgCopy.transform.position.y <= -totalHeight)
        {
            bgCopy.transform.position = new Vector3(
                bgCopy.transform.position.x,
                transform.position.y + totalHeight - offset,
                bgCopy.transform.position.z
            );
        }
    }
}