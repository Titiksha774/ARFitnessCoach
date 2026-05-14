using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TrainerSpawner : MonoBehaviour
{
    public GameObject trainerPrefab;

    private ARRaycastManager raycastManager;
    private GameObject spawnedTrainer;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            TryPlaceObject(Input.mousePosition);
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TryPlaceObject(Input.GetTouch(0).position);
        }
#endif
    }

    void TryPlaceObject(Vector2 screenPosition)
    {
        // 🔥 Prevent spawning more than one trainer
        if (spawnedTrainer != null)
            return;

        if (raycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            spawnedTrainer = Instantiate(
                trainerPrefab,
                pose.position,
                Quaternion.Euler(0f, pose.rotation.eulerAngles.y, 0f)
            );

            Debug.Log("Trainer Spawned!");
        }
    }

    
    public void DeleteTrainer()
    {
        if (spawnedTrainer != null)
        {
            Destroy(spawnedTrainer);
            spawnedTrainer = null;
            Debug.Log("Trainer Deleted!");
        }
    }

    public void PlayJumpingJacks()
    {
        if (spawnedTrainer != null)
            spawnedTrainer.GetComponent<TrainerController>()?.PlayJumpingJacks();
    }

    public void PlaySquat()
    {
        if (spawnedTrainer != null)
            spawnedTrainer.GetComponent<TrainerController>()?.PlaySquat();
    }

    public void PlayPushUp()
    {
        if (spawnedTrainer != null)
            spawnedTrainer.GetComponent<TrainerController>()?.PlayPushUp();
    }

    public void PlaySitUp()
    {
        if (spawnedTrainer != null)
            spawnedTrainer.GetComponent<TrainerController>()?.PlaySitUp();
    }
}