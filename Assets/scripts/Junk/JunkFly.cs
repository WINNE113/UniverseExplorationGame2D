using UnityEngine;

public class JunkFly : ParentFly
{
    protected override void LoadValue()
    {
        base.LoadValue();  
        moveSpeed = 1f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
       
        this.GetFlyDirection();
    }

    /**
     * get new direction = main camera - object
     * */
    private void GetFlyDirection()
    {

        if (GameCtrl.Instance != null && GameCtrl.Instance.MainCamera != null && transform.parent != null)
        {
            Vector3 camposition = GameCtrl.Instance.MainCamera.transform.position;

            Vector3 objposition = transform.parent.position;


            Vector3 direction = camposition - objposition;
            direction.Normalize();

            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

            Debug.DrawLine(objposition, objposition + direction * 7, Color.red, Mathf.Infinity);
        }
        else
        {
            Debug.Log(transform.name + "Null Reference ex");
        }
        
    }
}
