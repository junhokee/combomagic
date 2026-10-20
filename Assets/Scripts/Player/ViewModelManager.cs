using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class ViewModelManager : MonoBehaviour
{
    [SerializeField] private Transform modelHolder;

    private GameObject currentViewmodel;
    private Animator currentAnimator;
    public static ViewModelManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public void Equip(GameObject prefab)
    {
        SwapViewmodel(prefab);
        Debug.Log("did this work?");
    }

    public IEnumerator SwapViewmodel(GameObject newPrefab)
    {
        // lower

        yield return new WaitForSeconds(0.1f);
        if (currentViewmodel != null)
        {
            string cleanName = currentViewmodel.name.Replace("(Clone)", "").Trim();

            if(cleanName != newPrefab.name){
               Destroy(currentViewmodel);
                currentViewmodel = Instantiate(newPrefab, modelHolder);
                currentViewmodel.transform.localPosition = Vector3.zero;
                currentViewmodel.transform.localRotation = Quaternion.identity;
                currentAnimator =
                    currentViewmodel.GetComponent<Animator>();
                
                //raise

                yield return new WaitForSeconds(0.6f);
            }
            
            
        }
        else
        {
            currentViewmodel = Instantiate(newPrefab, modelHolder);
                currentViewmodel.transform.localPosition = Vector3.zero;
                currentViewmodel.transform.localRotation = Quaternion.identity;
                currentAnimator =
                    currentViewmodel.GetComponent<Animator>();
                
                //raise

                yield return new WaitForSeconds(0.6f);
        }
        
        
            
        
       
    }
}