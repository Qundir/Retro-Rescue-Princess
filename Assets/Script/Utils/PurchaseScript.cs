using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
[Serializable]
public class NonConsumableItem
{
    public string Name;
    public string ID;
    public string Desc;
    public float price;
}
public class PurchaseScript : MonoBehaviour, IStoreListener 
{
    IStoreController m_Storecontroller;
    public NonConsumableItem ncItem;
    public void Start()
    {
        Setupuilder();
    }
    public void NonConsumable_Btn_Pressed()
    {
        //RemoveAds();
        //m_Storecontroller.InitiatePurchase(ncItem.ID);
        
    }
    //procesing purchase
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;
        print("Purchase complete"+ product.definition.id);
        if(product.definition.id == ncItem.ID)
        {
            RemoveAds();
        }
        return PurchaseProcessingResult.Complete;
    }

    void Setupuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(ncItem.ID , ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        print("Success");
        m_Storecontroller = controller;
        CheckNonConsumable(ncItem.ID);
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        print("Initialized failed"+ error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        print("Initialized faied"+ error + message);
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        print("purchase failed");
    }
    void CheckNonConsumable(string id)
    {
        if(m_Storecontroller != null)
        {
            var product = m_Storecontroller.products.WithID(id);
            if(product !=null)
            {
                if(product.hasReceipt)
                {
                    RemoveAds();
                }
                else
                {
                    ShowAds();
                }
            }
        }
    }


    #region extra
    public void RemoveAds()
    {
        DisplayAds(false);
    }
    void ShowAds()
    {
        DisplayAds(true);
    }
    void DisplayAds(bool x )
    {
        if(!x)
        {
            GameManager.Instance.AdsRemoved = true;
        }else{
            GameManager.Instance.AdsRemoved = false;
        }
    }

    
    #endregion
}
