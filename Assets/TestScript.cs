using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestScript : MonoBehaviour, BallScript
{
    [SerializeField] private GameObject _ball;

    private bool _isBallActive = false;

    public void GetSize(Vector2 size)
    {
        _ball.transform.localScale = size;
    }



    void Awake(){
        // _ball.SetActive(_isBallActive);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            // _isBallActive = !_isBallActive;
            // _ball.SetActive(_isBallActive);
            _ball.transform.localScale = Vector2.one;
            float randomSize = Random.Range(1,21);
            GetSize(Vector2.one * randomSize);
        }
    }
}
