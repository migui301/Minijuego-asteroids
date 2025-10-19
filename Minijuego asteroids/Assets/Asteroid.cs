using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 7f;
    public bool divisible = true;
    public GameObject miniAsteroidePrefab;
    private Rigidbody rb;
    private bool iniciado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!iniciado)
        {
            rb.linearVelocity = Vector3.down * speed;
        }
    }

    public void Split(Vector3 dir)
    {
        if (divisible)
        {
            float angulo = 30f;
            dir.z = 0f;
            Vector3 izq = (Quaternion.Euler(0, 0, angulo) * dir);
            Vector3 der = (Quaternion.Euler(0, 0, -angulo) * dir);

            CrearMini(izq);
            CrearMini(der);
        }
        Destroy(gameObject);
    }

    void CrearMini(Vector3 dir)
    {
        GameObject mini = Instantiate(miniAsteroidePrefab, transform.position, Quaternion.identity);
        Rigidbody rbMini = mini.GetComponent<Rigidbody>();
        rbMini.linearVelocity = dir * speed;
        Asteroid script = mini.GetComponent<Asteroid>();
        script.divisible = false;
        script.iniciado = true;
        mini.transform.localScale = transform.localScale * 0.3f;
        Destroy(mini, 2f);

    }   
}
