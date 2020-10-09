using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float normalEdgeValue;
    public float extendEdgeValue;
    public float launchBallSpeed = 200;
    public Transform ballPivot;
    public Rigidbody2D ball;
    //
    //public Rigidbody2D ball2;
   // public Rigidbody2D ball3;
    //
    public Rigidbody2D bullet;
    public Transform leftMuzzle;
    public Transform rightMuzzle;
    public float bulletInitialForce = 10;
    public float bulletFireDelay = 0.1F;
    private float timer;
    private Transform trans;
    private Rigidbody2D rb;
    private bool carryingBall;
    private bool isEnlarged;
    private bool canShoot;
    //
    private bool MaisBola;
    //
    private bool shootFree;
    private AudioController audioController;
   // public GameObject MaisBola;
    public int numberOfBalls = 1;
    public GameObject Bola;



    public void Start()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        audioController = GameObject.FindWithTag("MainCamera").GetComponent<AudioController>();
        carryingBall = true;
        isEnlarged = false;
        canShoot = false;
        shootFree = false;
        MaisBola = false;
        timer = 0;
    }

    public void Update()
    {
        if (canShoot && !carryingBall)
        {
            timer += Time.deltaTime;
            if (timer > bulletFireDelay)
            {
                timer = 0;
                shootFree = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (carryingBall)
            {
                Vector2 force = Vector2.zero;
                int goLeft = UnityEngine.Random.Range(0, 11) > 5 ? -1 : 1;
                force.x = goLeft * launchBallSpeed;
                force.y = launchBallSpeed;
                ball.transform.parent = null;
                ball.AddForce(force);
                ball = null;
                carryingBall = false;
            }
            else if (shootFree)
            {
                shootFree = false;
                Rigidbody2D left = Instantiate(bullet, leftMuzzle.position, leftMuzzle.rotation) as Rigidbody2D;
                Rigidbody2D right = Instantiate(bullet, rightMuzzle.position, rightMuzzle.rotation) as Rigidbody2D;
                left.AddForce(Vector2.up * bulletInitialForce);
                right.AddForce(Vector2.up * bulletInitialForce);
                audioController.PlaySound(AudioType.SHOOT);
            }
        }

        float newPosX = speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        trans.Translate(newPosX, 0, 0);
        float edge = isEnlarged ? extendEdgeValue : normalEdgeValue;
        Vector3 pos = trans.position;
        if (pos.x > edge)
        {
            pos.x = edge;
            trans.position = pos;
        }
        else if (pos.x < -edge)
        {
            pos.x = -edge;
            trans.position = pos;
        }

        if (carryingBall)
        {
            ball.transform.position = ballPivot.position;
        }
        if (MaisBola)
        {
            numberOfBalls = 3;
        }
        if(numberOfBalls ==3)
        {
           Rigidbody2D ball2 = Instantiate(ball, ball.position, Quaternion.identity);
            //ball2.
        }
    }

    public void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Enlarge") && !isEnlarged)
        {
            Destroy(hit.gameObject);
            Vector3 scale = trans.localScale;
            scale.x = 1.5F;
            trans.localScale = scale;
            isEnlarged = true;
            audioController.PlaySound(AudioType.POWER_UP);
            canShoot = false;
            shootFree = false;
            MaisBola = false;
        }

        if (hit.gameObject.CompareTag("Shoot") && !canShoot)
        {
            Destroy(hit.gameObject);
            Vector3 scale = trans.localScale;
            scale.x = 1.0F;
            trans.localScale = scale;
            isEnlarged = false;
            audioController.PlaySound(AudioType.POWER_UP);
            canShoot = true;
            shootFree = true;
            MaisBola = false;
        }

        if (hit.gameObject.CompareTag("D1") && !MaisBola)
        {
            Destroy(hit.gameObject);
            Vector3 scale = trans.localScale;
            scale.x = 1.0F;
            trans.localScale = scale;
            isEnlarged = false;
            audioController.PlaySound(AudioType.POWER_UP);
            canShoot = false;
            MaisBola = true;
            shootFree = false;
           // numberOfBalls = 3;
        }

       
    }
}
