using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Purchasing;
using System;
using Unity.Services.Core;
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
    IStoreController m_StoreController;
    public NonConsumableItem ncItem;
    bool isInitialized = false;

    private void Start()
    {
    SetupBuilder();
    }

    [Obsolete]
    void SetupBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(ncItem.Id, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void NonConsumable_Btn_Pressed()
    {
        m_StoreController.InitiatePurchase(ncItem.Id);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        print("Succes");
        m_StoreController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        print("Inıtialize failed" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        print("Inıtialize failed" + error+ message);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        print("Purchase failed");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;
        print("Purchase complete " + product.definition.id);
        if(product.definition.id == ncItem.Id)
        {
            //todo remove ads
        }
        return PurchaseProcessingResult.Complete;
    }
}

