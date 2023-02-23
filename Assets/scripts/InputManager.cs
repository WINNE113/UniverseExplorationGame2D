using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class InputManager : MonoBehaviour
    {
    private static InputManager instance;

    public static InputManager Instance { get { return instance; } }        
    
    [SerializeField] public Vector3 mouseWorldPos;

    [SerializeField] public float onFiring;
        private void Awake()
        {
        if (instance != null)
        {
            Debug.LogError("Onlu 1 InputManager allow to exit");
        }
            InputManager.instance = this;
        }

    private void Update()
    {
        GetMouseDown();
    }

    void FixedUpdate()
        {
            this.GetMousePos();
        }

        protected virtual void GetMousePos()
        {
            mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        protected virtual void GetMouseDown()
        {
        this.onFiring = Input.GetAxis("Fire1");
        }
    

 
    }
    
