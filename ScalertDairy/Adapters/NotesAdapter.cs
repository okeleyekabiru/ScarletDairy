using Android.Support.V7.Widget;
using Android.Views;
using Scalert_Dairy.Utility;
using Scalert_Dairy.ViewHolders;
using ScarletDairy.Core.Repository;
using System;
using System.Collections.Generic;

namespace Scalert_Dairy.Adapters
{
    public class NotesAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        private List<Notes> _notes;
        public NotesAdapter()
        {
            _notes = new DiaryRepository().GetNotes();
        }
        public override int ItemCount => _notes.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is NotesViewHolder notesViewHolder)
            {

                notesViewHolder.NotesTextView.Text = _notes[position].Text.Trucate(40, true);
                var imageBitmap = ImageHelper.GetImageBitmapFromFilePath(_notes[position].ImagePath,100,100);
                notesViewHolder.NotesImageView.SetImageBitmap(imageBitmap);
            }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView =
              LayoutInflater.From(parent.Context).Inflate(Resource.Layout.notes_viewholder, parent, false);

            NotesViewHolder pieViewHolder = new NotesViewHolder(itemView, OnClick);
            return pieViewHolder;
        }

        private void OnClick(int position)
        {
            var notesId = _notes[position].Id;
            ItemClick?.Invoke(this, notesId);
        }
    }
}