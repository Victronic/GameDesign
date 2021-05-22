using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int selectWeeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectWeeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectWeeapon >= transform.childCount - 1)
                selectWeeapon = 0;
            else
            selectWeeapon++;

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectWeeapon <= 0)
                selectWeeapon = transform.childCount-1;
            else
                selectWeeapon--;

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectWeeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            selectWeeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectWeeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectWeeapon = 3;
        }

        if (previousSelectedWeapon != selectWeeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i== selectWeeapon)
            {
                weapon.gameObject.SetActive(true);

            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
