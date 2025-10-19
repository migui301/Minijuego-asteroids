using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PausarScript : MonoBehaviour
{

    public GameObject menuPausa;
    public bool pausado = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Renaudar();
            }
            else {
                Pausar();
            }
        }
    }

    public void Renaudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        pausado = false;
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        pausado = true;
    }
}
