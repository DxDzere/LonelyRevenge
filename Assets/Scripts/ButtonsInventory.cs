using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsInventory : MonoBehaviour
{
    private Animator buttonAnim;

    private Button button;

	void Start ()
    {
        buttonAnim = GetComponent<Animator>();
        button = GameObject.Find("Code").GetComponent<Button>();
	}
	
	void Update () {
        if (button.showMenu)
            buttonAnim.SetBool("b_showMenu", true);
        else if (!button.showMenu)
            buttonAnim.SetBool("b_showMenu", false);

    }
}
