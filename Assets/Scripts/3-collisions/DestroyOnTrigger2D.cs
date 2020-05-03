using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] int numOfLife;
    private List<GameObject> goList;
    private void Start()
    {
        numOfLife = 3;
        goList = new List<GameObject>();
        goList.Add(GameObject.Find("heart1"));
        goList.Add(GameObject.Find("heart2"));
        goList.Add(GameObject.Find("heart3"));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            if (other.tag == "Enemy")
            {
                if (goList.Count == 0)
                {
                    Restart();
                }
                else
                {
                    Destroy(goList[goList.Count - 1].gameObject);
                    goList.RemoveAt(goList.Count - 1);
                }
            }
            else
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }

        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
