using System.Numerics;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin.Tablet;

namespace TabletDriverFilters
{
    public abstract class MillimeterAsyncPositionedPipelineElement : AsyncPositionedPipelineElement<IDeviceReport>
    {
        [TabletReference]
        public TabletReference TabletReference { set => HandleTabletReferenceInternal(value); }

        protected Vector2 MillimeterScale;
        protected Vector2 TabletWH;

        private void HandleTabletReferenceInternal(TabletReference tabletReference)
        {
            var digitizer = tabletReference.Properties.Specifications.Digitizer;
            MillimeterScale = new Vector2
            {
                X = digitizer.Width / digitizer.MaxX,
                Y = digitizer.Height / digitizer.MaxY
            };
            TabletWH = new Vector2
            {
                X = digitizer.Width,
                Y = digitizer.Height,
            };
            HandleTabletReference(tabletReference);
        }

        protected virtual void HandleTabletReference(TabletReference tabletReference)
        {
            // Override when needed
        }
    }
}
