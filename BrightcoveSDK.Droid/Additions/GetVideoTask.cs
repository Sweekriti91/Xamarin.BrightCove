using System.Linq;
using Android.Runtime;

namespace Com.Brightcove.Player.Edge
{
	public partial class GetVideoTask
	{
		protected override unsafe global::Java.Lang.Object DoInBackground(params global::Java.Lang.Object[] @params)
			=> DoInBackground(@params.Select(p => p.JavaCast<Android.Net.Uri>()).ToArray());
	}
}