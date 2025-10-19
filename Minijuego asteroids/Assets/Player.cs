using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float thrustForce = 2f;
    public float rotationSpeed = 120f;

    public GameObject gun;

    float xMax = 10f, yMax = 9f;
    float xMin = -10f, yMin = -9f;

    public static int SCORE = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float thrust = Input.GetAxis("Thrust") * thrustForce;
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigidbody.AddForce(thrustForce * thrustDirection * thrust);
        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        Vector3 pos = transform.position;
        if (pos.x > xMax)
            pos.x = xMin;
        else if (pos.x < xMin)
            pos.x = xMax;
        if (pos.y > yMax)
            pos.y = yMin;
        else if (pos.y < yMin)
            pos.y = yMax;
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjectPool.Instance.RequestBullet(gun.transform.position, transform.right);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
