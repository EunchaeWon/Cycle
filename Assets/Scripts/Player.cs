using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
//Arduino
//using System.IO.Ports;
public class Player : MonoBehaviour
{
    //Arduino
   // SerialPort sp = new SerialPort("COM6", 9600);
    float a1L;
    float a2R;
    float a3U;
    float a4D;
    float a5J;
    float a6E;
    //
    public texture texture;
    public RidingAnim ridingAnim;
    public GameObject scanObject;
    Vector3 dirVec;
    float h;
    float v;
    float g;
    public float movementSpeed;
    public float rotationSpeed;
    public CharacterController charController;
    bool isRiding;
    public float jumpPower;
    VideoPlayer videoPlayer;
    public GPS gps;
    public Canvas canvas;
    public CanvasMenu canvasMenu;
    public Material[] skyMat;
    
    int b;
    void Awake()
    {
        //Arduino
       /* sp.Open();
        sp.ReadTimeout = 100;*/
        //
        
        charController = GetComponent<CharacterController>();
        
        isRiding = false;
    }

    /*  private void FixedUpdate()
      {
          Debug.DrawRay(transform.position, dirVec * 1, new Color(0, 1, 0));
          RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dirVec, 1, LayerMask.GetMask("nature"));
          if (rayHit.collider != null)
              scanObject = rayHit.collider.gameObject;
          else
              scanObject = null;
      }*/

    void Update()
    {
        //Arduino
        a1L = 0;
        a2R = 0;
        a3U = 0;
        a4D = 0;
        a5J = 0;
        a6E = 0;
        g = -jumpPower;
       /* if (sp.IsOpen)
        {
            try
            {
                // When left button is pushed
                if (sp.ReadByte() == 1)
                {
                    print(sp.ReadByte());
                    a1L = -1;
                    //charController.transform.Translate(Vector3.left * Time.deltaTime * 5);
                }
                // When right button is pushed
                if (sp.ReadByte() == 2)
                {
                    print(sp.ReadByte());
                    a2R = 1; 
                    //charController.transform.Translate(Vector3.right * Time.deltaTime * 5);
                }
                if (sp.ReadByte() == 3)
                {
                    print(sp.ReadByte());
                    a3U = 1; 
                    //charController.transform.Translate(Vector3.up * Time.deltaTime * 5);
                }
                if (sp.ReadByte() == 4)
                {
                    print(sp.ReadByte());
                    a4D = -1; 
                    //charController.transform.Translate(Vector3.down * Time.deltaTime * 5);
                }
                if (sp.ReadByte() == 5)
                {
                    print(sp.ReadByte());
                    a5J = 1;
                    //charController.transform.Translate(Vector3.down * Time.deltaTime * 5);
                }
                if (sp.ReadByte() == 6)
                {
                    print(sp.ReadByte());
                    a6E = 1;
                    //charController.transform.Translate(Vector3.down * Time.deltaTime * 5);
                }

            }
            catch (System.Exception)
            {

            }

        }
       
        */
        h = Input.GetAxisRaw("Horizontal") + a1L + a2R;
        v = -Input.GetAxisRaw("Vertical") - a3U - a4D;
        Vector3 Rotation = new Vector3(0, h, 0);
        Vector3 Movement = transform.forward * v;
        Vector3 Gravity = transform.up * g;
        if (Input.GetButtonDown("Jump") || a5J == 1)
        {
            g = jumpPower;
            Gravity = transform.up * g;

        }


        if (h + v != 0 && isRiding == false)
        {
            CancelInvoke();
            isRiding = true;
            ridingAnim.anim.SetBool("Move", true);
            
        }
        else if (h + v == 0 && isRiding == true)
        {
            Invoke("IsRiding",1);
            isRiding = false;
            
        }
            
      


        transform.Rotate(Rotation * Time.deltaTime * rotationSpeed);
        charController.Move(Movement * Time.deltaTime * movementSpeed);
        charController.Move(Gravity * Time.deltaTime);
        /*
        if (Input.GetButton("Vertical"))
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
        */
        if (Input.GetKeyDown(KeyCode.Escape) && canvas.enabled==false || a6E == 1 && canvas.enabled == false)
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && canvas.enabled == true || a6E == 1 && canvas.enabled == true)
        {
            Time.timeScale = 1;
            canvas.enabled = false;
        }
        if(canvas.enabled == true) 
        {
            Time.timeScale = 0;

            if(v != 0)
            {
                if (v > 0)
                    b = 1;
                else
                    b = -1;
                canvasMenu.ButtonMove(b);
            }
            if(Input.GetButtonDown("Jump")|| a5J ==1)
                canvasMenu.SpaceBar();
        }

    }
    private void FixedUpdate()
    {
        gps.gameObject.transform.position = new Vector3(transform.position.x, gps.gameObject.transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "video")
        {
            scanObject = other.gameObject;
            videoPlayer = scanObject.GetComponent<VideoPlayer>();
            videoPlayer.playOnAwake=true;
            videoPlayer.Play();
            videoPlayer.SetDirectAudioMute(0, false);
        
        }
        else if (other.gameObject.tag == "text")
        {
            scanObject = other.gameObject;
            MeshRenderer mesh = scanObject.GetComponent<MeshRenderer>();
            mesh.material = mesh.materials[1];
            Animator scanAnim = scanObject.GetComponent<Animator>();
            scanAnim.SetTrigger("TurnOn");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "video")
        {
            scanObject = other.gameObject;
            videoPlayer = scanObject.GetComponent<VideoPlayer>();
            videoPlayer.SetDirectAudioMute(0, true);

        }
        else if (other.gameObject.tag == "text")
        {
            scanObject = other.gameObject;
            MeshRenderer mesh = scanObject.GetComponent<MeshRenderer>();
            mesh.material = mesh.materials[0];
           
            
        }
    }
    void IsRiding()
    {
        
        ridingAnim.anim.SetBool("Move", false);
    }

}

