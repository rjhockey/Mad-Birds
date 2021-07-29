using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition; // underscore makes this a private variable only accessible in Bird class
    [SerializeField] private float _launchPower = 500;

    private void Awake()
    {
        // saves bird's starting position at game startup
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 10 ||
            transform.position.x < -10)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        // transform.position being the position of our mouse/finger
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
