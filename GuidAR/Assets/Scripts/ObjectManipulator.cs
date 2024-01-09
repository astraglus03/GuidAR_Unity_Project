using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody), typeof(AudioSource))]

public class ObjectManipulator : MonoBehaviour
{
    [SerializeField]
    private Button startBtn;
    
    [SerializeField] private Material[] materials = new Material[2];
    private Renderer objectRenderer;


    [SerializeField]
    public SpawnObject spawnObjectScript;

    private string handTag = "Player";
    private bool isGrabbing;
    private float skeletonConfidence = 0.0001f;
    private AudioSource audioSource;
    [SerializeField] public Renderer basedrum;



    private List<AudioSource> assetAudioSources = new List<AudioSource>(); // 추가

    public AudioClip[] audioClips; // 여러 오디오 클립을 담을 배열
    //private AudioSource audioSource; // AudioSource 컴포넌트
    private int currentClipIndex = 0; // 현재 재생 중인 오디오 클립의 인덱스

    // Start is called before the first frame update
    void Start()
    {
        // objectRenderer 초기화
        objectRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // objectRenderer 초기화
        objectRenderer = GetComponent<Renderer>();

        ManomotionManager.Instance.ShouldCalculateGestures(true);


        var currentGesture = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger;


        if (currentGesture == ManoGestureTrigger.GRAB_GESTURE)
        {
            isGrabbing = true;
        }

        else if (currentGesture == ManoGestureTrigger.RELEASE_GESTURE)
        {
            isGrabbing = false;
            transform.parent = null;
        }

        //  > skeletonConfidence
        //bool hasConfidence = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.confidence > skeletonConfidence;

        /*
        if (!hasConfidence)
        {
            objectRenderer.material = materials[0];
        }
        */

    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(handTag))
        {

            /*
            // 저장된 모든 오디오 소스 재생
            foreach (var audioSource in assetAudioSources)
            {
                audioSource.Play();
            }
            */


            objectRenderer.material = materials[1];
            Handheld.Vibrate();
            audioSource.Play();
            //AudioOn();
        }
        else if (isGrabbing)
        {
            transform.parent = other.gameObject.transform;
        }
    }
    // Update is called once per frame
    
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag(handTag) && isGrabbing)
        {

            transform.parent = other.gameObject.transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        transform.parent = null;

        objectRenderer.material = materials[0];
    }

}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class ObjectManipulator : MonoBehaviour
{
    
    [SerializeField] private Material[] materials = new Material[2];
    private Renderer objectRenderer;
    private string handTag = "Player"; 
    private bool isGrabbing; 
    private float skeletonConfidence = 0.0001f; 
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start() 
    {
        // objectRenderer  ʱ ȭ
        objectRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() 
    {
        
        ManomotionManager.Instance.ShouldCalculateGestures(true);

        
        var currentGesture = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger;

        
        if (currentGesture == ManoGestureTrigger.GRAB_GESTURE)
        {
            isGrabbing = true;

        }
        
        else if (currentGesture == ManoGestureTrigger.RELEASE_GESTURE)
        {
            isGrabbing = false;
            transform.parent = null;
        }

        //  > skeletonConfidence
        bool hasConfidence = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.confidence > skeletonConfidence;

        
        if (!hasConfidence)
        {
            objectRenderer.material = materials[0]; 
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag(handTag))
        {

           
            objectRenderer.material = materials[1];
            Handheld.Vibrate(); 
            audioSource.Play();
        

        }
        

        // isGrabbing = True, 
        else if (isGrabbing)
        {
            transform.parent = other.gameObject.transform;
        }
    }

    
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag(handTag) && isGrabbing)
        {
            
            transform.parent = other.gameObject.transform;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        
        transform.parent = null;
        
        objectRenderer.material = materials[0];
    }

    // 종혜 추가
    public void AudioOn()
    {
        audioSource.Play();
    }
}
*/