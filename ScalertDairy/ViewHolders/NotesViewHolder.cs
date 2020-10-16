using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Scalert_Dairy.ViewHolders
{
 public   class NotesViewHolder: RecyclerView.ViewHolder
    {
        public ImageView NotesImageView { get; set; }
        public TextView NotesTextView { get; set; }

        public NotesViewHolder(View itemView, Action<int> listener) :base(itemView)
        {
            NotesImageView = itemView.FindViewById<ImageView>(Resource.Id.notesImageView);
            NotesTextView = itemView.FindViewById<TextView>(Resource.Id.notesNameTextView);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);

        }
    }
}