using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRay : MonoBehaviour
{

   private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * 10, Color.green);
    }
}
