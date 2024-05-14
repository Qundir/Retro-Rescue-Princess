using System.Collections;
using UnityEngine;
using UnityEngine.Purchasing;
using System;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Core.Environments;
using UnityEngine.UI;


[Serializable]
public class NonConsumableItem
{
    public string Name;
    public string Id;
    public string desc;
    public float price;
}

public class ShopScript : MonoBehaviour, IStoreListener
{
    private IStoreController m_StoreController;
    public NonConsumableItem ncItem;
    public Text messageText;
    private static bool unityServicesInitialized  = false;

    [Obsolete]
    private async void Start()
    {
        if (!unityServicesInitialized)
        {
            await InitializeUnityServices();
        }
        else
        {
            SetupIAP();
        }
    }

    [Obsolete]
    private async System.Threading.Tasks.Task InitializeUnityServices()
    {
        try
        {
            var options = new InitializationOptions().SetEnvironmentName("production");
            await UnityServices.InitializeAsync(options);

            // Sign in anonymously if not already signed in
            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }

            Debug.Log("Unity Services and Authentication initialized successfully.");
            unityServicesInitialized = true;
            SetupIAP();
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to initialize Unity Services: " + e.Message);
        }
    }

    [Obsolete]
    void SetupIAP()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(ncItem.Id, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }

    public void NonConsumable_Btn_Pressed()
    {
        if (m_StoreController == null)
        {
            Debug.LogError("Store controller is not initialized.");
            return;
        }
        bool AdsRemovedButtonPressed = GameManager.Instance.adsRemoved;
        if(!AdsRemovedButtonPressed){
            m_StoreController.InitiatePurchase(ncItem.Id);
        }else{
            StartCoroutine(ShowMessage("Item Already purchased!", 2f));
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("IAP initialized successfully.");
        m_StoreController = controller;
        CheckNonConsumable(ncItem.Id);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("IAP initialization failed: " + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError("Purchase failed: " + failureReason);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;
        Debug.Log("Purchase complete: " + product.definition.id);
        if(product.definition.id == ncItem.Id)
        {
            // Satın alma işlemi gerçekleştiğinde reklamları kaldır
            GameManager.Instance.RemoveAds();
            PlayerPrefs.SetInt("AdsRemoved", 1); // Satın alım bilgisi kaydediliyor
            PlayerPrefs.Save();
        }
        return PurchaseProcessingResult.Complete;
    }   


    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new NotImplementedException();
    }
    void CheckNonConsumable(string id){
        if(m_StoreController!=null)
        {
            var product = m_StoreController.products.WithID(id);
            if(product!=null)
            {
                GameManager.Instance.adsRemoved = true;
            }else{
                GameManager.Instance.adsRemoved = false;
            }
        }
    }
    private IEnumerator ShowMessage(String message, float delay)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        messageText.gameObject.SetActive(false);
    }
}
