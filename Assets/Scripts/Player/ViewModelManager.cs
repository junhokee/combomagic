using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class ViewModelManager : MonoBehaviour
{
    [SerializeField] private Transform modelHolder;
    [SerializeField] private Animator viewmodelAnimator;

    private GameObject currentViewmodel;
    private Animator currentAnimator;
    public static ViewModelManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public void Equip(GameObject prefab)
    {
        
    }

    public IEnumerator SwapViewmodel(GameObject newPrefab)
    {
        viewmodelAnimator.SetTrigger("Lower");

        yield return new WaitForSeconds(0.1f);

        if (currentViewmodel != null)
            Destroy(currentViewmodel);

        currentViewmodel = Instantiate(newPrefab, modelHolder);

        currentViewmodel.transform.localPosition = Vector3.zero;
        currentViewmodel.transform.localRotation = Quaternion.identity;
        currentAnimator =
            currentViewmodel.GetComponent<Animator>();
        currentAnimator.SetTrigger("Enter");
        viewmodelAnimator.SetTrigger("Raise");

        yield return new WaitForSeconds(0.1f);
    }
}