using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class YarnCollision : MonoBehaviour
{
    public const string YARN_TAG = "Yarn";
    public const string CAT_TAG = "Cat";
    private bool hasCollidedBefore = false;
    public string YarnCollisionSound = "Play_Yarn_Hit";
    //public string CatYarnCollisionSound = "Play_Cat_Purr";
    public string YarnMergeCollisionSound = "Play_Yarn_Merge";
    public string MaxSizeGlowSound = "Play_MaxSizeGlow";
    public string fanEvent = "Play_Fan";
    public string stopFanEvent = "Stop_Fan";
    bool isFanOn = false;


    /// <summary>
    /// When yarn first collides with another object
    /// </summary>
    /// <param name="other">The other object</param>
    private void OnCollisionEnter(Collision other)
    {
        bool isYarn = other.gameObject.CompareTag(YARN_TAG);
        // TODO: Same color yarn collision
        bool isOtherSameColor = false;
        // TODO: Find cat component/tag
        bool isCat = other.gameObject.CompareTag(CAT_TAG);
        /*bool isCat = false;*/
        PostYarnCollisionEvent();
        // If yarn collides with another yarn
        if (isYarn)
        {
            if (isOtherSameColor)
            {
                // TODO: Yarn combining SFX
                PostYarnMergeCollisionEvent();

            }
            else
            {
                // TODO: Yarn-yarn collision SFX
            }
        }
        // If collided with cat
        else if (isCat)
        {
            // TODO: Yarn-cat collision SFX
            //PostCatYarnCollisionEvent(); //Now handled on Cat prefab > CatSound
        }
        // If first collision
        else if (!hasCollidedBefore)
        {
            hasCollidedBefore = true;
          
        }
        // otherwise
        else
        {
            
        }
    }

    public void OnMaxSize()
    {
        //TODO - Add max size sound
        AkSoundEngine.PostEvent(MaxSizeGlowSound, gameObject);

    }

    public void PostYarnCollisionEvent()
    {
        // Check if the event name is valid
        if (!string.IsNullOrEmpty(YarnCollisionSound))
        {
            // Post the Wwise yarn collision event by name
            AkSoundEngine.PostEvent(YarnCollisionSound, gameObject);
        }
        else
        {
            Debug.LogError("Yarn Collision Sound event name is not specified!");
        }
    }
/*    public void PostCatYarnCollisionEvent()
    {
        // Check if the event name is valid
        if (!string.IsNullOrEmpty(CatYarnCollisionSound))
        {
            // Post the Wwise yarn collision event by name
            AkSoundEngine.PostEvent(CatYarnCollisionSound, gameObject);
        }
        else
        {
            Debug.LogError("Cat-Yarn Collision Sound event name is not specified!");
        }
    }*/
    public void PostYarnMergeCollisionEvent()
    {
        // Check if the event name is valid
        if (!string.IsNullOrEmpty(YarnMergeCollisionSound))
        {
            // Post the Wwise yarn collision event by name
            AkSoundEngine.PostEvent(YarnMergeCollisionSound, gameObject);
        }
        else
        {
            Debug.LogError("Cat-Yarn Collision Sound event name is not specified!");
        }
    }
    public void PayFan()
    {
        if (!isFanOn) {
            AkSoundEngine.PostEvent(fanEvent, gameObject);
            isFanOn = true;
        }
        
        
    }



    public void StopFan()
    {
        if (isFanOn)
        {
            AkSoundEngine.PostEvent(stopFanEvent, gameObject);
            isFanOn = false;
        }
       

    }
}
