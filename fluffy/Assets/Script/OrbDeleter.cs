using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDeleter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Obstacle �^�O���t�����I�u�W�F�N�g����ʊO�ɏo����폜����
        if (collision.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }
}
