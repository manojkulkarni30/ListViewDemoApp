using FFImageLoading.Forms;
using FFImageLoading.Transformations;

namespace ListViewDemoApp.Controls
{
    public class CircleImage : CachedImage
    {
        public CircleImage()
        {
            WidthRequest = 60;
            HeightRequest = 60;
            DownsampleToViewSize = true;
            Transformations.Add(new CircleTransformation());
        }
    }
}
