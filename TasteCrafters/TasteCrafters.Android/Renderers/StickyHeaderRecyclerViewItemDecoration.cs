using Android.Content;
using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Util;
using Android.Widget;
using TasteCrafters.ViewModels;
using View = Android.Views.View;
using ItemViewType = Xamarin.Forms.Platform.Android.ItemViewType;
using Android.Util;

namespace TasteCrafters.Droid.Renderers
{
    public class StickyHeaderRecyclerViewItemDecoration : RecyclerView.ItemDecoration
    {
        private readonly IStickyHeaderRecyclerView _stickyHeaderRecyclerView;
        private int _stickyHeaderHeight;

        public StickyHeaderRecyclerViewItemDecoration(IStickyHeaderRecyclerView stickyHeaderRecyclerView)
        {
            _stickyHeaderRecyclerView = stickyHeaderRecyclerView;
        }

        public override void OnDrawOver(Canvas canvas, RecyclerView parent, RecyclerView.State state)
        {
            base.OnDrawOver(canvas, parent, state);
            var topChild = parent.GetChildAt(0);
            if (topChild == null)
            {
                return;
            }

            var topChildPosition = parent.GetChildAdapterPosition(topChild);
            if (topChildPosition == RecyclerView.NoPosition)
            {
                return;
            }

            var currentHeader = GetHeaderViewForItem(topChildPosition, parent);
            if (currentHeader == null)
            {
                return;
            }

            FixLayoutSize(parent, currentHeader);

            var contactPoint = currentHeader.Bottom;
            var childInContact = GetChildInContact(parent, contactPoint, topChildPosition);

            if (childInContact != null && _stickyHeaderRecyclerView.IsHeader(parent.GetChildAdapterPosition(childInContact)))
            {
                MoveHeader(canvas, currentHeader, childInContact);
                return;
            }

            currentHeader.Alpha = 1.0f;

            Log.Debug("StickyHeader", $"Drawing header for position {topChildPosition}: {currentHeader.Visibility}");

            // Ensure the text view within the header is visible
            var headerTextView = currentHeader.FindViewById<TextView>(Resource.Id.headerTextView);
            if (headerTextView != null)
            {
                headerTextView.Visibility = ViewStates.Visible;
                Log.Debug("StickyHeader", $"Header text for position {topChildPosition}: {headerTextView.Text}");
            }

            DrawHeader(canvas, currentHeader);
        }

        private View GetChildInContact(RecyclerView parent, int contactPoint, int currentHeaderPosition)
        {
            for (var i = 0; i < parent.ChildCount; i++)
            {
                var child = parent.GetChildAt(i);
                var isChildHeader = _stickyHeaderRecyclerView.IsHeader(parent.GetChildAdapterPosition(child));
                var heightTolerance = isChildHeader ? _stickyHeaderHeight - child.Height : 0;
                var childBottomPosition = child.Bottom + heightTolerance;

                if (childBottomPosition > contactPoint && child.Top <= contactPoint)
                {
                    return child;
                }
            }
            return null;
        }

        private void FixLayoutSize(ViewGroup parent, View view)
        {
            var widthSpec = View.MeasureSpec.MakeMeasureSpec(parent.Width, MeasureSpecMode.Exactly);
            var heightSpec = View.MeasureSpec.MakeMeasureSpec(parent.Height, MeasureSpecMode.Unspecified);

            var layoutParams = view.LayoutParameters ?? new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

            var childWidthSpec = ViewGroup.GetChildMeasureSpec(widthSpec, parent.PaddingLeft + parent.PaddingRight, layoutParams.Width);
            var childHeightSpec = ViewGroup.GetChildMeasureSpec(heightSpec, parent.PaddingTop + parent.PaddingBottom, layoutParams.Height);

            view.Measure(childWidthSpec, childHeightSpec);
            _stickyHeaderHeight = view.MeasuredHeight;
            view.Layout(0, 0, view.MeasuredWidth, _stickyHeaderHeight);
        }

        private View GetHeaderViewForItem(int headerPosition, RecyclerView parent)
        {
            return _stickyHeaderRecyclerView.GetHeaderLayout(headerPosition);
        }

        private void MoveHeader(Canvas canvas, View currentHeader, View nextHeader)
        {
            canvas.Save();
            canvas.Translate(0, nextHeader.Top - currentHeader.Height);
            currentHeader.Draw(canvas);
            canvas.Restore();
        }

        private void DrawHeader(Canvas canvas, View header)
        {
            canvas.Save();
            canvas.Translate(0, 0);
            header.Draw(canvas);
            canvas.Restore();
        }
    }

    public interface IStickyHeaderRecyclerView
    {
        View GetHeaderLayout(int headerPosition);
        bool IsHeader(int itemPosition);
        MainPageViewModel GetViewModel();
        int GetHeaderPosition(int itemPosition);
    }
}


