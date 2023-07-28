using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarHaraket : MonoBehaviour
{
    bool gfinish = false;
    public int puan = 0;
    // Start is called before the first frame update
    void Start()
    {
        puan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gfinish==false)
            GetComponent<Rigidbody>().AddForce(Vector3.left * 100, ForceMode.Force);
        else if (gfinish == true)
            GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 70, ForceMode.Force);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -70, ForceMode.Force);
        }
        if(GetComponent<Rigidbody>().position.x <=-90)
        {
            gfinish = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("wait", 3f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Engel")
        {
            Invoke("wait", 3f);
            gfinish = true;
        }
        if (collision.collider.tag=="Kuree")
        {
            puan++;
            Destroy(collision.gameObject);
        }
    }
    private void wait()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gfinish = false;
    }
}
