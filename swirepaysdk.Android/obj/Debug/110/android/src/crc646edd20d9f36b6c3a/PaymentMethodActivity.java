package crc646edd20d9f36b6c3a;


public class PaymentMethodActivity
	extends crc644fd200ef23cefd5e.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("swirepaysdk.Droid.Views.PaymentMethodActivity, swirepaysdk.Android", PaymentMethodActivity.class, __md_methods);
	}


	public PaymentMethodActivity ()
	{
		super ();
		if (getClass () == PaymentMethodActivity.class)
			mono.android.TypeManager.Activate ("swirepaysdk.Droid.Views.PaymentMethodActivity, swirepaysdk.Android", "", this, new java.lang.Object[] {  });
	}


	public PaymentMethodActivity (int p0)
	{
		super (p0);
		if (getClass () == PaymentMethodActivity.class)
			mono.android.TypeManager.Activate ("swirepaysdk.Droid.Views.PaymentMethodActivity, swirepaysdk.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
