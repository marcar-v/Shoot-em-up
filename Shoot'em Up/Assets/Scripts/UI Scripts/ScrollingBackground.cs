using UnityEngine;


public class ScrollingBackground : MonoBehaviour
{

    [SerializeField] float scrollSpeed = 0.5f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y < -8.2f)
        {
            transform.position = startPosition;
        }
    }
}
