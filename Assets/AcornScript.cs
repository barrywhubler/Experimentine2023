using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornScript : MonoBehaviour
{
    [SerializeField] ParticleSystem acornParticleSystem;
    public bool isEated = false;
    float shrinkScale = 1.0f;
    public float scaleShrinker = 0.01f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EatAcorn()
    {
        ParticleSystem acornParticleSystemInstance = Instantiate(acornParticleSystem, transform.position, transform.rotation);
        acornParticleSystemInstance.Play();
        isEated = true;
        GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 250);

        if (isEated)
        {
            shrinkScale -= scaleShrinker;
            if (shrinkScale <= 0)
            {
                Destroy(gameObject);
            }
            transform.localScale = new Vector3(shrinkScale, shrinkScale, shrinkScale);
        }
    }
}
