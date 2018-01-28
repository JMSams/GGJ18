using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace FallingSloth.GGJ18
{
    public class WeaponController : MonoBehaviour
    {
        public List<WeaponType> weaponTypes;

        int currentWeaponIndex = 0;
        WeaponType currentWeapon { get { return weaponTypes[currentWeaponIndex]; } }

        float timeOfLastShot = 0f;
        float reloadStartTime = 0f;

        bool isReloading = false;

        Camera cam;

        void Start()
        {
            cam = Camera.main;

            foreach (WeaponType weapon in weaponTypes)
            {
                weapon.currentRounds = weapon.roundsPerClip;
            }
        }

        void Update()
        {
            if (isReloading && Time.time - reloadStartTime >= currentWeapon.reloadTime)
            {
                currentWeapon.currentRounds = currentWeapon.roundsPerClip;
                isReloading = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - timeOfLastShot >= currentWeapon.timeBetweenRounds
                    && currentWeapon.currentRounds > 0
                    && !isReloading)
                {
                    Fire(Input.mousePosition);
                }
            }
        }

        void Fire(Vector2 mousePosition)
        {
            timeOfLastShot = Time.time;

            currentWeapon.currentRounds--;

            if (currentWeapon.currentRounds <= 0)
            {
                isReloading = true;
                reloadStartTime = Time.time;
            }

            Vector3 hitPos = cam.ScreenToWorldPoint(mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(hitPos, Vector3.forward, out hit, 200f))
            {
                if (hit.collider.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<Enemy>().Hit(currentWeapon.damagePerRound);
                }
            }
        }
    }
}