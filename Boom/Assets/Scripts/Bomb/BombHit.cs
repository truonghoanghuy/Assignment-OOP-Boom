﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHit : MonoBehaviour {
    //Những cái để dạng comment để dành khi làm màn hình kết thúc nha Ánh
 //  private GameObject GameController;
  //  public GameObject death;
 //   public GameObject boxbum;
    public GameObject explosionPrefab;
    const float TIME_TO_WAIT = 3f;
    float timeWaitPassed = 0;
    bool bWaiting = false;
    public int rangeofBoom = 2;
	// Use this for initialization
	void Start () {
        bWaiting = true;
        timeWaitPassed = 0;
  //      GameController = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
    void Update()
    {
      if (bWaiting)   //update wait time
        {
            timeWaitPassed += Time.deltaTime;   //increase time
            Destroy(gameObject, 3f);
            if (timeWaitPassed>TIME_TO_WAIT)
            {
                bWaiting = false;
                timeWaitPassed = 0;
                GameObject obj = Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
                Destroy(obj, 0.5f);
                Vector3 boomPosition = transform.position;
                for (int i = 1; i <= rangeofBoom; ++i)
                {
                    RaycastHit2D hitup = Physics2D.Raycast(boomPosition, Vector2.up, i, 1);
                    RaycastHit2D hitdown = Physics2D.Raycast(boomPosition, Vector2.down, i , 1);
                    RaycastHit2D hitright = Physics2D.Raycast(boomPosition, Vector2.right, i, 1);
                    RaycastHit2D hitleft = Physics2D.Raycast(boomPosition, Vector2.left, i, 1);
                    //Bomb bắt đầu nổ
                    if (hitdown.collider == null)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x, boomPosition.y - i), Quaternion.identity) as GameObject;
                        Destroy(obj1, 0.5f);
                    }
                    if (hitup.collider == null)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x, boomPosition.y + i), Quaternion.identity) as GameObject;
                        Destroy(obj1, 0.5f);

                    }
                    if (hitright.collider == null)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x + i, boomPosition.y), Quaternion.identity) as GameObject;
                        Destroy(obj1, 0.5f);
                    }
                    if (hitleft.collider == null)
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(boomPosition.x - i, boomPosition.y), Quaternion.identity) as GameObject;
                        Destroy(obj1, 0.5f);
                    }
                    // if (hitdown.transform.tag == "Player") Destroy(hitdown.transform);
                    if (hitdown.collider != null && hitdown.collider.tag == "Rao")
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y - i), Quaternion.identity) as GameObject;

                        //      GameObject obj = Instantiate(boxbum, hitdown.transform.position, Quaternion.identity) as GameObject;
                        Destroy(hitdown.collider);
                        Destroy(obj1, 0.5f);
                        //     Destroy(obj, 1f);

                    }
                    if (hitup.collider != null && hitup.collider.tag == "Rao")
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y + i), Quaternion.identity) as GameObject;

                        //     GameObject obj = Instantiate(boxbum, hitup.transform.position, Quaternion.identity) as GameObject;
                        Destroy(hitup.collider);
                        Destroy(obj1, 0.5f);
                        //    Destroy(obj, 1f);

                    }
                    if (hitleft.collider != null && hitleft.collider.tag == "Rao")
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(transform.position.x - i, transform.position.y), Quaternion.identity) as GameObject;
                        //    GameObject obj = Instantiate(boxbum, hitleft.transform.position, Quaternion.identity) as GameObject;
                        Destroy(hitleft.collider);
                        Destroy(obj1, 0.5f);
                        //  Destroy(obj, 1f);

                    }
                    if (hitright.collider != null && hitright.collider.tag == "Rao")
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(transform.position.x + i, transform.position.y), Quaternion.identity) as GameObject;

                        //    GameObject obj = Instantiate(boxbum, hitright.transform.position, Quaternion.identity) as GameObject;
                        Destroy(hitright.collider);
                        Destroy(obj1, 0.5f);
                        //  Destroy(obj, 1f);
                    }
                    if (hitdown.transform != null && (hitdown.transform.tag == "Player" || hitdown.transform.tag == "zombie" || hitdown.transform.tag == "Gift"))
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y - i), Quaternion.identity) as GameObject;
                        Destroy(obj1, 0.5f);
                        //    Destroy(hitdown.collider);
                    }
                    if (hitup.transform != null && (hitup.transform.tag == "Player" || hitup.transform.tag == "zombie" || hitup.transform.tag == "Gift"))
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y + i), Quaternion.identity) as GameObject;
                        Destroy(obj1, 0.5f);
                        //     Destroy(hitup.collider);

                    }
                    if (hitright.transform != null && (hitright.transform.tag == "Player" || hitright.transform.tag == "zombie" || hitright.transform.tag == "Gift"))
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(transform.position.x + i, transform.position.y), Quaternion.identity) as GameObject;
                        Destroy(obj1, 0.5f);
                        //   Destroy(hitright.collider);

                    }
                    if (hitleft.transform!=null && (hitleft.transform.tag == "Player" || hitleft.transform.tag == "zombie" || hitleft.transform.tag == "Gift"))
                    {
                        GameObject obj1 = Instantiate(explosionPrefab, new Vector2(transform.position.x - i, transform.position.y), Quaternion.identity) as GameObject;
                        Destroy(obj1, 0.5f);
                        // Destroy(hitleft.collider);

                    }
                }
                //Start Doing something he
            }
        }
           
      
    }
    

   
       
}
