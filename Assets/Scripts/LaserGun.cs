using UnityEngine;
public class LaserGun : Gun
{
    override protected void Update()
    {
        base.Update();
        // Laser Fire
        if (Input.GetMouseButton(0) && Time.time - lastFireTime > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}