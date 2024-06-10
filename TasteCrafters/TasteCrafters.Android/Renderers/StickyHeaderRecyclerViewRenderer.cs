using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TasteCrafters.Controls;
using TasteCrafters.Droid.Renderers;
using TasteCrafters.ViewModels;
using View = Android.Views.View;
using ItemViewType = Xamarin.Forms.Platform.Android.ItemViewType;
using Android.Util;

[assembly: ExportRenderer(typeof(StickyHeaderCollectionView), typeof(StickyHeaderRecyclerViewRenderer))]
namespace TasteCrafters.Droid.Renderers
{
    public class StickyHeaderRecyclerViewRenderer : CollectionViewRenderer, IStickyHeaderRecyclerView
    {
        private readonly Dictionary<int, View> _headerCache = new Dictionary<int, View>();

        public StickyHeaderRecyclerViewRenderer(Context context) : base(context)
        {
            AddItemDecoration(new StickyHeaderRecyclerViewItemDecoration(this));
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ItemsView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                // Additional setup if required
            }
        }

        public View GetHeaderLayout(int itemPosition)
        {
            var headerPosition = GetHeaderPosition(itemPosition);

            if (_headerCache.ContainsKey(headerPosition))
            {
                return _headerCache[headerPosition];
            }

            var headerView = CreateHeaderView(headerPosition);
            _headerCache[headerPosition] = headerView;

            return headerView;
        }

        private View CreateHeaderView(int headerPosition)
        {
            var inflater = LayoutInflater.From(Context);
            var headerView = inflater.Inflate(Resource.Layout.header_layout, null, false);

            var headerTextView = headerView.FindViewById<TextView>(Resource.Id.headerTextView);
            var viewModel = GetViewModel();
            if (viewModel != null && headerPosition < viewModel.Ingredients.Count)
            {
                var headerTitle = viewModel.Ingredients[headerPosition].Title;
                headerTextView.Text = headerTitle;
            }

            return headerView;
        }

        public bool IsHeader(int itemPosition)
        {
            var recyclerView = (RecyclerView)View;
            var adapter = recyclerView.GetAdapter();
            return adapter.GetItemViewType(itemPosition) == (int)ItemViewType.GroupHeader;
        }

        public MainPageViewModel GetViewModel()
        {
            return Element.BindingContext as MainPageViewModel;
        }

        public int GetHeaderPosition(int itemPosition)
        {
            var viewModel = GetViewModel();
            var headerPosition = 0;

            foreach (var group in viewModel.Ingredients)
            {
                itemPosition -= group.Count + 1; // +1 for the header
                if (itemPosition >= 0)
                {
                    headerPosition++;
                }
                else
                {
                    break;
                }
            }

            return headerPosition;
        }
    }
}

