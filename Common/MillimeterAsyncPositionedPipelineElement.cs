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
        protected Vector2 TabletValues1;
        protected Vector2 TabletValues2;

        private void HandleTabletReferenceInternal(TabletReference tabletReference)
        {
            var digitizer = tabletReference.Properties.Specifications.Digitizer;
            MillimeterScale = new Vector2
            {
                X = digitizer.Width / digitizer.MaxX,
                Y = digitizer.Height / digitizer.MaxY
            };
            TabletValues1 = new Vector2(digitizer.Width, digitizer.Height);
            TabletValues2 = new Vector2(digitizer.MaxX, digitizer.MaxY);
            HandleTabletReference(tabletReference);
        }

        protected virtual void HandleTabletReference(TabletReference tabletReference)
        {
            // Override when needed
        }
    }
}
