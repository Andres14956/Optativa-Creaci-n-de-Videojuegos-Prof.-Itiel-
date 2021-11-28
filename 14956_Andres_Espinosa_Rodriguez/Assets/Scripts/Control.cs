using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Control : MonoBehaviour
{
    public int velocidad = 0;
    public float giro = 0;
    public float Horizontal = 0;
    public float vertical = 0;
    public float limite_z = 0;
    public float limite_x = 0;
    

    public Rigidbody rb;
    public float jumpv = 0.4f;
    public float altura_salto = 0;

    bool m_isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && m_isGrounded == true){
            Jump();
        }

        Horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad * vertical);
        transform.Translate(Vector3.right * Time.deltaTime * giro * Horizontal);
        Debug.Log(transform.position);

        if(transform.position.x > limite_x || transform.position.x < -limite_x){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Game Over");
        }

        if(transform.position.z > limite_z || transform.position.z < -limite_z){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Game Over");
        }

        if(transform.position.x < -limite_x){
            transform.position = new Vector3(limite_x, transform.position.y, transform.position.z);
        }
                if(transform.position.x > limite_x){
            transform.position = new Vector3(-limite_x, transform.position.y, transform.position.z);
        }        
        if(transform.position.z < -limite_z){
            transform.position = new Vector3(transform.position.x, transform.position.y, limite_z);
        }
                if(transform.position.z > limite_z){
            transform.position = new Vector3(transform.position.x, transform.position.y, -limite_z);
        }

    }

            void Jump(){
            rb.AddForce(0,altura_salto,0, ForceMode.Impulse);
        }

        void OnCollisionEnter(Collision other){
            if(other.gameObject.CompareTag("Ground"))
            {
                m_isGrounded = true;
            }
        }
}
