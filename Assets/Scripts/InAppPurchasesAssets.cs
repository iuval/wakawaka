using UnityEngine;
using System.Collections;
using Soomla.Store;

public class InAppAssets : IStoreAssets {
	public const string UNLOCK_ALL_LIFETIME_PRODUCT_ID = "unlock_all";
	public const string NO_ADS_LIFETIME_PRODUCT_ID = "no_ads";
	
	public int GetVersion() {
		return 0;
	}
	
	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCurrency[] GetCurrencies() {
		return new VirtualCurrency[]{};
	}
	
	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualGood[] GetGoods() {
		return new VirtualGood[] {UNLOCK_ALL_LTVG, NO_ADS_LTVG};
	}
	
	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCurrencyPack[] GetCurrencyPacks() {
		return new VirtualCurrencyPack[] {};
	}
	
	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCategory[] GetCategories() {
		return new VirtualCategory[]{};
	}
	
	public static VirtualGood UNLOCK_ALL_LTVG = new LifetimeVG(
		"All things!", 													// name
		"Unlock All!",				 									// description
		UNLOCK_ALL_LIFETIME_PRODUCT_ID,											// item id
		new PurchaseWithMarket(UNLOCK_ALL_LIFETIME_PRODUCT_ID, 0.99));
		
	public static VirtualGood NO_ADS_LTVG = new LifetimeVG(
		"No Ads", 														// name
		"No More Ads!",				 									// description
		NO_ADS_LIFETIME_PRODUCT_ID,										// item id
		new PurchaseWithMarket(NO_ADS_LIFETIME_PRODUCT_ID, 0.99));
}
