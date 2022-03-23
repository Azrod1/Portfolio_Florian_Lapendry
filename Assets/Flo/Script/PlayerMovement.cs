using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool alterChange = false;
    public float moveSpeed;
    public Rigidbody rb;
    public GameObject character;
    public GameObject[] listAtler;
    public Animator[] listAnimator;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    private int alterActif = 0;

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance'PlayerMovement' dans la Scene");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        listAnimator[alterActif].SetBool("lydiaWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        //dir.rotation = Quaternion.Euler();

        //Deplacement du joueur

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;  // Déplacé le joueur lorsque l'Input Horizontal et détecté
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;     // Déplacé le joueur lorsque l'Input Vertical et détecté

        //Pour le changement d'alter
        if (Input.GetKeyDown("a"))
        {
            ChangeAlter();
        }   
        
    }

    private void FixedUpdate()
    {
        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocityX = new Vector3(_horizontalMovement, rb.velocity.y, rb.velocity.z);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocityX, ref velocity, .05f);

        Vector3 targetVelocityZ = new Vector3(rb.velocity.x, rb.velocity.y, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocityZ, ref velocity, .05f);

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            Vector3 turn = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            character.transform.forward = turn;

            listAnimator[alterActif].SetBool("lydiaWalking", true);
        }
        else
        {
            listAnimator[alterActif].SetBool("lydiaWalking", false);
        }
    }

    void ChangeAlter()
    {
        if (!alterChange)
        {
            alterChange = true;
            alterActif = 1;
            listAtler[0].gameObject.SetActive(false);
            listAtler[1].gameObject.SetActive(true);
            //rend.sharedMaterial = materialAtler[1];
        }
        else if (alterChange)
        {
            alterChange = false;
            alterActif = 0;
            listAtler[0].gameObject.SetActive(true);
            listAtler[1].gameObject.SetActive(false);
            //rend.sharedMaterial = materialAtler[0];
        }
    }
}