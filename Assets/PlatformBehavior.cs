using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] float velocity = 2f;
                        

    // Rigidbody2D rigidbody2D;

    // Update is called once per frame
   [SerializeField]  private void FixedUpdate()
    {
        // rigidbody2D = GetComponent<Rigidbody2D>();
        transform.Translate(Vector2.up * velocity * Time.deltaTime);
        // Destroy(this.gameObject,destroyTime);  
        if(transform.position.y>=FindObjectOfType<CalculateScreenSize>().ReturnCameraHalfHeight())Destroy(this.gameObject); 
        
    }
    

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "uppercollider")
    //     {
    //         Debug.Log("collision");
    //     }
    //     // Debug.Log(".....");
    // }
    


}
