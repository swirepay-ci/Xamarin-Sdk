package crc646edd20d9f36b6c3a;


public class InvoicePaymentActivity
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
		mono.android.Runtime.register ("swirepaysdk.Droid.Views.InvoicePaymentActivity, swirepaysdk.Android", InvoicePaymentActivity.class, __md_methods);
	}


	public InvoicePaymentActivity ()
	{
		super ();
		if (getClass () == InvoicePaymentActivity.class)
			mono.android.TypeManager.Activate ("swirepaysdk.Droid.Views.InvoicePaymentActivity, swirepaysdk.Android", "", this, new java.lang.Object[] {  });
	}


	public InvoicePaymentActivity (int p0)
	{
		super (p0);
		if (getClass () == InvoicePaymentActivity.class)
			mono.android.TypeManager.Activate ("swirepaysdk.Droid.Views.InvoicePaymentActivity, swirepaysdk.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
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
