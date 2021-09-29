package crc644fd200ef23cefd5e;


public abstract class BaseActivity_1
	extends crc643f46942d9dd1fff9.FormsAppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("swirepaysdk.Droid.BaseActivity`1, swirepaysdk.Android", BaseActivity_1.class, __md_methods);
	}


	public BaseActivity_1 ()
	{
		super ();
		if (getClass () == BaseActivity_1.class)
			mono.android.TypeManager.Activate ("swirepaysdk.Droid.BaseActivity`1, swirepaysdk.Android", "", this, new java.lang.Object[] {  });
	}


	public BaseActivity_1 (int p0)
	{
		super (p0);
		if (getClass () == BaseActivity_1.class)
			mono.android.TypeManager.Activate ("swirepaysdk.Droid.BaseActivity`1, swirepaysdk.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();

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
