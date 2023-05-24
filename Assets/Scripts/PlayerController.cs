using UnityEngine;

public class PlayerController : MonoBehaviour , IColorChanger
{ 
    public event System.Action OnGameOver;
    public event System.Action<Transform> OnCollision;
    // public static GameOver gameOver;
    Rigidbody2D rb2D;  
    Vector2 direction;

    CalculateScreenSize calculateScreenSize;
    [SerializeField] float speed = 10;
    public bool isGameOver=false;  

    Color randomColor;  

    [SerializeField] GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        calculateScreenSize = FindObjectOfType<CalculateScreenSize>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb2D.transform.Translate(new Vector2(velocity,0));
        if(transform.position.x>=calculateScreenSize.ReturnCameraHalfWidth())transform.position = 
        new Vector2(-calculateScreenSize.ReturnCameraHalfWidth(),transform.position.y);
        else if(transform.position.x<=-calculateScreenSize.ReturnCameraHalfWidth())transform.position =
         new Vector2(calculateScreenSize.ReturnCameraHalfWidth(),transform.position.y);
    }

 
    

    void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.gameObject.CompareTag("uppercollider") || collision2D.gameObject.CompareTag("spike")){
            isGameOver = true;
            // Background.SetActive(true);
            // gameOver?.Invoke();
            OnGameOver?.Invoke();

            // if(gameOver!=null)gameOver.Invoke();
            Destroy(this.gameObject);
        }

        if(collision2D.gameObject.CompareTag("platform")){
            OnCollision?.Invoke(transform);
            float red = Random.Range(0f,1f);
            float green  =Random.Range(0f,1f);
            float blue = Random.Range(0f,1f);
            randomColor= new Color(red,green,0,1);
            ChangeColor(randomColor);
        }

    }

    public void ChangeColor(Color clr)
    {
        GetComponent<SpriteRenderer>().color = randomColor;
    }
}
