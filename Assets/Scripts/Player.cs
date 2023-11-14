using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int armor;
    public GameUI gameUI;
    private GunEquipper gunEquipper;
    private Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }
    public void TakeDamage(int amount)
    {
        int healthDamage = amount;
        if (armor > 0)
        {
            int effectiveArmor = armor * 2;
            effectiveArmor -= healthDamage;
            // If there is still armor, don't need to process
            // health damage
            if (effectiveArmor > 0)
            {
                armor = effectiveArmor / 2;
                return;
            }
            armor = 0;
        }

        health -= healthDamage;
        Debug.Log("Health is " + health);
        if (health <= 0)
        {
            Debug.Log("GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 1
    private void pickupHealth()
    {
        health += 50;
        if (health > 200)
        {
            health = 200;
        }
        Debug.Log("Health is Picked");
    }
    private void pickupArmor()
    {
        armor += 15;
        Debug.Log("Armor is Picked");
    }

    // 2
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        Debug.Log("Assault Ammo is Picked");
    }
    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
        Debug.Log("Pistol Ammo is Picked");
    }
    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
        Debug.Log("Shotgun Ammo is Picked");
    }

    public void PickUpItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.PickUpPistolAmmo:
                pickupPistolAmmo();
                break;
            case Constants.PickUpAssaultRifleAmmo:
                pickupAssaultRifleAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                pickupShotgunAmmo();
                break;
            case Constants.PickUpHealth:
                pickupHealth();
                break;
            case Constants.PickUpArmor:
                pickupArmor();
                break;
            default:
                Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
}
