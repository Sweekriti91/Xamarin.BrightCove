using System.Linq;
using Android.Runtime;

namespace Com.Brightcove.Player.Display.Tasks
{
	public partial class LoadImageTask
	{
		protected override unsafe global::Java.Lang.Object DoInBackground(params global::Java.Lang.Object[] @params)
			=> DoInBackground(@params.Select(p => p.JavaCast<Java.Net.URI>()).ToArray());
	}
}

