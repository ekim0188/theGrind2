using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSprites : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public Sprite sprite; 
    
    public void Swap()
    {
        
        for (int i = 0; i < gameObjects.Count; i++)
        {
            //bad code
            if(gameObjects[i].GetComponent<Draggable>() != null)
            {
                if(gameObjects[i].GetComponent<Draggable>().itemType == Draggable.ItemType.ShotGlass1)
                { 
                    if(GameManager.Instance.ShotGlass1OnMachine)
                    {
                        gameObjects[i].GetComponent<SpriteRenderer>().sprite = sprite;
                        gameObjects[i].GetComponent<ShotGlass>().IsEmpty = false;
                        gameObjects[i].GetComponent<ShotGlass>().ShotModifier = 
                            GameManager.Instance.SelectedShotModifier;
                        gameObjects[i].GetComponent<ShotGlass>().ShotType =
                            GameManager.Instance.SelectedShotType;
                    }
                }
                if(gameObjects[i].GetComponent<Draggable>().itemType == Draggable.ItemType.ShotGlass2)
                { 
                    if(GameManager.Instance.ShotGlass2OnMachine)
                    { 
                        gameObjects[i].GetComponent<SpriteRenderer>().sprite = sprite;
                        gameObjects[i].GetComponent<ShotGlass>().IsEmpty = false;
                        gameObjects[i].GetComponent<ShotGlass>().ShotModifier =
                            GameManager.Instance.SelectedShotModifier;
                        gameObjects[i].GetComponent<ShotGlass>().ShotType =
                            GameManager.Instance.SelectedShotType;
                    }
                }
            }
            else
            {
                gameObjects[i].GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
    }

    //I dont want to update the editor references so i just copy pasted
    public void Swap(bool isClear)
    {

        for(int i = 0; i < gameObjects.Count; i++)
        {
            //bad code
            if(gameObjects[i].GetComponent<Draggable>() != null)
            {
                if(gameObjects[i].GetComponent<Draggable>().itemType == Draggable.ItemType.ShotGlass1)
                {
                    if(GameManager.Instance.ShotGlass1OnMachine)
                    {
                        gameObjects[i].GetComponent<SpriteRenderer>().sprite = sprite;
                        if(isClear)
                        {
                            gameObjects[i].GetComponent<ShotGlass>().IsEmpty = true;
                        }
                        else
                        {
                            gameObjects[i].GetComponent<ShotGlass>().IsEmpty = false;
                        }
                            
                        gameObjects[i].GetComponent<ShotGlass>().ShotModifier =
                            GameManager.Instance.SelectedShotModifier;
                    }
                }
                if(gameObjects[i].GetComponent<Draggable>().itemType == Draggable.ItemType.ShotGlass2)
                {
                    if(GameManager.Instance.ShotGlass2OnMachine)
                    {
                        gameObjects[i].GetComponent<SpriteRenderer>().sprite = sprite;
                        if(isClear)
                        {
                            gameObjects[i].GetComponent<ShotGlass>().IsEmpty = true;
                        }
                        else
                        {
                            gameObjects[i].GetComponent<ShotGlass>().IsEmpty = false;
                        }

                        gameObjects[i].GetComponent<ShotGlass>().ShotModifier =
                            GameManager.Instance.SelectedShotModifier;
                    }
                }
            }
            else
            {
                gameObjects[i].GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
    }

}
