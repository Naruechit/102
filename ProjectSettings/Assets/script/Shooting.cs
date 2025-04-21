using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shell;
    public Transform barrel;

    private float _canShoot;
    public float coolDown = 1.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _canShoot)
        {
            _canShoot = Time.time + coolDown;
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(shell, barrel.position, barrel.rotation);
        print("Fire!");
    }
}
